using System;
using System.Data;
using System.Windows.Forms;

namespace AZ_Kviz.Forms
{
    internal partial class QuestionsEditorForm : BaseForm
    {
        private readonly uint _currentSetId;
        private readonly bool _isNewSet; // Víme, zda sadu zrovna zakládáme
        private bool _isSaved = false;   // Příznak, zda uživatel uložil změny
        private string _sqlNormal;
        private string _sqlReplacement;

        private DataTable _normalTable;
        private DataTable _replacementTable;
        private BindingSource _normalQuestionsBinding = new BindingSource();
        private BindingSource _replacementQuestionsBinding = new BindingSource();

        public QuestionsEditorForm(uint setId, string setName, bool isNewSet)
        {
            InitializeComponent();
            WindowUtils.ReallyCenterToScreen(this);

            _currentSetId = setId;
            _isNewSet = isNewSet;
            this.Text = $"Editor otázek - Sada: {setName}";

            // Dotaz pro normální otázky
            _sqlNormal = $@"
        SELECT id, set_id, text, answer, is_replacement,
        ROW_NUMBER() OVER (ORDER BY id) as DisplayOrder 
        FROM Questions 
        WHERE set_id = {setId} AND (is_replacement = 0 OR is_replacement IS NULL)";

            // Dotaz pro náhradní otázky
            _sqlReplacement = $@"
        SELECT id, set_id, text, answer, is_replacement,
        ROW_NUMBER() OVER (ORDER BY id) as DisplayOrder 
        FROM Questions 
        WHERE set_id = {setId} AND is_replacement = 1";

            LoadQuestions();
        }

        private void LoadQuestions()
        {
            try
            {
                dgvNormal.AutoGenerateColumns = false;
                dgvReplacement.AutoGenerateColumns = false;

                // Načteme každou skupinu do vlastní tabulky v paměti
                _normalTable = DatabaseFunctions.GetTable(_sqlNormal);
                _replacementTable = DatabaseFunctions.GetTable(_sqlReplacement);

                // Propojíme s BindingSource (už bez filtrů!)
                _normalQuestionsBinding.DataSource = _normalTable;
                _replacementQuestionsBinding.DataSource = _replacementTable;

                // Spárujeme sloupce
                MapColumnsToDatabase(dgvNormal);
                MapColumnsToDatabase(dgvReplacement);

                // Přiřadíme mřížkám
                dgvNormal.DataSource = _normalQuestionsBinding;
                dgvReplacement.DataSource = _replacementQuestionsBinding;

                ConfigureGrids();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Chyba při načítání", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Pomocná metoda, která spáruje tvoje naklikané sloupce s daty z SQL
        private void MapColumnsToDatabase(DataGridView dgv)
        {
            if (dgv == dgvNormal)
            {
                if (dgv.Columns["colNormalId"] != null) dgv.Columns["colNormalId"].DataPropertyName = "DisplayOrder";
                if (dgv.Columns["colNormalText"] != null) dgv.Columns["colNormalText"].DataPropertyName = "text";
                if (dgv.Columns["colNormalAnswer"] != null) dgv.Columns["colNormalAnswer"].DataPropertyName = "answer";
            }
            else if (dgv == dgvReplacement)
            {
                if (dgv.Columns["colReplacementId"] != null) dgv.Columns["colReplacementId"].DataPropertyName = "DisplayOrder";
                if (dgv.Columns["colReplacementText"] != null) dgv.Columns["colReplacementText"].DataPropertyName = "text";
                if (dgv.Columns["colReplacementAnswer"] != null) dgv.Columns["colReplacementAnswer"].DataPropertyName = "answer";
            }
        }

        private void ConfigureGrids()
        {
            ConfigureGridProperties(dgvNormal);
            ConfigureGridProperties(dgvReplacement);
        }

        private void ConfigureGridProperties(DataGridView dgv)
        {
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;

            // Najdeme správné názvy podle mřížky
            string idCol = (dgv == dgvNormal) ? "colNormalId" : "colReplacementId";
            string textCol = (dgv == dgvNormal) ? "colNormalText" : "colReplacementText";
            string answerCol = (dgv == dgvNormal) ? "colNormalAnswer" : "colReplacementAnswer";

            if (dgv.Columns[idCol] != null)
            {
                dgv.Columns[idCol].ReadOnly = true;
                dgv.Columns[idCol].Width = 50;
                dgv.Columns[idCol].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Vycentrujeme číslo na střed
            }

            if (dgv.Columns[answerCol] != null)
            {
                dgv.Columns[answerCol].Width = 150;
            }

            if (dgv.Columns[textCol] != null)
            {
                dgv.Columns[textCol].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (!AreQuestionsValid())
                {
                    return;
                }

                dgvNormal.EndEdit();
                dgvReplacement.EndEdit();
                _normalQuestionsBinding.EndEdit();
                _replacementQuestionsBinding.EndEdit();

                // Uložíme obě tabulky zpět přes jejich původní SELECT dotazy
                DatabaseFunctions.SaveTable(_normalTable, _sqlNormal);
                DatabaseFunctions.SaveTable(_replacementTable, _sqlReplacement);

                _isSaved = true;
                Cursor.Current = Cursors.Default;

                MessageBox.Show("Všechny otázky byly úspěšně uloženy.", "Uloženo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ukládání selhalo: {ex.Message}", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool AreQuestionsValid()
        {
            Cursor.Current = Cursors.WaitCursor;
            foreach(DataRow row in _normalTable.Rows)
            {
                if (row.RowState == DataRowState.Deleted) continue;

                string text = row["text"]?.ToString();
                string answer = row["answer"]?.ToString();
                int order = Convert.ToInt32(row["DisplayOrder"]);

                if (string.IsNullOrWhiteSpace(text))
                {
                    MessageBox.Show($"U normální otázky číslo {order} chybí text otázky!", "Chyba validace", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tabControl.SelectedTab = normalQuestionsPage; // Přepne na tab/záložku s normálními otázkami (případně uprav název tvého TabControlu/TabPage)
                    return false;
                }

                if (string.IsNullOrWhiteSpace(answer))
                {
                    MessageBox.Show($"U normální otázky číslo {order} chybí odpověď!", "Chyba validace", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tabControl.SelectedTab = normalQuestionsPage;
                    return false;
                }
            }

            foreach (DataRow row in _replacementTable.Rows)
            {
                if (row.RowState == DataRowState.Deleted) continue;

                string text = row["text"]?.ToString();
                string answer = row["answer"]?.ToString();
                int order = Convert.ToInt32(row["DisplayOrder"]);

                if (string.IsNullOrWhiteSpace(text))
                {
                    MessageBox.Show($"U náhradní otázky číslo {order} chybí text otázky!", "Chyba validace", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tabControl.SelectedTab = replacementQuestionsPage; // Přepne na záložku s náhradními
                    return false;
                }

                if (string.IsNullOrWhiteSpace(answer))
                {
                    MessageBox.Show($"U náhradní otázky číslo {order} chybí odpověď!", "Chyba validace", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tabControl.SelectedTab = replacementQuestionsPage;
                    return false;
                }
            }
            Cursor.Current = Cursors.Default;
            return true;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            // Zavřením se automaticky vyvolá metoda OnFormClosing níže
            DialogResult = DialogResult.Cancel;
            Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            // Pokud uživatel NEKLIKNUL na tlačítko Uložit (změny jsou neuložené)
            if (!_isSaved)
            {
                if (_isNewSet)
                {
                    // Tvorba NOVÉ sady byla přerušena -> komplet to vyčistíme
                    try
                    {
                        using (SqlCursorManager.Show())
                        {
                            DatabaseFunctions.DeleteQuestionSet(_currentSetId);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Chyba při mazání stornované sady: {ex.Message}", "Chyba systému", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // U STARÉ sady se jen zeptáme, zda chce odejít a ztratit změny
                    var result = MessageBox.Show("Máte neuložené změny v textu otázek. Opravdu chcete odejít bez uložení?",
                                                 "Upozornění", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.No)
                    {
                        e.Cancel = true; // Zruší zavření okna, uživatel zůstává v editoru
                    }
                }
            }
        }

        private void ImportData()
        {
            Cursor.Current = Cursors.WaitCursor;
            bool isNormalSelected = (tabControl.SelectedTab == normalQuestionsPage);
            DataTable targetTable = isNormalSelected ? _normalTable : _replacementTable;
            string tabName = isNormalSelected ? "NORMÁLNÍCH" : "NÁHRADNÍCH";
            Cursor.Current = Cursors.Default;

            var confirmResult = MessageBox.Show(
                $"Opravdu chcete přepsat všech 28 záznamů v tabulce {tabName} otázek daty z CSV souboru?",
                "Potvrdit import", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmResult == DialogResult.No) return;

            Cursor.Current = Cursors.WaitCursor;

            using(OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "CSV soubory (*.csv)|*.csv";
                openFileDialog.Title = $"Import {tabName.ToLower()} otázek z CSV";
                openFileDialog.Multiselect = false;

                Cursor.Current = Cursors.Default;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    ImportResult result = CSVImporter.ImportToDataTable(openFileDialog.FileName, targetTable);

                    string errorReport = result.Errors.Count > 0
                        ? "\n\nNalezené problémy:\n• " + string.Join("\n• ", result.Errors)
                        : string.Empty;

                    if(!result.Sucess || result.LoadedRowsCount == 0)
                    {
                        MessageBox.Show($"Import zcela selhal! Žádná data nebyla nahrána.{errorReport}",
                                "Chyba importu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (isNormalSelected)
                    {
                        _normalQuestionsBinding.ResetBindings(false);
                    }
                    else
                    {
                        _replacementQuestionsBinding.ResetBindings(false);
                    }

                    Cursor.Current = Cursors.Default;

                    if (result.LoadedRowsCount < 28)
                    {
                        MessageBox.Show(
                            $"Import dokončen pouze částečně.\n\n" +
                            $"Úspěšně se načetlo {result.LoadedRowsCount} řádků z 28 očekávaných.{errorReport}\n\n" +
                            $"Zbývajících {28 - result.LoadedRowsCount} otázek musíte vyplnit ručně!",
                            "Neúplný import", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        if (result.Errors.Count > 0)
                        {
                            MessageBox.Show($"Všech 28 otázek bylo načteno, ale některé řádky v souboru byly přeskočeny kvůli chybám.{errorReport}",
                                "Import s varováním", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            MessageBox.Show($"Všech 28 {tabName.ToLower()} otázek bylo úspěšně naimportováno.",
                                "Import dokončen", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }

        private void ExportData()
        {
            Cursor.Current = Cursors.WaitCursor;
            bool isNormalSelected = (tabControl.SelectedTab == normalQuestionsPage);
            DataTable sourceTable = isNormalSelected ? _normalTable : _replacementTable;
            string tabName = isNormalSelected ? "NORMÁLNÍCH" : "NÁHRADNÍCH";

            dgvNormal.EndEdit();
            dgvReplacement.EndEdit();
            _normalQuestionsBinding.EndEdit();
            _replacementQuestionsBinding.EndEdit();

            using(SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "CSV soubory (*.csv)|*.csv";
                saveFileDialog.Title = saveFileDialog.Title = $"Export {tabName.ToLower()} otázek do CSV";

                string safeTabSuffix = isNormalSelected ? "normalni" : "nahradni";
                saveFileDialog.FileName = $"otazky_{safeTabSuffix}.csv";

                Cursor.Current = Cursors.Default;
                if (saveFileDialog.ShowDialog() ==DialogResult.OK)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    bool success = CSVExporter.ExportFromDataTable(saveFileDialog.FileName, sourceTable, out string errorMsg);

                    if (success)
                    {
                        MessageBox.Show($"Všech {sourceTable.Rows.Count} otázek z karty '{tabName.ToLower()}' bylo úspěšně uloženo do CSV.",
                                        "Export dokončen", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"Export selhal!\n\n{errorMsg}",
                                        "Chyba exportu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    Cursor.Current = Cursors.Default;
                }
            }
        }

        private void ImportButton_Click(object sender, EventArgs e)
        {
            ImportData();
        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            ExportData();
        }
    }
}

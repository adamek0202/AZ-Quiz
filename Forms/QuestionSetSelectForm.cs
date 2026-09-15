using AZ_Kviz.Models;
using AZ_Kviz.Utils;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AZ_Kviz.Forms
{
    internal partial class QuestionSetSelectForm : BaseForm
    {
        public uint SelectedSetId { get; private set; }
        public QuestionSetSelectForm()
        {
            InitializeComponent();
            WindowUtils.ReallyCenterToScreen(this);

            listView.View = View.Details;
            listView.FullRowSelect = true;
            listView.MultiSelect = true;

            LoadQuestionsSets();
        }

        private void LoadQuestionsSets()
        {
            try
            {
                listView.Items.Clear();
                List<QuestionSet> questionSets;
                using (SqlCursorManager.Show())
                {
                    questionSets = DatabaseFunctions.GetAllQuestionSets();
                }
                foreach(var set in questionSets)
                {
                    var item = new ListViewItem(set.Name);
                    item.SubItems.Add(set.Scope);
                    item.SubItems.Add(set.Difficulty.ToString());
                    item.Tag = set;

                    listView.Items.Add(item);
                }
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Chyba databáze", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Start()
        {
            if(listView.SelectedItems.Count == 1)
            {
                ListViewItem selectedItem = listView.SelectedItems[0];
                if (selectedItem.Tag is QuestionSet selectedSet)
                {
                    SelectedSetId = selectedSet.Id;

                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }

        private void CreateNewSetButton_Click(object sender, EventArgs e)
        {
            using(var form = new QuestionSetParamsForm())
            {
                if(form.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }
                string setName = form.SetName;
                string scope = form.SetScope;
                uint difficulty = form.SetDifficulty;

                if (string.IsNullOrWhiteSpace(setName)) return;

                try
                {
                    uint newSetId;
                    using (SqlCursorManager.Show())
                    {
                        newSetId = DatabaseFunctions.CreateNewQuestionSet(setName.Trim(), scope.Trim(), difficulty);
                    }

                    // 2. Otevřeme editor s příznakem isNewSet = true
                    using (var editorForm = new QuestionsEditorForm(newSetId, setName, isNewSet: true))
                    {
                        editorForm.ShowDialog();
                    }

                    // Seznam se obnoví (pokud uživatel dal storno, nová sada v něm už nebude, protože se smazala)
                    LoadQuestionsSets();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void EditSetButton_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count == 1)
            {
                ListViewItem selectedItem = listView.SelectedItems[0];
                if (selectedItem.Tag is QuestionSet selectedSet)
                {
                    // Otevíráme existující, takže isNewSet = false
                    using (var editorForm = new QuestionsEditorForm(selectedSet.Id, selectedSet.Name, isNewSet: false))
                    {
                        editorForm.ShowDialog();
                    }

                    LoadQuestionsSets();
                }
            }
        }

        private void ExitButton_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ListView_DoubleClick(object sender, EventArgs e)
        {
            Start();
        }

        private void ListView_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                Start();
            }
        }

        private void PlayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Start();
        }

        private void ListView_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                var focusedItem = listView.FocusedItem;
                if(focusedItem != null && focusedItem.Bounds.Contains(e.Location))
                {
                    contextMenuStrip.Show(Cursor.Position);
                }
            }
        }

        private void RemoveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListViewItem selectedItem = listView.SelectedItems[0];
            if (listView.SelectedItems.Count == 1 && MsgBoxes.QuestionBox("Opravdu chcete smazat vybranou sadu otázek?") && (selectedItem.Tag is QuestionSet selectedSet))
            {
                try
                {
                    DatabaseFunctions.DeleteQuestionsSet(selectedSet.Id);
                    LoadQuestionsSets();
                }
                catch (Exception ex)
                {
                    MsgBoxes.ErrorBox("Nepodařilo se smazat sadu otázek");
                }
            }
        }
    }
}

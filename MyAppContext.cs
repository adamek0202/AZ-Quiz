using AZ_Kviz.Forms;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Windows.Forms;

namespace AZ_Kviz
{
    internal class MyAppContext : ApplicationContext
    {
        public MyAppContext()
        {
            RunGameFlow();
        }

        private void RunGameFlow()
        {
            while (true)
            {
                uint selectedSetId = 0;
                using (var selectForm = new QuestionSetSelectForm())
                {
                    if (selectForm.ShowDialog() != DialogResult.OK)
                    {
                        Shutdown();
                        return;
                    }
                    selectedSetId = selectForm.SelectedSetId;
                }

                using (var setupForm = new PlayersSetupForm())
                {
                    if (setupForm.ShowDialog() != DialogResult.OK)
                    {
                        continue;
                    }

                    Game.Init(
                        setupForm.PlayerOneName, setupForm.PlayerOneColor,
                        setupForm.PlayerTwoName, setupForm.PlayerTwoColor);
                }
                DatabaseFunctions.ResetQuestionUsage(selectedSetId);

                try
                {
                    using (var mainForm = new MainForm(selectedSetId))
                    {
                        mainForm.ShowDialog();
                    }
                }
                catch (Exception ex)
                {
                    Serilog.Log.Error(ex, "Chyba během hry.");
                    MessageBox.Show($"Během hry došlo k chybě: {ex.Message}", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Shutdown()
        {
            ExitThread();
            Application.Exit();
            Environment.Exit(0);
        }
    }
}
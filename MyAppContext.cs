using AZ_Kviz.Forms;
using NAudio.Wave;
using System;
using System.Windows.Forms;

namespace AZ_Kviz
{
    internal class MyAppContext : ApplicationContext
    {
        public MyAppContext()
        {
            if(WaveOut.DeviceCount > 1)
            {
                if(ShowAudioOutputSelector() == DialogResult.Cancel)
                {
                    Environment.Exit(0);
                    return;
                }
            }
            if (!ShowSelectionForm())
            {
                Environment.Exit(0);
                return;
            }
            if(ShowSetupForm() != DialogResult.OK)
            {
                Environment.Exit(0);
                return;
            }
            this.MainForm = new MainForm();
        }

        private bool ShowSelectionForm()
        {
            bool result = false;
            while (true)
            {
                using (var selectForm = new QuestionSetSelectForm())
                {
                    result = selectForm.ShowDialog() == DialogResult.OK;
                    if (selectForm.Action == Utilities.Actions.Edit)
                    {

                    }
                    else
                    {
                        break;
                    }
                }
            }
            return result;
        }

        private DialogResult ShowAudioOutputSelector()
        {
            using(var selForm = new AudioOutSelectForm())
            {
                return selForm.ShowDialog();
            }
        }

        private DialogResult ShowSetupForm()
        {
            using(var setupForm = new PlayersSetupForm())
            {
                return setupForm.ShowDialog();
            }

        }
    }
}

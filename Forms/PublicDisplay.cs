using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AZ_Kviz
{
    public partial class PublicDisplay : Form
    {
        public PublicDisplay()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            var screens = Screen.AllScreens;

            if(screens.Length > 1)
            {
                var external = screens[1];

                this.StartPosition = FormStartPosition.Manual;
                this.Location = external.WorkingArea.Location;
            }
        }

        private void UpdateCountdown(int seconds)
        {
            circularProgressBar.Text = seconds.ToString();
            circularProgressBar.Value = seconds * 10;
        }
    }
}

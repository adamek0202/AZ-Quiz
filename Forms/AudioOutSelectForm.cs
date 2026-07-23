using NAudio.CoreAudioApi;
using NAudio.Wave;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static AZ_Kviz.Forms.BasicTheme;

namespace AZ_Kviz.Forms
{
    public partial class AudioOutSelectForm : Form
    {
        public AudioOutSelectForm()
        {
            InitializeComponent();

            var enumerator = new MMDeviceEnumerator();
            for (int i = 0; i < WaveOut.DeviceCount; i++)
            {
                deviceListBox.Items.Add(enumerator.EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active)[0].FriendlyName);
            }
            enumerator.Dispose();
            deviceListBox.SelectedIndex = 0;
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            DWMNCRENDERINGPOLICY renderingPolicy = DWMNCRENDERINGPOLICY.DWMNCRP_DISABLED;
            int hr = DwmSetWindowAttribute(Handle, DWMWINDOWATTRIBUTE.DWMWA_NCRENDERING_POLICY, renderingPolicy, sizeof(DWMNCRENDERINGPOLICY));
            if (hr != 0)
            {
                throw Marshal.GetExceptionForHR(hr);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}

using System;
using System.Windows.Forms;
using Windows.Storage;

namespace Component.WindowsForms
{
    public partial class Form1 : Form
    {
        private Timer timer;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("bridge:Via G. B. Piranesi 14, Milan");
        }

        private void OnFormLoaded(object sender, EventArgs e)
        {
            ApplicationData.Current.LocalSettings.Values.Clear();

            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (ApplicationData.Current.LocalSettings.Values.ContainsKey("coordinates"))
            {
                txtCoordinates.Text = ApplicationData.Current.LocalSettings.Values["coordinates"].ToString();
                timer.Stop();
            }
        }
    }
}

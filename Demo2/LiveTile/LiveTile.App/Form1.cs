using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Windows.UI.Notifications;

namespace LiveTile.App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void OnCreateFile(object sender, EventArgs e)
        {
            string userPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            string fileName = $"{userPath}\\centennial.txt";
            File.WriteAllText(fileName, "This file has been created by a Centennial app");
            UpdateTile();
        }

        [Conditional("DesktopUWP")]
        public void UpdateTile()
        {
            string dateTime = DateTime.Now.ToString("g");

            string xml = $@"<tile>
                            <visual>
                                <binding template='TileMedium'>
                                    <text>Live Tile App</text>
                                    <text hint-wrap='true'>The file has been created at {dateTime}</text>
                                </binding >
                                <binding template='TileWide'>
                                    <text>Live Tile App</text>
                                    <text hint-wrap='true'>The file has been created at {dateTime}</text>
                                </binding>
                            </visual>
                        </tile>";

            Windows.Data.Xml.Dom.XmlDocument doc = new Windows.Data.Xml.Dom.XmlDocument();
            doc.LoadXml(xml);

            TileNotification tile = new TileNotification(doc);
            TileUpdateManager.CreateTileUpdaterForApplication().Update(tile);
        }

        private void OnFormLoaded(object sender, EventArgs e)
        {
            DesktopBridge.Helpers helpers = new DesktopBridge.Helpers();
            bool isUwp = helpers.IsRunningAsUwp();
#if DesktopUWP
            if (!isUwp)
            {
                MessageBox.Show("You're compiling the app with the wrong configuration!");
                this.Close();
            }
#endif
            string text = isUwp ? "The app is running inside the UWP container" : "The app is running as a native Win32 app";
            txtStatus.Text = text;
        }
    }
}

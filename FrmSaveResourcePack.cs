using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ionic.Zip;
using System.Threading;
using System.IO;

namespace MinecraftTextureStudio
{
    public partial class FrmSaveResourcePack : Form
    {
        public bool done;

        public FrmSaveResourcePack()
        {
            InitializeComponent();
            done = false;

            Thread thread = new Thread(saveTexturePack);
            thread.Start();
        }

        public void saveTexturePack()
        {
            try
            {
                if (File.Exists(FrmMain.path))
                {
                    File.Delete(FrmMain.path);
                }

                using (ZipFile zip = new ZipFile())
                {
                    zip.AddDirectory(FrmMain.directory);

                    // Save to output filename
                    zip.Save(FrmMain.path);
                }

                done = true;
            }
            catch (Exception exception)
            {
                MessageBox.Show("Exception occured saving resource pack: " + exception.Message);
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (done)
            {
                this.Close();
            }

            if (progressBar.Value + 5 <= progressBar.Maximum)
            {
                progressBar.Value = progressBar.Value + 5;
            }
            else
            {
                progressBar.Value = 0;
            }
        }
    }
}

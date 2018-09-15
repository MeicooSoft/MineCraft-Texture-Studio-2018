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

namespace MinecraftTextureStudio
{
    public partial class FrmJarExtractOrganise : Form
    {
        public bool done;

        public FrmJarExtractOrganise()
        {
            InitializeComponent();
            done = false;

            Thread thread = new Thread(extractJar);
            thread.Start();
        }

        public void extractJar()
        {
            using (ZipFile zipFile = new ZipFile(FrmMain.minecraftJarPath))
            {
                zipFile.ExtractAll(FrmMain.directory, ExtractExistingFileAction.OverwriteSilently);
            }

            done = true;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (done)
            {
                this.Close();
            }

            if (progressBar.Value + 1 <= progressBar.Maximum)
            {
                progressBar.Value = progressBar.Value + 1;
            }
            else
            {
                progressBar.Value = 0;
            }
        }
    }
}

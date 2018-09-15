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
    public partial class FrmResourcePackExtract : Form
    {
        public bool done;
        public string path;

        public FrmResourcePackExtract(string path)
        {
            InitializeComponent();
            this.path = path;
            done = false;
            
            Thread thread = new Thread(extractZip);
            thread.Start();
        }

        public void extractZip()
        {
            FrmMain.texturePackFileName = "";

            int pathIndexIf = path.LastIndexOf(".");
            if (path.LastIndexOf(".") == -1)
            {
                FrmMain.texturePackFileName = path.Substring(path.LastIndexOf("\\") + 1, path.Length - path.LastIndexOf("\\") - 1);
            }
            else
            {
                FrmMain.texturePackFileName = path.Substring(path.LastIndexOf("\\") + 1, path.LastIndexOf(".") - path.LastIndexOf("\\") - 1);
            }

            FrmMain.directory = path.Substring(0, path.LastIndexOf("\\")) + "\\" + FrmMain.texturePackFileName;

            if (Directory.Exists(FrmMain.directory))
            {
                Directory.Delete(FrmMain.directory, true);
            }

            using (ZipFile zipFile = new ZipFile(this.path))
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

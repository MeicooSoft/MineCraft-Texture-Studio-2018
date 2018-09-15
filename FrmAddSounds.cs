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
    public partial class FrmAddSounds : Form
    {
        public static bool addSoundDebug = false;
        public static bool done;

        public FrmAddSounds()
        {
            InitializeComponent();
            done = false;

            Thread thread = new Thread(addSounds);
            thread.Start();
        }

        public static void addSounds()
        {
            string jsonPath = FrmMain.minecraftJarPath.Substring(0, FrmMain.minecraftJarPath.Length - 4) + ".json";

            StreamReader reader = null;
            string assetsPath = "";

            try
            {
                reader = new StreamReader(new FileStream(jsonPath, FileMode.Open, FileAccess.Read));

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();

                    if (line.Contains("\"assets\""))
                    {
                        string[] aposDelim = { "\"" };
                        string[] aposTokens = line.Split(aposDelim, StringSplitOptions.None);

                        if (aposTokens.Length == 5)
                        {
                            assetsPath = aposTokens[3];
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Exception occured reading the minecraft JSON file: " + exception.Message);
                return;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Dispose();
                }
            }

            if (assetsPath == "")
            {
                MessageBox.Show("Failed to find assets entry in minecraft jar JSON file");
                return;
            }
            else
            {
                reader = null;

                try
                {
                    reader = new StreamReader(new FileStream(FrmMain.minecraftPath + "\\" + FrmMain.indexesJSON +
                        "\\" + assetsPath + ".json", FileMode.Open, FileAccess.Read));

                    //discard first two lines
                    reader.ReadLine();
                    reader.ReadLine();

                    while (!reader.EndOfStream)
                    {
                        string firstLine = reader.ReadLine();

                        if (firstLine.EndsWith("}"))
                        {
                            //discard last line
                            reader.ReadLine();
                        }
                        else
                        {
                            string fullPathLine = firstLine;
                            string hashLine = reader.ReadLine();
                            string size = reader.ReadLine();
                            string closingBracket = reader.ReadLine();

                            string[] aposDelim = { "\"" };
                            string[] fullPathTokens = fullPathLine.Split(aposDelim, StringSplitOptions.None);
                            string fullPath = fullPathTokens[1];
                            fullPath = fullPath.Replace("/", "\\");

                            if (fullPath.StartsWith("minecraft\\"))
                            {
                                fullPath = fullPath.Substring(10, fullPath.Length - 10);
                            }

                            string[] hashTokens = hashLine.Split(aposDelim, StringSplitOptions.None);
                            string hash = hashTokens[3];

                            if (fullPathTokens.Length == 3 && hashTokens.Length == 5)
                            {
                                string path = fullPathTokens[1];
                                if (path.StartsWith("minecraft/"))
                                {
                                    path = path.Substring(10, path.Length - 10);
                                }

                                string[] slashDelim = { "/" };
                                string[] slashTokens = path.Split(slashDelim, StringSplitOptions.None);

                                string directoryPath = "";
                                string filename = slashTokens[slashTokens.Length - 1];

                                if (filename.EndsWith(".ogg"))
                                {
                                    for (int a = 0; a < slashTokens.Length - 1; a++)
                                    {
                                        if (directoryPath != "")
                                        {
                                            directoryPath += "\\";
                                        }

                                        directoryPath += slashTokens[a];
                                        Directory.CreateDirectory(FrmMain.directory + "\\assets\\minecraft\\" + directoryPath);
                                    }

                                    string first2Hash = hash.Substring(0, 2);
                                    File.Copy(FrmMain.minecraftPath + "\\" + FrmMain.objectsPath + "\\" + first2Hash + "\\" + hash,
                                        FrmMain.directory + "\\assets\\minecraft\\" + fullPath, true);

                                    if (addSoundDebug)
                                    {
                                        Console.WriteLine("Found sound at " + FrmMain.minecraftPath + "\\" + FrmMain.objectsPath + "\\" + first2Hash + "\\" + hash + ", copying to " +
                                            FrmMain.directory + "\\assets\\minecraft\\" + fullPath);
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Exception occured reading the assets JSON file: " + exception.Message);
                }
                finally
                {
                    if (reader != null)
                    {
                        reader.Dispose();
                    }
                }
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

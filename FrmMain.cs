using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.IO.Compression;
using Ionic.Zip;
using System.Diagnostics;
using IrrKlang;
using System.Reflection;

namespace MinecraftTextureStudio
{
    public partial class FrmMain : Form
    {
        public static string version = "1.12";
        public static int undoLimit = 50;
        public static float pixelSize = 10;
        public static int textureWidth;
        public static int textureHeight;

        public static Vector3 textureClickPos = new Vector3();
        public static Vector3 textureClickStart = new Vector3();
        public static List<Vector3> cubePositions;

        public static int itemMouseDownX;
        public static int itemMouseDownY;
        public static int itemMouseUpX;
        public static int itemMouseUpY;
        public static bool itemIsMouseDown;
        public static Bitmap itemRestoreTexture;

        public static bool textureClicked = false;
        public static bool prevTexturePreviewMouseDown = false;
        public static bool texturePreviewMouseDown = false;
        public static bool clickComplete = false;
        public static bool showCubes = false;

        public static string indexesJSON = "assets\\indexes";
        public static string objectsPath = "assets\\objects";

        public static string minecraftJarPath = "";
        public static string minecraftPath = "";
        public static string extractedJarPath = "";
        public static string extractJarOption = "";

        public static Bitmap texture1 = null;
        public static Bitmap texture2 = null;
        public static Bitmap texture3 = null;
        public static Bitmap texture4 = null;
        public static Bitmap texture5 = null;
        public static Bitmap texture6 = null;
        public static Bitmap texture7 = null;
        public static Bitmap texture8 = null;
        public static Bitmap texture9 = null;
        public static Bitmap restoreTexture = null;

        public static string texture1Filename;
        public static string texture2Filename;
        public static string texture3Filename;
        public static string texture4Filename;
        public static string texture5Filename;
        public static string texture6Filename;
        public static string texture7Filename;
        public static string texture8Filename;
        public static string texture9Filename;

        Color paintColour;
        Color itemPaintColour;
        PanelConfiguration panelConfig;

        public static string path;
        public static string directory;
        public static string texturePackFileName;
        public static string texturePackName;
        public static string jarName;
        public static bool texturePackLoaded;
        public static PaintMode mode;
        public static PaintMode itemMode;

        public static Hashtable blocks;
        public static Hashtable items;
        public static TreeView treeView;

        public static Bitmap fireLayer1;
        public static Bitmap fireLayer2;
        public static Bitmap textureStrip;
        public static Bitmap itemTextureStrip;

        public static int layer1frameIndex;
        public static int layer2frameIndex;

        public static int mouseDownX;
        public static int mouseDownY;
        public static int mouseDownPanel;

        public static int mouseUpX;
        public static int mouseUpY;
        public static int mouseUpPanel;
        public static int colourIndex;
        public static int itemColourIndex;

        public static bool isMouseDown;
        public static bool done;

        public static Bitmap paintBucketPicture;
        public static Bitmap itemPicture;
        public static int itemPixelSize;

        public static List<string> blockList;
        public static List<string> itemList;
        public static List<string> soundList;

        public static SortOption sortOption;
        public static Color packNameColour;

        public List<TextureChange> undos;
        public List<TextureChange> redos;
        public List<TextureChange> itemUndos;
        public List<TextureChange> itemRedos;
        public int undoIndex;
        public int itemUndoIndex;

        public FrmMain()
        {
            try
            {
                InitializeComponent();

                Rectangle resolution = Screen.PrimaryScreen.Bounds;
                if (resolution.Height < 840)
                {
                    this.Height = resolution.Height - 140;
                }

                this.FormClosed += new FormClosedEventHandler(FrmMain_FormClosed);
                paintColour = Color.Black;
                itemPaintColour = Color.Black;
                texturePackLoaded = false;
                sortOption = SortOption.Id;

                packNameColour = Color.FromArgb(1, 1, 1);
                done = false;

                isMouseDown = false;
                mode = PaintMode.Pen;
                itemMode = PaintMode.Pen;
                lblVersion.Text = "Version " + version;
                undos = new List<TextureChange>();
                redos = new List<TextureChange>();
                itemUndos = new List<TextureChange>();
                itemRedos = new List<TextureChange>();

                colourIndex = 0;
                undoIndex = 0;
                itemUndoIndex = 0;
                itemColourIndex = 0;

                panelConfig = PanelConfiguration.T1x1;
                txtResourcePackName.TextChanged += new EventHandler(txtResourcePackName_TextChanged);
                extractJarOption = "0";
                directory = "";

                treeView = new System.Windows.Forms.TreeView();
                this.tabOrganise.Controls.Add(treeView);

                treeView.Location = new System.Drawing.Point(13, 14);
                treeView.Name = "treeView";
                treeView.Size = new System.Drawing.Size(305, 575);

                treeView.TabIndex = 1;
                treeView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
                treeView.Enabled = false;

                this.cmbTextColour.SelectedItem = "Black";
                this.cmbTextColour.DrawMode = DrawMode.OwnerDrawFixed;
                this.cmbTextColour.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cmbTextColour.DrawItem += new DrawItemEventHandler(cmbTextColour_DrawItem);
                this.cmbTextColour.SelectedIndexChanged += new EventHandler(cmbTextColour_SelectedIndexChanged);
                this.cmbItems.SelectedIndexChanged += new EventHandler(cmbItems_SelectedIndexChanged);
                this.cmbSounds.SelectedIndexChanged += new EventHandler(cmbSounds_SelectedIndexChanged);

                this.lblDropImage.AllowDrop = true;
                this.panelThumbnail.AllowDrop = true;
                this.lblFontDropImage.AllowDrop = true;
                this.panelFont.AllowDrop = true;

                this.lblDropImage.DragEnter += new DragEventHandler(picture_DragEnter);
                this.lblDropImage.DragDrop += new DragEventHandler(picture_DragDrop);

                this.panelThumbnail.DragEnter += new DragEventHandler(picture_DragEnter);
                this.panelThumbnail.DragDrop += new DragEventHandler(picture_DragDrop);

                this.lblFontDropImage.DragEnter += new DragEventHandler(font_DragEnter);
                this.lblFontDropImage.DragDrop += new DragEventHandler(font_DragDrop);

                this.panelFont.DragEnter += new DragEventHandler(font_DragEnter);
                this.panelFont.DragDrop += new DragEventHandler(font_DragDrop);

                this.cmbBlocks.SelectedIndexChanged += new EventHandler(cmbBlocks_SelectedIndexChanged);
                this.cmbFrames1.SelectedIndexChanged += new EventHandler(cmbFrames1_SelectedIndexChanged);
                this.cmbFrames2.SelectedIndexChanged += new EventHandler(cmbFrames2_SelectedIndexChanged);
                this.cmbItemFrames.SelectedIndexChanged += cmbItemFrames_SelectedIndexChanged;

                this.panelDropSound.DragEnter += new DragEventHandler(panelDropSound_DragEnter);
                this.panelDropSound.DragDrop += new DragEventHandler(panelDropSound_DragDrop);
                this.lblDropSound.DragEnter += new DragEventHandler(panelDropSound_DragEnter);
                this.lblDropSound.DragDrop += new DragEventHandler(panelDropSound_DragDrop);

                this.itemPanel.Paint += new PaintEventHandler(itemPanel_Paint);
                this.itemPanel.DragEnter += new DragEventHandler(itemPanel_DragEnter);
                this.itemPanel.DragDrop += new DragEventHandler(itemPanel_DragDrop);
                this.itemPanel.MouseDown += new MouseEventHandler(itemPanel_MouseDown);
                this.itemPanel.MouseUp += new MouseEventHandler(itemPanel_MouseUp);
                this.itemPanel.MouseMove += new MouseEventHandler(itemPanel_MouseMove);

                this.panel1.Paint += new PaintEventHandler(panel_Paint);
                this.panel1.DragEnter += new DragEventHandler(panel_DragEnter);
                this.panel1.DragDrop += new DragEventHandler(panel_DragDrop);
                this.panel1.MouseDown += new MouseEventHandler(panel_MouseDown);
                this.panel1.MouseUp += new MouseEventHandler(panel_MouseUp);
                this.panel1.MouseMove += new MouseEventHandler(panel_MouseMove);

                this.panel2.Paint += new PaintEventHandler(panel_Paint);
                this.panel2.DragEnter += new DragEventHandler(panel_DragEnter);
                this.panel2.DragDrop += new DragEventHandler(panel_DragDrop);
                this.panel2.MouseDown += new MouseEventHandler(panel_MouseDown);
                this.panel2.MouseUp += new MouseEventHandler(panel_MouseUp);
                this.panel2.MouseMove += new MouseEventHandler(panel_MouseMove);

                this.panel3.Paint += new PaintEventHandler(panel_Paint);
                this.panel3.DragEnter += new DragEventHandler(panel_DragEnter);
                this.panel3.DragDrop += new DragEventHandler(panel_DragDrop);
                this.panel3.MouseDown += new MouseEventHandler(panel_MouseDown);
                this.panel3.MouseUp += new MouseEventHandler(panel_MouseUp);
                this.panel3.MouseMove += new MouseEventHandler(panel_MouseMove);

                this.panel4.Paint += new PaintEventHandler(panel_Paint);
                this.panel4.DragEnter += new DragEventHandler(panel_DragEnter);
                this.panel4.DragDrop += new DragEventHandler(panel_DragDrop);
                this.panel4.MouseDown += new MouseEventHandler(panel_MouseDown);
                this.panel4.MouseUp += new MouseEventHandler(panel_MouseUp);
                this.panel4.MouseMove += new MouseEventHandler(panel_MouseMove);

                this.panel5.Paint += new PaintEventHandler(panel_Paint);
                this.panel5.DragEnter += new DragEventHandler(panel_DragEnter);
                this.panel5.DragDrop += new DragEventHandler(panel_DragDrop);
                this.panel5.MouseDown += new MouseEventHandler(panel_MouseDown);
                this.panel5.MouseUp += new MouseEventHandler(panel_MouseUp);
                this.panel5.MouseMove += new MouseEventHandler(panel_MouseMove);

                this.panel6.Paint += new PaintEventHandler(panel_Paint);
                this.panel6.DragEnter += new DragEventHandler(panel_DragEnter);
                this.panel6.DragDrop += new DragEventHandler(panel_DragDrop);
                this.panel6.MouseDown += new MouseEventHandler(panel_MouseDown);
                this.panel6.MouseUp += new MouseEventHandler(panel_MouseUp);
                this.panel6.MouseMove += new MouseEventHandler(panel_MouseMove);

                this.panel7.Paint += new PaintEventHandler(panel_Paint);
                this.panel7.DragEnter += new DragEventHandler(panel_DragEnter);
                this.panel7.DragDrop += new DragEventHandler(panel_DragDrop);
                this.panel7.MouseDown += new MouseEventHandler(panel_MouseDown);
                this.panel7.MouseUp += new MouseEventHandler(panel_MouseUp);
                this.panel7.MouseMove += new MouseEventHandler(panel_MouseMove);

                this.panel8.Paint += new PaintEventHandler(panel_Paint);
                this.panel8.DragEnter += new DragEventHandler(panel_DragEnter);
                this.panel8.DragDrop += new DragEventHandler(panel_DragDrop);
                this.panel8.MouseDown += new MouseEventHandler(panel_MouseDown);
                this.panel8.MouseUp += new MouseEventHandler(panel_MouseUp);
                this.panel8.MouseMove += new MouseEventHandler(panel_MouseMove);

                this.panel9.Paint += new PaintEventHandler(panel_Paint);
                this.panel9.DragEnter += new DragEventHandler(panel_DragEnter);
                this.panel9.DragDrop += new DragEventHandler(panel_DragDrop);
                this.panel9.MouseDown += new MouseEventHandler(panel_MouseDown);
                this.panel9.MouseUp += new MouseEventHandler(panel_MouseUp);
                this.panel9.MouseMove += new MouseEventHandler(panel_MouseMove);

                this.panelColour1.MouseClick += new MouseEventHandler(panelColour_MouseClick);
                this.panelColour2.MouseClick += new MouseEventHandler(panelColour_MouseClick);
                this.panelColour3.MouseClick += new MouseEventHandler(panelColour_MouseClick);
                this.panelColour4.MouseClick += new MouseEventHandler(panelColour_MouseClick);
                this.panelColour5.MouseClick += new MouseEventHandler(panelColour_MouseClick);
                this.panelColour6.MouseClick += new MouseEventHandler(panelColour_MouseClick);
                this.panelColour7.MouseClick += new MouseEventHandler(panelColour_MouseClick);
                this.panelColour8.MouseClick += new MouseEventHandler(panelColour_MouseClick);
                this.panelColour9.MouseClick += new MouseEventHandler(panelColour_MouseClick);
                this.panelColour10.MouseClick += new MouseEventHandler(panelColour_MouseClick);
                this.panelColour11.MouseClick += new MouseEventHandler(panelColour_MouseClick);
                this.panelColour12.MouseClick += new MouseEventHandler(panelColour_MouseClick);
                this.panelColour13.MouseClick += new MouseEventHandler(panelColour_MouseClick);
                this.panelColour14.MouseClick += new MouseEventHandler(panelColour_MouseClick);
                this.panelColour15.MouseClick += new MouseEventHandler(panelColour_MouseClick);
                this.panelColour16.MouseClick += new MouseEventHandler(panelColour_MouseClick);
                this.panelColour17.MouseClick += new MouseEventHandler(panelColour_MouseClick);
                this.panelColour18.MouseClick += new MouseEventHandler(panelColour_MouseClick);
                this.panelColour19.MouseClick += new MouseEventHandler(panelColour_MouseClick);
                this.panelColour20.MouseClick += new MouseEventHandler(panelColour_MouseClick);
                this.panelColour21.MouseClick += new MouseEventHandler(panelColour_MouseClick);
                this.panelColour22.MouseClick += new MouseEventHandler(panelColour_MouseClick);
                this.panelColour23.MouseClick += new MouseEventHandler(panelColour_MouseClick);
                this.panelColour24.MouseClick += new MouseEventHandler(panelColour_MouseClick);

                this.itemPanelColour1.MouseClick += new MouseEventHandler(itemPanelColour_MouseClick);
                this.itemPanelColour2.MouseClick += new MouseEventHandler(itemPanelColour_MouseClick);
                this.itemPanelColour3.MouseClick += new MouseEventHandler(itemPanelColour_MouseClick);
                this.itemPanelColour4.MouseClick += new MouseEventHandler(itemPanelColour_MouseClick);
                this.itemPanelColour5.MouseClick += new MouseEventHandler(itemPanelColour_MouseClick);
                this.itemPanelColour6.MouseClick += new MouseEventHandler(itemPanelColour_MouseClick);
                this.itemPanelColour7.MouseClick += new MouseEventHandler(itemPanelColour_MouseClick);
                this.itemPanelColour8.MouseClick += new MouseEventHandler(itemPanelColour_MouseClick);
                this.itemPanelColour9.MouseClick += new MouseEventHandler(itemPanelColour_MouseClick);
                this.itemPanelColour10.MouseClick += new MouseEventHandler(itemPanelColour_MouseClick);
                this.itemPanelColour11.MouseClick += new MouseEventHandler(itemPanelColour_MouseClick);
                this.itemPanelColour12.MouseClick += new MouseEventHandler(itemPanelColour_MouseClick);
                this.itemPanelColour13.MouseClick += new MouseEventHandler(itemPanelColour_MouseClick);
                this.itemPanelColour14.MouseClick += new MouseEventHandler(itemPanelColour_MouseClick);
                this.itemPanelColour15.MouseClick += new MouseEventHandler(itemPanelColour_MouseClick);
                this.itemPanelColour16.MouseClick += new MouseEventHandler(itemPanelColour_MouseClick);
                this.itemPanelColour17.MouseClick += new MouseEventHandler(itemPanelColour_MouseClick);
                this.itemPanelColour18.MouseClick += new MouseEventHandler(itemPanelColour_MouseClick);
                this.itemPanelColour19.MouseClick += new MouseEventHandler(itemPanelColour_MouseClick);
                this.itemPanelColour20.MouseClick += new MouseEventHandler(itemPanelColour_MouseClick);
                this.itemPanelColour21.MouseClick += new MouseEventHandler(itemPanelColour_MouseClick);
                this.itemPanelColour22.MouseClick += new MouseEventHandler(itemPanelColour_MouseClick);
                this.itemPanelColour23.MouseClick += new MouseEventHandler(itemPanelColour_MouseClick);
                this.itemPanelColour24.MouseClick += new MouseEventHandler(itemPanelColour_MouseClick);

                bool error = false;
                if (File.Exists("minecrafttexturestudio.cfg"))
                {
                    StreamReader reader = null;
                    try
                    {
                        reader = new StreamReader(new FileStream("minecrafttexturestudio.cfg", FileMode.Open, FileAccess.Read));
                        minecraftPath = reader.ReadLine();
                        txtMinecraftPath.Text = minecraftPath;

                        minecraftJarPath = reader.ReadLine();
                        txtMinecraftJarPath.Text = minecraftJarPath;

                        extractedJarPath = reader.ReadLine();
                        txtExtractedJarPath.Text = extractedJarPath;

                        extractJarOption = reader.ReadLine();
                        string strSortOption = reader.ReadLine();
                        reader.Close();

                        if (extractJarOption == "0")
                        {
                            radExtractFromJar.Checked = true;
                        }
                        else if (extractJarOption == "1")
                        {
                            radExtractedPath.Checked = true;
                        }
                        else if (String.IsNullOrEmpty(extractJarOption))
                        {
                            extractJarOption = "0";
                            radExtractFromJar.Checked = true;
                        }

                        if (strSortOption == "0")
                        {
                            sortOption = SortOption.Id;
                            radId.Checked = true;
                        }
                        else if (strSortOption == "1")
                        {
                            sortOption = SortOption.Alphabetical;
                            radAlphabetical.Checked = true;
                        }
                        else
                        {
                            sortOption = SortOption.Id;
                        }

                        if (minecraftPath == null)
                        {
                            minecraftPath = "";
                        }

                        if (minecraftJarPath == null)
                        {
                            minecraftJarPath = "";
                        }

                        if (extractedJarPath == null)
                        {
                            extractedJarPath = "";
                        }

                        if (!Directory.Exists(minecraftPath))
                        {
                            minecraftPath = "";
                            MessageBox.Show("Minecraft folder not found. Go to the settings tab, locate your minecraft folder and " +
                                "set it there", "Minecraft Texture Studio");
                        }

                        if (!File.Exists(minecraftJarPath))
                        {
                            minecraftJarPath = "";
                            MessageBox.Show("Minecraft jar file not found. Go to the settings tab, locate your minecraft jar file and " +
                                "set it there", "Minecraft Texture Studio");
                        }

                        if (minecraftJarPath != "")
                        {
                            jarName = minecraftJarPath.Substring(minecraftJarPath.LastIndexOf("\\") + 1,
                                minecraftJarPath.LastIndexOf(".") - minecraftJarPath.LastIndexOf("\\") - 1);
                        }
                    }
                    catch (IOException exception)
                    {
                        MessageBox.Show("IOException occured reading from minecrafttexturestudio.cfg: " + exception.Message, "Error");
                        error = true;
                    }
                    finally
                    {
                        if (reader != null)
                        {
                            reader.Dispose();
                        }
                    }
                }

                if (error || !File.Exists("minecrafttexturestudio.cfg"))
                {
                    minecraftPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\.minecraft";
                    string latestDirPath = "";

                    if (!Directory.Exists(minecraftPath))
                    {
                        MessageBox.Show("Minecraft folder not found. Go to the settings tab, locate your minecraft folder and " +
                            "set it there", "Minecraft Texture Studio");
                    }

                    if (Directory.Exists(minecraftPath + "\\versions"))
                    {
                        string[] directories = Directory.GetDirectories(minecraftPath + "\\versions");
                        DateTime latestDirCreated = new DateTime();

                        foreach (string currentDirectory in directories)
                        {
                            DateTime lastWriteTime = Directory.GetLastWriteTime(currentDirectory);

                            if (lastWriteTime > latestDirCreated)
                            {
                                latestDirCreated = lastWriteTime;
                                latestDirPath = currentDirectory;
                            }
                        }
                    }

                    if (latestDirPath != "")
                    {
                        jarName = latestDirPath.Substring(latestDirPath.LastIndexOf("\\") + 1,
                            latestDirPath.Length - latestDirPath.LastIndexOf("\\") - 1);

                        minecraftJarPath = latestDirPath + "\\" + jarName + ".jar";
                    }

                    if (!File.Exists(minecraftJarPath))
                    {
                        minecraftJarPath = "";
                        MessageBox.Show("Minecraft jar file not found. Go to the settings tab, locate your minecraft jar file and " +
                            "set it there", "Minecraft Texture Studio");
                    }

                    saveConfig();
                }

                txtMinecraftPath.Text = minecraftPath;
                txtMinecraftJarPath.Text = minecraftJarPath;
                txtExtractedJarPath.Text = extractedJarPath;

                txtMinecraftPath.TextChanged += new EventHandler(txtMinecraftPath_TextChanged);
                txtMinecraftJarPath.TextChanged += new EventHandler(txtMinecraftJarPath_TextChanged);
                txtExtractedJarPath.TextChanged += new EventHandler(txtExtractedJarPath_TextChanged);

                OrganiseResourcePack.loadOrganiseTree();

                treeView.AfterCheck += new TreeViewEventHandler(treeView_AfterCheck);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Exception occured initialising program: " + exception.Message);
            }

            setPanelsLocation();

            /**/
            //createNewPack(@"C:\Users\Rolf\Desktop\texturepack.zip");
        }

        void cmbItemFrames_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (itemTextureStrip != null)
            {
                int width = itemPicture.Width;

                //use width for width and height to make it square
                for (int y = 0; y < width; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        Color colour = itemTextureStrip.GetPixel(x, cmbItemFrames.SelectedIndex * width + y);
                        itemPicture.SetPixel(x, y, colour);
                    }
                }

                itemPanel.Refresh();
            }
        }

        void itemPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            Bitmap currentTexture = itemPicture;
            if (currentTexture != null)
            {
                lock (currentTexture)
                {
                    for (int y = 0; y < currentTexture.Height; y++)
                    {
                        for (int x = 0; x < currentTexture.Width; x++)
                        {
                            Color colour = currentTexture.GetPixel(x, y);
                            Brush brush = new SolidBrush(colour);

                            g.FillRectangle(brush, new Rectangle(x * itemPixelSize, y * itemPixelSize,
                                itemPixelSize, itemPixelSize));
                        }
                    }
                }
            }
        }

        void cmbItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmbItemFrames.Visible = false;
                cmbItemFrames.Items.Clear();

                string itemName = (string)cmbItems.Items[cmbItems.SelectedIndex];
                List<string> textures = Items.getTextures(itemName);
                itemPixelSize = 10;

                Bitmap loadPicture = new Bitmap(textures[0]);
                itemPicture = new Bitmap(loadPicture);
                loadPicture.Dispose();

                if (itemPicture.Width == 32 && itemPicture.Width == 32)
                {
                    itemPixelSize = 10;
                }
                else if (itemPicture.Width == 64 && itemPicture.Width == 64)
                {
                    itemPixelSize = 5;
                }
                else if (itemPicture.Width == 128 && itemPicture.Width == 128)
                {
                    itemPixelSize = 4;
                }
                else if (itemPicture.Width == 256 && itemPicture.Width == 256)
                {
                    itemPixelSize = 2;
                }

                if (itemName != "Clock" && itemName != "Compass")
                {
                    itemPanel.Width = itemPicture.Width * itemPixelSize;
                    itemPanel.Height = itemPicture.Height * itemPixelSize;
                }

                string path = textures[0];
                lblFilename.Text = path.Substring(path.LastIndexOf("\\") + 1, path.Length - path.LastIndexOf("\\") - 1);
                lblFilename.Location = new Point(itemPanel.Location.X, itemPanel.Location.Y - 22);

                if (itemName == "Clock")
                {
                    for (int a = 0; a < 64; a++)
                    {
                        cmbItemFrames.Items.Add(a + 1);
                    }
                }
                else if (itemName == "Compass")
                {
                    for (int a = 0; a < 32; a++)
                    {
                        cmbItemFrames.Items.Add(a + 1);
                    }
                }

                if (itemName == "Clock" || itemName == "Compass")
                {
                    //using width for both to make it square
                    itemPanel.Width = itemPicture.Width * itemPixelSize;
                    itemPanel.Height = itemPicture.Width * itemPixelSize;

                    lblFilename.Text = "Textures";
                    lblFilename.Location = new Point(itemPanel.Location.X, itemPanel.Location.Y - 27);
                    itemTextureStrip = new Bitmap(itemPicture);
                    int width = itemPicture.Width;

                    cmbItemFrames.SelectedIndex = 0;
                    cmbItemFrames.Visible = true;

                    //use width for width and height to make it square
                    for (int y = 0; y < width; y++)
                    {
                        for (int x = 0; x < width; x++)
                        {
                            Color colour = itemTextureStrip.GetPixel(x, cmbItemFrames.SelectedIndex * width + y);
                            itemPicture.SetPixel(x, y, colour);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Exception occured loading item: " + exception.Message + "\n" +
                    exception.StackTrace);
            }

            itemPanel.Refresh();
        }

        void setPanelsLocation()
        {
            setPanelLocation(0, panel1, lblFilename1);
            setPanelLocation(1, panel2, lblFilename2);
            setPanelLocation(2, panel7, lblFilename7); //panel 7 is on the top row
            setPanelLocation(3, panel3, lblFilename3);
            setPanelLocation(4, panel4, lblFilename4);
            setPanelLocation(5, panel8, lblFilename8); //panel 8 is on the top row
            setPanelLocation(6, panel5, lblFilename5);
            setPanelLocation(7, panel6, lblFilename6);
            setPanelLocation(8, panel9, lblFilename9); //panel 9 is on the top row
        }

        void setPanelLocation(int index, Panel panel, Label label)
        {
            int width = panel.Width;
            int height = panel.Height;

            int xIndex = index % 3;
            int yIndex = index / 3;

            int widthOffset = 62;
            int heightOffset = 34;

            if (pixelSize == 7)
            {
                widthOffset = 0;
                heightOffset = 0;
            }

            panel.Location = new Point(9 + xIndex * (width + widthOffset), 72 + yIndex * (height + heightOffset));
            label.Location = new Point(panel.Location.X, panel.Location.Y - 22);
        }

        void cmbSounds_SelectedIndexChanged(object sender, EventArgs e)
        {
            string soundName = (string)cmbSounds.Items[cmbSounds.SelectedIndex];
            string filename = Sounds.getSounds(soundName);
        }

        void panelDropSound_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        void panelDropSound_DragDrop(object sender, DragEventArgs e)
        {
            string[] paths = (string[])e.Data.GetData(DataFormats.FileDrop);

            if (paths.Length != 1)
            {
                MessageBox.Show("Only drop in one file", "Minecraft Texture Studio");
                return;
            }

            string soundFilename = paths[0];
            saveSoundFile(soundFilename);
        }

        void saveSoundFile(string soundFilename)
        {
            if (!soundFilename.EndsWith(".ogg"))
            {
                MessageBox.Show("File must be an Ogg Vorbis file with ogg extension", "Minecraft Texture Studio");
                return;
            }

            if (cmbSounds.SelectedIndex == -1)
            {
                MessageBox.Show("No sound selected", "Minecraft Texture Studio");
                return;
            }

            try
            {
                if (cmbSounds.SelectedIndex != -1)
                {
                    string soundName = (string)cmbSounds.Items[cmbSounds.SelectedIndex];
                    string filename = Sounds.getSounds(soundName);

                    File.Copy(soundFilename, filename, true);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Exception occured saving sound file: " + exception.Message);
            }
        }

        void cmbTextColour_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTextColour.SelectedIndex == 0)
            {
                packNameColour = Color.FromArgb(1, 1, 1);
            }
            else if (cmbTextColour.SelectedIndex == 1)
            {
                packNameColour = Color.FromArgb(0, 0, 170);
            }
            else if (cmbTextColour.SelectedIndex == 2)
            {
                packNameColour = Color.FromArgb(0, 170, 0);
            }
            else if (cmbTextColour.SelectedIndex == 3)
            {
                packNameColour = Color.FromArgb(0, 170, 170);
            }
            else if (cmbTextColour.SelectedIndex == 4)
            {
                packNameColour = Color.FromArgb(170, 0, 0);
            }
            else if (cmbTextColour.SelectedIndex == 5)
            {
                packNameColour = Color.FromArgb(170, 0, 170);
            }
            else if (cmbTextColour.SelectedIndex == 6)
            {
                packNameColour = Color.FromArgb(255, 170, 0);
            }
            else if (cmbTextColour.SelectedIndex == 7)
            {
                packNameColour = Color.FromArgb(170, 170, 170);
            }
            else if (cmbTextColour.SelectedIndex == 8)
            {
                packNameColour = Color.FromArgb(85, 85, 85);
            }
            else if (cmbTextColour.SelectedIndex == 9)
            {
                packNameColour = Color.FromArgb(85, 85, 255);
            }
            else if (cmbTextColour.SelectedIndex == 10)
            {
                packNameColour = Color.FromArgb(85, 255, 85);
            }
            else if (cmbTextColour.SelectedIndex == 11)
            {
                packNameColour = Color.FromArgb(85, 255, 255);
            }
            else if (cmbTextColour.SelectedIndex == 12)
            {
                packNameColour = Color.FromArgb(255, 85, 85);
            }
            else if (cmbTextColour.SelectedIndex == 13)
            {
                packNameColour = Color.FromArgb(255, 85, 255);
            }
            else if (cmbTextColour.SelectedIndex == 14)
            {
                packNameColour = Color.FromArgb(255, 255, 85);
            }
            else if (cmbTextColour.SelectedIndex == 15)
            {
                packNameColour = Color.FromArgb(255, 255, 255);
            }
            else if (cmbTextColour.SelectedIndex == 16)
            {
                packNameColour = Color.FromArgb(0, 0, 0);
            }
        }

        void cmbTextColour_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle bounds = e.Bounds;

            if (e.Index >= 0)
            {
                Color colour = Color.Black;

                if (e.Index == 0)
                {
                    colour = Color.FromArgb(1, 1, 1);
                }
                else if (e.Index == 1)
                {
                    colour = Color.FromArgb(0, 0, 170);
                }
                else if (e.Index == 2)
                {
                    colour = Color.FromArgb(0, 170, 0);
                }
                else if (e.Index == 3)
                {
                    colour = Color.FromArgb(0, 170, 170);
                }
                else if (e.Index == 4)
                {
                    colour = Color.FromArgb(170, 0, 0);
                }
                else if (e.Index == 5)
                {
                    colour = Color.FromArgb(170, 0, 170);
                }
                else if (e.Index == 6)
                {
                    colour = Color.FromArgb(255, 170, 0);
                }
                else if (e.Index == 7)
                {
                    colour = Color.FromArgb(170, 170, 170);
                }
                else if (e.Index == 8)
                {
                    colour = Color.FromArgb(85, 85, 85);
                }
                else if (e.Index == 9)
                {
                    colour = Color.FromArgb(85, 85, 255);
                }
                else if (e.Index == 10)
                {
                    colour = Color.FromArgb(85, 255, 85);
                }
                else if (e.Index == 11)
                {
                    colour = Color.FromArgb(85, 255, 255);
                }
                else if (e.Index == 12)
                {
                    colour = Color.FromArgb(255, 85, 85);
                }
                else if (e.Index == 13)
                {
                    colour = Color.FromArgb(255, 85, 255);
                }
                else if (e.Index == 14)
                {
                    colour = Color.FromArgb(255, 255, 85);
                }
                else if (e.Index == 15)
                {
                    colour = Color.FromArgb(255, 255, 255);
                }
                else if (e.Index == 16)
                {
                    colour = Color.FromArgb(255, 255, 255);
                }

                g.FillRectangle(new SolidBrush(colour), e.Bounds);

                Brush brush = Brushes.White;
                if (e.Index >= 10)
                {
                    brush = Brushes.Black;
                }

                g.DrawString((string)cmbTextColour.Items[e.Index], new Font("Arial", 10), brush, bounds.Location);
            }
        }

        int getColourIndex(Color colour)
        {
            if (colour.R == 0 && colour.G == 0 && colour.B == 0)
            {
                return -1;
            }
            else if (colour.R == 1 && colour.G == 1 && colour.B == 1)
            {
                return 0;
            }
            else if (colour.R == 0 && colour.G == 0 && colour.B == 170)
            {
                return 1;
            }
            else if (colour.R == 0 && colour.G == 170 && colour.B == 0)
            {
                return 2;
            }
            else if (colour.R == 0 && colour.G == 170 && colour.B == 170)
            {
                return 3;
            }
            else if (colour.R == 0 && colour.G == 0 && colour.B == 170)
            {
                return 4;
            }
            else if (colour.R == 170 && colour.G == 0 && colour.B == 170)
            {
                return 5;
            }
            else if (colour.R == 255 && colour.G == 170 && colour.B == 170)
            {
                return 6;
            }
            else if (colour.R == 170 && colour.G == 170 && colour.B == 170)
            {
                return 7;
            }
            else if (colour.R == 85 && colour.G == 85 && colour.B == 85)
            {
                return 8;
            }
            else if (colour.R == 85 && colour.G == 85 && colour.B == 255)
            {
                return 9;
            }
            else if (colour.R == 85 && colour.G == 255 && colour.B == 85)
            {
                return 10;
            }
            else if (colour.R == 85 && colour.G == 255 && colour.B == 255)
            {
                return 11;
            }
            else if (colour.R == 255 && colour.G == 85 && colour.B == 85)
            {
                return 12;
            }
            else if (colour.R == 255 && colour.G == 85 && colour.B == 255)
            {
                return 13;
            }
            else if (colour.R == 255 && colour.G == 255 && colour.B == 85)
            {
                return 14;
            }
            else if (colour.R == 255 && colour.G == 255 && colour.B == 255)
            {
                return 15;
            }

            return -1;
        }

        void resetMode(Button button)
        {
            mode = PaintMode.None;

            if (button != btnPen)
            {
                btnPen.Toggled = false;
            }

            if (button != btnLine)
            {
                btnLine.Toggled = false;
            }

            if (button != btnRectangle)
            {
                btnRectangle.Toggled = false;
            }

            if (button != btnBucket)
            {
                btnBucket.Toggled = false;
            }

            if (button != btnClear)
            {
                btnClear.Toggled = false;
            }

            if (button != btnPicker)
            {
                btnPicker.Toggled = false;
            }
        }

        void resetItemMode(Button button)
        {
            itemMode = PaintMode.None;

            if (button != btnItemPen)
            {
                btnItemPen.Toggled = false;
            }

            if (button != btnItemLine)
            {
                btnItemLine.Toggled = false;
            }

            if (button != btnItemRectangle)
            {
                btnItemRectangle.Toggled = false;
            }

            if (button != btnItemBucket)
            {
                btnItemBucket.Toggled = false;
            }

            if (button != btnItemClear)
            {
                btnItemClear.Toggled = false;
            }

            if (button != btnItemPicker)
            {
                btnItemPicker.Toggled = false;
            }
        }

        public void saveConfig()
        {
            StreamWriter writer = new StreamWriter(new FileStream("minecrafttexturestudio.cfg", FileMode.Create, FileAccess.Write));
            writer.WriteLine(minecraftPath);
            writer.WriteLine(minecraftJarPath);
            writer.WriteLine(extractedJarPath);
            writer.WriteLine(extractJarOption);

            if (sortOption == SortOption.Id)
            {
                writer.WriteLine("0");
            }
            else if (sortOption == SortOption.Alphabetical)
            {
                writer.WriteLine("1");
            }

            writer.Close();
        }

        void panel_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (cmbBlocks.SelectedIndex != -1)
                {
                    int mouseX = (int)(e.X / pixelSize);
                    int mouseY = (int)(e.Y / pixelSize);

                    string blockName = (string)cmbBlocks.Items[cmbBlocks.SelectedIndex];
                    List<string> textures = Blocks.getTextures(blockName);
                    string filename = textures[mouseDownPanel];

                    int currentTextureWidth = 0;
                    int currentTextureHeight = 0;

                    int panelIndex = getPanel(sender);
                    Bitmap bitmap = getTexture(sender);

                    lock (bitmap)
                    {
                        currentTextureWidth = bitmap.Width;
                        currentTextureHeight = bitmap.Height;
                    }

                    if (mouseX >= 0 && mouseX < currentTextureWidth &&
                        mouseY >= 0 && mouseY < currentTextureHeight && isMouseDown)
                    {
                        lock (bitmap)
                        {
                            if (mode == PaintMode.Line ||
                                mode == PaintMode.Rectangle)
                            {
                                if (restoreTexture != null)
                                {
                                    for (int y = 0; y < currentTextureHeight; y++)
                                    {
                                        for (int x = 0; x < currentTextureWidth; x++)
                                        {
                                            bitmap.SetPixel(x, y, restoreTexture.GetPixel(x, y));
                                        }
                                    }
                                }
                            }

                            Graphics g = Graphics.FromImage(bitmap);
                            Pen pen = new Pen(paintColour, 1.0f);

                            if (mode == PaintMode.Pen)
                            {
                                bitmap.SetPixel(mouseX, mouseY, paintColour);
                            }
                            else if (mode == PaintMode.Line)
                            {
                                g.DrawLine(pen, mouseDownX, mouseDownY, mouseX, mouseY);
                            }
                            else if (mode == PaintMode.Rectangle)
                            {
                                g.DrawRectangle(pen, mouseDownX, mouseDownY, mouseX - mouseDownX, mouseY - mouseDownY);
                            }
                            else if (mode == PaintMode.Clear)
                            {
                                bitmap.SetPixel(mouseX, mouseY, Color.FromArgb(0, 0, 0, 0));
                            }

                            g.Dispose();

                            try
                            {
                                Bitmap saveBitmap = new Bitmap(bitmap);
                                saveBitmap.Save(filename);
                                saveBitmap.Dispose();
                            }
                            catch (Exception exception)
                            {
                                Console.WriteLine("Exception occured in panelMouseMove: " + exception.Message);
                            }

                            FrmTexturePreview.boolUpdateTextures = true;
                            Blocks.getTextures(FrmTexturePreview.blockName);

                            Panel panel = (Panel)sender;

                            if (panel == panel1)
                            {
                                lock (texture1)
                                {
                                    for (int y = 0; y < texture1.Height; y++)
                                    {
                                        for (int x = 0; x < texture1.Width; x++)
                                        {
                                            Color colour = bitmap.GetPixel(x, y);
                                            texture1.SetPixel(x, y, colour);
                                        }
                                    }
                                }
                            }
                            else if (panel == panel2)
                            {
                                lock (texture2)
                                {
                                    for (int y = 0; y < texture2.Height; y++)
                                    {
                                        for (int x = 0; x < texture2.Width; x++)
                                        {
                                            Color colour = bitmap.GetPixel(x, y);
                                            texture2.SetPixel(x, y, colour);
                                        }
                                    }
                                }
                            }
                            else if (panel == panel3)
                            {
                                lock (texture3)
                                {
                                    for (int y = 0; y < texture3.Height; y++)
                                    {
                                        for (int x = 0; x < texture3.Width; x++)
                                        {
                                            Color colour = bitmap.GetPixel(x, y);
                                            texture3.SetPixel(x, y, colour);
                                        }
                                    }
                                }
                            }
                            else if (panel == panel4)
                            {
                                lock (texture4)
                                {
                                    for (int y = 0; y < texture4.Height; y++)
                                    {
                                        for (int x = 0; x < texture4.Width; x++)
                                        {
                                            Color colour = bitmap.GetPixel(x, y);
                                            texture4.SetPixel(x, y, colour);
                                        }
                                    }
                                }
                            }
                            else if (panel == panel5)
                            {
                                lock (texture5)
                                {
                                    for (int y = 0; y < texture5.Height; y++)
                                    {
                                        for (int x = 0; x < texture5.Width; x++)
                                        {
                                            Color colour = bitmap.GetPixel(x, y);
                                            texture5.SetPixel(x, y, colour);
                                        }
                                    }
                                }
                            }
                            else if (panel == panel6)
                            {
                                lock (texture6)
                                {
                                    for (int y = 0; y < texture6.Height; y++)
                                    {
                                        for (int x = 0; x < texture6.Width; x++)
                                        {
                                            Color colour = bitmap.GetPixel(x, y);
                                            texture6.SetPixel(x, y, colour);
                                        }
                                    }
                                }
                            }
                            else if (panel == panel7)
                            {
                                lock (texture7)
                                {
                                    for (int y = 0; y < texture7.Height; y++)
                                    {
                                        for (int x = 0; x < texture7.Width; x++)
                                        {
                                            Color colour = bitmap.GetPixel(x, y);
                                            texture7.SetPixel(x, y, colour);
                                        }
                                    }
                                }
                            }
                            else if (panel == panel8)
                            {
                                lock (texture8)
                                {
                                    for (int y = 0; y < texture8.Height; y++)
                                    {
                                        for (int x = 0; x < texture8.Width; x++)
                                        {
                                            Color colour = bitmap.GetPixel(x, y);
                                            texture8.SetPixel(x, y, colour);
                                        }
                                    }
                                }
                            }
                            else if (panel == panel9)
                            {
                                lock (texture9)
                                {
                                    for (int y = 0; y < texture9.Height; y++)
                                    {
                                        for (int x = 0; x < texture9.Width; x++)
                                        {
                                            Color colour = bitmap.GetPixel(x, y);
                                            texture9.SetPixel(x, y, colour);
                                        }
                                    }
                                }
                            }

                            panel.Refresh();
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("Exception occured: " + exception.Message);
            }
        }

        void itemPanel_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (cmbItems.SelectedIndex != -1)
                {
                    int mouseX = (int)(e.X / itemPixelSize);
                    int mouseY = (int)(e.Y / itemPixelSize);

                    string itemName = (string)cmbItems.Items[cmbItems.SelectedIndex];
                    List<string> textures = Items.getTextures(itemName);
                    string filename = textures[0];

                    if (mouseX >= 0 && mouseX < itemPicture.Width &&
                        mouseY >= 0 && mouseY < itemPicture.Height && itemIsMouseDown)
                    {
                        if (itemMode == PaintMode.Line ||
                            itemMode == PaintMode.Rectangle)
                        {
                            if (itemRestoreTexture != null)
                            {
                                for (int y = 0; y < itemPicture.Height; y++)
                                {
                                    for (int x = 0; x < itemPicture.Width; x++)
                                    {
                                        itemPicture.SetPixel(x, y, itemRestoreTexture.GetPixel(x, y));
                                    }
                                }
                            }
                        }

                        Graphics g = Graphics.FromImage(itemPicture);
                        Pen pen = new Pen(itemPaintColour, 1.0f);

                        if (itemMode == PaintMode.Pen)
                        {
                            itemPicture.SetPixel(mouseX, mouseY, itemPaintColour);
                        }
                        else if (itemMode == PaintMode.Line)
                        {
                            g.DrawLine(pen, itemMouseDownX, itemMouseDownY, mouseX, mouseY);
                        }
                        else if (itemMode == PaintMode.Rectangle)
                        {
                            g.DrawRectangle(pen, itemMouseDownX, itemMouseDownY, mouseX - itemMouseDownX, mouseY - itemMouseDownY);
                        }
                        else if (itemMode == PaintMode.Clear)
                        {
                            itemPicture.SetPixel(mouseX, mouseY, Color.FromArgb(0, 0, 0, 0));
                        }

                        g.Dispose();

                        try
                        {
                            Bitmap saveBitmap = new Bitmap(itemPicture);
                            saveBitmap.Save(filename);
                            saveBitmap.Dispose();
                        }
                        catch (Exception exception)
                        {
                            Console.WriteLine("Exception occured saving bitmap in itemPanelMouseMove: " + exception.Message);
                        }

                        itemPanel.Refresh();
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Exception occured in itemPanelMouseMove: " + exception.Message + "\n" +
                    exception.StackTrace);
            }
        }

        void panelColour_MouseClick(object sender, MouseEventArgs e)
        {
            Panel panel = (Panel)sender;
            paintColour = panel.BackColor;
            panelColour.BackColor = paintColour;

            if (panel == panelColour1)
            {
                colourIndex = 0;
            }
            else if (panel == panelColour2)
            {
                colourIndex = 1;
            }
            else if (panel == panelColour3)
            {
                colourIndex = 2;
            }
            else if (panel == panelColour4)
            {
                colourIndex = 3;
            }
            else if (panel == panelColour5)
            {
                colourIndex = 4;
            }
            else if (panel == panelColour6)
            {
                colourIndex = 5;
            }
            else if (panel == panelColour7)
            {
                colourIndex = 6;
            }
            else if (panel == panelColour8)
            {
                colourIndex = 7;
            }
            else if (panel == panelColour9)
            {
                colourIndex = 8;
            }
            else if (panel == panelColour10)
            {
                colourIndex = 9;
            }
            else if (panel == panelColour11)
            {
                colourIndex = 10;
            }
            else if (panel == panelColour12)
            {
                colourIndex = 11;
            }
            else if (panel == panelColour13)
            {
                colourIndex = 12;
            }
            else if (panel == panelColour14)
            {
                colourIndex = 13;
            }
            else if (panel == panelColour15)
            {
                colourIndex = 14;
            }
            else if (panel == panelColour16)
            {
                colourIndex = 15;
            }
            else if (panel == panelColour17)
            {
                colourIndex = 16;
            }
            else if (panel == panelColour18)
            {
                colourIndex = 17;
            }
            else if (panel == panelColour19)
            {
                colourIndex = 18;
            }
            else if (panel == panelColour20)
            {
                colourIndex = 19;
            }
            else if (panel == panelColour21)
            {
                colourIndex = 20;
            }
            else if (panel == panelColour22)
            {
                colourIndex = 21;
            }
            else if (panel == panelColour23)
            {
                colourIndex = 22;
            }
            else if (panel == panelColour24)
            {
                colourIndex = 23;
            }
        }

        void itemPanelColour_MouseClick(object sender, MouseEventArgs e)
        {
            Panel panel = (Panel)sender;
            itemPaintColour = panel.BackColor;
            itemPanelColour.BackColor = itemPaintColour;

            if (panel == itemPanelColour1)
            {
                itemColourIndex = 0;
            }
            else if (panel == itemPanelColour2)
            {
                itemColourIndex = 1;
            }
            else if (panel == itemPanelColour3)
            {
                itemColourIndex = 2;
            }
            else if (panel == itemPanelColour4)
            {
                itemColourIndex = 3;
            }
            else if (panel == itemPanelColour5)
            {
                itemColourIndex = 4;
            }
            else if (panel == itemPanelColour6)
            {
                itemColourIndex = 5;
            }
            else if (panel == itemPanelColour7)
            {
                itemColourIndex = 6;
            }
            else if (panel == itemPanelColour8)
            {
                itemColourIndex = 7;
            }
            else if (panel == itemPanelColour9)
            {
                itemColourIndex = 8;
            }
            else if (panel == itemPanelColour10)
            {
                itemColourIndex = 9;
            }
            else if (panel == itemPanelColour11)
            {
                itemColourIndex = 10;
            }
            else if (panel == itemPanelColour12)
            {
                itemColourIndex = 11;
            }
            else if (panel == itemPanelColour13)
            {
                itemColourIndex = 12;
            }
            else if (panel == itemPanelColour14)
            {
                itemColourIndex = 13;
            }
            else if (panel == itemPanelColour15)
            {
                itemColourIndex = 14;
            }
            else if (panel == itemPanelColour16)
            {
                itemColourIndex = 15;
            }
            else if (panel == itemPanelColour17)
            {
                itemColourIndex = 16;
            }
            else if (panel == itemPanelColour18)
            {
                itemColourIndex = 17;
            }
            else if (panel == itemPanelColour19)
            {
                itemColourIndex = 18;
            }
            else if (panel == itemPanelColour20)
            {
                itemColourIndex = 19;
            }
            else if (panel == itemPanelColour21)
            {
                itemColourIndex = 20;
            }
            else if (panel == itemPanelColour22)
            {
                itemColourIndex = 21;
            }
            else if (panel == itemPanelColour23)
            {
                itemColourIndex = 22;
            }
            else if (panel == itemPanelColour24)
            {
                itemColourIndex = 23;
            }
        }

        void panel_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDownPanel = getPanel(sender);
            mouseDownX = (int)(e.X / pixelSize);
            mouseDownY = (int)(e.Y / pixelSize);
            isMouseDown = true;

            /**/
            Console.WriteLine("Clicked " + mouseDownX + " " + mouseDownY);

            Bitmap panelPicture = getTexture(sender);

            lock (panelPicture)
            {
                restoreTexture = new Bitmap(panelPicture);
            }

            /**/
            //Console.WriteLine("Texture1 0, 0: " + panelPicture.GetPixel(0, 0));
            //Console.WriteLine("restoreTexture 0, 0: " + restoreTexture.GetPixel(0, 0));

            if (mode == PaintMode.Clear)
            {
                int deleteCount = undos.Count - undoIndex - 1;
                if (deleteCount > 0 & undoIndex < undos.Count - 1)
                {
                    try
                    {
                        undos.RemoveRange(undoIndex + 1, deleteCount);
                        redos.RemoveRange(undoIndex + 1, deleteCount);
                    }
                    catch (ArgumentException exception)
                    {
                        Console.WriteLine("ArgumentException occured: " + exception.Message);
                    }
                }

                undos.Add(new TextureChange(mouseDownPanel, new Bitmap(panelPicture)));

                undoIndex++;
            }
        }

        void itemPanel_MouseDown(object sender, MouseEventArgs e)
        {
            itemMouseDownX = (int)(e.X / itemPixelSize);
            itemMouseDownY = (int)(e.Y / itemPixelSize);
            itemIsMouseDown = true;

            /**/
            Console.WriteLine("Item Panel: Clicked " + itemMouseDownX + " " + itemMouseDownY);

            lock (itemPicture)
            {
                itemRestoreTexture = new Bitmap(itemPicture);

                if (itemMode == PaintMode.Clear)
                {
                    int deleteCount = itemUndos.Count - itemUndoIndex - 1;
                    if (deleteCount > 0 & itemUndoIndex < itemUndos.Count - 1)
                    {
                        try
                        {
                            itemUndos.RemoveRange(itemUndoIndex + 1, deleteCount);
                            itemRedos.RemoveRange(itemUndoIndex + 1, deleteCount);
                        }
                        catch (ArgumentException exception)
                        {
                            Console.WriteLine("ArgumentException occured: " + exception.Message);
                        }
                    }

                    itemUndos.Add(new TextureChange(0, new Bitmap(itemPicture)));
                    itemUndoIndex++;
                }
            }
        }

        void panel_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                mouseUpPanel = getPanel(sender);
                mouseUpX = (int)(e.X / pixelSize);
                mouseUpY = (int)(e.Y / pixelSize);
                isMouseDown = false;

                int panelIndex = getPanel(sender);
                Bitmap panelPicture = getTexture(panelIndex);

                lock (panelPicture)
                {
                    /**/
                    //Console.WriteLine("mouse up");

                    if (mode == PaintMode.Line ||
                        mode == PaintMode.Rectangle)
                    {
                        if (restoreTexture != null)
                        {
                            for (int y = 0; y < 16; y++)
                            {
                                for (int x = 0; x < 16; x++)
                                {
                                    panelPicture.SetPixel(x, y, restoreTexture.GetPixel(x, y));
                                }
                            }
                        }
                    }

                    Graphics g = Graphics.FromImage(panelPicture);
                    Pen pen = new Pen(paintColour, 1.0f);

                    if (mouseDownPanel == mouseUpPanel)
                    {
                        if (mode == PaintMode.Clear)
                        {
                            int deleteCount = undos.Count - undoIndex - 1;
                            if (deleteCount > 0 & undoIndex < undos.Count - 1)
                            {
                                try
                                {
                                    undos.RemoveRange(undoIndex + 1, deleteCount);
                                    redos.RemoveRange(undoIndex + 1, deleteCount);
                                }
                                catch (ArgumentException exception)
                                {
                                    Console.WriteLine("ArgumentException occured: " + exception.Message);
                                }
                            }

                            undos.Add(new TextureChange(mouseDownPanel, new Bitmap(panelPicture)));

                            undoIndex++;
                        }

                        if (mode == PaintMode.Line)
                        {
                            g.DrawLine(pen, mouseDownX, mouseDownY, mouseUpX, mouseUpY);
                        }
                        else if (mode == PaintMode.Rectangle)
                        {
                            g.DrawRectangle(pen, mouseDownX, mouseDownY, mouseUpX - mouseDownX, mouseUpY - mouseDownY);
                        }
                        else if (mode == PaintMode.Pen)
                        {
                            panelPicture.SetPixel(mouseUpX, mouseUpY, paintColour);
                        }
                        else if (mode == PaintMode.Bucket)
                        {
                            paintBucket(panelPicture, mouseUpX, mouseUpY, panelPicture.Width, panelPicture.Height, paintColour);
                        }
                        else if (mode == PaintMode.Clear)
                        {
                            panelPicture.SetPixel(mouseUpX, mouseUpY, Color.FromArgb(0, 0, 0, 0));
                        }
                        else if (mode == PaintMode.Picker)
                        {
                            pickColour(panelPicture, mouseUpX, mouseUpY);
                        }

                        g.Dispose();

                        if (mode != PaintMode.None)
                        {
                            redos.Add(new TextureChange(panelIndex, new Bitmap(panelPicture)));
                            undoIndex = undos.Count - 1;

                            saveTexture(panelPicture, panelIndex);

                            Panel panel = (Panel)sender;
                            panel.Refresh();

                            FrmTexturePreview.boolUpdateTextures = true;
                            Blocks.getTextures(FrmTexturePreview.blockName);
                        }
                    }

                    /**/
                    Console.WriteLine("Saved restoreTexture to current texture after mouse up");

                    restoreTexture = new Bitmap(panelPicture);
                    restoreTexture.SetPixel(0, 0, Color.Black);

                    //panelRestoreTexture.Refresh();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Exception occured at mouse up event: " + exception.Message + "\n" +
                    exception.StackTrace);
            }
        }

        void itemPanel_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                itemMouseUpX = (int)(e.X / itemPixelSize);
                itemMouseUpY = (int)(e.Y / itemPixelSize);
                itemIsMouseDown = false;

                /**/
                //Console.WriteLine("mouse up");

                //lock (panelPicture)
                {
                    /*if (mode == PaintMode.Line ||
                        mode == PaintMode.Rectangle)
                    {
                        if (restoreTexture != null)
                        {
                            for (int y = 0; y < 16; y++)
                            {
                                for (int x = 0; x < 16; x++)
                                {
                                    panelPicture.SetPixel(x, y, restoreTexture.GetPixel(x, y));
                                }
                            }
                        }
                    }*/

                    Graphics g = Graphics.FromImage(itemPicture);
                    Pen pen = new Pen(itemPaintColour, 1.0f);

                    if (itemMode != PaintMode.None)
                    {
                        int deleteCount = itemUndos.Count - itemUndoIndex - 1;
                        if (deleteCount > 0 & itemUndoIndex < itemUndos.Count - 1)
                        {
                            itemUndos.RemoveRange(itemUndoIndex + 1, deleteCount);
                            itemRedos.RemoveRange(itemUndoIndex + 1, deleteCount);
                        }

                        itemUndos.Add(new TextureChange(0, new Bitmap(itemPicture)));
                    }

                    if (itemMode == PaintMode.Line)
                    {
                        g.DrawLine(pen, itemMouseDownX, itemMouseDownY, itemMouseUpX, itemMouseUpY);
                    }
                    else if (itemMode == PaintMode.Rectangle)
                    {
                        g.DrawRectangle(pen, itemMouseDownX, itemMouseDownY, itemMouseUpX - itemMouseDownX, itemMouseUpY - itemMouseDownY);
                    }
                    else if (itemMode == PaintMode.Pen)
                    {
                        itemPicture.SetPixel(itemMouseUpX, itemMouseUpY, itemPaintColour);
                    }
                    else if (itemMode == PaintMode.Bucket)
                    {
                        paintBucket(itemPicture, itemMouseUpX, itemMouseUpY, itemPicture.Width, itemPicture.Height, itemPaintColour);
                    }
                    else if (itemMode == PaintMode.Clear)
                    {
                        itemPicture.SetPixel(itemMouseUpX, itemMouseUpY, Color.FromArgb(0, 0, 0, 0));
                    }
                    else if (itemMode == PaintMode.Picker)
                    {
                        itemPickColour(itemPicture, itemMouseUpX, itemMouseUpY);
                    }

                    g.Dispose();

                    if (itemMode != PaintMode.None)
                    {
                        itemRedos.Add(new TextureChange(0, new Bitmap(itemPicture)));
                        itemUndoIndex = itemUndos.Count - 1;

                        string currentItemName = (string)cmbItems.Items[cmbItems.SelectedIndex];
                        List<string> textures = Items.getTextures(currentItemName);

                        string filename = textures[0];
                        itemPicture.Save(filename);

                        itemPanel.Refresh();
                    }

                    /**/
                    //Console.WriteLine("Saved restoreTexture to current texture after mouse up");

                    //restoreTexture = new Bitmap(panelPicture);
                    //restoreTexture.SetPixel(0, 0, Color.Black);

                    //panelRestoreTexture.Refresh();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Exception occured at itemPanel mouse up event: " + exception.Message + "\n" +
                    exception.StackTrace);
            }
        }

        public void paintBucket(Bitmap bitmap, int pixelX, int pixelY, int width, int height, Color paintColour)
        {
            paintBucketPicture = new Bitmap(bitmap);
            paintBucket(pixelX, pixelY, bitmap.GetPixel(pixelX, pixelY), width, height, paintColour);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    bitmap.SetPixel(x, y, paintBucketPicture.GetPixel(x, y));
                }
            }
        }

        public void pickColour(Bitmap bitmap, int pixelX, int pixelY)
        {
            Color colour = bitmap.GetPixel(pixelX, pixelY);
            paintColour = colour;
            panelColour.BackColor = paintColour;

            if (colourIndex == 0)
            {
                panelColour1.BackColor = paintColour;
            }
            else if (colourIndex == 1)
            {
                panelColour2.BackColor = paintColour;
            }
            else if (colourIndex == 2)
            {
                panelColour3.BackColor = paintColour;
            }
            else if (colourIndex == 3)
            {
                panelColour4.BackColor = paintColour;
            }
            else if (colourIndex == 4)
            {
                panelColour5.BackColor = paintColour;
            }
            else if (colourIndex == 5)
            {
                panelColour6.BackColor = paintColour;
            }
            else if (colourIndex == 6)
            {
                panelColour7.BackColor = paintColour;
            }
            else if (colourIndex == 7)
            {
                panelColour8.BackColor = paintColour;
            }
            else if (colourIndex == 8)
            {
                panelColour9.BackColor = paintColour;
            }
            else if (colourIndex == 9)
            {
                panelColour10.BackColor = paintColour;
            }
            else if (colourIndex == 10)
            {
                panelColour11.BackColor = paintColour;
            }
            else if (colourIndex == 11)
            {
                panelColour12.BackColor = paintColour;
            }
            else if (colourIndex == 12)
            {
                panelColour13.BackColor = paintColour;
            }
            else if (colourIndex == 13)
            {
                panelColour14.BackColor = paintColour;
            }
            else if (colourIndex == 14)
            {
                panelColour15.BackColor = paintColour;
            }
            else if (colourIndex == 15)
            {
                panelColour16.BackColor = paintColour;
            }
            else if (colourIndex == 16)
            {
                panelColour17.BackColor = paintColour;
            }
            else if (colourIndex == 17)
            {
                panelColour18.BackColor = paintColour;
            }
            else if (colourIndex == 18)
            {
                panelColour19.BackColor = paintColour;
            }
            else if (colourIndex == 19)
            {
                panelColour20.BackColor = paintColour;
            }
            else if (colourIndex == 20)
            {
                panelColour21.BackColor = paintColour;
            }
            else if (colourIndex == 21)
            {
                panelColour22.BackColor = paintColour;
            }
            else if (colourIndex == 22)
            {
                panelColour23.BackColor = paintColour;
            }
            else if (colourIndex == 23)
            {
                panelColour24.BackColor = paintColour;
            }
        }

        public void itemPickColour(Bitmap bitmap, int pixelX, int pixelY)
        {
            Color colour = bitmap.GetPixel(pixelX, pixelY);
            itemPaintColour = colour;
            itemPanelColour.BackColor = itemPaintColour;

            if (itemColourIndex == 0)
            {
                itemPanelColour1.BackColor = itemPaintColour;
            }
            else if (itemColourIndex == 1)
            {
                itemPanelColour2.BackColor = itemPaintColour;
            }
            else if (itemColourIndex == 2)
            {
                itemPanelColour3.BackColor = itemPaintColour;
            }
            else if (itemColourIndex == 3)
            {
                itemPanelColour4.BackColor = itemPaintColour;
            }
            else if (itemColourIndex == 4)
            {
                itemPanelColour5.BackColor = itemPaintColour;
            }
            else if (itemColourIndex == 5)
            {
                itemPanelColour6.BackColor = itemPaintColour;
            }
            else if (itemColourIndex == 6)
            {
                itemPanelColour7.BackColor = itemPaintColour;
            }
            else if (itemColourIndex == 7)
            {
                itemPanelColour8.BackColor = itemPaintColour;
            }
            else if (itemColourIndex == 8)
            {
                itemPanelColour9.BackColor = itemPaintColour;
            }
            else if (itemColourIndex == 9)
            {
                itemPanelColour10.BackColor = itemPaintColour;
            }
            else if (itemColourIndex == 10)
            {
                itemPanelColour11.BackColor = itemPaintColour;
            }
            else if (itemColourIndex == 11)
            {
                itemPanelColour12.BackColor = itemPaintColour;
            }
            else if (itemColourIndex == 12)
            {
                itemPanelColour13.BackColor = itemPaintColour;
            }
            else if (itemColourIndex == 13)
            {
                itemPanelColour14.BackColor = itemPaintColour;
            }
            else if (itemColourIndex == 14)
            {
                itemPanelColour15.BackColor = itemPaintColour;
            }
            else if (itemColourIndex == 15)
            {
                itemPanelColour16.BackColor = itemPaintColour;
            }
            else if (itemColourIndex == 16)
            {
                itemPanelColour17.BackColor = itemPaintColour;
            }
            else if (itemColourIndex == 17)
            {
                itemPanelColour18.BackColor = itemPaintColour;
            }
            else if (itemColourIndex == 18)
            {
                itemPanelColour19.BackColor = itemPaintColour;
            }
            else if (itemColourIndex == 19)
            {
                itemPanelColour20.BackColor = itemPaintColour;
            }
            else if (itemColourIndex == 20)
            {
                itemPanelColour21.BackColor = itemPaintColour;
            }
            else if (itemColourIndex == 21)
            {
                itemPanelColour22.BackColor = itemPaintColour;
            }
            else if (itemColourIndex == 22)
            {
                itemPanelColour23.BackColor = itemPaintColour;
            }
            else if (itemColourIndex == 23)
            {
                itemPanelColour24.BackColor = itemPaintColour;
            }
        }

        public void saveTexture(Bitmap bitmap, int panelIndex)
        {
            string blockName = (string)cmbBlocks.Items[cmbBlocks.SelectedIndex];
            if (blockName == "Fire")
            {
                int index = 0;
                Bitmap fireLayerPicture = null;

                if (panelIndex == 0)
                {
                    index = cmbFrames1.SelectedIndex;
                    fireLayerPicture = fireLayer1;
                }
                else if (panelIndex == 1)
                {
                    index = cmbFrames2.SelectedIndex;
                    fireLayerPicture = fireLayer2;
                }

                for (int y = 0; y < 16; y++)
                {
                    for (int x = 0; x < 16; x++)
                    {
                        fireLayerPicture.SetPixel(x, y + index * 16, bitmap.GetPixel(x, y));
                    }
                }

                fireLayerPicture.Save(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\fire_layer_0.png");
            }
            else if (blockName == "Water Still" || blockName == "Water Flowing" ||
                    blockName == "Lava Still" || blockName == "Lava Flowing" ||
                    blockName == "Portal")
            {
                int index = 0;
                if (panelIndex == 0)
                {
                    index = cmbFrames1.SelectedIndex;
                }
                else if (panelIndex == 1)
                {
                    index = cmbFrames2.SelectedIndex;
                }

                for (int y = 0; y < 16; y++)
                {
                    for (int x = 0; x < 16; x++)
                    {
                        textureStrip.SetPixel(x, y + index * 16, bitmap.GetPixel(x, y));
                    }
                }

                string picturePath = "";
                if (blockName == "Water Still")
                {
                    picturePath = FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\water_still.png";
                }
                else if (blockName == "Water Flowing")
                {
                    picturePath = FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\water_flow.png";
                }
                else if (blockName == "Lava Still")
                {
                    picturePath = FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\lava_still.png";
                }
                else if (blockName == "Lava Flowing")
                {
                    picturePath = FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\lava_flow.png";
                }
                else if (blockName == "Portal")
                {
                    picturePath = FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\portal.png";
                }

                textureStrip.Save(picturePath);
            }
            else if (blockName == "Destroy")
            {
                int index = 0;
                if (panelIndex == 0)
                {
                    index = cmbFrames1.SelectedIndex;
                }
                else if (panelIndex == 1)
                {
                    index = cmbFrames2.SelectedIndex;
                }

                string picturePath = FrmMain.directory +
                    "\\assets\\minecraft\\textures\\blocks\\destroy_stage_" + index + ".png";

                bitmap.Save(picturePath);
            }
            else
            {
                try
                {
                    string currentBlockName = (string)cmbBlocks.Items[cmbBlocks.SelectedIndex];
                    List<string> textures = Blocks.getTextures(currentBlockName);

                    string filename = textures[panelIndex];
                    bitmap.Save(filename);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
        }

        public void paintBucket(int x, int y, Color colour, int width, int height, Color paintColour)
        {
            Color currentColour = paintBucketPicture.GetPixel(x, y);
            if (currentColour.R == paintColour.R &&
                currentColour.G == paintColour.G &&
                currentColour.B == paintColour.B)
            {
                return;
            }

            paintBucketPicture.SetPixel(x, y, paintColour);

            if (y - 1 >= 0)
            {
                Color northColour = paintBucketPicture.GetPixel(x, y - 1);

                if (northColour.R == colour.R &&
                    northColour.G == colour.G &&
                    northColour.B == colour.B)
                {
                    paintBucket(x, y - 1, colour, width, height, paintColour);
                }
            }

            if (y + 1 < height)
            {
                Color southColour = paintBucketPicture.GetPixel(x, y + 1);

                if (southColour.R == colour.R &&
                    southColour.G == colour.G &&
                    southColour.B == colour.B)
                {
                    paintBucket(x, y + 1, colour, width, height, paintColour);
                }
            }

            if (x - 1 >= 0)
            {
                Color westColour = paintBucketPicture.GetPixel(x - 1, y);

                if (westColour.R == colour.R &&
                    westColour.G == colour.G &&
                    westColour.B == colour.B)
                {
                    paintBucket(x - 1, y, colour, width, height, paintColour);
                }
            }

            if (x + 1 < width)
            {
                Color eastColour = paintBucketPicture.GetPixel(x + 1, y);

                if (eastColour.R == colour.R &&
                    eastColour.G == colour.G &&
                    eastColour.B == colour.B)
                {
                    paintBucket(x + 1, y, colour, width, height, paintColour);
                }
            }
        }

        public int getPanel(object sender)
        {
            int index = -1;

            if (sender == panel1)
            {
                index = 0;
            }
            else if (sender == panel2)
            {
                index = 1;
            }
            else if (sender == panel3)
            {
                index = 2;
            }
            else if (sender == panel4)
            {
                index = 3;
            }
            else if (sender == panel5)
            {
                index = 4;
            }
            else if (sender == panel6)
            {
                index = 5;
            }
            else if (sender == panel7)
            {
                index = 6;
            }
            else if (sender == panel8)
            {
                index = 7;
            }
            else if (sender == panel9)
            {
                index = 8;
            }

            return index;
        }

        public Panel getPanel(int index)
        {
            if (index == 0)
            {
                return panel1;
            }
            else if (index == 1)
            {
                return panel2;
            }
            else if (index == 2)
            {
                return panel3;
            }
            else if (index == 3)
            {
                return panel4;
            }
            else if (index == 4)
            {
                return panel5;
            }
            else if (index == 5)
            {
                return panel6;
            }
            else if (index == 6)
            {
                return panel7;
            }
            else if (index == 7)
            {
                return panel8;
            }
            else if (index == 8)
            {
                return panel9;
            }
            else
            {
                return null;
            }
        }

        public Bitmap getTexture(object sender)
        {
            if (sender == panel1)
            {
                return texture1;
            }
            else if (sender == panel2)
            {
                return texture2;
            }
            else if (sender == panel3)
            {
                return texture3;
            }
            else if (sender == panel4)
            {
                return texture4;
            }
            else if (sender == panel5)
            {
                return texture5;
            }
            else if (sender == panel6)
            {
                return texture6;
            }
            else if (sender == panel7)
            {
                return texture7;
            }
            else if (sender == panel8)
            {
                return texture8;
            }
            else if (sender == panel9)
            {
                return texture9;
            }
            else
            {
                return null;
            }
        }

        public Bitmap getTexture(int index)
        {
            if (index == 0)
            {
                return texture1;
            }
            else if (index == 1)
            {
                return texture2;
            }
            else if (index == 2)
            {
                return texture3;
            }
            else if (index == 3)
            {
                return texture4;
            }
            else if (index == 4)
            {
                return texture5;
            }
            else if (index == 5)
            {
                return texture6;
            }
            else if (index == 6)
            {
                return texture7;
            }
            else if (index == 7)
            {
                return texture8;
            }
            else if (index == 8)
            {
                return texture9;
            }
            else
            {
                return null;
            }
        }

        void cmbFrames1_SelectedIndexChanged(object sender, EventArgs e)
        {
            layer1frameIndex = cmbFrames1.SelectedIndex;
            texture1 = new Bitmap(16, 16);

            string blockName = (string)cmbBlocks.Items[cmbBlocks.SelectedIndex];

            if (blockName == "Fire")
            {
                for (int y = 0; y < 16; y++)
                {
                    for (int x = 0; x < 16; x++)
                    {
                        texture1.SetPixel(x, y, fireLayer1.GetPixel(x, y + layer1frameIndex * 16));
                    }
                }
            }
            else if (blockName == "Water Still" || blockName == "Water Flowing" ||
                    blockName == "Lava Still" || blockName == "Lava Flowing" ||
                    blockName == "Portal")
            {
                for (int y = 0; y < 16; y++)
                {
                    for (int x = 0; x < 16; x++)
                    {
                        texture1.SetPixel(x, y, textureStrip.GetPixel(x, y + layer1frameIndex * 16));
                    }
                }
            }
            else if (blockName == "Destroy")
            {
                Bitmap loadPicture = new Bitmap(FrmMain.directory +
                    "\\assets\\minecraft\\textures\\blocks\\destroy_stage_" + layer1frameIndex + ".png");

                texture1 = new Bitmap(loadPicture);
                loadPicture.Dispose();
            }

            panel1.Refresh();
        }

        void cmbFrames2_SelectedIndexChanged(object sender, EventArgs e)
        {
            layer2frameIndex = cmbFrames2.SelectedIndex;
            texture2 = new Bitmap(16, 16);

            for (int y = 0; y < 16; y++)
            {
                for (int x = 0; x < 16; x++)
                {
                    texture2.SetPixel(x, y, fireLayer2.GetPixel(x, y + layer2frameIndex * 16));
                }
            }

            panel2.Refresh();
        }

        void panel_DragDrop(object sender, DragEventArgs e)
        {
            string[] paths = (string[])e.Data.GetData(DataFormats.FileDrop);

            string blockName = (string)cmbBlocks.Items[cmbBlocks.SelectedIndex];
            List<string> textures = Blocks.getTextures(blockName);

            if (paths.Length != 1)
            {
                MessageBox.Show("Only drop in one image", "Minecraft Texture Studio");
                return;
            }

            Bitmap currentTexture = getTexture(sender);
            int panelIndex = getPanel(sender);

            try
            {
                Bitmap loadPicture = new Bitmap(paths[0]);
                Bitmap bitmap = new Bitmap(loadPicture);
                loadPicture.Dispose();

                if (blockName == "Fire")
                {
                    int currentWidth = bitmap.Width;

                    //using width for both to make sure it's square
                    if (currentWidth != fireLayer1.Width ||
                        currentWidth != fireLayer2.Width)
                    {
                        fireLayer1 = new Bitmap(currentWidth, currentWidth * 32);
                        fireLayer2 = new Bitmap(currentWidth, currentWidth * 32);
                    }

                    int index = 0;
                    Bitmap fireLayerPicture = null;

                    if (panelIndex == 0)
                    {
                        index = cmbFrames1.SelectedIndex;
                        fireLayerPicture = fireLayer1;
                    }
                    else if (panelIndex == 1)
                    {
                        index = cmbFrames2.SelectedIndex;
                        fireLayerPicture = fireLayer2;
                    }

                    int width = fireLayerPicture.Width;

                    //use width as both to make it square
                    for (int y = 0; y < width; y++)
                    {
                        for (int x = 0; x < width; x++)
                        {
                            if (x <= currentTexture.Width &&
                                y + index * width <= currentTexture.Height)
                            {
                                fireLayerPicture.SetPixel(x, y + index * width, currentTexture.GetPixel(x, y));
                            }
                        }
                    }

                    fireLayerPicture.Save(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\fire_layer_" + index + ".png");
                }
                else if (blockName == "Water Still" || blockName == "Water Flowing" ||
                    blockName == "Lava Still" || blockName == "Lava Flowing" ||
                    blockName == "Portal")
                {
                    int checkWidth = bitmap.Width;
                    if (blockName == "Water Flowing")
                    {
                        checkWidth = checkWidth * 2;
                    }

                    //using width for both to make sure it's square
                    if (checkWidth != textureStrip.Width)
                    {
                        int frameCount = 0;
                        if (blockName == "Water Still")
                        {
                            frameCount = 32;
                        }
                        else if (blockName == "Water Flowing")
                        {
                            frameCount = 64;
                        }
                        else if (blockName == "Lava Still")
                        {
                            frameCount = 20;
                        }
                        else if (blockName == "Lava Flowing")
                        {
                            frameCount = 32;
                        }
                        else if (blockName == "Portal")
                        {
                            frameCount = 32;
                        }

                        textureStrip = new Bitmap(checkWidth, checkWidth * frameCount);
                    }

                    int index = cmbFrames1.SelectedIndex;
                    int currentWidth = bitmap.Width;

                    for (int y = 0; y < currentWidth; y++)
                    {
                        for (int x = 0; x < currentWidth; x++)
                        {
                            if (x <= textureStrip.Width &&
                                y + index * currentWidth <= textureStrip.Height)
                            {
                                textureStrip.SetPixel(x, y + index * currentWidth, bitmap.GetPixel(x, y));
                                currentTexture.SetPixel(x, y, bitmap.GetPixel(x, y));
                            }
                        }
                    }

                    string picturePath = "";
                    if (blockName == "Water Still")
                    {
                        picturePath = FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\water_still.png";
                    }
                    else if (blockName == "Water Flowing")
                    {
                        picturePath = FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\water_flow.png";
                    }
                    else if (blockName == "Lava Still")
                    {
                        picturePath = FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\lava_still.png";
                    }
                    else if (blockName == "Lava Flowing")
                    {
                        picturePath = FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\lava_flow.png";
                    }
                    else if (blockName == "Portal")
                    {
                        picturePath = FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\portal.png";
                    }

                    textureStrip.Save(picturePath);
                }
                else if (blockName == "Destroy")
                {
                    int index = cmbFrames1.SelectedIndex;
                    int width = bitmap.Width;

                    string picturePath = FrmMain.directory +
                        "\\assets\\minecraft\\textures\\blocks\\destroy_stage_" + index + ".png";

                    //using width and height for both to make sure it's square
                    lock (currentTexture)
                    {
                        for (int y = 0; y < width; y++)
                        {
                            for (int x = 0; x < width; x++)
                            {
                                if (x <= bitmap.Width &&
                                    y <= bitmap.Height)
                                {
                                    Color colour = bitmap.GetPixel(x, y);
                                    currentTexture.SetPixel(x, y, colour);
                                }
                            }
                        }

                        currentTexture.Save(picturePath);
                    }
                }
                else
                {
                    int width = currentTexture.Width;

                    //using width and height for both to make it square
                    lock (currentTexture)
                    {
                        for (int y = 0; y < width; y++)
                        {
                            for (int x = 0; x < width; x++)
                            {
                                if (x <= currentTexture.Width &&
                                    y <= currentTexture.Height)
                                {
                                    Color colour = bitmap.GetPixel(x, y);
                                    currentTexture.SetPixel(x, y, colour);
                                }
                            }
                        }
                    }

                    if (textures.Count > 0)
                    {
                        string filename = textures[panelIndex];

                        lock (currentTexture)
                        {
                            currentTexture.Save(filename);
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid picture or not supported by .net", "Minecraft Texture Studio");
                return;
            }

            panel1.Refresh();
            panel2.Refresh();
            panel3.Refresh();
            panel4.Refresh();
            panel5.Refresh();
            panel6.Refresh();
            panel7.Refresh();
            panel8.Refresh();
            panel9.Refresh();

            FrmTexturePreview.boolUpdateTextures = true;
            Blocks.getTextures(FrmTexturePreview.blockName);
        }

        void itemPanel_DragDrop(object sender, DragEventArgs e)
        {
            string[] paths = (string[])e.Data.GetData(DataFormats.FileDrop);

            string itemName = (string)cmbItems.Items[cmbItems.SelectedIndex];
            List<string> textures = Items.getTextures(itemName);

            if (paths.Length != 1)
            {
                MessageBox.Show("Only drop in one image", "Minecraft Texture Studio");
                return;
            }

            Bitmap newItemPicture = null;

            try
            {
                Bitmap bitmap = new Bitmap(paths[0]);
                newItemPicture = new Bitmap(bitmap);
                bitmap.Dispose();
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid picture or not supported by .net", "Minecraft Texture Studio");
                return;
            }

            if (itemName == "Clock" || itemName == "Compass")
            {
                int index = cmbItemFrames.SelectedIndex;
                int width = newItemPicture.Width;

                //use width for both to make sure its square
                for (int y = 0; y < width; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        Color colour = newItemPicture.GetPixel(x, y);

                        if (x <= itemTextureStrip.Width &&
                            y + index * width <= itemTextureStrip.Height)
                        {
                            itemTextureStrip.SetPixel(x, y + index * width, colour);
                        }

                        itemPicture.SetPixel(x, y, colour);
                    }
                }

                if (textures.Count > 0)
                {
                    string picturePath = textures[0];
                    itemTextureStrip.Save(picturePath);
                }
            }

            if (itemName != "Clock" && itemName != "Compass" && textures.Count > 0)
            {
                string filename = textures[0];
                itemPicture.Save(filename);
            }

            itemPanel.Refresh();
        }

        void panel_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        void itemPanel_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void checkAllChildNodes(TreeNode treeNode, bool nodeChecked)
        {
            foreach (TreeNode node in treeNode.Nodes)
            {
                node.Checked = nodeChecked;
                if (node.Nodes.Count > 0)
                {
                    this.checkAllChildNodes(node, nodeChecked);
                }
            }
        }

        void treeView_AfterCheck(object sender, TreeViewEventArgs e)
        {
            //only respond to user action
            if (e.Action != TreeViewAction.Unknown)
            {
                if (e.Node.Nodes.Count > 0)
                {
                    this.checkAllChildNodes(e.Node, e.Node.Checked);
                }
            }
        }

        private void CheckForCheckedChildrenHandler(object sender,
            TreeViewCancelEventArgs e)
        {
            if (!HasCheckedChildNodes(e.Node)) e.Cancel = true;
        }

        private bool HasCheckedChildNodes(TreeNode node)
        {
            if (node.Nodes.Count == 0) return false;
            foreach (TreeNode childNode in node.Nodes)
            {
                if (childNode.Checked) return true;
                // Recursively check the children of the current child node. 
                if (HasCheckedChildNodes(childNode)) return true;
            }
            return false;
        }

        void picture_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        void picture_DragDrop(object sender, DragEventArgs e)
        {
            string[] paths = (string[])e.Data.GetData(DataFormats.FileDrop);

            if (paths.Length != 1)
            {
                MessageBox.Show("Only drop in one image", "Minecraft Texture Studio");
                return;
            }

            string imagePath = paths[0];
            loadThumbnail(imagePath);
        }

        void font_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        void font_DragDrop(object sender, DragEventArgs e)
        {
            string[] paths = (string[])e.Data.GetData(DataFormats.FileDrop);

            if (paths.Length != 1)
            {
                MessageBox.Show("Only drop in one image", "Minecraft Texture Studio");
                return;
            }

            string fontPath = paths[0];
            Bitmap bitmap = null;

            try
            {
                bitmap = new Bitmap(fontPath);

                if (bitmap.Width != 128 || bitmap.Height != 128)
                {
                    MessageBox.Show("Font must be 128 x 128", "Minecraft Texture Studio");
                    return;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Invalid picture, " + exception.Message, "Error");
                return;
            }
            finally
            {
                if (bitmap != null)
                {
                    bitmap.Dispose();
                }
            }

            if (!Directory.Exists(FrmMain.directory + "\\assets\\minecraft\\textures\\font"))
            {
                Directory.CreateDirectory(FrmMain.directory + "\\assets\\minecraft\\textures\\font");
            }

            File.Copy(fontPath, FrmMain.directory + "\\assets\\minecraft\\textures\\font\\ascii.png", true);
            loadFont(fontPath);
        }

        void loadFont(string fontPath)
        {
            Bitmap bitmap = null;

            try
            {
                bitmap = new Bitmap(fontPath);
                panelFont.BackgroundImage = new Bitmap(bitmap);
                lblFontDropImage.Visible = false;
            }
            catch (Exception exception)
            {
                MessageBox.Show("Invalid picture, " + exception.Message, "Error");
            }
            finally
            {
                if (bitmap != null)
                {
                    bitmap.Dispose();
                }
            }
        }

        void loadThumbnail(string imagePath)
        {
            bool error = false;

            try
            {
                Bitmap bitmap = new Bitmap(imagePath);

                if (bitmap.Width != 128 || bitmap.Height != 128)
                {
                    MessageBox.Show("Picture must be 128 x 128", "Minecraft Texture Studio");
                    error = true;
                }
            }
            catch (ArgumentException)
            {
                MessageBox.Show("File is not a bitmap, or not supported by .net", "Minecraft Texture Studio");
                error = true;
            }
            catch (Exception exception)
            {
                MessageBox.Show("Exception occured loading image: " + exception.Message, "Error");
            }

            if (!error)
            {
                Bitmap loadPicture = null;
                try
                {
                    Bitmap bitmap = new Bitmap(imagePath);
                    bitmap.Save(directory + "\\pack.png");
                    bitmap.Dispose();

                    loadPicture = new Bitmap(directory + "\\pack.png");
                    panelThumbnail.BackgroundImage = new Bitmap(loadPicture);

                    lblDropImage.Visible = false;
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Exception occured copying picture to resource pack: " + exception.Message, "Error");
                }
                finally
                {
                    if (loadPicture != null)
                    {
                        loadPicture.Dispose();
                    }
                }
            }
        }

        void txtMinecraftPath_TextChanged(object sender, EventArgs e)
        {
            changeMinecraftPath(txtMinecraftPath.Text);
        }

        void txtMinecraftJarPath_TextChanged(object sender, EventArgs e)
        {
            changeMinecraftJarPath(txtMinecraftJarPath.Text);
        }

        void txtExtractedJarPath_TextChanged(object sender, EventArgs e)
        {
            changeExtractedJarPath(txtExtractedJarPath.Text);
        }

        void enableControls()
        {
            txtResourcePackName.Enabled = true;
            txtMarkup.Enabled = true;
            cmbBlocks.Enabled = true;
            cmbItems.Enabled = true;

            panelThumbnail.Enabled = true;
            lblDropImage.Enabled = true;
            panelFont.Enabled = true;
            lblFontDropImage.Enabled = true;
            btnImageBrowse.Enabled = true;
            btnSaveChanges.Enabled = true;
            btnAddColour.Enabled = true;
            btnBrowseFont.Enabled = true;
            cmbTextColour.Enabled = true;
            treeView.Enabled = true;

            //pack details tab
            btnBold.Enabled = true;
            btnItalic.Enabled = true;
            btnUnderline.Enabled = true;
            btnStrikethrough.Enabled = true;
            btnRemoveFormatting.Enabled = true;

            //sounds tab
            btnAddSounds.Enabled = true;
            btnBrowseSound.Enabled = true;
        }

        void txtResourcePackName_TextChanged(object sender, EventArgs e)
        {
            lblTexturePack.Text = "Resource Pack: " + txtResourcePackName.Text;
            texturePackName = txtResourcePackName.Text;
            updateTextMarkup();
            saveResourcePackName();
        }

        void saveResourcePackName()
        {
            StreamWriter writer = null;
            try
            {
                writer = new StreamWriter(new FileStream(directory + "\\pack.mcmeta", FileMode.Create, FileAccess.Write));
                writer.WriteLine("{");
                writer.WriteLine("  \"pack\": {");
                writer.WriteLine("    \"pack_format\": 3,");
                writer.WriteLine("    \"description\": \"" + txtMarkup.Text + "\"");
                writer.WriteLine("  }");
                writer.WriteLine("}");
            }
            catch (Exception exception)
            {
                MessageBox.Show("Exception occured creating pack.mcmeta: " + exception.Message, "Error");
            }
            finally
            {
                if (writer != null)
                {
                    writer.Dispose();
                }
            }
        }

        void refreshPanels()
        {
            panel1.Refresh();
            panel2.Refresh();
            panel3.Refresh();
            panel4.Refresh();
            panel5.Refresh();
            panel6.Refresh();
            panel7.Refresh();
            panel8.Refresh();
            panel9.Refresh();
        }

        void panel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            Bitmap currentTexture = getTexture(sender);
            if (currentTexture != null)
            {
                lock (currentTexture)
                {
                    for (int y = 0; y < currentTexture.Height; y++)
                    {
                        for (int x = 0; x < currentTexture.Width; x++)
                        {
                            Color colour = currentTexture.GetPixel(x, y);
                            Brush brush = new SolidBrush(colour);

                            g.FillRectangle(brush, new Rectangle((int)(x * pixelSize), (int)(y * pixelSize),
                                (int)pixelSize, (int)pixelSize));

                            /*if ((mode == PaintMode.Line || mode == PaintMode.Rectangle) && isMouseDown)
                            {
                                Color drawToolColour = drawToolPicture.GetPixel(x, y);
                                Brush drawBrush = new SolidBrush(drawToolColour);

                                if (drawToolColour.R == paintColour.R &&
                                    drawToolColour.G == paintColour.G &&
                                    drawToolColour.B == paintColour.B)
                                {
                                    g.FillRectangle(drawBrush, new Rectangle((int)(x * pixelSize), (int)(y * pixelSize),
                                        (int)pixelSize, (int)pixelSize));
                                }
                            }*/
                        }
                    }
                }
            }
        }

        void cmbBlocks_SelectedIndexChanged(object sender, EventArgs e)
        {
            string blockName = (string)cmbBlocks.Items[cmbBlocks.SelectedIndex];
            List<string> textures = Blocks.getTextures(blockName);
            pixelSize = 10;

            if (texturePackLoaded)
            {
                undos = new List<TextureChange>();
                redos = new List<TextureChange>();
                undoIndex = 0;

                layer1frameIndex = 0;
                layer2frameIndex = 0;

                cmbFrames1.Items.Clear();
                cmbFrames2.Items.Clear();

                cmbFrames1.Visible = false;
                cmbFrames2.Visible = false;

                ModelType modelType = FrmTexturePreview.getModelType(blockName);
                List<Cube> cubes = TexturePaint3D.getCubePositions(modelType);

                lblTexture3D.Visible = false;
                if (cubes.Count == 0)
                {
                    lblTexture3D.Visible = true;
                }

                if (blocks.Contains(blockName))
                {
                    int blockIndex = (int)blocks[blockName];
                    FrmTexturePreview.changeBlockName = blockName;
                    FrmTexturePreview.loadNewTextures = true;
                }

                panelConfig = PanelConfiguration.T1x1;

                if (blockName == "Skeleton Skull")
                {
                    panelConfig = PanelConfiguration.T4x2;
                }
                else if (blockName == "Wither Skeleton Skull")
                {
                    panelConfig = PanelConfiguration.T4x2;
                }
                else if (blockName == "Zombie Head")
                {
                    panelConfig = PanelConfiguration.T4x4;
                }
                else if (blockName == "Head")
                {
                    panelConfig = PanelConfiguration.T4x2;
                }
                else if (blockName == "Creeper Head")
                {
                    panelConfig = PanelConfiguration.T4x2;
                }
                else if (blockName == "Standing Sign")
                {
                    panelConfig = PanelConfiguration.T4x2;
                }
                else if (blockName == "Wall Sign")
                {
                    panelConfig = PanelConfiguration.T4x2;
                }
                else if (blockName == "Chest")
                {
                    panelConfig = PanelConfiguration.T4x4;
                }
                else if (blockName == "Double Chest")
                {
                    panelConfig = PanelConfiguration.T8x4;
                }
                else if (blockName == "Trapped Chest")
                {
                    panelConfig = PanelConfiguration.T4x4;
                }
                else if (blockName == "Double Trapped Chest")
                {
                    panelConfig = PanelConfiguration.T8x4;
                }

                resetPanels();
                setPanelsLocation();

                if (panelConfig == PanelConfiguration.T1x1)
                {
                    panel1.Size = new Size(160, 160);
                }
                else if (panelConfig == PanelConfiguration.T4x2)
                {
                    panel1.Size = new Size(640, 320);
                }
                else if (panelConfig == PanelConfiguration.T4x4)
                {
                    panel1.Size = new Size(640, 640);
                }
                else if (panelConfig == PanelConfiguration.T8x4)
                {
                    panel1.Size = new Size(1280, 640);
                }

                Blocks.getTextures(blockName);

                if (blockName == "Fire")
                {
                    for (int a = 1; a <= 32; a++)
                    {
                        cmbFrames1.Items.Add("Frame " + a);
                        cmbFrames2.Items.Add("Frame " + a);
                    }

                    panel1.Visible = true;
                    panel2.Visible = true;

                    loadPanel(0);
                    loadPanel(1);

                    lblFilename1.Text = "Layer 1";
                    lblFilename2.Text = "Layer 2";
                    lblFilename1.Location = new Point(panel1.Location.X, panel1.Location.Y - 27);
                    lblFilename2.Location = new Point(panel2.Location.X, panel2.Location.Y - 27);
                    lblFilename1.Visible = true;
                    lblFilename2.Visible = true;

                    cmbFrames1.Visible = true;
                    cmbFrames2.Visible = true;

                    Bitmap loadLayer1 = new Bitmap(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\fire_layer_0.png");
                    Bitmap loadLayer2 = new Bitmap(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\fire_layer_1.png");

                    FrmMain.fireLayer1 = new Bitmap(loadLayer1);
                    FrmMain.fireLayer2 = new Bitmap(loadLayer2);

                    loadLayer1.Dispose();
                    loadLayer2.Dispose();

                    lock (texture1)
                    {
                        lock (texture2)
                        {
                            texture1 = new Bitmap(16, 16);
                            texture2 = new Bitmap(16, 16);

                            for (int y = 0; y < 16; y++)
                            {
                                for (int x = 0; x < 16; x++)
                                {
                                    texture1.SetPixel(x, y, fireLayer1.GetPixel(x, y));
                                    texture2.SetPixel(x, y, fireLayer2.GetPixel(x, y));
                                }
                            }

                            cmbFrames1.SelectedIndex = 0;
                            cmbFrames2.SelectedIndex = 0;
                        }
                    }
                }
                else if (blockName == "Water Still" || blockName == "Water Flowing" ||
                    blockName == "Lava Still" || blockName == "Lava Flowing" ||
                    blockName == "Portal")
                {
                    int frameCount = 32;

                    if (blockName == "Water Flowing")
                    {
                        frameCount = 64;
                    }
                    else if (blockName == "Lava Still")
                    {
                        frameCount = 20;
                    }

                    for (int a = 1; a <= frameCount; a++)
                    {
                        cmbFrames1.Items.Add("Frame " + a);
                    }

                    panel1.Visible = true;
                    loadPanel(0);

                    lblFilename1.Text = "Textures";
                    lblFilename1.Location = new Point(panel1.Location.X, panel1.Location.Y - 27);
                    lblFilename1.Visible = true;
                    cmbFrames1.Visible = true;

                    string picturePath = "";
                    if (blockName == "Water Still")
                    {
                        picturePath = FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\water_still.png";
                    }
                    else if (blockName == "Water Flowing")
                    {
                        picturePath = FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\water_flow.png";
                    }
                    else if (blockName == "Lava Still")
                    {
                        picturePath = FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\lava_still.png";
                    }
                    else if (blockName == "Lava Flowing")
                    {
                        picturePath = FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\lava_flow.png";
                    }
                    else if (blockName == "Portal")
                    {
                        picturePath = FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\portal.png";
                    }

                    Bitmap loadTextureStrip = new Bitmap(picturePath);
                    FrmMain.textureStrip = new Bitmap(loadTextureStrip);
                    loadTextureStrip.Dispose();

                    lock (texture1)
                    {
                        texture1 = new Bitmap(16, 16);

                        for (int y = 0; y < 16; y++)
                        {
                            for (int x = 0; x < 16; x++)
                            {
                                texture1.SetPixel(x, y, textureStrip.GetPixel(x, y));
                            }
                        }
                    }

                    cmbFrames1.SelectedIndex = 0;
                }
                else if (blockName == "Destroy")
                {
                    for (int a = 1; a <= 10; a++)
                    {
                        cmbFrames1.Items.Add("Frame " + a);
                    }

                    panel1.Visible = true;
                    loadPanel(0);

                    lblFilename1.Text = "Textures";
                    lblFilename1.Location = new Point(panel1.Location.X, panel1.Location.Y - 27);
                    lblFilename1.Visible = true;
                    cmbFrames1.Visible = true;
                    cmbFrames1.SelectedIndex = 0;
                }
                else
                {
                    for (int a = 0; a < 9; a++)
                    {
                        if (textures.Count > a)
                        {
                            loadPanel(a);
                        }
                    }
                }

                restoreTexture = new Bitmap(texture1);
                refreshPanels();
            }
        }

        void loadPanel(int index)
        {
            Label label = getLabel(index);
            label.Visible = true;

            Panel panel = getPanel(index);
            panel.Visible = true;

            string blockName = (string)cmbBlocks.Items[cmbBlocks.SelectedIndex];
            List<string> textures = Blocks.getTextures(blockName);

            if (index == 0)
            {
                cmbFrames1.Location = new Point(panel.Location.X + 70, panel.Location.Y - 30);
            }
            else if (index == 1)
            {
                cmbFrames2.Location = new Point(panel.Location.X + 70, panel.Location.Y - 30);
            }

            if (index == 0)
            {
                texture1Filename = textures[index];
            }
            else if (index == 1)
            {
                texture2Filename = textures[index];
            }
            else if (index == 2)
            {
                texture3Filename = textures[index];
            }
            else if (index == 3)
            {
                texture4Filename = textures[index];
            }
            else if (index == 4)
            {
                texture5Filename = textures[index];
            }
            else if (index == 5)
            {
                texture6Filename = textures[index];
            }
            else if (index == 6)
            {
                texture7Filename = textures[index];
            }
            else if (index == 7)
            {
                texture8Filename = textures[index];
            }
            else if (index == 8)
            {
                texture9Filename = textures[index];
            }

            Bitmap loadPicture = new Bitmap(textures[index]);

            try
            {
                if (index == 0)
                {
                    if (texture1 == null)
                    {
                        texture1 = new Bitmap(loadPicture);
                    }
                    else
                    {
                        lock (texture1)
                        {
                            texture1 = new Bitmap(loadPicture);
                        }
                    }

                    lock (texture1)
                    {
                        textureWidth = texture1.Width;
                        textureHeight = texture1.Height;
                    }

                    if (texture1.Width == 32 && texture1.Height == 32)
                    {
                        pixelSize = 5;
                    }
                    else if (texture1.Width == 64 && texture1.Height == 64)
                    {
                        pixelSize = 2;
                    }
                    else if (texture1.Width == 128 && texture1.Height == 128)
                    {
                        pixelSize = 1;
                    }
                    else if (texture1.Width == 256 && texture1.Height == 256)
                    {
                        pixelSize = 1;
                    }

                    if (panelConfig == PanelConfiguration.T4x2)
                    {
                        if (texture1.Width == 64 && texture1.Width == 32)
                        {
                            pixelSize = 10;
                        }
                        else if (texture1.Width == 128 && texture1.Width == 64)
                        {
                            pixelSize = 5;
                        }
                        else if (texture1.Width == 256 && texture1.Width == 128)
                        {
                            pixelSize = 2;
                        }
                        else if (texture1.Width == 512 && texture1.Width == 256)
                        {
                            pixelSize = 1;
                        }
                        else if (texture1.Width == 1024 && texture1.Width == 512)
                        {
                            pixelSize = 1;
                        }
                    }
                    else if (panelConfig == PanelConfiguration.T4x4)
                    {
                        if (texture1.Width == 64 && texture1.Width == 64)
                        {
                            pixelSize = 10;
                        }
                        else if (texture1.Width == 128 && texture1.Width == 128)
                        {
                            pixelSize = 5;
                        }
                        else if (texture1.Width == 256 && texture1.Width == 256)
                        {
                            pixelSize = 2;
                        }
                        else if (texture1.Width == 512 && texture1.Width == 512)
                        {
                            pixelSize = 1;
                        }
                        else if (texture1.Width == 1024 && texture1.Width == 1024)
                        {
                            pixelSize = 1;
                        }
                    }
                    else if (panelConfig == PanelConfiguration.T8x4)
                    {
                        if (texture1.Width == 128 && texture1.Height == 64)
                        {
                            pixelSize = 10;
                        }
                        else if (texture1.Width == 256 && texture1.Height == 128)
                        {
                            pixelSize = 5;
                        }
                        else if (texture1.Width == 512 && texture1.Height == 256)
                        {
                            pixelSize = 2;
                        }
                        else if (texture1.Width == 1024 && texture1.Height == 512)
                        {
                            pixelSize = 1;
                        }
                        else if (texture1.Width == 2048 && texture1.Height == 1024)
                        {
                            pixelSize = 1;
                        }
                    }
                }
                else if (index == 1)
                {
                    if (texture2 == null)
                    {
                        texture2 = new Bitmap(loadPicture);
                    }
                    else
                    {
                        lock (texture2)
                        {
                            texture2 = new Bitmap(loadPicture);
                        }
                    }
                }
                else if (index == 2)
                {
                    if (texture3 == null)
                    {
                        texture3 = new Bitmap(loadPicture);
                    }
                    else
                    {
                        lock (texture3)
                        {
                            texture3 = new Bitmap(loadPicture);
                        }
                    }
                }
                else if (index == 3)
                {
                    if (texture4 == null)
                    {
                        texture4 = new Bitmap(loadPicture);
                    }
                    else
                    {
                        lock (texture4)
                        {
                            texture4 = new Bitmap(loadPicture);
                        }
                    }
                }
                else if (index == 4)
                {
                    if (texture5 == null)
                    {
                        texture5 = new Bitmap(loadPicture);
                    }
                    else
                    {
                        lock (texture5)
                        {
                            texture5 = new Bitmap(loadPicture);
                        }
                    }
                }
                else if (index == 5)
                {
                    if (texture6 == null)
                    {
                        texture6 = new Bitmap(loadPicture);
                    }
                    else
                    {
                        lock (texture6)
                        {
                            texture6 = new Bitmap(loadPicture);
                        }
                    }
                }
                else if (index == 6)
                {
                    if (texture7 == null)
                    {
                        texture7 = new Bitmap(loadPicture);
                    }
                    else
                    {
                        lock (texture7)
                        {
                            texture7 = new Bitmap(loadPicture);
                        }
                    }
                }
                else if (index == 7)
                {
                    if (texture8 == null)
                    {
                        texture8 = new Bitmap(loadPicture);
                    }
                    else
                    {
                        lock (texture8)
                        {
                            texture8 = new Bitmap(loadPicture);
                        }
                    }
                }
                else if (index == 8)
                {
                    if (texture9 == null)
                    {
                        texture9 = new Bitmap(loadPicture);
                    }
                    else
                    {
                        lock (texture9)
                        {
                            texture9 = new Bitmap(loadPicture);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

            loadPicture.Dispose();

            string filenameDisplay = getTextureFilename(index);
            filenameDisplay = filenameDisplay.Substring(filenameDisplay.LastIndexOf("\\") + 1,
                filenameDisplay.Length - filenameDisplay.LastIndexOf("\\") - 1);

            label.Text = filenameDisplay;
        }

        Label getLabel(int index)
        {
            if (index == 0)
            {
                return lblFilename1;
            }
            else if (index == 1)
            {
                return lblFilename2;
            }
            else if (index == 2)
            {
                return lblFilename3;
            }
            else if (index == 3)
            {
                return lblFilename4;
            }
            else if (index == 4)
            {
                return lblFilename5;
            }
            else if (index == 5)
            {
                return lblFilename6;
            }
            else if (index == 6)
            {
                return lblFilename7;
            }
            else if (index == 7)
            {
                return lblFilename8;
            }
            else if (index == 8)
            {
                return lblFilename9;
            }

            return null;
        }

        string getTextureFilename(int index)
        {
            if (index == 0)
            {
                return texture1Filename;
            }
            else if (index == 1)
            {
                return texture2Filename;
            }
            else if (index == 2)
            {
                return texture3Filename;
            }
            else if (index == 3)
            {
                return texture4Filename;
            }
            else if (index == 4)
            {
                return texture5Filename;
            }
            else if (index == 5)
            {
                return texture6Filename;
            }
            else if (index == 6)
            {
                return texture7Filename;
            }
            else if (index == 7)
            {
                return texture8Filename;
            }
            else if (index == 8)
            {
                return texture9Filename;
            }

            return null;
        }

        void resetPanels()
        {
            lblFilename1.Visible = false;
            panel1.Visible = false;
            panel1.Size = new System.Drawing.Size(160, 160);

            lblFilename2.Visible = false;
            panel2.Visible = false;
            panel2.Size = new System.Drawing.Size(160, 160);

            lblFilename3.Visible = false;
            panel3.Visible = false;
            panel3.Size = new System.Drawing.Size(160, 160);

            lblFilename4.Visible = false;
            panel4.Visible = false;
            panel4.Size = new System.Drawing.Size(160, 160);

            lblFilename5.Visible = false;
            panel5.Visible = false;
            panel5.Size = new System.Drawing.Size(160, 160);

            lblFilename6.Visible = false;
            panel6.Visible = false;
            panel6.Size = new System.Drawing.Size(160, 160);

            lblFilename7.Visible = false;
            panel7.Visible = false;
            panel7.Size = new System.Drawing.Size(160, 160);

            lblFilename8.Visible = false;
            panel8.Visible = false;
            panel8.Size = new System.Drawing.Size(160, 160);

            lblFilename9.Visible = false;
            panel9.Visible = false;
            panel9.Size = new System.Drawing.Size(160, 160);
        }

        void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.done = true;
            FrmMain.done = true;
        }

        public static void loadBlocks(FrmMain frmMain)
        {
            Blocks.loadBlocks();

            if (sortOption == SortOption.Id)
            {
                loadBlockIdList(frmMain);
            }
            else if (sortOption == SortOption.Alphabetical)
            {
                loadBlockAlphabeticalList(frmMain);
            }
        }

        public static void loadItems(FrmMain frmMain)
        {
            Items.loadItems();

            if (sortOption == SortOption.Id)
            {
                loadItemIdList(frmMain);
            }
            else if (sortOption == SortOption.Alphabetical)
            {
                loadItemAlphabeticalList(frmMain);
            }
        }

        public static void loadBlockIdList(FrmMain frmMain)
        {
            List<Id> blockIds = new List<Id>();
            foreach (DictionaryEntry entry in FrmMain.blocks)
            {
                string name = (string)entry.Key;
                int id = (int)entry.Value;

                blockIds.Add(new Id(name, id));
            }

            blockIds.Sort();
            frmMain.blocksClearItems();

            foreach (Id blockId in blockIds)
            {
                frmMain.blocksAddItem(blockId.name);
            }
        }

        public static void loadBlockAlphabeticalList(FrmMain frmMain)
        {
            FrmMain.sortOption = SortOption.Alphabetical;

            List<string> blockNames = new List<string>();
            foreach (string blockName in FrmMain.blocks.Keys)
            {
                blockNames.Add(blockName);
            }

            blockNames.Sort();
            frmMain.blocksClearItems();

            foreach (string blockName in blockNames)
            {
                frmMain.blocksAddItem(blockName);
            }
        }

        public static void loadItemIdList(FrmMain frmMain)
        {
            List<Id> itemIds = new List<Id>();
            foreach (DictionaryEntry entry in FrmMain.items)
            {
                string name = (string)entry.Key;
                int id = (int)entry.Value;

                itemIds.Add(new Id(name, id));
            }

            itemIds.Sort();
            frmMain.itemsClearItems();

            foreach (Id itemId in itemIds)
            {
                frmMain.itemsAddItem(itemId.name);
            }
        }

        public static void loadItemAlphabeticalList(FrmMain frmMain)
        {
            FrmMain.sortOption = SortOption.Alphabetical;

            List<string> itemNames = new List<string>();
            foreach (string itemName in FrmMain.items.Keys)
            {
                itemNames.Add(itemName);
            }

            itemNames.Sort();
            frmMain.itemsClearItems();

            foreach (string itemName in itemNames)
            {
                frmMain.itemsAddItem(itemName);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (minecraftJarPath == "")
            {
                MessageBox.Show("Minecraft jar path not set. Set it on the settings tab", "Minecraft Texture Studio");
            }
            else
            {
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Filter = "Minecraft Resource Pack Files (*.zip)|*.zip";

                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    path = dialog.FileName;
                    texturePackFileName = "";

                    int pathIndexIf = path.LastIndexOf(".");
                    if (path.LastIndexOf(".") == -1)
                    {
                        texturePackFileName = path.Substring(path.LastIndexOf("\\") + 1, path.Length - path.LastIndexOf("\\") - 1);
                    }
                    else
                    {
                        texturePackFileName = path.Substring(path.LastIndexOf("\\") + 1, path.LastIndexOf(".") - path.LastIndexOf("\\") - 1);
                    }

                    directory = path.Substring(0, path.LastIndexOf("\\")) + "\\" + texturePackFileName;

                    Directory.CreateDirectory(directory);

                    if (extractJarOption == "1")
                    {
                        if (Directory.Exists(extractedJarPath))
                        {
                            copyFileRecursively(extractedJarPath + "\\assets\\minecraft\\textures", directory + "\\assets\\minecraft\\textures");
                        }
                        else
                        {
                            MessageBox.Show("Extracted jar folder not found. Go to the settings tab, and set a valid directory for the extracted jar", "Minecraft Texture Studio");
                            return;
                        }
                    }

                    StreamWriter writer = null;
                    try
                    {
                        writer = new StreamWriter(new FileStream(directory + "\\pack.mcmeta", FileMode.Create, FileAccess.Write));
                        writer.WriteLine("{");
                        writer.WriteLine("  \"pack\": {");
                        writer.WriteLine("    \"pack_format\": 3,");
                        writer.WriteLine("    \"description\": \"" + texturePackName + "\"");
                        writer.WriteLine("  }");
                        writer.WriteLine("}");
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show("Exception occured creating pack.mcmeta: " + exception.Message, "Error");
                    }
                    finally
                    {
                        if (writer != null)
                        {
                            writer.Dispose();
                        }
                    }

                    cmbBlocks.Items.Clear();
                    cmbItems.Items.Clear();
                    cmbSounds.Items.Clear();
                    cmbSounds.Text = "";

                    texturePackName = "Untitled";
                    txtResourcePackName.Text = texturePackName;

                    texturePackLoaded = true;
                    lblTexturePack.Text = "Resource Pack: " + texturePackName;
                    this.Text = "Minecraft Texture Studio - " + path;
                    enableControls();

                    if (extractJarOption == "0")
                    {
                        extractJar();
                    }

                    loadBlocks(this);
                    Items.loadItems();

                    foreach (string itemName in itemList)
                    {
                        cmbItems.Items.Add(itemName);
                    }

                    setupItemsComboBox();

                    cmbBlocks.Text = "Stone";
                    cmbBlocks.SelectedItem = "Stone";

                    string fontPath = directory + "\\assets\\minecraft\\textures\\font\\ascii.png";
                    if (File.Exists(fontPath))
                    {
                        loadFont(fontPath);
                    }

                    foreach (TreeNode node in FrmMain.treeView.Nodes)
                    {
                        if (node.Text == "Blocks")
                        {
                            OrganiseResourcePack.checkAll(node);
                        }
                        else if (node.Text == "Items")
                        {
                            OrganiseResourcePack.checkAll(node);
                        }
                        else if (node.Text == "Sounds")
                        {
                            OrganiseResourcePack.checkAll(node);
                        }
                    }
                }
            }
        }

        /**/
        public void createNewPack(string path)
        {
            FrmMain.path = path;
            FrmMain.texturePackLoaded = true;
            texturePackFileName = "";

            int pathIndexIf = path.LastIndexOf(".");
            if (path.LastIndexOf(".") == -1)
            {
                texturePackFileName = path.Substring(path.LastIndexOf("\\") + 1, path.Length - path.LastIndexOf("\\") - 1);
            }
            else
            {
                texturePackFileName = path.Substring(path.LastIndexOf("\\") + 1, path.LastIndexOf(".") - path.LastIndexOf("\\") - 1);
            }

            directory = path.Substring(0, path.LastIndexOf("\\")) + "\\" + texturePackFileName;

            cmbBlocks.Items.Clear();
            cmbSounds.Items.Clear();
            cmbSounds.Text = "";

            texturePackName = "Untitled";
            txtResourcePackName.Text = texturePackName;

            texturePackLoaded = true;
            lblTexturePack.Text = "Resource Pack: " + texturePackName;
            this.Text = "Minecraft Texture Studio - " + path;
            enableControls();

            if (extractJarOption == "0")
            {
                extractJar();
            }

            loadBlocks(this);

            cmbBlocks.Text = "Stone";
            cmbBlocks.SelectedItem = "Stone";

            foreach (TreeNode node in FrmMain.treeView.Nodes)
            {
                if (node.Text == "Blocks")
                {
                    OrganiseResourcePack.checkAll(node);
                }
                else if (node.Text == "Sounds")
                {
                    OrganiseResourcePack.uncheckAll(node);
                }
            }
        }

        public void extractJar()
        {
            FrmJarExtract frmExtract = new FrmJarExtract();
            frmExtract.ShowDialog();

            try
            {
                //delete the class files
                string[] names = Directory.GetFiles(FrmMain.directory);

                foreach (string name in names)
                {
                    if (name.EndsWith(".class"))
                    {
                        File.Delete(name);
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Exception occured deleting class files: " + exception.Message);
            }

            MessageBox.Show("Extracting minecraft jar successfully completed", "Minecraft Texture Studio");
        }

        public static void copyFileRecursively(string path, string destPath)
        {
            try
            {
                string[] names = Directory.GetFiles(path);

                foreach (string name in names)
                {
                    string filename = name.Substring(name.LastIndexOf("\\") + 1, name.Length - name.LastIndexOf("\\") - 1);

                    if (!filename.EndsWith(".class"))
                    {
                        File.Copy(name, destPath + "\\" + filename, true);
                    }
                }

                string[] directories = Directory.GetDirectories(path);

                foreach (string directory in directories)
                {
                    string directoryName = directory.Substring(directory.LastIndexOf("\\") + 1,
                        directory.Length - directory.LastIndexOf("\\") - 1);

                    if (directoryName != "font")
                    {
                        Directory.CreateDirectory(destPath + "\\" + directoryName);
                        copyFileRecursively(path + "\\" + directoryName, destPath + "\\" + directoryName);
                    }
                }
            }
            catch (IOException exception)
            {
                MessageBox.Show("IOException occured copying files: " + exception.Message, "Error");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveTexturePack(true);
        }

        public void saveTexturePack(bool outputSaveResult)
        {
            try
            {
                if (directory != "")
                {
                    FrmSaveResourcePack frmSaveTexturePack = new FrmSaveResourcePack();
                    frmSaveTexturePack.ShowDialog();

                    if (outputSaveResult)
                    {
                        MessageBox.Show("Resource pack saved successfully", "Minecraft Texture Studio");
                    }
                }
                else
                {
                    MessageBox.Show("No resource pack loaded", "Minecraft Texture Studio");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Exception occured saving resource pack: " + exception.Message + "\n" +
                    exception.StackTrace);
            }
        }

        private void btnSaveToMinecraft_Click(object sender, EventArgs e)
        {
            try
            {
                if (minecraftPath == "")
                {
                    MessageBox.Show("Minecraft path not set. Set it on the settings tab", "Minecraft Texture Studio");
                }
                else if (String.IsNullOrEmpty(path))
                {
                    MessageBox.Show("No resource pack loaded", "Minecraft Texture Studio");
                }
                else
                {
                    saveTexturePack(false);

                    try
                    {
                        if (path != "" && File.Exists(path))
                        {
                            File.Copy(path, minecraftPath + "\\resourcepacks\\" + texturePackFileName + ".zip", true);
                            MessageBox.Show("Resource pack copied successfully", "Minecraft Texture Studio");
                        }
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show("Exception occured copying file to minecraft: " + exception.Message, "Error");
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Exception occured saving resource pack to minecraft: " + exception.Message + "\n" +
                    exception.StackTrace);
            }
        }

        private void btnPathBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string path = dialog.SelectedPath;
                changeMinecraftPath(path);
            }
        }

        private void btnJarBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string path = dialog.FileName;
                changeMinecraftJarPath(path);
            }
        }

        private void btnExtractedJarBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string path = dialog.SelectedPath;
                changeExtractedJarPath(path);
            }
        }

        public void changeMinecraftPath(string path)
        {
            minecraftPath = path;
            txtMinecraftPath.Text = minecraftPath;
            saveConfig();
        }

        public void changeMinecraftJarPath(string path)
        {
            minecraftJarPath = path;
            txtMinecraftJarPath.Text = minecraftJarPath;
            saveConfig();
        }

        public void changeExtractedJarPath(string path)
        {
            extractedJarPath = path;
            txtExtractedJarPath.Text = extractedJarPath;
            saveConfig();
        }

        public void changeExtractJarOption()
        {
            saveConfig();
        }

        private void btnImageBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string filename = dialog.FileName;
                loadThumbnail(filename);
            }
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            try
            {
                OrganiseResourcePack.saveChanges(this);
                MessageBox.Show("The contents of the resource pack have been updated", "Minecraft Texture Studio");
            }
            catch (Exception exception)
            {
                MessageBox.Show("Exception occured saving resource pack: " + exception.Message + "\n" +
                    exception.StackTrace);
            }
        }

        private void radExtractFromJar_CheckedChanged(object sender, EventArgs e)
        {
            extractJarOption = "0";
            saveConfig();
        }

        private void radExtractedPath_CheckedChanged(object sender, EventArgs e)
        {
            extractJarOption = "1";
            saveConfig();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FrmMain.path = dialog.FileName;

                try
                {
                    FrmResourcePackExtract frmResourcePackExtract = new FrmResourcePackExtract(path);
                    frmResourcePackExtract.ShowDialog();
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Exception occured unzipping resource pack: " + exception.Message, "Error");
                }

                //read pack.mcmeta
                StreamReader reader = null;
                string descriptionLine = "";

                try
                {
                    reader = new StreamReader(new FileStream(directory + "\\pack.mcmeta", FileMode.Open, FileAccess.Read));
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();

                        if (line.Contains("\"description\""))
                        {
                            descriptionLine = line;
                        }
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Exception occured reading pack.mcmeta: " + exception.Message, "Error");
                }
                finally
                {
                    if (reader != null)
                    {
                        reader.Dispose();
                    }
                }

                string description = descriptionLine.Substring(descriptionLine.LastIndexOf(":") + 1,
                    descriptionLine.Length - descriptionLine.LastIndexOf(":") - 1);

                description = description.Trim();
                description = description.Replace("\"", "");

                texturePackName = description;
                txtResourcePackName.Text = texturePackName;
                cmbSounds.Text = "";

                if (File.Exists(directory + "\\pack.png"))
                {
                    Bitmap loadPicture = null;
                    try
                    {
                        loadPicture = new Bitmap(directory + "\\pack.png");
                        panelThumbnail.BackgroundImage = new Bitmap(loadPicture);
                        lblDropImage.Visible = false;
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show("Exception occured loading thumbnail picture from resource pack: " + exception.Message, "Error");
                    }
                    finally
                    {
                        if (loadPicture != null)
                        {
                            loadPicture.Dispose();
                        }
                    }
                }

                if (File.Exists(directory + "\\assets\\minecraft\\textures\\font\\ascii.png"))
                {
                    Bitmap loadPicture = null;
                    try
                    {
                        loadPicture = new Bitmap(directory + "\\assets\\minecraft\\textures\\font\\ascii.png");
                        panelFont.BackgroundImage = new Bitmap(loadPicture);
                        lblFontDropImage.Visible = false;
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show("Exception occured loading font picture from resource pack: " + exception.Message, "Error");
                    }
                    finally
                    {
                        if (loadPicture != null)
                        {
                            loadPicture.Dispose();
                        }
                    }
                }

                texturePackLoaded = true;
                lblTexturePack.Text = "Resource Pack: " + texturePackName;
                this.Text = "Minecraft Texture Studio - " + path;
                enableControls();
                loadResourcePack(this);

                cmbBlocks.Text = "Stone";
                cmbBlocks.SelectedItem = "Stone";
            }
        }

        public static void loadResourcePack(FrmMain frmMain)
        {
            //loading the updated resource pack
            frmMain.blocksClearItems();
            frmMain.itemsClearItems();
            frmMain.soundsClearItems();

            loadBlocks(frmMain);
            loadItems(frmMain);
            Sounds.loadSounds();

            foreach (string soundName in soundList)
            {
                frmMain.soundsAddItem(soundName);
            }

            //update organise tree
            OrganiseResourcePack.loadResourcePack();

            frmMain.setupBlocksComboBox();
            frmMain.setupItemsComboBox();
            frmMain.setupSoundsComboBox();
            frmMain.setSoundControls();
        }

        private void btnPen_Click(object sender, EventArgs e)
        {
            resetMode(btnPen);

            if (!btnPen.Toggled)
            {
                mode = PaintMode.Pen;
            }
        }

        private void btnLine_Click(object sender, EventArgs e)
        {
            resetMode(btnLine);

            if (!btnLine.Toggled)
            {
                mode = PaintMode.Line;
            }
        }

        private void btnRectangle_Click(object sender, EventArgs e)
        {
            resetMode(btnRectangle);

            if (!btnRectangle.Toggled)
            {
                mode = PaintMode.Rectangle;
            }
        }

        private void btnBucket_Click(object sender, EventArgs e)
        {
            resetMode(btnBucket);

            if (!btnBucket.Toggled)
            {
                mode = PaintMode.Bucket;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            resetMode(btnClear);

            if (!btnClear.Toggled)
            {
                mode = PaintMode.Clear;
            }
        }

        private void btnColour_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.ShowDialog();

            paintColour = colorDialog.Color;
            panelColour.BackColor = paintColour;

            if (colourIndex == 0)
            {
                panelColour1.BackColor = colorDialog.Color;
            }
            else if (colourIndex == 1)
            {
                panelColour2.BackColor = colorDialog.Color;
            }
            else if (colourIndex == 2)
            {
                panelColour3.BackColor = colorDialog.Color;
            }
            else if (colourIndex == 3)
            {
                panelColour4.BackColor = colorDialog.Color;
            }
            else if (colourIndex == 4)
            {
                panelColour5.BackColor = colorDialog.Color;
            }
            else if (colourIndex == 5)
            {
                panelColour6.BackColor = colorDialog.Color;
            }
            else if (colourIndex == 6)
            {
                panelColour7.BackColor = colorDialog.Color;
            }
            else if (colourIndex == 7)
            {
                panelColour8.BackColor = colorDialog.Color;
            }
            else if (colourIndex == 8)
            {
                panelColour9.BackColor = colorDialog.Color;
            }
            else if (colourIndex == 9)
            {
                panelColour10.BackColor = colorDialog.Color;
            }
            else if (colourIndex == 10)
            {
                panelColour11.BackColor = colorDialog.Color;
            }
            else if (colourIndex == 11)
            {
                panelColour12.BackColor = colorDialog.Color;
            }
            else if (colourIndex == 12)
            {
                panelColour13.BackColor = colorDialog.Color;
            }
            else if (colourIndex == 13)
            {
                panelColour14.BackColor = colorDialog.Color;
            }
            else if (colourIndex == 14)
            {
                panelColour15.BackColor = colorDialog.Color;
            }
            else if (colourIndex == 15)
            {
                panelColour16.BackColor = colorDialog.Color;
            }
            else if (colourIndex == 16)
            {
                panelColour17.BackColor = colorDialog.Color;
            }
            else if (colourIndex == 17)
            {
                panelColour18.BackColor = colorDialog.Color;
            }
            else if (colourIndex == 18)
            {
                panelColour19.BackColor = colorDialog.Color;
            }
            else if (colourIndex == 19)
            {
                panelColour20.BackColor = colorDialog.Color;
            }
            else if (colourIndex == 20)
            {
                panelColour21.BackColor = colorDialog.Color;
            }
            else if (colourIndex == 21)
            {
                panelColour22.BackColor = colorDialog.Color;
            }
            else if (colourIndex == 22)
            {
                panelColour23.BackColor = colorDialog.Color;
            }
            else if (colourIndex == 23)
            {
                panelColour24.BackColor = colorDialog.Color;
            }
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            if (undos.Count > 0)
            {
                TextureChange undoTexture = undos[undoIndex];
                Bitmap bitmap = getTexture(undoTexture.index);

                for (int y = 0; y < bitmap.Height; y++)
                {
                    for (int x = 0; x < bitmap.Width; x++)
                    {
                        if (x < undoTexture.bitmap.Width &&
                            y < undoTexture.bitmap.Height)
                        {
                            bitmap.SetPixel(x, y, undoTexture.bitmap.GetPixel(x, y));
                        }
                    }
                }

                saveTexture(bitmap, undoTexture.index);
                restoreTexture = new Bitmap(bitmap);

                undoIndex--;
                if (undoIndex < 0)
                {
                    undoIndex = 0;
                }

                Panel panel = getPanel(undoTexture.index);
                panel.Refresh();

                FrmTexturePreview.boolUpdateTextures = true;
                Blocks.getTextures(FrmTexturePreview.blockName);
            }
        }

        private void btnRedo_Click(object sender, EventArgs e)
        {
            if (redos.Count > 0)
            {
                if (undoIndex <= undos.Count - 1)
                {
                    TextureChange redoTexture = redos[undoIndex];
                    Bitmap bitmap = getTexture(redoTexture.index);

                    for (int y = 0; y < bitmap.Height; y++)
                    {
                        for (int x = 0; x < bitmap.Width; x++)
                        {
                            if (x < redoTexture.bitmap.Width &&
                                y < redoTexture.bitmap.Height)
                            {
                                bitmap.SetPixel(x, y, redoTexture.bitmap.GetPixel(x, y));
                            }
                        }
                    }

                    saveTexture(bitmap, redoTexture.index);
                    restoreTexture = new Bitmap(bitmap);

                    undoIndex++;
                    if (undoIndex >= undos.Count - 1)
                    {
                        undoIndex = undos.Count - 1;
                    }

                    Panel panel = getPanel(redoTexture.index);
                    panel.Refresh();

                    FrmTexturePreview.boolUpdateTextures = true;
                    Blocks.getTextures(FrmTexturePreview.blockName);
                }
            }
        }

        private void radId_CheckedChanged(object sender, EventArgs e)
        {
            sortOption = SortOption.Id;
            saveConfig();

            if (FrmMain.blocks != null)
            {
                loadBlockIdList(this);
            }

            if (FrmMain.items != null)
            {
                loadItemIdList(this);
            }
        }

        private void radAlphabetical_CheckedChanged(object sender, EventArgs e)
        {
            sortOption = SortOption.Alphabetical;
            saveConfig();

            if (FrmMain.blocks != null)
            {
                loadBlockAlphabeticalList(this);
            }

            if (FrmMain.items != null)
            {
                loadItemAlphabeticalList(this);
            }
        }

        private void lblLinkForum_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
        }

        private delegate void SetControlPropertyThreadSafeDelegate(Control control, string propertyName, object propertyValue);

        public static void SetControlPropertyThreadSafe(Control control, string propertyName, object propertyValue)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new SetControlPropertyThreadSafeDelegate(SetControlPropertyThreadSafe), new object[] { control, propertyName, propertyValue });
            }
            else
            {
                control.GetType().InvokeMember(propertyName, BindingFlags.SetProperty, null, control, new object[] { propertyValue });
            }
        }

        public void setSoundControls()
        {
            SetControlPropertyThreadSafe(lblAddSounds1, "Visible", false);
            SetControlPropertyThreadSafe(lblAddSounds2, "Visible", false);
            SetControlPropertyThreadSafe(btnAddSounds, "Visible", false);

            SetControlPropertyThreadSafe(btnPlay, "Visible", true);
            SetControlPropertyThreadSafe(btnPlayNext, "Visible", true);
            SetControlPropertyThreadSafe(btnBrowseSound, "Visible", true);

            SetControlPropertyThreadSafe(panelDropSound, "Visible", true);
            SetControlPropertyThreadSafe(lblDropSound, "Visible", true);
            SetControlPropertyThreadSafe(cmbSounds, "Enabled", true);
        }

        private void btnAddSounds_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(minecraftPath) ||
                !Directory.Exists(minecraftPath))
            {
                MessageBox.Show("Minecraft folder not found. Go to the settings tab, locate your minecraft folder and " +
                    "set it there", "Minecraft Texture Studio");
                return;
            }

            //find the json file for the current version of minecraft
            if (String.IsNullOrEmpty(minecraftJarPath) || minecraftJarPath.Length < 4 ||
                !File.Exists(minecraftJarPath))
            {
                MessageBox.Show("Minecraft jar file not found. Go to the settings tab, locate your minecraft jar file and " +
                    "set it there", "Minecraft Texture Studio");
                return;
            }
            else if (!minecraftJarPath.EndsWith(".jar"))
            {
                MessageBox.Show("Minecraft jar file selected is not a jar file. Go to the settings tab, locate a valid minecraft jar file and " +
                    "set it there", "Minecraft Texture Studio");
                return;
            }
            else
            {
                FrmAddSounds frmAddSounds = new FrmAddSounds();
                frmAddSounds.ShowDialog();

                Sounds.loadSounds();

                foreach (string soundName in soundList)
                {
                    cmbSounds.Items.Add(soundName);
                }

                if (cmbSounds.Items.Count > 0)
                {
                    cmbSounds.SelectedIndex = 0;
                }

                OrganiseResourcePack.loadResourcePack();
                setSoundControls();
            }
        }

        private void btnAddColour_Click(object sender, EventArgs e)
        {
            txtResourcePackName.SelectionColor = packNameColour;
            updateTextMarkup();
            saveResourcePackName();
        }

        private delegate void BlocksClearItemsDelegate();

        public void blocksClearItems()
        {
            if (cmbBlocks.InvokeRequired)
            {
                cmbBlocks.Invoke(new BlocksClearItemsDelegate(blocksClearItems));
            }
            else
            {
                cmbBlocks.Items.Clear();
            }
        }

        private delegate void BlocksAddItemDelegate(string text);

        public void blocksAddItem(string text)
        {
            if (cmbBlocks.InvokeRequired)
            {
                cmbBlocks.Invoke(new BlocksAddItemDelegate(blocksAddItem), new object[] { text });
            }
            else
            {
                cmbBlocks.Items.Add(text);
            }
        }

        private delegate void SoundsClearItemsDelegate();

        public void soundsClearItems()
        {
            if (cmbSounds.InvokeRequired)
            {
                cmbSounds.Invoke(new SoundsClearItemsDelegate(soundsClearItems));
            }
            else
            {
                cmbSounds.Items.Clear();
            }
        }

        private delegate void SoundsAddItemDelegate(string text);

        public void soundsAddItem(string text)
        {
            if (cmbSounds.InvokeRequired)
            {
                cmbSounds.Invoke(new SoundsAddItemDelegate(soundsAddItem), new object[] { text });
            }
            else
            {
                cmbSounds.Items.Add(text);
            }
        }

        private delegate void ItemsClearItemsDelegate();

        public void itemsClearItems()
        {
            if (cmbItems.InvokeRequired)
            {
                cmbItems.Invoke(new ItemsClearItemsDelegate(itemsClearItems));
            }
            else
            {
                cmbItems.Items.Clear();
            }
        }

        private delegate void ItemsAddItemDelegate(string text);

        public void itemsAddItem(string text)
        {
            if (cmbItems.InvokeRequired)
            {
                cmbItems.Invoke(new ItemsAddItemDelegate(itemsAddItem), new object[] { text });
            }
            else
            {
                cmbItems.Items.Add(text);
            }
        }

        private delegate void SetupBlocksComboBoxDelegate();

        public void setupBlocksComboBox()
        {
            if (cmbBlocks.InvokeRequired)
            {
                cmbBlocks.Invoke(new SetupBlocksComboBoxDelegate(setupBlocksComboBox));
            }
            else
            {
                if (cmbBlocks.Items.Contains("Stone"))
                {
                    cmbBlocks.Text = "Stone";
                    cmbBlocks.SelectedItem = "Stone";
                }
                else if (cmbBlocks.Items.Count > 0)
                {
                    cmbBlocks.SelectedIndex = 0;
                }
            }
        }

        private delegate void SetupSoundsComboBoxDelegate();

        public void setupSoundsComboBox()
        {
            if (cmbSounds.InvokeRequired)
            {
                cmbSounds.Invoke(new SetupSoundsComboBoxDelegate(setupSoundsComboBox));
            }
            else
            {
                if (cmbSounds.Items.Count > 0)
                {
                    cmbSounds.SelectedIndex = 0;
                }
            }
        }

        private delegate void SetupItemsComboBoxDelegate();

        public void setupItemsComboBox()
        {
            if (cmbItems.InvokeRequired)
            {
                cmbItems.Invoke(new SetupItemsComboBoxDelegate(setupItemsComboBox));
            }
            else
            {
                if (cmbItems.Items.Count > 0)
                {
                    cmbItems.SelectedIndex = 0;
                }
            }
        }

        public void updateTextMarkup()
        {
            int select = txtResourcePackName.SelectionStart;

            string markup = "";
            Color prevColour = Color.Black;
            Color currentColour = Color.Black;

            Font prevFont = new Font("Microsoft Sans Serif", 10);
            Font currentFont = new Font("Microsoft Sans Serif", 10);

            for (int a = 0; a < txtResourcePackName.Text.Length; a++)
            {
                txtResourcePackName.Select(a, 1);

                prevFont = currentFont;
                currentFont = txtResourcePackName.SelectionFont;

                prevColour = currentColour;
                currentColour = txtResourcePackName.SelectionColor;

                if (currentFont.Style != prevFont.Style || prevColour != currentColour)
                {
                    markup += "§r";

                    //reapply the colour since formatting was reset
                    int colourIndex = getColourIndex(currentColour);
                    markup += getMarkupforIndex(colourIndex);

                    if ((currentFont.Style & FontStyle.Bold) == FontStyle.Bold)
                    {
                        markup += "§l";
                    }

                    if ((currentFont.Style & FontStyle.Strikeout) == FontStyle.Strikeout)
                    {
                        markup += "§m";
                    }

                    if ((currentFont.Style & FontStyle.Underline) == FontStyle.Underline)
                    {
                        markup += "§n";
                    }

                    if ((currentFont.Style & FontStyle.Italic) == FontStyle.Italic)
                    {
                        markup += "§o";
                    }
                }

                markup += txtResourcePackName.Text.Substring(a, 1);
            }

            txtResourcePackName.SelectionStart = select;
            txtMarkup.Text = markup;
        }

        public string getMarkupforIndex(int colourIndex)
        {
            string markup = "";
            if (colourIndex == -1)
            {
                markup = "";
            }
            else if (colourIndex <= 9)
            {
                markup += "§" + colourIndex.ToString();
            }
            else if (colourIndex == 10)
            {
                markup += "§a";
            }
            else if (colourIndex == 11)
            {
                markup += "§b";
            }
            else if (colourIndex == 12)
            {
                markup += "§c";
            }
            else if (colourIndex == 13)
            {
                markup += "§d";
            }
            else if (colourIndex == 14)
            {
                markup += "§e";
            }
            else if (colourIndex == 15)
            {
                markup += "§f";
            }

            return markup;
        }

        private void btnBold_Click(object sender, EventArgs e)
        {
            Font selectionFont = txtResourcePackName.SelectionFont;
            Font newFont = new System.Drawing.Font(selectionFont, selectionFont.Style | FontStyle.Bold);
            txtResourcePackName.SelectionFont = newFont;

            updateTextMarkup();
            saveResourcePackName();
        }

        private void btnItalic_Click(object sender, EventArgs e)
        {
            Font selectionFont = txtResourcePackName.SelectionFont;
            Font newFont = new System.Drawing.Font(selectionFont, selectionFont.Style | FontStyle.Italic);
            txtResourcePackName.SelectionFont = newFont;

            updateTextMarkup();
            saveResourcePackName();
        }

        private void btnUnderline_Click(object sender, EventArgs e)
        {
            Font selectionFont = txtResourcePackName.SelectionFont;
            Font newFont = new System.Drawing.Font(selectionFont, selectionFont.Style | FontStyle.Underline);
            txtResourcePackName.SelectionFont = newFont;

            updateTextMarkup();
            saveResourcePackName();
        }

        private void btnStrikethrough_Click(object sender, EventArgs e)
        {
            Font selectionFont = txtResourcePackName.SelectionFont;
            Font newFont = new System.Drawing.Font(selectionFont, selectionFont.Style | FontStyle.Strikeout);
            txtResourcePackName.SelectionFont = newFont;

            updateTextMarkup();
            saveResourcePackName();
        }

        private void btnRemoveFormatting_Click(object sender, EventArgs e)
        {
            Font selectionFont = txtResourcePackName.SelectionFont;
            Font newFont = new System.Drawing.Font(selectionFont, FontStyle.Regular);
            txtResourcePackName.SelectionFont = newFont;

            updateTextMarkup();
            saveResourcePackName();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            playSound();
        }

        public void playSound()
        {
            try
            {
                if (cmbSounds.SelectedIndex != -1)
                {
                    string soundName = (string)cmbSounds.Items[cmbSounds.SelectedIndex];
                    string filename = Sounds.getSounds(soundName);

                    if (!File.Exists(filename))
                    {
                        MessageBox.Show("Sound not found: " + filename, "Minecraft Texture Studio");
                    }
                    else
                    {
                        ISoundEngine engine = new ISoundEngine();
                        engine.Play2D(filename);
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Exception occured playing sound: " + exception.Message);
            }
        }

        private void btnPlayNext_Click(object sender, EventArgs e)
        {
            if (cmbSounds.SelectedIndex < cmbSounds.Items.Count - 1)
            {
                cmbSounds.SelectedIndex++;
                playSound();
            }
        }

        private void btnPicker_Click(object sender, EventArgs e)
        {
            resetMode(btnPicker);

            if (!btnPicker.Toggled)
            {
                mode = PaintMode.Picker;
            }
        }

        private void btnBrowseSound_Click(object sender, EventArgs e)
        {
            if (cmbSounds.SelectedIndex != -1)
            {
                OpenFileDialog dialog = new OpenFileDialog();

                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    saveSoundFile(dialog.FileName);
                }
            }
            else
            {
                MessageBox.Show("No sound selected", "Minecraft Texture Studio");
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            prevTexturePreviewMouseDown = texturePreviewMouseDown;
            texturePreviewMouseDown = FrmTexturePreview.mouseDown;

            if (textureClicked)
            {
                /**/
                /*Console.WriteLine("--------");
                Console.WriteLine("clickPos = " + FrmMain.textureClickPos);
                Console.WriteLine("Mouse pos = " + FrmTexturePreview.mouseStartX + ", " + FrmTexturePreview.mouseStartY);
                Console.WriteLine("Eye position = " + FrmTexturePreview.eyePosition);*/

                textureClicked = false;

                bool foundCube = false;
                Vector3 mousePoint = new Vector3();
                float xDiff = 0.0f;
                float yDiff = 0.0f;

                int selectedPlane = -1;
                float minDistance = (float)Math.Pow(10, 6);
                List<Cube> cubes = TexturePaint3D.getCubePositions(FrmTexturePreview.modelType);

                for (int a = 0; a < cubes.Count; a++)
                {
                    Cube cubePosition = cubes[a];

                    if (cubePosition != null)
                    {
                        List<Vector3> planes = new List<Vector3>();

                        //front
                        planes.Add(new Vector3(-1.0f / 2.0f + 1.0f / 16.0f * cubePosition.x,
                            -1.0f / 2.0f + 1.0f / 16.0f * cubePosition.y,
                            -1.0f / 2.0f + 1.0f / 16.0f * cubePosition.z));

                        //back
                        planes.Add(new Vector3(-1.0f / 2.0f + 1.0f / 16.0f * (cubePosition.x + 1),
                            -1.0f / 2.0f + 1.0f / 16.0f * cubePosition.y,
                            -1.0f / 2.0f + 1.0f / 16.0f * cubePosition.z));

                        //top
                        planes.Add(new Vector3(-1.0f / 2.0f + 1.0f / 16.0f * cubePosition.x,
                            -1.0f / 2.0f + 1.0f / 16.0f * cubePosition.y,
                            -1.0f / 2.0f + 1.0f / 16.0f * cubePosition.z));

                        //bottom
                        planes.Add(new Vector3(-1.0f / 2.0f + 1.0f / 16.0f * cubePosition.x,
                            -1.0f / 2.0f + 1.0f / 16.0f * (cubePosition.y + 1),
                            -1.0f / 2.0f + 1.0f / 16.0f * cubePosition.z));

                        //left
                        planes.Add(new Vector3(-1.0f / 2.0f + 1.0f / 16.0f * cubePosition.x,
                            -1.0f / 2.0f + 1.0f / 16.0f * cubePosition.y,
                            -1.0f / 2.0f + 1.0f / 16.0f * cubePosition.z));

                        //right
                        planes.Add(new Vector3(-1.0f / 2.0f + 1.0f / 16.0f * cubePosition.x,
                            -1.0f / 2.0f + 1.0f / 16.0f * cubePosition.y,
                            -1.0f / 2.0f + 1.0f / 16.0f * (cubePosition.z + 1)));

                        for (int planeIndex = 0; planeIndex < planes.Count; planeIndex++)
                        {
                            Vector3 targetPoint = planes[planeIndex];

                            Vector3 xPlanePoint = getClickPosXPlane(targetPoint.x, FrmMain.textureClickPos);
                            Vector3 yPlanePoint = getClickPosYPlane(targetPoint.y, FrmMain.textureClickPos);
                            Vector3 zPlanePoint = getClickPosZPlane(targetPoint.z, FrmMain.textureClickPos);

                            if (planeIndex == 0 && !cubePosition.front)
                            {
                                continue;
                            }
                            else if (planeIndex == 1 && !cubePosition.back)
                            {
                                continue;
                            }
                            else if (planeIndex == 2 && !cubePosition.bottom)
                            {
                                continue;
                            }
                            else if (planeIndex == 3 && !cubePosition.top)
                            {
                                continue;
                            }
                            else if (planeIndex == 4 && !cubePosition.left)
                            {
                                continue;
                            }
                            else if (planeIndex == 5 && !cubePosition.right)
                            {
                                continue;
                            }

                            float dist = 0;

                            //front, back
                            if (planeIndex == 0 || planeIndex == 1)
                            {
                                dist = MathUtil.getDist(xPlanePoint, FrmTexturePreview.eyePosition);
                            }

                            //top, bottom
                            if (planeIndex == 2 || planeIndex == 3)
                            {
                                dist = MathUtil.getDist(yPlanePoint, FrmTexturePreview.eyePosition);
                            }

                            //left, right
                            if (planeIndex == 4 || planeIndex == 5)
                            {
                                dist = MathUtil.getDist(zPlanePoint, FrmTexturePreview.eyePosition);
                            }

                            bool isValidPoint = false;
                            float currentXDiff = 0.0f;
                            float currentYDiff = 0.0f;

                            //front, back
                            if (planeIndex == 0 || planeIndex == 1)
                            {
                                isValidPoint = (xPlanePoint.z >= targetPoint.z && xPlanePoint.z <= targetPoint.z + 1.0f / 16.0f &&
                                                xPlanePoint.y >= targetPoint.y && xPlanePoint.y <= targetPoint.y + 1.0f / 16.0f);

                                if (isValidPoint)
                                {
                                    if (planeIndex == 0)
                                    {
                                        currentXDiff = (xPlanePoint.z - targetPoint.z) * 16;
                                        currentYDiff = 1 - (xPlanePoint.y - targetPoint.y) * 16;
                                    }
                                    else if (planeIndex == 1)
                                    {
                                        currentXDiff = 1 - (xPlanePoint.z - targetPoint.z) * 16;
                                        currentYDiff = 1 - (xPlanePoint.y - targetPoint.y) * 16;
                                    }
                                }
                            }

                            //top, bottom
                            if (planeIndex == 2 || planeIndex == 3)
                            {
                                isValidPoint = (yPlanePoint.x >= targetPoint.x && yPlanePoint.x <= targetPoint.x + 1.0f / 16.0f &&
                                                yPlanePoint.z >= targetPoint.z && yPlanePoint.z <= targetPoint.z + 1.0f / 16.0f);

                                if (isValidPoint)
                                {
                                    if (planeIndex == 2)
                                    {
                                        currentXDiff = 1 - (yPlanePoint.x - targetPoint.x) * 16;
                                        currentYDiff = (yPlanePoint.z - targetPoint.z) * 16;
                                    }
                                    else if (planeIndex == 3)
                                    {
                                        currentXDiff = (yPlanePoint.x - targetPoint.x) * 16;
                                        currentYDiff = (yPlanePoint.z - targetPoint.z) * 16;
                                    }
                                }
                            }

                            //left, right
                            if (planeIndex == 4 || planeIndex == 5)
                            {
                                isValidPoint = (zPlanePoint.x >= targetPoint.x && zPlanePoint.x <= targetPoint.x + 1.0f / 16.0f &&
                                                zPlanePoint.y >= targetPoint.y && zPlanePoint.y <= targetPoint.y + 1.0f / 16.0f);

                                if (isValidPoint)
                                {
                                    if (planeIndex == 4)
                                    {
                                        currentXDiff = 1 - (zPlanePoint.x - targetPoint.x) * 16;
                                        currentYDiff = 1 - (zPlanePoint.y - targetPoint.y) * 16;
                                    }
                                    else if (planeIndex == 5)
                                    {
                                        currentXDiff = (zPlanePoint.x - targetPoint.x) * 16;
                                        currentYDiff = 1 - (zPlanePoint.y - targetPoint.y) * 16;
                                    }
                                }
                            }

                            if (isValidPoint && dist < minDistance)
                            {
                                FrmTexturePreview.selectedCube = cubePosition;
                                mousePoint = xPlanePoint;
                                selectedPlane = planeIndex;
                                minDistance = dist;
                                foundCube = true;

                                xDiff = currentXDiff;
                                yDiff = currentYDiff;
                            }
                        }
                    }
                }

                if (foundCube)
                {
                    Console.WriteLine("Selected " + FrmTexturePreview.selectedCube);
                    Console.WriteLine("Selected plane: " + selectedPlane);
                    Console.WriteLine("Mouse point: " + mousePoint);
                    Console.WriteLine("Eye position: " + FrmTexturePreview.eyePosition);
                    Console.WriteLine("Diff X: " + xDiff);
                    Console.WriteLine("Diff Y: " + yDiff);
                }
                else
                {
                    Console.WriteLine("No cube found");
                    FrmTexturePreview.selectedCube = new Cube(-1, -1, -1);
                }

                TextureUpdate textureUpdate = TexturePaint3D.updateTexture(selectedPlane, FrmTexturePreview.modelType, FrmTexturePreview.selectedCube);
                Vector2 clickPos2D = textureUpdate.uv;

                if (textureUpdate.textureIndex != -1)
                {
                    /**/
                    Console.WriteLine("Drawing at " + textureUpdate.uv.x + " " + textureUpdate.uv.y);
                    Bitmap texture = getTexture(textureUpdate.textureIndex);

                    try
                    {
                        lock (texture)
                        {
                            if (texturePreviewMouseDown && !prevTexturePreviewMouseDown)
                            {
                                if (mode != PaintMode.None)
                                {
                                    int deleteCount = undos.Count - undoIndex - 1;
                                    if (deleteCount > 0 & undoIndex < undos.Count - 1)
                                    {
                                        try
                                        {
                                            undos.RemoveRange(undoIndex + 1, deleteCount);
                                        }
                                        catch (Exception exception)
                                        {
                                            Console.WriteLine("Exception occurred removing undos when using texture preview: " + exception.Message);
                                        }

                                        try
                                        {
                                            redos.RemoveRange(undoIndex + 1, deleteCount);
                                        }
                                        catch (Exception exception)
                                        {
                                            Console.WriteLine("Exception occurred removing redos when using texture preview: " + exception.Message);
                                        }
                                    }

                                    undos.Add(new TextureChange(textureUpdate.textureIndex, new Bitmap(texture)));
                                }
                            }

                            if (clickPos2D.x >= 0 && clickPos2D.x < texture.Width &&
                                clickPos2D.y >= 0 && clickPos2D.y < texture.Height)
                            {
                                if (texture.Width == 32 && texture.Height == 32)
                                {
                                    clickPos2D.x = clickPos2D.x * 2 + xDiff * 2;
                                    clickPos2D.y = clickPos2D.y * 2 + yDiff * 2;
                                }
                                else if (texture.Width == 64 && texture.Height == 64)
                                {
                                    clickPos2D.x = clickPos2D.x * 4 + xDiff * 4;
                                    clickPos2D.y = clickPos2D.y * 4 + yDiff * 4;
                                }
                                if (texture.Width == 128 && texture.Height == 128)
                                {
                                    clickPos2D.x = clickPos2D.x * 8 + xDiff * 8;
                                    clickPos2D.y = clickPos2D.y * 8 + yDiff * 8;
                                }
                                if (texture.Width == 256 && texture.Height == 256)
                                {
                                    clickPos2D.x = clickPos2D.x * 16 + xDiff * 16;
                                    clickPos2D.y = clickPos2D.y * 16 + yDiff * 16;
                                }

                                if (mode == PaintMode.Pen)
                                {
                                    texture.SetPixel((int)clickPos2D.x, (int)clickPos2D.y, paintColour);
                                }
                                else if (mode == PaintMode.Bucket)
                                {
                                    paintBucket(texture, (int)clickPos2D.x, (int)clickPos2D.y, texture.Width, texture.Height, paintColour);
                                }
                                else if (mode == PaintMode.Clear)
                                {
                                    texture.SetPixel((int)clickPos2D.x, (int)clickPos2D.y, Color.FromArgb(0, 0, 0, 0));
                                }
                                else if (mode == PaintMode.Picker)
                                {
                                    pickColour(texture, (int)clickPos2D.x, (int)clickPos2D.y);
                                }
                            }

                            saveTexture(texture, textureUpdate.textureIndex);
                            Panel panel = getPanel(textureUpdate.textureIndex);
                            panel.Refresh();

                            FrmTexturePreview.boolUpdateTextures = true;
                            Blocks.getTextures(FrmTexturePreview.blockName);

                            if (FrmMain.clickComplete)
                            {
                                FrmMain.clickComplete = false;

                                if (mode != PaintMode.None)
                                {
                                    redos.Add(new TextureChange(textureUpdate.textureIndex, new Bitmap(texture)));
                                    undoIndex = undos.Count - 1;
                                }
                            }
                        }
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                }
            }
        }

        public bool isPointWithinRange(Vector3 point, Vector3 targetPoint, float range)
        {
            return (Math.Abs(point.x - targetPoint.x) < range &&
                    Math.Abs(point.y - targetPoint.y) < range &&
                    Math.Abs(point.z - targetPoint.z) < range);
        }

        public Vector2 convertCoord(Vector3 vector, int index)
        {
            float xPos2D = 0;
            float yPos2D = 0;

            if (index == 0 || index == 1)
            {
                xPos2D = (int)Math.Round((vector.z + 1.0f) / 2.0f * 16.0f - 0.5f);
                yPos2D = (int)Math.Round((vector.y + 1.0f) / 2.0f * 16.0f - 0.5f);
                yPos2D = 15 - yPos2D;

                if (index == 1)
                {
                    xPos2D = 15 - xPos2D;
                }
            }
            else if (index == 2 || index == 3)
            {
                xPos2D = (int)Math.Round((vector.x + 1.0f) / 2.0f * 16.0f - 0.5f);
                yPos2D = (int)Math.Round((vector.z + 1.0f) / 2.0f * 16.0f - 0.5f);

                if (index == 2)
                {
                    xPos2D = 15 - xPos2D;
                }
            }
            else if (index == 4 || index == 5)
            {
                xPos2D = (int)Math.Round((vector.x + 1.0f) / 2.0f * 16.0f - 0.5f);
                yPos2D = (int)Math.Round((vector.y + 1.0f) / 2.0f * 16.0f - 0.5f);
                yPos2D = 15 - yPos2D;

                if (index == 4)
                {
                    xPos2D = 15 - xPos2D;
                }
            }

            return new Vector2(xPos2D, yPos2D);
        }

        public Vector3 getClickPosXPlane(float targetX, Vector3 vector)
        {
            Vector3 clickVector = vector - FrmTexturePreview.eyePosition;
            float a = (targetX - FrmTexturePreview.eyePosition.x) / clickVector.x;

            float clickX = targetX;
            float clickY = FrmTexturePreview.eyePosition.y + clickVector.y * a;
            float clickZ = FrmTexturePreview.eyePosition.z + clickVector.z * a;

            return new Vector3(clickX, clickY, clickZ);
        }

        public Vector3 getClickPosYPlane(float targetY, Vector3 vector)
        {
            Vector3 clickVector = vector - FrmTexturePreview.eyePosition;
            float a = (targetY - FrmTexturePreview.eyePosition.y) / clickVector.y;

            float clickY = targetY;
            float clickX = FrmTexturePreview.eyePosition.x + clickVector.x * a;
            float clickZ = FrmTexturePreview.eyePosition.z + clickVector.z * a;

            return new Vector3(clickX, clickY, clickZ);
        }

        public Vector3 getClickPosZPlane(float targetZ, Vector3 vector)
        {
            Vector3 clickVector = vector - FrmTexturePreview.eyePosition;
            float a = (targetZ - FrmTexturePreview.eyePosition.z) / clickVector.z;

            float clickZ = targetZ;
            float clickX = FrmTexturePreview.eyePosition.x + clickVector.x * a;
            float clickY = FrmTexturePreview.eyePosition.y + clickVector.y * a;

            return new Vector3(clickX, clickY, clickZ);
        }

        /**/
        private void chkShowCubes_CheckedChanged(object sender, EventArgs e)
        {
            showCubes = chkShowCubes.Checked;
        }

        private void btnOpenDirectory_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FrmMain.directory = dialog.SelectedPath;
                FrmMain.path = dialog.SelectedPath + ".zip";

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

                //read pack.mcmeta
                StreamReader reader = null;
                string descriptionLine = "";

                try
                {
                    reader = new StreamReader(new FileStream(directory + "\\pack.mcmeta", FileMode.Open, FileAccess.Read));
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();

                        if (line.Contains("\"description\""))
                        {
                            descriptionLine = line;
                        }
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Exception occured reading pack.mcmeta: " + exception.Message, "Error");
                }
                finally
                {
                    if (reader != null)
                    {
                        reader.Dispose();
                    }
                }

                string description = descriptionLine.Substring(descriptionLine.LastIndexOf(":") + 1,
                    descriptionLine.Length - descriptionLine.LastIndexOf(":") - 1);

                description = description.Trim();
                description = description.Replace("\"", "");

                texturePackName = description;
                txtResourcePackName.Text = texturePackName;
                cmbSounds.Text = "";

                if (File.Exists(directory + "\\pack.png"))
                {
                    Bitmap loadPicture = null;
                    try
                    {
                        loadPicture = new Bitmap(directory + "\\pack.png");
                        panelThumbnail.BackgroundImage = new Bitmap(loadPicture);
                        lblDropImage.Visible = false;
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show("Exception occured loading thumbnail picture from resource pack: " + exception.Message, "Error");
                    }
                    finally
                    {
                        if (loadPicture != null)
                        {
                            loadPicture.Dispose();
                        }
                    }
                }

                if (File.Exists(directory + "\\assets\\minecraft\\textures\\font\\ascii.png"))
                {
                    Bitmap loadPicture = null;
                    try
                    {
                        loadPicture = new Bitmap(directory + "\\assets\\minecraft\\textures\\font\\ascii.png");
                        panelFont.BackgroundImage = new Bitmap(loadPicture);
                        lblFontDropImage.Visible = false;
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show("Exception occured loading font picture from resource pack: " + exception.Message, "Error");
                    }
                    finally
                    {
                        if (loadPicture != null)
                        {
                            loadPicture.Dispose();
                        }
                    }
                }

                texturePackLoaded = true;
                lblTexturePack.Text = "Resource Pack: " + texturePackName;
                this.Text = "Minecraft Texture Studio - " + path;
                enableControls();
                loadResourcePack(this);

                cmbBlocks.Text = "Stone";
                cmbBlocks.SelectedItem = "Stone";
            }
        }

        private void btnBrowseFont_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string filename = dialog.FileName;
                Bitmap bitmap = null;

                try
                {
                    bitmap = new Bitmap(filename);

                    if (bitmap.Width != 128 || bitmap.Height != 128)
                    {
                        MessageBox.Show("Font must be 128 x 128", "Minecraft Texture Studio");
                        return;
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Invalid picture, " + exception.Message, "Error");
                    return;
                }
                finally
                {
                    if (bitmap != null)
                    {
                        bitmap.Dispose();
                    }
                }

                if (!Directory.Exists(FrmMain.directory + "\\assets\\minecraft\\textures\\font"))
                {
                    Directory.CreateDirectory(FrmMain.directory + "\\assets\\minecraft\\textures\\font");
                }

                File.Copy(filename, FrmMain.directory + "\\assets\\minecraft\\textures\\font\\ascii.png", true);
                loadFont(filename);
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://www.minecraftforum.net/forums/mapping-and-modding/minecraft-tools/2146316-windows-version-1-0-0-create-and-edit-minecraft");
        }

        private void btnItemColour_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.ShowDialog();

            itemPaintColour = colorDialog.Color;
            itemPanelColour.BackColor = itemPaintColour;

            if (itemColourIndex == 0)
            {
                itemPanelColour1.BackColor = colorDialog.Color;
            }
            else if (itemColourIndex == 1)
            {
                itemPanelColour2.BackColor = colorDialog.Color;
            }
            else if (itemColourIndex == 2)
            {
                itemPanelColour3.BackColor = colorDialog.Color;
            }
            else if (itemColourIndex == 3)
            {
                itemPanelColour4.BackColor = colorDialog.Color;
            }
            else if (itemColourIndex == 4)
            {
                itemPanelColour5.BackColor = colorDialog.Color;
            }
            else if (itemColourIndex == 5)
            {
                itemPanelColour6.BackColor = colorDialog.Color;
            }
            else if (itemColourIndex == 6)
            {
                itemPanelColour7.BackColor = colorDialog.Color;
            }
            else if (itemColourIndex == 7)
            {
                itemPanelColour8.BackColor = colorDialog.Color;
            }
            else if (itemColourIndex == 8)
            {
                itemPanelColour9.BackColor = colorDialog.Color;
            }
            else if (itemColourIndex == 9)
            {
                itemPanelColour10.BackColor = colorDialog.Color;
            }
            else if (itemColourIndex == 10)
            {
                itemPanelColour11.BackColor = colorDialog.Color;
            }
            else if (itemColourIndex == 11)
            {
                itemPanelColour12.BackColor = colorDialog.Color;
            }
            else if (itemColourIndex == 12)
            {
                itemPanelColour13.BackColor = colorDialog.Color;
            }
            else if (itemColourIndex == 13)
            {
                itemPanelColour14.BackColor = colorDialog.Color;
            }
            else if (itemColourIndex == 14)
            {
                itemPanelColour15.BackColor = colorDialog.Color;
            }
            else if (itemColourIndex == 15)
            {
                itemPanelColour16.BackColor = colorDialog.Color;
            }
            else if (itemColourIndex == 16)
            {
                itemPanelColour17.BackColor = colorDialog.Color;
            }
            else if (itemColourIndex == 17)
            {
                itemPanelColour18.BackColor = colorDialog.Color;
            }
            else if (itemColourIndex == 18)
            {
                itemPanelColour19.BackColor = colorDialog.Color;
            }
            else if (itemColourIndex == 19)
            {
                itemPanelColour20.BackColor = colorDialog.Color;
            }
            else if (itemColourIndex == 20)
            {
                itemPanelColour21.BackColor = colorDialog.Color;
            }
            else if (itemColourIndex == 21)
            {
                itemPanelColour22.BackColor = colorDialog.Color;
            }
            else if (itemColourIndex == 22)
            {
                itemPanelColour23.BackColor = colorDialog.Color;
            }
            else if (itemColourIndex == 23)
            {
                itemPanelColour24.BackColor = colorDialog.Color;
            }
        }

        private void btnItemPen_Click(object sender, EventArgs e)
        {
            resetItemMode(btnItemPen);

            if (!btnItemPen.Toggled)
            {
                itemMode = PaintMode.Pen;
            }
        }

        private void btnItemLine_Click(object sender, EventArgs e)
        {
            resetItemMode(btnItemLine);

            if (!btnItemLine.Toggled)
            {
                itemMode = PaintMode.Line;
            }
        }

        private void btnItemRectangle_Click(object sender, EventArgs e)
        {
            resetItemMode(btnItemRectangle);

            if (!btnItemRectangle.Toggled)
            {
                itemMode = PaintMode.Rectangle;
            }
        }

        private void btnItemBucket_Click(object sender, EventArgs e)
        {
            resetItemMode(btnItemBucket);

            if (!btnItemBucket.Toggled)
            {
                itemMode = PaintMode.Bucket;
            }
        }

        private void btnItemClear_Click(object sender, EventArgs e)
        {
            resetItemMode(btnItemClear);

            if (!btnItemClear.Toggled)
            {
                itemMode = PaintMode.Clear;
            }
        }

        private void btnItemPicker_Click(object sender, EventArgs e)
        {
            resetItemMode(btnItemPicker);

            if (!btnItemPicker.Toggled)
            {
                itemMode = PaintMode.Picker;
            }
        }

        private void btnItemUndo_Click(object sender, EventArgs e)
        {
            if (itemUndos.Count > 0)
            {
                TextureChange itemUndoTexture = itemUndos[itemUndoIndex];

                for (int y = 0; y < itemPicture.Height; y++)
                {
                    for (int x = 0; x < itemPicture.Width; x++)
                    {
                        if (x < itemUndoTexture.bitmap.Width &&
                            y < itemUndoTexture.bitmap.Height)
                        {
                            itemPicture.SetPixel(x, y, itemUndoTexture.bitmap.GetPixel(x, y));
                        }
                    }
                }

                string currentItemName = (string)cmbItems.Items[cmbItems.SelectedIndex];
                List<string> textures = Items.getTextures(currentItemName);

                string filename = textures[0];
                itemPicture.Save(filename);

                itemUndoIndex--;
                if (itemUndoIndex < 0)
                {
                    itemUndoIndex = 0;
                }

                itemPanel.Refresh();
            }
        }

        private void btnItemRedo_Click(object sender, EventArgs e)
        {
            if (itemRedos.Count > 0)
            {
                if (itemUndoIndex <= itemUndos.Count - 1)
                {
                    TextureChange itemRedoTexture = itemRedos[itemUndoIndex];

                    for (int y = 0; y < itemPicture.Height; y++)
                    {
                        for (int x = 0; x < itemPicture.Width; x++)
                        {
                            if (x < itemRedoTexture.bitmap.Width &&
                                y < itemRedoTexture.bitmap.Height)
                            {
                                itemPicture.SetPixel(x, y, itemRedoTexture.bitmap.GetPixel(x, y));
                            }
                        }
                    }

                    string currentItemName = (string)cmbItems.Items[cmbItems.SelectedIndex];
                    List<string> textures = Items.getTextures(currentItemName);

                    string filename = textures[0];
                    itemPicture.Save(filename);

                    itemUndoIndex++;
                    if (itemUndoIndex >= itemUndos.Count - 1)
                    {
                        itemUndoIndex = itemUndos.Count - 1;
                    }

                    itemPanel.Refresh();
                }
            }
        }

        private void lblCoded_Click(object sender, EventArgs e)
        {

        }

        private void panelColour2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel14_Paint(object sender, PaintEventArgs e)
        {
        }

            private void panelColour23_Paint(object sender, PaintEventArgs e)
            {

            }

        private void lblVersion_Click(object sender, EventArgs e)
        {

        }
    }

    public enum PanelConfiguration
        {
            T1x1, T4x4, T4x2, T8x4
        }

        public enum PaintMode
        {
            Pen, Line, Rectangle, Bucket, Clear, Picker, None
        }

        public enum SortOption
        {
            Id, Alphabetical
        }
    }




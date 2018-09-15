using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Tao.OpenGl;
using Tao.Platform.Windows;

namespace MinecraftTextureStudio
{
    public class FrmTexturePreview : Form
    {
        public static IntPtr hDC;
        public static IntPtr hRC;
        public static Form form;
        public static bool[] keys = new bool[256];
        public static bool active = true;
        public static bool done = false;
        public static bool mouseDown = false;
        public static bool firstLoad = true;
        public static int frameIndex;
        public static float animationSpeed = 100.0f;
        public static float fireAnimationSpeed = 25.0f;
        public static float orbitDistance = 2.5f;
        public static float windowWidth;
        public static float windowHeight;
        public static Vector3 eyePosition;
        public static Cube selectedCube;

        public static int mouseStartX;
        public static int mouseStartY;

        public static float startRotX;
        public static float startRotY;

        public static float rotX;
        public static float rotY;
        public static float rotZ;
        public static int[] textures = new int[64];
        public static int textureCount = 1;

        public static string blockName;
        public static string changeBlockName;
        public static bool loadNewTextures;
        public static bool boolUpdateTextures;

        public static ModelType modelType;
        public static DateTime blockChangeTime;

        public FrmTexturePreview()
        {
            try
            {
                FrmTexturePreview.loadNewTextures = false;
                blockChangeTime = DateTime.Now;
                modelType = ModelType.None;
                frameIndex = 0;

                eyePosition = new Vector3(-5.0f, 0.0f, 0.0f);
                selectedCube = new Cube(0.0f, 0.0f, -1.0f);

                //startRotX = 30.0f;
                //startRotY = -45.0f;

                rotX = startRotX;
                rotY = startRotY;

                this.CreateParams.ClassStyle = this.CreateParams.ClassStyle |       // Redraw On Size, And Own DC For Window.
                    User.CS_HREDRAW | User.CS_VREDRAW | User.CS_OWNDC;
                this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
                this.SetStyle(ControlStyles.DoubleBuffer, true);
                this.SetStyle(ControlStyles.Opaque, true);
                this.SetStyle(ControlStyles.ResizeRedraw, true);
                this.SetStyle(ControlStyles.UserPaint, true);

                this.Activated += new EventHandler(this.Form_Activated);            // On Activate Event Call Form_Activated
                this.Closing += new CancelEventHandler(this.Form_Closing);          // On Closing Event Call Form_Closing
                this.Deactivate += new EventHandler(this.Form_Deactivate);          // On Deactivate Event Call Form_Deactivate
                this.KeyDown += new KeyEventHandler(this.Form_KeyDown);             // On KeyDown Event Call Form_KeyDown
                this.KeyUp += new KeyEventHandler(this.Form_KeyUp);                 // On KeyUp Event Call Form_KeyUp
                this.Resize += new EventHandler(this.Form_Resize);                  // On Resize Event Call Form_Resize
                this.MouseDown += new MouseEventHandler(FrmTexturePreview_MouseDown);
                this.MouseUp += new MouseEventHandler(FrmTexturePreview_MouseUp);
                this.MouseMove += new MouseEventHandler(FrmTexturePreview_MouseMove);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Exception occured in texture preview form: " + exception.Message + "\n" +
                    exception.StackTrace);
            }
        }

        public void FrmTexturePreview_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left && mouseDown)
            {
                int diffX = (int)((e.X - mouseStartX) * 0.5f);
                int diffY = (int)((e.Y - mouseStartY) * 0.5f);

                rotX = startRotX + diffX;
                rotY = startRotY + diffY;

                if (rotY > 89.9f)
                {
                    rotY = 89.9f;
                }
                else if (rotY < -89.9f)
                {
                    rotY = -89.9f;
                }

                FrmMain.textureClickPos = new Vector3();
                FrmMain.textureClickStart = new Vector3();
            }

            if (e.Button == System.Windows.Forms.MouseButtons.Right && mouseDown)
            {
                Vector3 coord = windowToWorld(new Vector3(e.X, e.Y, 0.0f));
                FrmMain.textureClickPos = coord;
                FrmMain.textureClicked = true;
            }
        }

        public void FrmTexturePreview_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
            FrmMain.clickComplete = true;
        }

        public void FrmTexturePreview_MouseDown(object sender, MouseEventArgs e)
        {
            mouseStartX = e.X;
            mouseStartY = e.Y;
            startRotX = rotX;
            startRotY = rotY;

            mouseDown = true;

            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                Vector3 coord = windowToWorld(new Vector3(mouseStartX, mouseStartY, 0.0f));
                FrmMain.textureClickPos = coord;
                FrmMain.textureClickStart = coord;
                FrmMain.textureClicked = true;
            }
        }

        Vector3 windowToWorld(Vector3 windowCoord)
        {
            double[] modelViewMatrix = new double[16];
            double[] projectionMatrix = new double[16];

            int[] viewport = new int[4];

            Gl.glGetDoublev(Gl.GL_MODELVIEW_MATRIX, modelViewMatrix);
            Gl.glGetDoublev(Gl.GL_PROJECTION_MATRIX, projectionMatrix);
            Gl.glGetIntegerv(Gl.GL_VIEWPORT, viewport);

            /**/
            /*Console.WriteLine("Model View");

            int index = 0;
            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    Console.Write(modelViewMatrix[index] + " ");
                    index++;
                }

                Console.WriteLine("");
            }

            Console.WriteLine("Projection");*/

            /*index = 0;
            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    Console.Write(modelViewMatrix[index] + " ");
                    index++;
                }

                Console.WriteLine("");
            }*/

            windowCoord.y = (float)viewport[3] - (float)windowCoord.y;
            windowCoord.y -= 38;

            Gl.glGetIntegerv(Gl.GL_VIEWPORT, viewport);

            Vector3 returnVector = new Vector3();
            double returnX = 0;
            double returnY = 0;
            double returnZ = 0;

            Glu.gluUnProject(windowCoord.x, windowCoord.y, windowCoord.z, modelViewMatrix, projectionMatrix, viewport,
                out returnX, out returnY, out returnZ);

            returnVector.x = (float)returnX;
            returnVector.y = (float)returnY;
            returnVector.z = (float)returnZ;

            return returnVector;
        }

        public static bool createWindow(string title, int width, int height, int bits)
        {
            try
            {
                int intPixelFormat;
                form = null;

                GC.Collect();
                Kernel.SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, -1, -1);

                form = new FrmTexturePreview();

                form.FormBorderStyle = FormBorderStyle.Sizable;
                Cursor.Show();

                form.Width = width;
                form.Height = height;
                form.Text = title;

                Gdi.PIXELFORMATDESCRIPTOR pixelFormat = new Gdi.PIXELFORMATDESCRIPTOR();
                pixelFormat.nSize = (short)Marshal.SizeOf(pixelFormat);
                pixelFormat.nVersion = 1;
                pixelFormat.dwFlags = Gdi.PFD_DRAW_TO_WINDOW |
                    Gdi.PFD_SUPPORT_OPENGL |
                    Gdi.PFD_DOUBLEBUFFER;

                pixelFormat.iPixelType = (byte)Gdi.PFD_TYPE_RGBA;
                pixelFormat.cColorBits = (byte)bits;
                pixelFormat.cRedBits = 0;
                pixelFormat.cRedShift = 0;
                pixelFormat.cGreenBits = 0;
                pixelFormat.cGreenShift = 0;
                pixelFormat.cBlueBits = 0;
                pixelFormat.cBlueShift = 0;
                pixelFormat.cAlphaBits = 0;
                pixelFormat.cAlphaShift = 0;
                pixelFormat.cAccumBits = 0;
                pixelFormat.cAccumRedBits = 0;
                pixelFormat.cAccumGreenBits = 0;
                pixelFormat.cAccumBlueBits = 0;
                pixelFormat.cAccumAlphaBits = 0;
                pixelFormat.cDepthBits = 16;
                pixelFormat.cStencilBits = 0;
                pixelFormat.cAuxBuffers = 0;
                pixelFormat.iLayerType = (byte)Gdi.PFD_MAIN_PLANE;
                pixelFormat.bReserved = 0;
                pixelFormat.dwLayerMask = 0;
                pixelFormat.dwVisibleMask = 0;
                pixelFormat.dwDamageMask = 0;

                hDC = User.GetDC(form.Handle);
                if (hDC == IntPtr.Zero)
                {
                    closeOpenGLwindow();
                    MessageBox.Show("Can't create an OpenGL device context", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                intPixelFormat = Gdi.ChoosePixelFormat(hDC, ref pixelFormat);
                if (intPixelFormat == 0)
                {
                    closeOpenGLwindow();
                    MessageBox.Show("Can't find a suitable pixel format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (!Gdi.SetPixelFormat(hDC, intPixelFormat, ref pixelFormat))
                {
                    closeOpenGLwindow();
                    MessageBox.Show("Can't set the pixel format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                hRC = Wgl.wglCreateContext(hDC);
                if (hRC == IntPtr.Zero)
                {
                    closeOpenGLwindow();
                    MessageBox.Show("Can't create an OpenGL rendering context", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (!Wgl.wglMakeCurrent(hDC, hRC))
                {
                    closeOpenGLwindow();
                    MessageBox.Show("Can't activate the OpenGL rendering context", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                form.Location = new Point(775, 0);
                form.Show();
                form.Focus();
                form.BringToFront();
                form.WindowState = FormWindowState.Normal;
                form.FormClosed += new FormClosedEventHandler(FrmTexturePreview_FormClosed);

                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
                form.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));

                resizeOpenGLWindow(width, height);

                if (!initialiseOpenGL())
                {
                    closeOpenGLwindow();
                    MessageBox.Show("Failed to initialise OpenGL window", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                return true;
            }
            catch (Exception exception)
            {
                MessageBox.Show("Exception occured trying to creating texture preview windo: " + exception.Message + "\n" +
                    exception.StackTrace);
                return false;
            }
        }

        static void FrmTexturePreview_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.done = true;
        }

        public static bool render()
        {
            try
            {
                int[] viewport = new int[4];

                Gl.glGetIntegerv(Gl.GL_VIEWPORT, viewport);

                Gl.glMatrixMode(Gl.GL_PROJECTION);
                Gl.glLoadIdentity();
                Glu.gluPerspective(45, windowWidth / (double)windowHeight, 0.1, 100);

                orbitDistance = 2.5f;

                if (blockName == "Lilac" ||
                    blockName == "Large Fern" ||
                    blockName == "Peony" ||
                    blockName == "Piston Extended" ||
                    blockName == "Rose Bush" ||
                    blockName == "Tall Grass" ||
                    blockName == "Wooden Door" ||
                    blockName == "Iron Door" ||
                    blockName == "Bed" ||
                    blockName == "Double Chest" ||
                    blockName == "Double Trapped Chest" ||
                    blockName == "Spruce Door" ||
                    blockName == "Birch Door" ||
                    blockName == "Jungle Door" ||
                    blockName == "Acacia Door" ||
                    blockName == "Dark Oak Door")
                {
                    orbitDistance = 3.5f;
                }

                setEyePosition();

                Vector3 lookAt = new Vector3(0.0f, 0.0f, 0.0f);

                Glu.gluLookAt(eyePosition.x, eyePosition.y, eyePosition.z,
                    lookAt.x, lookAt.y, lookAt.z, 0.0, 1.0, 0.0);

                Gl.glMatrixMode(Gl.GL_MODELVIEW);
                Gl.glLoadIdentity();

                if (blockName == "Portal" ||
                    blockName == "Water Still" || blockName == "Water Flowing" ||
                    blockName == "Lava Still" || blockName == "Lava Flowing" ||
                    blockName == "Destroy")
                {
                    DateTime now = DateTime.Now;
                    double timeSinceChange = (now - blockChangeTime).TotalMilliseconds;

                    if (timeSinceChange > animationSpeed)
                    {
                        blockChangeTime = DateTime.Now;
                        frameIndex++;

                        if (blockName == "Lava Still")
                        {
                            frameIndex = frameIndex % (textureCount * 2 - 2);
                        }
                        else
                        {
                            frameIndex = frameIndex % textureCount;
                        }
                    }
                }

                if (blockName == "Fire")
                {
                    DateTime now = DateTime.Now;
                    double timeSinceChange = (now - blockChangeTime).TotalMilliseconds;

                    if (timeSinceChange > fireAnimationSpeed)
                    {
                        blockChangeTime = DateTime.Now;
                        frameIndex++;
                        frameIndex = frameIndex % 32;
                    }
                }

                Gl.glClearColor(0.05f, 0.05f, 0.05f, 1.0f);
                Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);

                if (blockName == "Wooden Door" || blockName == "Iron Door" ||
                    blockName == "Redstone Torch On" || blockName == "Ice" ||
                    blockName == "Trapdoor" || blockName == "Tripwire Hook" ||
                    blockName == "Beacon" || blockName == "Acacia Door" ||
                    blockName == "Jungle Door")
                {
                    Gl.glEnable(Gl.GL_CULL_FACE);
                }
                else
                {
                    Gl.glDisable(Gl.GL_CULL_FACE);
                }

                Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[0]);

                if (FrmMain.showCubes)
                {
                    //Gl.glPushMatrix();
                    //Gl.glTranslatef(1.0f / 32.0f, 1.0f / 32.0f, 1.0f / 32.0f);

                    //drawModel(1, 1, 1, new UVinfo());
                    //Gl.glPopMatrix();

                    /**/
                    List<Cube> cubes = TexturePaint3D.getCubePositions(FrmTexturePreview.modelType);

                    for (int a = 0; a < cubes.Count; a++)
                    {
                        Cube cubePosition = cubes[a];

                        if (cubePosition != null)
                        {
                            Gl.glPushMatrix();
                            Gl.glTranslatef(-1.0f / 2.0f + 1.0f / 16.0f * cubePosition.x + 1.0f / 32.0f,
                                -1.0f / 2.0f + 1.0f / 16.0f * cubePosition.y + 1.0f / 32.0f,
                                -1.0f / 2.0f + 1.0f / 16.0f * cubePosition.z + 1.0f / 32.0f);

                            UVinfo uvInfo = new UVinfo();
                            uvInfo.setTextureIndex(63);

                            if (selectedCube.x == cubePosition.x &&
                                selectedCube.y == cubePosition.y &&
                                selectedCube.z == cubePosition.z)
                            {
                                uvInfo.setTextureIndex(5);
                            }

                            drawModel(1, 1, 1, 0.0f, 0.0f, 0.0f, uvInfo, cubePosition);

                            Gl.glPopMatrix();
                        }
                    }
                }
                else
                {
                    if (modelType == ModelType.Block)
                    {
                        renderBlock();
                    }
                    else if (modelType == ModelType.BlockSTBF)
                    {
                        Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[0]);

                        Gl.glBegin(Gl.GL_QUADS);

                        //back face
                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(-0.5f, -0.5f, -0.5f);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(-0.5f, 0.5f, -0.5f);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(0.5f, 0.5f, -0.5f);

                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(0.5f, -0.5f, -0.5f);

                        //right face
                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(0.5f, -0.5f, -0.5f);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(0.5f, 0.5f, -0.5f);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(0.5f, 0.5f, 0.5f);

                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(0.5f, -0.5f, 0.5f);

                        //left face
                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(-0.5f, -0.5f, -0.5f);

                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(-0.5f, -0.5f, 0.5f);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(-0.5f, 0.5f, 0.5f);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(-0.5f, 0.5f, -0.5f);

                        Gl.glEnd();

                        Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[1]);

                        Gl.glBegin(Gl.GL_QUADS);

                        //top face
                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(-0.5f, 0.5f, -0.5f);

                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(-0.5f, 0.5f, 0.5f);

                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(0.5f, 0.5f, 0.5f);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(0.5f, 0.5f, -0.5f);

                        Gl.glEnd();

                        Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[2]);

                        Gl.glBegin(Gl.GL_QUADS);

                        //bottom face
                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(-0.5f, -0.5f, -0.5f);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(0.5f, -0.5f, -0.5f);

                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(0.5f, -0.5f, 0.5f);

                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(-0.5f, -0.5f, 0.5f);

                        Gl.glEnd();

                        Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[3]);

                        Gl.glBegin(Gl.GL_QUADS);

                        //front face
                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(-0.5f, -0.5f, 0.5f);

                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(0.5f, -0.5f, 0.5f);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(0.5f, 0.5f, 0.5f);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(-0.5f, 0.5f, 0.5f);

                        Gl.glEnd();
                    }
                    else if (modelType == ModelType.BlockTop)
                    {
                        Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[0]);

                        Gl.glBegin(Gl.GL_QUADS);

                        //front face
                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(-0.5f, -0.5f, 0.5f);

                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(0.5f, -0.5f, 0.5f);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(0.5f, 0.5f, 0.5f);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(-0.5f, 0.5f, 0.5f);

                        //back face
                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(-0.5f, -0.5f, -0.5f);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(-0.5f, 0.5f, -0.5f);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(0.5f, 0.5f, -0.5f);

                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(0.5f, -0.5f, -0.5f);

                        //right face
                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(0.5f, -0.5f, -0.5f);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(0.5f, 0.5f, -0.5f);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(0.5f, 0.5f, 0.5f);

                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(0.5f, -0.5f, 0.5f);

                        //left face
                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(-0.5f, -0.5f, -0.5f);

                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(-0.5f, -0.5f, 0.5f);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(-0.5f, 0.5f, 0.5f);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(-0.5f, 0.5f, -0.5f);

                        //bottom face
                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(-0.5f, -0.5f, -0.5f);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(0.5f, -0.5f, -0.5f);

                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(0.5f, -0.5f, 0.5f);

                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(-0.5f, -0.5f, 0.5f);

                        Gl.glEnd();

                        Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[1]);

                        Gl.glBegin(Gl.GL_QUADS);

                        //top face
                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(-0.5f, 0.5f, -0.5f);

                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(-0.5f, 0.5f, 0.5f);

                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(0.5f, 0.5f, 0.5f);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(0.5f, 0.5f, -0.5f);

                        Gl.glEnd();
                    }
                    else if (modelType == ModelType.BlockSameTopAndBottom)
                    {
                        Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[0]);

                        Gl.glBegin(Gl.GL_QUADS);

                        //front face
                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(-0.5f, -0.5f, 0.5f);

                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(0.5f, -0.5f, 0.5f);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(0.5f, 0.5f, 0.5f);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(-0.5f, 0.5f, 0.5f);

                        //back face
                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(-0.5f, -0.5f, -0.5f);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(-0.5f, 0.5f, -0.5f);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(0.5f, 0.5f, -0.5f);

                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(0.5f, -0.5f, -0.5f);

                        //right face
                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(0.5f, -0.5f, -0.5f);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(0.5f, 0.5f, -0.5f);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(0.5f, 0.5f, 0.5f);

                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(0.5f, -0.5f, 0.5f);

                        //left face
                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(-0.5f, -0.5f, -0.5f);

                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(-0.5f, -0.5f, 0.5f);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(-0.5f, 0.5f, 0.5f);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(-0.5f, 0.5f, -0.5f);

                        Gl.glEnd();

                        Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[1]);

                        Gl.glBegin(Gl.GL_QUADS);

                        //top face
                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(-0.5f, 0.5f, -0.5f);

                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(-0.5f, 0.5f, 0.5f);

                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(0.5f, 0.5f, 0.5f);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(0.5f, 0.5f, -0.5f);

                        //bottom face
                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(-0.5f, -0.5f, -0.5f);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(0.5f, -0.5f, -0.5f);

                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(0.5f, -0.5f, 0.5f);

                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(-0.5f, -0.5f, 0.5f);

                        Gl.glEnd();
                    }
                    else if (modelType == ModelType.BlockDiffTopAndBottom)
                    {
                        Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[0]);

                        Gl.glBegin(Gl.GL_QUADS);

                        //front face
                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(-0.5f, -0.5f, 0.5f);

                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(0.5f, -0.5f, 0.5f);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(0.5f, 0.5f, 0.5f);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(-0.5f, 0.5f, 0.5f);

                        //back face
                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(-0.5f, -0.5f, -0.5f);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(-0.5f, 0.5f, -0.5f);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(0.5f, 0.5f, -0.5f);

                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(0.5f, -0.5f, -0.5f);

                        //right face
                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(0.5f, -0.5f, -0.5f);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(0.5f, 0.5f, -0.5f);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(0.5f, 0.5f, 0.5f);

                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(0.5f, -0.5f, 0.5f);

                        //left face
                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(-0.5f, -0.5f, -0.5f);

                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(-0.5f, -0.5f, 0.5f);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(-0.5f, 0.5f, 0.5f);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(-0.5f, 0.5f, -0.5f);

                        Gl.glEnd();

                        Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[1]);

                        Gl.glBegin(Gl.GL_QUADS);

                        //top face
                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(-0.5f, 0.5f, -0.5f);

                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(-0.5f, 0.5f, 0.5f);

                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(0.5f, 0.5f, 0.5f);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(0.5f, 0.5f, -0.5f);

                        Gl.glEnd();

                        Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[2]);

                        Gl.glBegin(Gl.GL_QUADS);

                        //bottom face
                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(-0.5f, -0.5f, -0.5f);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(0.5f, -0.5f, -0.5f);

                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(0.5f, -0.5f, 0.5f);

                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(-0.5f, -0.5f, 0.5f);

                        Gl.glEnd();
                    }
                    else if (modelType == ModelType.BlockFrontTopAndBottom)
                    {
                        Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[2]);

                        Gl.glBegin(Gl.GL_QUADS);

                        //front face
                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(-0.5f, -0.5f, 0.5f);

                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(0.5f, -0.5f, 0.5f);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(0.5f, 0.5f, 0.5f);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(-0.5f, 0.5f, 0.5f);

                        Gl.glEnd();

                        Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[0]);

                        Gl.glBegin(Gl.GL_QUADS);

                        //back face
                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(-0.5f, -0.5f, -0.5f);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(-0.5f, 0.5f, -0.5f);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(0.5f, 0.5f, -0.5f);

                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(0.5f, -0.5f, -0.5f);

                        //right face
                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(0.5f, -0.5f, -0.5f);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(0.5f, 0.5f, -0.5f);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(0.5f, 0.5f, 0.5f);

                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(0.5f, -0.5f, 0.5f);

                        //left face
                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(-0.5f, -0.5f, -0.5f);

                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(-0.5f, -0.5f, 0.5f);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(-0.5f, 0.5f, 0.5f);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(-0.5f, 0.5f, -0.5f);

                        Gl.glEnd();

                        Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[1]);

                        Gl.glBegin(Gl.GL_QUADS);

                        //top face
                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(-0.5f, 0.5f, -0.5f);

                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(-0.5f, 0.5f, 0.5f);

                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(0.5f, 0.5f, 0.5f);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(0.5f, 0.5f, -0.5f);

                        Gl.glEnd();

                        Gl.glBegin(Gl.GL_QUADS);

                        //bottom face
                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(-0.5f, -0.5f, -0.5f);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(0.5f, -0.5f, -0.5f);

                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(0.5f, -0.5f, 0.5f);

                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(-0.5f, -0.5f, 0.5f);

                        Gl.glEnd();
                    }
                    else if (modelType == ModelType.PlaneCross)
                    {
                        Gl.glBegin(Gl.GL_QUADS);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(-0.5f, 0.5f, -0.5f);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(0.5f, 0.5f, 0.5f);

                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(0.5f, -0.5f, 0.5f);

                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(-0.5f, -0.5f, -0.5f);

                        Gl.glEnd();

                        Gl.glBegin(Gl.GL_QUADS);

                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(0.5f, -0.5f, -0.5f);

                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(-0.5f, -0.5f, 0.5f);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(-0.5f, 0.5f, 0.5f);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(0.5f, 0.5f, -0.5f);

                        Gl.glEnd();
                    }
                    else if (modelType == ModelType.FrontFace)
                    {
                        Gl.glBegin(Gl.GL_QUADS);

                        //front face
                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(-0.5f, -0.5f, 0);

                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(0.5f, -0.5f, 0);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(0.5f, 0.5f, 0);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(-0.5f, 0.5f, 0);

                        Gl.glEnd();
                    }
                    else if (modelType == ModelType.TopFace)
                    {
                        Gl.glBegin(Gl.GL_QUADS);

                        //top face
                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(-0.5f, 0, -0.5f);

                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(-0.5f, 0, 0.5f);

                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(0.5f, 0, 0.5f);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(0.5f, 0, -0.5f);

                        Gl.glEnd();
                    }
                    if (modelType == ModelType.GrassBlock)
                    {
                        Gl.glBegin(Gl.GL_QUADS);

                        //front face
                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(-0.5f, -0.5f, 0.5f);

                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(0.5f, -0.5f, 0.5f);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(0.5f, 0.5f, 0.5f);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(-0.5f, 0.5f, 0.5f);

                        Gl.glEnd();

                        Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[0]);

                        Gl.glBegin(Gl.GL_QUADS);

                        //back face
                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(-0.5f, -0.5f, -0.5f);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(-0.5f, 0.5f, -0.5f);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(0.5f, 0.5f, -0.5f);

                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(0.5f, -0.5f, -0.5f);

                        //right face
                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(0.5f, -0.5f, -0.5f);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(0.5f, 0.5f, -0.5f);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(0.5f, 0.5f, 0.5f);

                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(0.5f, -0.5f, 0.5f);

                        //left face
                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(-0.5f, -0.5f, -0.5f);

                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(-0.5f, -0.5f, 0.5f);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(-0.5f, 0.5f, 0.5f);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(-0.5f, 0.5f, -0.5f);

                        Gl.glEnd();

                        Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[1]);

                        Gl.glBegin(Gl.GL_QUADS);

                        //top face
                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(-0.5f, 0.5f, -0.5f);

                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(-0.5f, 0.5f, 0.5f);

                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(0.5f, 0.5f, 0.5f);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(0.5f, 0.5f, -0.5f);

                        Gl.glEnd();

                        Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[2]);

                        Gl.glBegin(Gl.GL_QUADS);

                        //bottom face
                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(-0.5f, -0.5f, -0.5f);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(0.5f, -0.5f, -0.5f);

                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(0.5f, -0.5f, 0.5f);

                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(-0.5f, -0.5f, 0.5f);

                        Gl.glEnd();
                    }
                    else if (modelType == ModelType.Cactus)
                    {
                        Gl.glBegin(Gl.GL_QUADS);

                        //front face
                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(-0.5f, -0.5f, 0.5f - 1.0f / 16.0f);

                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(0.5f, -0.5f, 0.5f - 1.0f / 16.0f);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(0.5f, 0.5f, 0.5f - 1.0f / 16.0f);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(-0.5f, 0.5f, 0.5f - 1.0f / 16.0f);

                        //back face
                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(-0.5f, -0.5f, -0.5f + 1.0f / 16.0f);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(-0.5f, 0.5f, -0.5f + 1.0f / 16.0f);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(0.5f, 0.5f, -0.5f + 1.0f / 16.0f);

                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(0.5f, -0.5f, -0.5f + 1.0f / 16.0f);

                        //right face
                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(0.5f - 1.0f / 16.0f, -0.5f, -0.5f);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(0.5f - 1.0f / 16.0f, 0.5f, -0.5f);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(0.5f - 1.0f / 16.0f, 0.5f, 0.5f);

                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(0.5f - 1.0f / 16.0f, -0.5f, 0.5f);

                        //left face
                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(-0.5f + 1.0f / 16.0f, -0.5f, -0.5f);

                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(-0.5f + 1.0f / 16.0f, -0.5f, 0.5f);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(-0.5f + 1.0f / 16.0f, 0.5f, 0.5f);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(-0.5f + 1.0f / 16.0f, 0.5f, -0.5f);

                        Gl.glEnd();

                        if (textureCount >= 2)
                        {
                            Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[1]);
                        }

                        Gl.glBegin(Gl.GL_QUADS);

                        //top face
                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(-0.5f, 0.5f, -0.5f);

                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(-0.5f, 0.5f, 0.5f);

                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(0.5f, 0.5f, 0.5f);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(0.5f, 0.5f, -0.5f);

                        Gl.glEnd();

                        if (textureCount >= 3)
                        {
                            Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[2]);
                        }

                        Gl.glBegin(Gl.GL_QUADS);

                        //bottom face
                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(-0.5f, -0.5f, -0.5f);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(0.5f, -0.5f, -0.5f);

                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(0.5f, -0.5f, 0.5f);

                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(-0.5f, -0.5f, 0.5f);

                        Gl.glEnd();
                    }
                    else if (modelType == ModelType.EndPortalBlock)
                    {
                        Gl.glBegin(Gl.GL_QUADS);

                        //front face
                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(-0.5f, -0.5f, 0.5f);

                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(0.5f, -0.5f, 0.5f);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(0.5f, 0.5f, 0.5f);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(-0.5f, 0.5f, 0.5f);

                        //back face
                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(-0.5f, -0.5f, -0.5f);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(-0.5f, 0.5f, -0.5f);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(0.5f, 0.5f, -0.5f);

                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(0.5f, -0.5f, -0.5f);

                        //right face
                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(0.5f, -0.5f, -0.5f);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(0.5f, 0.5f, -0.5f);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(0.5f, 0.5f, 0.5f);

                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(0.5f, -0.5f, 0.5f);

                        //left face
                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(-0.5f, -0.5f, -0.5f);

                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(-0.5f, -0.5f, 0.5f);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(-0.5f, 0.5f, 0.5f);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(-0.5f, 0.5f, -0.5f);

                        Gl.glEnd();

                        if (textureCount >= 2)
                        {
                            Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[1]);
                        }

                        Gl.glBegin(Gl.GL_QUADS);

                        float yOffset = 6.0f / 32.0f;

                        //top face
                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(-0.5f, 0.5f - yOffset, -0.5f);

                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(-0.5f, 0.5f - yOffset, 0.5f);

                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(0.5f, 0.5f - yOffset, 0.5f);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(0.5f, 0.5f - yOffset, -0.5f);

                        Gl.glEnd();

                        if (textureCount >= 3)
                        {
                            Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[2]);
                        }

                        Gl.glBegin(Gl.GL_QUADS);

                        //bottom face
                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(-0.5f, -0.5f, -0.5f);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(0.5f, -0.5f, -0.5f);

                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(0.5f, -0.5f, 0.5f);

                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(-0.5f, -0.5f, 0.5f);

                        Gl.glEnd();
                    }
                    else if (modelType == ModelType.CocoaStage0)
                    {
                        UV front = new UV(11.0f / 16.0f, 15.0f / 16.0f, 1 - 9.0f / 16.0f, 1 - 4.0f / 16.0f);
                        UV back = new UV(11.0f / 16.0f, 15.0f / 16.0f, 1 - 9.0f / 16.0f, 1 - 4.0f / 16.0f);
                        UV left = new UV(11.0f / 16.0f, 15.0f / 16.0f, 1 - 9.0f / 16.0f, 1 - 4.0f / 16.0f);
                        UV right = new UV(11.0f / 16.0f, 15.0f / 16.0f, 1 - 9.0f / 16.0f, 1 - 4.0f / 16.0f);
                        UV top = new UV(0.0f, 4.0f / 16.0f, 1.0f - 4.0f / 16.0f, 1.0f);
                        UV bottom = new UV(0.0f, 4.0f / 16.0f, 1.0f - 4.0f / 16.0f, 1.0f);
                        UVinfo cocoaUV = new UVinfo(front, back, left, right, top, bottom);

                        drawModel(4.0f, 5.0f, 4.0f, 0.0f, -1.0f / 32.0f, 0.0f, cocoaUV);

                        //draw stem
                        Gl.glBegin(Gl.GL_QUADS);

                        float yOffset = 9.0f / 32.0f;
                        float zOffset = -2.0f / 32.0f;

                        Gl.glTexCoord2f(12.0f / 16.0f, 1.0f - 4.0f / 16.0f); //0, 0
                        Gl.glVertex3f(0.0f, -4.0f / 32.0f + yOffset, 4.0f / 32.0f + zOffset);

                        Gl.glTexCoord2f(1.0f, 1.0f - 4.0f / 16.0f); //1, 0
                        Gl.glVertex3f(0.0f, -4.0f / 32.0f + yOffset, -4.0f / 32.0f + zOffset);

                        Gl.glTexCoord2f(1.0f, 1.0f); //1, 1
                        Gl.glVertex3f(0.0f, 4.0f / 32.0f + yOffset, -4.0f / 32.0f + zOffset);

                        Gl.glTexCoord2f(12.0f / 16.0f, 1.0f); //0, 1
                        Gl.glVertex3f(0.0f, 4.0f / 32.0f + yOffset, 4.0f / 32.0f + zOffset);

                        Gl.glEnd();
                    }
                    else if (modelType == ModelType.CocoaStage1)
                    {
                        UV front = new UV(9.0f / 16.0f, 15.0f / 16.0f, 1 - 11.0f / 16.0f, 1 - 4.0f / 16.0f);
                        UV back = new UV(9.0f / 16.0f, 15.0f / 16.0f, 1 - 11.0f / 16.0f, 1 - 4.0f / 16.0f);
                        UV left = new UV(9.0f / 16.0f, 15.0f / 16.0f, 1 - 11.0f / 16.0f, 1 - 4.0f / 16.0f);
                        UV right = new UV(9.0f / 16.0f, 15.0f / 16.0f, 1 - 11.0f / 16.0f, 1 - 4.0f / 16.0f);
                        UV top = new UV(0.0f, 6.0f / 16.0f, 1.0f - 6.0f / 16.0f, 1.0f);
                        UV bottom = new UV(0.0f, 6.0f / 16.0f, 1.0f - 6.0f / 16.0f, 1.0f);
                        UVinfo cocoaUV = new UVinfo(front, back, left, right, top, bottom);

                        drawModel(6.0f, 7.0f, 6.0f, 0.0f, -1.0f / 32.0f, 0.0f, cocoaUV);

                        //draw stem
                        Gl.glBegin(Gl.GL_QUADS);

                        float yOffset = 11.0f / 32.0f;
                        float zOffset = -4.0f / 32.0f;

                        Gl.glTexCoord2f(12.0f / 16.0f, 1.0f - 4.0f / 16.0f); //0, 0
                        Gl.glVertex3f(0.0f, -4.0f / 32.0f + yOffset, 4.0f / 32.0f + zOffset);

                        Gl.glTexCoord2f(1.0f, 1.0f - 4.0f / 16.0f); //1, 0
                        Gl.glVertex3f(0.0f, -4.0f / 32.0f + yOffset, -4.0f / 32.0f + zOffset);

                        Gl.glTexCoord2f(1.0f, 1.0f); //1, 1
                        Gl.glVertex3f(0.0f, 4.0f / 32.0f + yOffset, -4.0f / 32.0f + zOffset);

                        Gl.glTexCoord2f(12.0f / 16.0f, 1.0f); //0, 1
                        Gl.glVertex3f(0.0f, 4.0f / 32.0f + yOffset, 4.0f / 32.0f + zOffset);

                        Gl.glEnd();
                    }
                    else if (modelType == ModelType.CocoaStage2)
                    {
                        UV front = new UV(7.0f / 16.0f, 15.0f / 16.0f, 3.0f / 16.0f, 12.0f / 16.0f);
                        UV back = new UV(7.0f / 16.0f, 15.0f / 16.0f, 3.0f / 16.0f, 12.0f / 16.0f);
                        UV left = new UV(7.0f / 16.0f, 15.0f / 16.0f, 3.0f / 16.0f, 12.0f / 16.0f);
                        UV right = new UV(7.0f / 16.0f, 15.0f / 16.0f, 3.0f / 16.0f, 12.0f / 16.0f);
                        UV top = new UV(0.0f, 7.0f / 16.0f, 1.0f - 7.0f / 16.0f, 1.0f);
                        UV bottom = new UV(0.0f, 7.0f / 16.0f, 1.0f - 7.0f / 16.0f, 1.0f);
                        UVinfo cocoaUV = new UVinfo(front, back, left, right, top, bottom);

                        drawModel(8.0f, 9.0f, 8.0f, 0.0f, -1.0f / 32.0f, 0.0f, cocoaUV);

                        //draw stem
                        Gl.glBegin(Gl.GL_QUADS);

                        float yOffset = 13.0f / 32.0f;
                        float zOffset = -6.0f / 32.0f;

                        Gl.glTexCoord2f(12.0f / 16.0f, 1.0f - 4.0f / 16.0f); //0, 0
                        Gl.glVertex3f(0.0f, -4.0f / 32.0f + yOffset, 4.0f / 32.0f + zOffset);

                        Gl.glTexCoord2f(1.0f, 1.0f - 4.0f / 16.0f); //1, 0
                        Gl.glVertex3f(0.0f, -4.0f / 32.0f + yOffset, -4.0f / 32.0f + zOffset);

                        Gl.glTexCoord2f(1.0f, 1.0f); //1, 1
                        Gl.glVertex3f(0.0f, 4.0f / 32.0f + yOffset, -4.0f / 32.0f + zOffset);

                        Gl.glTexCoord2f(12.0f / 16.0f, 1.0f); //0, 1
                        Gl.glVertex3f(0.0f, 4.0f / 32.0f + yOffset, 4.0f / 32.0f + zOffset);

                        Gl.glEnd();
                    }
                    else if (modelType == ModelType.Chest)
                    {
                        float yOffset = -3.0f;

                        Gl.glPushMatrix();

                        UV lidFront = new UV(14, 14, 27, 18, 64, 64);
                        UV lidBack = new UV(42, 14, 55, 18, 64, 64);
                        UV lidLeft = new UV(0, 14, 13, 18, 64, 64);
                        UV lidRight = new UV(28, 14, 41, 18, 64, 64);
                        UV lidTop = new UV(14, 0, 27, 13, 64, 64);
                        UV lidBottom = new UV(28, 0, 41, 13, 64, 64);
                        UVinfo lid = new UVinfo(lidFront, lidBack, lidLeft, lidRight,
                            lidTop, lidBottom);

                        drawModel(14.0f, 5.0f, 14.0f, 0.0f, (6.5f + yOffset) / 16.0f, 0.0f, lid);

                        Gl.glPopMatrix();

                        UV chestFront = new UV(14, 33, 27, 42, 64, 64);
                        UV chestBack = new UV(42, 33, 55, 42, 64, 64);
                        UV chestLeft = new UV(0, 33, 13, 42, 64, 64);
                        UV chestRight = new UV(28, 33, 41, 42, 64, 64);
                        UV chestTop = new UV(14, 19, 27, 32, 64, 64);
                        UV chestBottom = new UV(28, 19, 41, 32, 64, 64);
                        UVinfo chest = new UVinfo(chestFront, chestBack, chestLeft, chestRight,
                            chestTop, chestBottom);

                        drawModel(14.0f, 10.0f, 14.0f, 0.0f, yOffset / 16.0f, 0.0f, chest);

                        UV latchFront = new UV(1, 1, 2, 4, 64, 64);
                        UV latchBack = new UV(3, 1, 4, 4, 64, 64);
                        UV latchLeft = new UV(0, 1, 0, 4, 64, 64);
                        UV latchRight = new UV(5, 1, 5, 4, 64, 64);
                        UV latchTop = new UV(1, 0, 2, 0, 64, 64);
                        UV latchBottom = new UV(3, 0, 4, 0, 64, 64, true, false);
                        UVinfo latch = new UVinfo(latchFront, latchBack, latchLeft, latchRight,
                            latchTop, latchBottom);

                        drawModel(2.0f, 4.0f, 1.0f, 0.0f, (yOffset + 4.0f) / 16.0f, 7.5f / 16.0f, latch);
                    }
                    else if (modelType == ModelType.DoubleChest)
                    {
                        float yOffset = -3.0f;

                        Gl.glPushMatrix();

                        UV lidFront = new UV(14, 14, 43, 18, 128, 64);
                        UV lidBack = new UV(58, 14, 87, 18, 128, 64);
                        UV lidLeft = new UV(0, 14, 13, 18, 128, 64);
                        UV lidRight = new UV(44, 14, 57, 18, 128, 64);
                        UV lidTop = new UV(14, 0, 43, 13, 128, 64);
                        UV lidBottom = new UV(44, 0, 73, 13, 128, 64);
                        UVinfo lid = new UVinfo(lidFront, lidBack, lidLeft, lidRight,
                            lidTop, lidBottom);

                        drawModel(30.0f, 4.5f, 14.0f, 0.0f, (11.0f + 2 * yOffset) / 32.0f, 0.0f, lid);

                        Gl.glPopMatrix();

                        UV chestFront = new UV(14, 33, 43, 42, 128, 64);
                        UV chestBack = new UV(58, 33, 87, 42, 128, 64);
                        UV chestLeft = new UV(0, 33, 13, 42, 128, 64);
                        UV chestRight = new UV(44, 33, 57, 42, 128, 64);
                        UV chestTop = new UV(14, 19, 43, 32, 128, 64);
                        UV chestBottom = new UV(44, 19, 73, 32, 128, 64);
                        UVinfo chest = new UVinfo(chestFront, chestBack, chestLeft, chestRight,
                            chestTop, chestBottom);

                        drawModel(30.0f, 9.0f, 14.0f, 0.0f, (2 * yOffset - 1.0f) / 32.0f, 0.0f, chest);

                        UV latchFront = new UV(1, 1, 2, 4, 128, 64);
                        UV latchBack = new UV(3, 1, 4, 4, 128, 64);
                        UV latchLeft = new UV(0, 1, 0, 4, 128, 64);
                        UV latchRight = new UV(5, 1, 5, 4, 128, 64);
                        UV latchTop = new UV(1, 0, 2, 0, 128, 64);
                        UV latchBottom = new UV(3, 0, 4, 0, 128, 64, true, false);
                        UVinfo latch = new UVinfo(latchFront, latchBack, latchLeft, latchRight,
                            latchTop, latchBottom);

                        drawModel(2.0f, 4.0f, 1.0f, 0.0f, (2 * yOffset + 6.0f) / 32.0f, 7.5f / 16.0f, latch);
                    }
                    else if (modelType == ModelType.Torch)
                    {
                        UV torchFront = new UV(7, 6, 8, 15, 16, 16);
                        UV torchBack = new UV(7, 6, 8, 15, 16, 16);
                        UV torchLeft = new UV(7, 6, 8, 15, 16, 16);
                        UV torchRight = new UV(7, 6, 8, 15, 16, 16);
                        UV torchTop = new UV(7, 6, 7, 6, 16, 16);
                        UV torchBottom = new UV(7, 6, 7, 6, 16, 16);
                        UVinfo torch = new UVinfo(torchFront, torchBack, torchLeft, torchRight,
                            torchTop, torchBottom);

                        drawModel(2.0f, 10.0f, 2.0f, torch);
                    }
                    else if (modelType == ModelType.RedstoneTorchOn)
                    {
                        UV torchFront = new UV(7, 6, 8, 15, 16, 16);
                        UV torchBack = new UV(7, 6, 8, 15, 16, 16);
                        UV torchLeft = new UV(7, 6, 8, 15, 16, 16);
                        UV torchRight = new UV(7, 6, 8, 15, 16, 16);
                        UV torchTop = new UV(7, 6, 8, 7, 16, 16);
                        UV torchBottom = new UV(7, 6, 8, 7, 16, 16);
                        UVinfo torch = new UVinfo(torchFront, torchBack, torchLeft, torchRight,
                            torchTop, torchBottom);

                        drawModelDoor(2.0f, 10.0f, 2.0f, 0.0f, 0.0f, 0.0f, torch, true, true);

                        drawTorchPlanes(1.0f, 0.0f, 0.0f, 0.0f);
                    }
                    else if (modelType == ModelType.Bed)
                    {
                        //first half
                        Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[1]);

                        Gl.glBegin(Gl.GL_QUADS);

                        //left face
                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(0.0f, -0.5f, -0.5f);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(0.0f, 0.5f, -0.5f);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(1.0f, 0.5f, -0.5f);

                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(1.0f, -0.5f, -0.5f);

                        //right face
                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(0.0f, -0.5f, 0.5f);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(0.0f, 0.5f, 0.5f);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(1.0f, 0.5f, 0.5f);

                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(1.0f, -0.5f, 0.5f);

                        Gl.glEnd();

                        Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[3]);

                        Gl.glBegin(Gl.GL_QUADS);

                        //front face
                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(1.0f, -0.5f, -0.5f);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(1.0f, 0.5f, -0.5f);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(1.0f, 0.5f, 0.5f);

                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(1.0f, -0.5f, 0.5f);

                        Gl.glEnd();

                        Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[0]);

                        Gl.glBegin(Gl.GL_QUADS);

                        //top face
                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(0.0f, 2.0f / 32.0f, -0.5f);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(0.0f, 2.0f / 32.0f, 0.5f);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(1.0f, 2.0f / 32.0f, 0.5f);

                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(1.0f, 2.0f / 32.0f, -0.5f);

                        Gl.glEnd();

                        if (textureCount >= 3)
                        {
                            Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[2]);
                        }

                        Gl.glBegin(Gl.GL_QUADS);

                        //bottom face
                        Gl.glTexCoord2f(1.0f, 1.0f);
                        Gl.glVertex3f(0.0f, -0.5f + 6.0f / 32.0f, -0.5f);

                        Gl.glTexCoord2f(0.0f, 1.0f);
                        Gl.glVertex3f(1.0f, -0.5f + 6.0f / 32.0f, -0.5f);

                        Gl.glTexCoord2f(0.0f, 0.0f);
                        Gl.glVertex3f(1.0f, -0.5f + 6.0f / 32.0f, 0.5f);

                        Gl.glTexCoord2f(1.0f, 0.0f);
                        Gl.glVertex3f(0.0f, -0.5f + 6.0f / 32.0f, 0.5f);

                        Gl.glEnd();

                        //second half
                        Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[5]);

                        Gl.glBegin(Gl.GL_QUADS);

                        //left face
                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(-1.0f, -0.5f, -0.5f);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(-1.0f, 0.5f, -0.5f);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(0.0f, 0.5f, -0.5f);

                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(0.0f, -0.5f, -0.5f);

                        //right face
                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(-1.0f, -0.5f, 0.5f);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(-1.0f, 0.5f, 0.5f);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(0.0f, 0.5f, 0.5f);

                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(0.0f, -0.5f, 0.5f);

                        Gl.glEnd();

                        Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[4]);

                        Gl.glBegin(Gl.GL_QUADS);

                        //back face
                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(-1.0f, -0.5f, -0.5f);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(-1.0f, 0.5f, -0.5f);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(-1.0f, 0.5f, 0.5f);

                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(-1.0f, -0.5f, 0.5f);

                        Gl.glEnd();

                        Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[6]);

                        Gl.glBegin(Gl.GL_QUADS);

                        //top face
                        Gl.glTexCoord2f(0.0f, 0.0f);
                        Gl.glVertex3f(-1.0f, 2.0f / 32.0f, -0.5f);

                        Gl.glTexCoord2f(0.0f, 1.0f);
                        Gl.glVertex3f(-1.0f, 2.0f / 32.0f, 0.5f);

                        Gl.glTexCoord2f(1.0f, 1.0f);
                        Gl.glVertex3f(0.0f, 2.0f / 32.0f, 0.5f);

                        Gl.glTexCoord2f(1.0f, 0.0f);
                        Gl.glVertex3f(0.0f, 2.0f / 32.0f, -0.5f);

                        Gl.glEnd();

                        Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[2]);

                        Gl.glBegin(Gl.GL_QUADS);

                        //bottom face
                        Gl.glTexCoord2f(1.0f, 1.0f);
                        Gl.glVertex3f(-1.0f, -0.5f + 6.0f / 32.0f, -0.5f);

                        Gl.glTexCoord2f(0.0f, 1.0f);
                        Gl.glVertex3f(0.0f, -0.5f + 6.0f / 32.0f, -0.5f);

                        Gl.glTexCoord2f(0.0f, 0.0f);
                        Gl.glVertex3f(0.0f, -0.5f + 6.0f / 32.0f, 0.5f);

                        Gl.glTexCoord2f(1.0f, 0.0f);
                        Gl.glVertex3f(-1.0f, -0.5f + 6.0f / 32.0f, 0.5f);

                        Gl.glEnd();
                    }
                    else if (modelType == ModelType.PistonExtended)
                    {
                        //arm
                        UV pistonArmFront = new UV(0, 0, 15, 3, 16, 16);
                        UV pistonArmBack = new UV(0, 0, 15, 3, 16, 16, true, false);
                        UV pistonArmLeft = new UV(0, 0, 0, 0, 16, 16); //invisible
                        UV pistonArmRight = new UV(0, 0, 0, 0, 16, 16); //invisible
                        UV pistonArmTop = new UV(0, 0, 15, 3, 16, 16);
                        UV pistonArmBottom = new UV(0, 0, 15, 3, 16, 16, true, true);

                        UVinfo pistonArm = new UVinfo(pistonArmFront, pistonArmBack, pistonArmLeft, pistonArmRight,
                            pistonArmTop, pistonArmBottom);

                        drawModel(16.0f, 4.0f, 4.0f, pistonArm);

                        UV pistonPusherFront = new UV(0, 0, 15, 3, 16, 16, true);
                        UV pistonPusherBack = new UV(0, 0, 15, 3, 0, 16, 16, true, true, false);
                        UV pistonPusherLeft = new UV(0, 0, 15, 15, 1, 16, 16);
                        UV pistonPusherRight = new UV(0, 0, 15, 15, 1, 16, 16);
                        UV pistonPusherTop = new UV(0, 0, 15, 3, 16, 16, true);
                        UV pistonPusherBottom = new UV(0, 0, 15, 3, 0, 16, 16, true, true, false);

                        UVinfo pistonPusher = new UVinfo(pistonPusherFront, pistonPusherBack, pistonPusherLeft, pistonPusherRight,
                            pistonPusherTop, pistonPusherBottom);

                        drawModel(4.0f, 16.0f, 16.0f, 10.0f / 16.0f, 0.0f, 0.0f, pistonPusher);

                        UV pistonBaseFront = new UV(0, 4, 15, 15, 0, 16, 16, true);
                        UV pistonBaseBack = new UV(0, 4, 15, 15, 0, 16, 16, true, true, false);
                        UV pistonBaseLeft = new UV(0, 0, 15, 15, 2, 16, 16);
                        UV pistonBaseRight = new UV(0, 0, 15, 15, 3, 16, 16);
                        UV pistonBaseTop = new UV(0, 4, 15, 15, 0, 16, 16, true);
                        UV pistonBaseBottom = new UV(0, 4, 15, 15, 0, 16, 16, true, true, false);

                        UVinfo pistonBase = new UVinfo(pistonBaseFront, pistonBaseBack, pistonBaseLeft, pistonBaseRight,
                            pistonBaseTop, pistonBaseBottom);

                        drawModel(12.0f, 16.0f, 16.0f, -14.0f / 16.0f, 0.0f, 0.0f, pistonBase);
                    }
                    else if (modelType == ModelType.StoneSlab)
                    {
                        UV slabFront = new UV(0, 8, 15, 15, 0, 16, 16);
                        UV slabBack = new UV(0, 8, 15, 15, 0, 16, 16);
                        UV slabLeft = new UV(0, 8, 15, 15, 0, 16, 16);
                        UV slabRight = new UV(0, 8, 15, 15, 0, 16, 16);
                        UV slabTop = new UV(0, 0, 15, 15, 1, 16, 16);
                        UV slabBottom = new UV(0, 0, 15, 15, 1, 16, 16);

                        UVinfo slab = new UVinfo(slabFront, slabBack, slabLeft, slabRight,
                            slabTop, slabBottom);

                        drawModel(16.0f, 8.0f, 16.0f, slab);
                    }
                    else if (modelType == ModelType.DoubleStoneSlab)
                    {
                        UV slabFront = new UV(0, 0, 15, 15, 0, 16, 16);
                        UV slabBack = new UV(0, 0, 15, 15, 0, 16, 16);
                        UV slabLeft = new UV(0, 0, 15, 15, 0, 16, 16);
                        UV slabRight = new UV(0, 0, 15, 15, 0, 16, 16);
                        UV slabTop = new UV(0, 0, 15, 15, 1, 16, 16);
                        UV slabBottom = new UV(0, 0, 15, 15, 1, 16, 16);

                        UVinfo slab = new UVinfo(slabFront, slabBack, slabLeft, slabRight,
                            slabTop, slabBottom);

                        drawModel(16.0f, 16.0f, 16.0f, slab);
                    }
                    else if (modelType == ModelType.Slab)
                    {
                        UV slabFront = new UV(0, 8, 15, 15, 0, 16, 16);
                        UV slabBack = new UV(0, 8, 15, 15, 0, 16, 16);
                        UV slabLeft = new UV(0, 8, 15, 15, 0, 16, 16);
                        UV slabRight = new UV(0, 8, 15, 15, 0, 16, 16);
                        UV slabTop = new UV(0, 0, 15, 15, 0, 16, 16);
                        UV slabBottom = new UV(0, 0, 15, 15, 0, 16, 16);

                        UVinfo slab = new UVinfo(slabFront, slabBack, slabLeft, slabRight,
                            slabTop, slabBottom);

                        drawModel(16.0f, 8.0f, 16.0f, slab);
                    }
                    else if (modelType == ModelType.Stairs)
                    {
                        //top left
                        UV stairTopLeftFront = new UV(0, 0, 7, 7, 0, 16, 16);
                        UV stairTopLeftBack = new UV(8, 0, 15, 7, 0, 16, 16);
                        UV stairTopLeftLeft = new UV(0, 0, 15, 7, 0, 16, 16);
                        UV stairTopLeftRight = new UV(0, 0, 15, 7, 0, 16, 16);
                        UV stairTopLeftTop = new UV(0, 0, 15, 7, 0, 16, 16, true, true, true);
                        UV stairTopLeftBottom = new UV(0, 0, 15, 15, 5, 16, 16);

                        UVinfo stairTopLeft = new UVinfo(stairTopLeftFront, stairTopLeftBack, stairTopLeftLeft, stairTopLeftRight,
                            stairTopLeftTop, stairTopLeftBottom);

                        drawModel(8.0f, 8.0f, 16.0f, -4.0f / 16.0f, 4.0f / 16.0f, 0.0f, stairTopLeft);

                        //bottom right
                        UV stairBottomRightFront = new UV(8, 8, 15, 15, 0, 16, 16);
                        UV stairBottomRightBack = new UV(0, 8, 7, 15, 0, 16, 16);
                        UV stairBottomRightLeft = new UV(0, 0, 15, 15, 5, 16, 16);
                        UV stairBottomRightRight = new UV(0, 8, 15, 15, 0, 16, 16);
                        UV stairBottomRightTop = new UV(0, 8, 15, 15, 0, 16, 16, true, true, true);
                        UV stairBottomRightBottom = new UV(0, 8, 15, 15, 0, 16, 16, true, false, true);

                        UVinfo stairBottomRight = new UVinfo(stairBottomRightFront, stairBottomRightBack, stairBottomRightLeft, stairBottomRightRight,
                            stairBottomRightTop, stairBottomRightBottom);

                        drawModel(8.0f, 8.0f, 16.0f, 4.0f / 16.0f, -4.0f / 16.0f, 0.0f, stairBottomRight);

                        //bottom left
                        UV stairBottomLeftFront = new UV(0, 8, 7, 15, 0, 16, 16);
                        UV stairBottomLeftBack = new UV(8, 8, 15, 15, 0, 16, 16);
                        UV stairBottomLeftLeft = new UV(0, 8, 15, 15, 0, 16, 16);
                        UV stairBottomLeftRight = new UV(0, 0, 15, 15, 5, 16, 16);
                        UV stairBottomLeftTop = new UV(0, 0, 15, 15, 5, 16, 16);
                        UV stairBottomLeftBottom = new UV(0, 0, 15, 7, 0, 16, 16, true, false, true);

                        UVinfo stairBottomLeft = new UVinfo(stairBottomLeftFront, stairBottomLeftBack, stairBottomLeftLeft, stairBottomLeftRight,
                            stairBottomLeftTop, stairBottomLeftBottom);

                        drawModel(8.0f, 8.0f, 16.0f, -4.0f / 16.0f, -4.0f / 16.0f, 0.0f, stairBottomLeft);
                    }
                    else if (modelType == ModelType.MultiTextureStairs)
                    {
                        //top left
                        UV stairTopLeftFront = new UV(0, 0, 7, 7, 0, 16, 16);
                        UV stairTopLeftBack = new UV(8, 0, 15, 7, 0, 16, 16);
                        UV stairTopLeftLeft = new UV(0, 0, 15, 7, 0, 16, 16);
                        UV stairTopLeftRight = new UV(0, 0, 15, 7, 0, 16, 16);
                        UV stairTopLeftTop = new UV(0, 0, 15, 7, 1, 16, 16, true, true, true);
                        UV stairTopLeftBottom = new UV(0, 0, 15, 15, 5, 16, 16);

                        UVinfo stairTopLeft = new UVinfo(stairTopLeftFront, stairTopLeftBack, stairTopLeftLeft, stairTopLeftRight,
                            stairTopLeftTop, stairTopLeftBottom);

                        drawModel(8.0f, 8.0f, 16.0f, -4.0f / 16.0f, 4.0f / 16.0f, 0.0f, stairTopLeft);

                        //bottom right
                        UV stairBottomRightFront = new UV(8, 8, 15, 15, 0, 16, 16);
                        UV stairBottomRightBack = new UV(0, 8, 7, 15, 0, 16, 16);
                        UV stairBottomRightLeft = new UV(0, 0, 15, 15, 5, 16, 16);
                        UV stairBottomRightRight = new UV(0, 8, 15, 15, 0, 16, 16);
                        UV stairBottomRightTop = new UV(0, 8, 15, 15, 1, 16, 16, true, true, true);
                        UV stairBottomRightBottom = new UV(0, 8, 15, 15, 2, 16, 16, true, false, true);

                        UVinfo stairBottomRight = new UVinfo(stairBottomRightFront, stairBottomRightBack, stairBottomRightLeft, stairBottomRightRight,
                            stairBottomRightTop, stairBottomRightBottom);

                        drawModel(8.0f, 8.0f, 16.0f, 4.0f / 16.0f, -4.0f / 16.0f, 0.0f, stairBottomRight);

                        //bottom left
                        UV stairBottomLeftFront = new UV(0, 8, 7, 15, 0, 16, 16);
                        UV stairBottomLeftBack = new UV(8, 8, 15, 15, 0, 16, 16);
                        UV stairBottomLeftLeft = new UV(0, 8, 15, 15, 0, 16, 16);
                        UV stairBottomLeftRight = new UV(0, 0, 15, 15, 5, 16, 16);
                        UV stairBottomLeftTop = new UV(0, 0, 15, 15, 5, 16, 16);
                        UV stairBottomLeftBottom = new UV(0, 0, 15, 7, 2, 16, 16, true, false, true);

                        UVinfo stairBottomLeft = new UVinfo(stairBottomLeftFront, stairBottomLeftBack, stairBottomLeftLeft, stairBottomLeftRight,
                            stairBottomLeftTop, stairBottomLeftBottom);

                        drawModel(8.0f, 8.0f, 16.0f, -4.0f / 16.0f, -4.0f / 16.0f, 0.0f, stairBottomLeft);
                    }
                    else if (modelType == ModelType.Wheat)
                    {
                        if (textureCount == 4)
                        {
                            Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[3]);
                        }

                        float offset = 8.0f / 32.0f;

                        Gl.glBegin(Gl.GL_QUADS);

                        //front face
                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(-0.5f, -0.5f, 0.5f - offset);

                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(0.5f, -0.5f, 0.5f - offset);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(0.5f, 0.5f, 0.5f - offset);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(-0.5f, 0.5f, 0.5f - offset);

                        Gl.glEnd();

                        Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[0]);

                        Gl.glBegin(Gl.GL_QUADS);

                        //back face
                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(-0.5f, -0.5f, -0.5f + offset);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(-0.5f, 0.5f, -0.5f + offset);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(0.5f, 0.5f, -0.5f + offset);

                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(0.5f, -0.5f, -0.5f + offset);

                        //right face
                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(0.5f - offset, -0.5f, -0.5f);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(0.5f - offset, 0.5f, -0.5f);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(0.5f - offset, 0.5f, 0.5f);

                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(0.5f - offset, -0.5f, 0.5f);

                        Gl.glEnd();

                        Gl.glBegin(Gl.GL_QUADS);
                        //left face
                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(-0.5f + offset, -0.5f, -0.5f);

                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(-0.5f + offset, -0.5f, 0.5f);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(-0.5f + offset, 0.5f, 0.5f);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(-0.5f + offset, 0.5f, -0.5f);

                        Gl.glEnd();
                    }
                    else if (modelType == ModelType.StandingSign)
                    {
                        float scale = 2.0f;
                        float yOffset = -0.27f;

                        UV signFront = new UV(2, 2, 25, 13, 0, 64, 32);
                        UV signBack = new UV(28, 2, 51, 13, 0, 64, 32);
                        UV signLeft = new UV(0, 2, 1, 13, 0, 64, 32);
                        UV signRight = new UV(26, 2, 27, 13, 0, 64, 32);
                        UV signTop = new UV(2, 0, 25, 1, 0, 64, 32);
                        UV signBottom = new UV(26, 0, 49, 1, 0, 64, 32, true, false);

                        UVinfo sign = new UVinfo(signFront, signBack, signLeft, signRight,
                            signTop, signBottom);

                        drawModel(12.0f * scale, 6.0f * scale, 1.0f * scale,
                            0.0f, (6.25f / 16.0f + yOffset) * scale, 0.0f, sign);

                        UV signStandFront = new UV(2, 16, 3, 29, 0, 64, 32);
                        UV signStandBack = new UV(6, 16, 7, 29, 0, 64, 32);
                        UV signStandLeft = new UV(0, 16, 1, 29, 0, 64, 32);
                        UV signStandRight = new UV(4, 16, 5, 29, 0, 64, 32);
                        UV signStandTop = new UV(2, 14, 3, 15, 0, 64, 32);
                        UV signStandBottom = new UV(4, 14, 5, 15, 0, 64, 32);

                        UVinfo signStand = new UVinfo(signStandFront, signStandBack, signStandLeft, signStandRight,
                            signStandTop, signStandBottom);

                        drawModel(1.0f * scale, (7.0f - 0.5f / 16.0f) * scale, 1.0f * scale,
                            0.0f, (yOffset - 0.24f / 16.0f) * scale, 0.0f, signStand);
                        //0.0f, (yOffset - 0.25f / 16.0f) * scale, 0.0f, signStand);
                    }
                    else if (modelType == ModelType.WallSign)
                    {
                        UV signFront = new UV(2, 2, 25, 13, 0, 64, 32);
                        UV signBack = new UV(28, 2, 51, 13, 0, 64, 32);
                        UV signLeft = new UV(0, 2, 1, 13, 0, 64, 32);
                        UV signRight = new UV(26, 2, 27, 13, 0, 64, 32);
                        UV signTop = new UV(2, 0, 25, 1, 0, 64, 32);
                        UV signBottom = new UV(26, 0, 49, 1, 0, 64, 32, true, false);

                        UVinfo sign = new UVinfo(signFront, signBack, signLeft, signRight,
                            signTop, signBottom);

                        drawModel(24.0f, 12.0f, 2.0f, sign);
                    }
                    else if (modelType == ModelType.Door)
                    {
                        UV doorTopFront = new UV(0, 0, 15, 15, 0, 16, 16);
                        UV doorTopBack = new UV(0, 0, 15, 15, 0, 16, 16, true, false);
                        UV doorTopLeft = new UV(0, 0, 2, 15, 0, 16, 16);
                        UV doorTopRight = new UV(0, 0, 2, 15, 0, 16, 16);
                        UV doorTopTop = new UV(0, 0, 15, 2, 1, 16, 16, true, true);
                        UV doorTopBottom = new UV(0, 0, 15, 2, 5, 16, 16, true, false);

                        UVinfo doorTop = new UVinfo(doorTopFront, doorTopBack, doorTopLeft, doorTopRight,
                            doorTopTop, doorTopBottom);

                        drawModelDoor(16.0f, 16.0f, 3.0f, 0.0f, 0.5f, 0.5f / 16.0f, doorTop, true, false);

                        UV doorBottomFront = new UV(0, 0, 15, 15, 1, 16, 16);
                        UV doorBottomBack = new UV(0, 0, 15, 15, 1, 16, 16, true, false);
                        UV doorBottomLeft = new UV(0, 0, 2, 15, 1, 16, 16);
                        UV doorBottomRight = new UV(0, 0, 2, 15, 1, 16, 16);
                        UV doorBottomTop = new UV(0, 0, 15, 2, 5, 16, 16);
                        UV doorBottomBottom = new UV(0, 0, 15, 2, 1, 16, 16);

                        UVinfo doorBottom = new UVinfo(doorBottomFront, doorBottomBack, doorBottomLeft, doorBottomRight,
                            doorBottomTop, doorBottomBottom);

                        drawModelDoor(16.0f, 16.0f, 3.0f, 0.0f, -0.5f, 0.5f / 16.0f, doorBottom, false, true);
                    }
                    else if (modelType == ModelType.DaylightSensor)
                    {
                        UV sensorFront = new UV(0, 0, 15, 5, 0, 16, 16);
                        UV sensorBack = new UV(0, 0, 15, 5, 0, 16, 16);
                        UV sensorLeft = new UV(0, 0, 15, 5, 0, 16, 16);
                        UV sensorRight = new UV(0, 0, 15, 5, 0, 16, 16);
                        UV sensorTop = new UV(0, 0, 15, 15, 1, 16, 16);
                        UV sensorBottom = new UV(0, 0, 15, 15, 0, 16, 16, true, false);

                        UVinfo sensor = new UVinfo(sensorFront, sensorBack, sensorLeft, sensorRight,
                            sensorTop, sensorBottom);

                        drawModel(16.0f, 6.0f, 16.0f, sensor);
                    }
                    else if (modelType == ModelType.IronBars)
                    {
                        Gl.glBegin(Gl.GL_QUADS);

                        //front face
                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(-0.5f, -0.5f, 0);

                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(0.5f, -0.5f, 0);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(0.5f, 0.5f, 0);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(-0.5f, 0.5f, 0);

                        Gl.glEnd();

                        //left face
                        Gl.glBegin(Gl.GL_QUADS);

                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(0, -0.5f, -0.5f);

                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(0, -0.5f, 0.5f);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(0, 0.5f, 0.5f);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(0, 0.5f, -0.5f);

                        Gl.glEnd();

                        //top
                        UV top = new UV(7, 0, 8, 15, 16, 16);

                        Gl.glBegin(Gl.GL_QUADS);

                        Gl.glTexCoord2f(top.startU, top.endV); //0, 1
                        Gl.glVertex3f(-2.0f / 32.0f, 0.5f, -0.5f);

                        Gl.glTexCoord2f(top.startU, top.startV); //0, 0
                        Gl.glVertex3f(-2.0f / 32.0f, 0.5f, 0.5f);

                        Gl.glTexCoord2f(top.endU, top.startV); //1, 0
                        Gl.glVertex3f(2.0f / 32.0f, 0.5f, 0.5f);

                        Gl.glTexCoord2f(top.endU, top.endV); //1, 1
                        Gl.glVertex3f(2.0f / 32.0f, 0.5f, -0.5f);

                        Gl.glEnd();

                        Gl.glRotatef(90.0f, 0.0f, 1.0f, 0.0f);

                        UV top2 = new UV(7, 0, 8, 15, 16, 16, true, true);

                        float startU = top2.startU;
                        float endU = top2.endU;

                        float startV = top2.startV;
                        float endV = top2.endV;

                        if (top2.flipU)
                        {
                            float saveStartU = startU;
                            float saveEndU = endU;

                            startU = saveEndU;
                            endU = saveStartU;
                        }

                        if (top2.flipV)
                        {
                            float saveStartV = startV;
                            float saveEndV = endV;

                            startV = saveEndV;
                            endV = saveStartV;
                        }

                        Gl.glBegin(Gl.GL_QUADS);

                        Gl.glTexCoord2f(startU, endV); //0, 1
                        Gl.glVertex3f(-2.0f / 32.0f, 0.51f, -0.5f);

                        Gl.glTexCoord2f(startU, startV); //0, 0
                        Gl.glVertex3f(-2.0f / 32.0f, 0.51f, 0.5f);

                        Gl.glTexCoord2f(endU, startV); //1, 0
                        Gl.glVertex3f(2.0f / 32.0f, 0.51f, 0.5f);

                        Gl.glTexCoord2f(endU, endV); //1, 1
                        Gl.glVertex3f(2.0f / 32.0f, 0.51f, -0.5f);

                        Gl.glEnd();

                        //bottom
                        UV bottom = new UV(7, 0, 8, 15, 16, 16, true, true);

                        startU = bottom.startU;
                        endU = bottom.endU;

                        startV = bottom.startV;
                        endV = bottom.endV;

                        if (bottom.flipU)
                        {
                            float saveStartU = startU;
                            float saveEndU = endU;

                            startU = saveEndU;
                            endU = saveStartU;
                        }

                        if (bottom.flipV)
                        {
                            float saveStartV = startV;
                            float saveEndV = endV;

                            startV = saveEndV;
                            endV = saveStartV;
                        }

                        Gl.glBegin(Gl.GL_QUADS);

                        Gl.glTexCoord2f(startU, endV); //0, 1
                        Gl.glVertex3f(-2.0f / 32.0f, -0.5f, -0.5f);

                        Gl.glTexCoord2f(startU, startV); //0, 0
                        Gl.glVertex3f(-2.0f / 32.0f, -0.5f, 0.5f);

                        Gl.glTexCoord2f(endU, startV); //1, 0
                        Gl.glVertex3f(2.0f / 32.0f, -0.5f, 0.5f);

                        Gl.glTexCoord2f(endU, endV); //1, 1
                        Gl.glVertex3f(2.0f / 32.0f, -0.5f, -0.5f);

                        Gl.glEnd();

                        Gl.glRotatef(90.0f, 0.0f, 1.0f, 0.0f);

                        UV bottom2 = new UV(7, 0, 8, 15, 16, 16, true, true);

                        startU = bottom2.startU;
                        endU = bottom2.endU;

                        startV = bottom2.startV;
                        endV = bottom2.endV;

                        if (bottom2.flipU)
                        {
                            float saveStartU = startU;
                            float saveEndU = endU;

                            startU = saveEndU;
                            endU = saveStartU;
                        }

                        if (bottom2.flipV)
                        {
                            float saveStartV = startV;
                            float saveEndV = endV;

                            startV = saveEndV;
                            endV = saveStartV;
                        }

                        Gl.glBegin(Gl.GL_QUADS);

                        Gl.glTexCoord2f(startU, endV); //0, 1
                        Gl.glVertex3f(-2.0f / 32.0f, -0.51f, -0.5f);

                        Gl.glTexCoord2f(startU, startV); //0, 0
                        Gl.glVertex3f(-2.0f / 32.0f, -0.51f, 0.5f);

                        Gl.glTexCoord2f(endU, startV); //1, 0
                        Gl.glVertex3f(2.0f / 32.0f, -0.51f, 0.5f);

                        Gl.glTexCoord2f(endU, endV); //1, 1
                        Gl.glVertex3f(2.0f / 32.0f, -0.51f, -0.5f);

                        Gl.glEnd();
                    }
                    else if (modelType == ModelType.DragonEgg)
                    {
                        drawModelTextureMappedDragonEgg(6, 15, 6, 4, 1, 4,
                            -0.5f, -0.5f, -0.5f, false);

                        drawModelTextureMappedDragonEgg(5, 14, 5, 6, 1, 6,
                            -0.5f, -0.5f, -0.5f, false);

                        drawModelTextureMappedDragonEgg(4, 13, 4, 8, 1, 8,
                            -0.5f, -0.5f, -0.5f, false);

                        drawModelTextureMappedDragonEgg(3, 11, 3, 10, 2, 10,
                            -0.5f, -0.5f, -0.5f, false);

                        drawModelTextureMappedDragonEgg(2, 8, 2, 12, 3, 12,
                            -0.5f, -0.5f, -0.5f, false);

                        drawModelTextureMappedDragonEgg(1, 3, 1, 14, 5, 14,
                            -0.5f, -0.5f, -0.5f, false);

                        drawModelTextureMappedDragonEgg(2, 1, 2, 12, 2, 12,
                            -0.5f, -0.5f, -0.5f, false);

                        drawModelTextureMappedDragonEgg(5, 0, 5, 6, 1, 6,
                            -0.5f, -0.5f, -0.5f, false);
                    }
                    else if (modelType == ModelType.Lever)
                    {
                        Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[0]);

                        Gl.glPushMatrix();
                        Gl.glTranslatef(-0.5f, -0.5f, 0.0f - 3.0f / 32.0f);

                        drawModelTextureMapped(5, 4, 0, 6, 8, 3);

                        Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[1]);

                        Gl.glPopMatrix();

                        Gl.glRotatef(45.0f, 1.0f, 0.0f, 0.0f);
                        Gl.glTranslatef(-0.5f, 0.0f, -16.0f / 32.0f);

                        drawModelTextureMappedLever(7, 0, 7, 2, 10, 2);
                    }
                    else if (modelType == ModelType.PressurePlate)
                    {
                        drawModelTextureMapped(1, 0, 1, 14, 1, 14, -0.5f, 0.0f, -0.5f, false);
                    }
                    else if (modelType == ModelType.Fire)
                    {
                        //layer 1
                        Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[frameIndex]);

                        Gl.glBegin(Gl.GL_QUADS);

                        //front face
                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(-0.5f, -0.5f, 0.5f);

                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(0.5f, -0.5f, 0.5f);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(0.5f, 0.5f, 0.5f);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(-0.5f, 0.5f, 0.5f);

                        Gl.glEnd();

                        Gl.glBegin(Gl.GL_QUADS);

                        //back face
                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(-0.5f, -0.5f, -0.5f);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(-0.5f, 0.5f, -0.5f);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(0.5f, 0.5f, -0.5f);

                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(0.5f, -0.5f, -0.5f);

                        //right face
                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(0.5f, -0.5f, -0.5f);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(0.5f, 0.5f, -0.5f);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(0.5f, 0.5f, 0.5f);

                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(0.5f, -0.5f, 0.5f);

                        //left face
                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(-0.5f, -0.5f, -0.5f);

                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(-0.5f, -0.5f, 0.5f);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(-0.5f, 0.5f, 0.5f);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(-0.5f, 0.5f, -0.5f);

                        Gl.glEnd();

                        //layer 2
                        Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[frameIndex + 32]);

                        Gl.glPushMatrix();

                        Gl.glRotatef(330.0f, 1.0f, 0.0f, 0.0f);
                        Gl.glTranslatef(0.0f, -1.0f / 16.0f, 0.0f);

                        Gl.glBegin(Gl.GL_QUADS);

                        //front face
                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(-0.5f, -0.5f, 0);

                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(0.5f, -0.5f, 0);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(0.5f, 0.5f, 0);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(-0.5f, 0.5f, 0);

                        Gl.glEnd();

                        Gl.glPopMatrix();

                        Gl.glPushMatrix();

                        Gl.glRotatef(30.0f, 1.0f, 0.0f, 0.0f);
                        Gl.glTranslatef(0.0f, -1.0f / 16.0f, 0.0f);

                        Gl.glBegin(Gl.GL_QUADS);

                        //back face
                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(-0.5f, -0.5f, 0);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(-0.5f, 0.5f, 0);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(0.5f, 0.5f, 0);

                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(0.5f, -0.5f, 0);

                        Gl.glEnd();

                        Gl.glPopMatrix();

                        Gl.glPushMatrix();

                        Gl.glRotatef(30.0f, 0.0f, 0.0f, 1.0f);
                        Gl.glTranslatef(0.0f, -1.0f / 16.0f, 0.0f);

                        Gl.glBegin(Gl.GL_QUADS);

                        //right face
                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(0, -0.5f, -0.5f);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(0, 0.5f, -0.5f);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(0, 0.5f, 0.5f);

                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(0, -0.5f, 0.5f);

                        Gl.glEnd();

                        Gl.glPopMatrix();

                        Gl.glPushMatrix();

                        Gl.glRotatef(330.0f, 0.0f, 0.0f, 1.0f);
                        Gl.glTranslatef(0.0f, -1.0f / 16.0f, 0.0f);

                        Gl.glBegin(Gl.GL_QUADS);

                        //left face
                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(0, -0.5f, -0.5f);

                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(0, -0.5f, 0.5f);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(0, 0.5f, 0.5f);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(0, 0.5f, -0.5f);

                        Gl.glEnd();

                        Gl.glPopMatrix();
                    }
                    else if (modelType == ModelType.AnimatedStrip)
                    {
                        int currentFrameIndex = frameIndex;
                        if (currentFrameIndex == -1)
                        {
                            currentFrameIndex = 0;
                        }

                        if (frameIndex >= textureCount)
                        {
                            currentFrameIndex = textureCount * 2 - frameIndex - 2;
                        }

                        Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[currentFrameIndex]);

                        Gl.glBegin(Gl.GL_QUADS);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(-0.5f, 0, -0.5f);

                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(-0.5f, 0, 0.5f);

                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(0.5f, 0, 0.5f);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(0.5f, 0, -0.5f);

                        Gl.glEnd();
                    }
                    else if (modelType == ModelType.AnimatedStripFront)
                    {
                        int currentFrameIndex = frameIndex;
                        if (frameIndex >= textureCount)
                        {
                            currentFrameIndex = textureCount * 2 - frameIndex - 2;
                        }

                        Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[currentFrameIndex]);

                        Gl.glBegin(Gl.GL_QUADS);

                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(-0.5f, -0.5f, 0);

                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(0.5f, -0.5f, 0);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(0.5f, 0.5f, 0);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(-0.5f, 0.5f, 0);

                        Gl.glEnd();
                    }
                    else if (modelType == ModelType.Button)
                    {
                        drawModelTextureMapped(5.0f, 6.0f, 0.0f, 6.0f, 4.0f, 2.0f,
                            -8.0f / 16.0f, -8.0f / 16.0f, -1.0f / 16.0f, false);
                    }
                    else if (modelType == ModelType.Snow)
                    {
                        drawModelTextureMapped(0.0f, 0.0f, 0.0f, 16.0f, 2.0f, 16.0f,
                            -8.0f / 16.0f, 0.0f / 16.0f, -8.0f / 16.0f, false);
                    }
                    else if (modelType == ModelType.Fence)
                    {
                        float xDiff = -16.0f / 16.0f;
                        float yDiff = -8.0f / 16.0f;
                        float zDiff = -8.0f / 16.0f;

                        //top horizontal post
                        drawModelTextureMapped(10.0f, 12.0f, 7.0f, 12.0f, 3.0f, 2.0f,
                            xDiff, yDiff, zDiff, false);

                        //bottom horizontal post
                        drawModelTextureMapped(10.0f, 6.0f, 7.0f, 12.0f, 3.0f, 2.0f,
                            xDiff, yDiff, zDiff, false);

                        float postXdiff = 3.0f;

                        //left post
                        drawModelTextureMapped(6.0f, 0.0f, 6.0f, 4.0f, 16.0f, 4.0f,
                            (-postXdiff + 3.0f) / 16.0f + xDiff, 0.0f / 16.0f + yDiff, zDiff, false);

                        //right post
                        drawModelTextureMapped(6.0f, 0.0f, 6.0f, 4.0f, 16.0f, 4.0f,
                            (postXdiff + 13.0f) / 16.0f + xDiff, 0.0f / 16.0f + yDiff, zDiff, false);
                    }
                    else if (modelType == ModelType.GlassPane)
                    {
                        Gl.glBegin(Gl.GL_QUADS);

                        //front face
                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(-0.5f, -0.5f, 0);

                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(0.5f, -0.5f, 0);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(0.5f, 0.5f, 0);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(-0.5f, 0.5f, 0);

                        Gl.glEnd();

                        Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[1]);

                        Gl.glBegin(Gl.GL_QUADS);

                        //right face
                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(0.5f, -0.5f, -0.5f);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(0.5f, 0.5f, -0.5f);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(0.5f, 0.5f, 0.5f);

                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(0.5f, -0.5f, 0.5f);

                        //left face
                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(-0.5f, -0.5f, -0.5f);

                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(-0.5f, -0.5f, 0.5f);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(-0.5f, 0.5f, 0.5f);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(-0.5f, 0.5f, -0.5f);

                        Gl.glEnd();

                        UV top = new UV(0, 0, 16, 16, 1, 16, 16, true);

                        Gl.glTranslatef(0.0f, 0.0f, -0.5f / 16.0f);

                        Gl.glBegin(Gl.GL_QUADS);

                        //top face
                        Gl.glTexCoord2f(1 - top.endV, top.startU); //0, 1
                        Gl.glVertex3f(-0.5f, 0.5f, -0.5f);

                        Gl.glTexCoord2f(1 - top.startV, top.startU); //0, 0
                        Gl.glVertex3f(-0.5f, 0.5f, 0.5f);

                        Gl.glTexCoord2f(1 - top.startV, top.endU); //1, 0
                        Gl.glVertex3f(0.5f, 0.5f, 0.5f);

                        Gl.glTexCoord2f(1 - top.endV, top.endU); //1, 1
                        Gl.glVertex3f(0.5f, 0.5f, -0.5f);

                        //bottom face
                        Gl.glTexCoord2f(1 - top.endV, top.endU); //1, 1
                        Gl.glVertex3f(-0.5f, -0.5f, -0.5f);

                        Gl.glTexCoord2f(1 - top.endV, top.startU); //0, 1
                        Gl.glVertex3f(0.5f, -0.5f, -0.5f);

                        Gl.glTexCoord2f(1 - top.startV, top.startU); //0, 0
                        Gl.glVertex3f(0.5f, -0.5f, 0.5f);

                        Gl.glTexCoord2f(1 - top.startV, top.endU); //1, 0
                        Gl.glVertex3f(-0.5f, -0.5f, 0.5f);

                        Gl.glEnd();
                    }
                    else if (modelType == ModelType.Cake)
                    {
                        float offset = 1.0f / 16.0f;

                        Gl.glBegin(Gl.GL_QUADS);

                        //front face
                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(-0.5f, -0.5f, 0.5f - offset);

                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(0.5f, -0.5f, 0.5f - offset);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(0.5f, 0.5f, 0.5f - offset);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(-0.5f, 0.5f, 0.5f - offset);

                        //back face
                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(-0.5f, -0.5f, -0.5f + offset);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(-0.5f, 0.5f, -0.5f + offset);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(0.5f, 0.5f, -0.5f + offset);

                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(0.5f, -0.5f, -0.5f + offset);

                        //right face
                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(0.5f - offset, -0.5f, -0.5f);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(0.5f - offset, 0.5f, -0.5f);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(0.5f - offset, 0.5f, 0.5f);

                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(0.5f - offset, -0.5f, 0.5f);

                        //left face
                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(-0.5f + offset, -0.5f, -0.5f);

                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(-0.5f + offset, -0.5f, 0.5f);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(-0.5f + offset, 0.5f, 0.5f);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(-0.5f + offset, 0.5f, -0.5f);

                        Gl.glEnd();

                        float yOffset = 8.0f / 16.0f;

                        Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[1]);

                        Gl.glBegin(Gl.GL_QUADS);

                        //top face
                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(-0.5f, 0.5f - yOffset, -0.5f);

                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(-0.5f, 0.5f - yOffset, 0.5f);

                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(0.5f, 0.5f - yOffset, 0.5f);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(0.5f, 0.5f - yOffset, -0.5f);

                        Gl.glEnd();

                        Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[2]);

                        Gl.glBegin(Gl.GL_QUADS);

                        //bottom face
                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(-0.5f, -0.5f, -0.5f);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(0.5f, -0.5f, -0.5f);

                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(0.5f, -0.5f, 0.5f);

                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(-0.5f, -0.5f, 0.5f);

                        Gl.glEnd();
                    }
                    else if (modelType == ModelType.Trapdoor)
                    {
                        drawModelTextureMapped(0, 0, 0, 16, 3, 16,
                            0.0f, 0.5f / 16.0f, 0.0f, true);
                    }
                    else if (modelType == ModelType.NetherWart)
                    {
                        float zOffset = 4.0f / 16.0f;

                        Gl.glBegin(Gl.GL_QUADS);

                        //front face
                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(-0.5f, -0.5f, 0.25f);

                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(0.5f, -0.5f, 0.25f);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(0.5f, 0.5f, 0.25f);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(-0.5f, 0.5f, 0.25f);

                        //front face
                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(-0.5f, -0.5f, -0.25f);

                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(0.5f, -0.5f, -0.25f);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(0.5f, 0.5f, -0.25f);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(-0.5f, 0.5f, -0.25f);

                        float offset = -0.25f;

                        //right face
                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(0.5f + offset, -0.5f, -0.75f + zOffset);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(0.5f + offset, 0.5f, -0.75f + zOffset);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(0.5f + offset, 0.5f, 0.25f + zOffset);

                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(0.5f + offset, -0.5f, 0.25f + zOffset);

                        float offset2 = 0.125f + 2.0f / 16.0f;

                        //left face
                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(-0.5f + offset2, -0.5f, -0.75f + zOffset);

                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(-0.5f + offset2, -0.5f, 0.25f + zOffset);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(-0.5f + offset2, 0.5f, 0.25f + zOffset);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(-0.5f + offset2, 0.5f, -0.75f + zOffset);

                        Gl.glEnd();
                    }
                    else if (modelType == ModelType.EnchantmentTable)
                    {
                        Gl.glBegin(Gl.GL_QUADS);

                        //front face
                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(-0.5f, -0.5f, 0.5f);

                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(0.5f, -0.5f, 0.5f);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(0.5f, 0.5f, 0.5f);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(-0.5f, 0.5f, 0.5f);

                        //back face
                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(-0.5f, -0.5f, -0.5f);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(-0.5f, 0.5f, -0.5f);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(0.5f, 0.5f, -0.5f);

                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(0.5f, -0.5f, -0.5f);

                        //right face
                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(0.5f, -0.5f, -0.5f);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(0.5f, 0.5f, -0.5f);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(0.5f, 0.5f, 0.5f);

                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(0.5f, -0.5f, 0.5f);

                        //left face
                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(-0.5f, -0.5f, -0.5f);

                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(-0.5f, -0.5f, 0.5f);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(-0.5f, 0.5f, 0.5f);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(-0.5f, 0.5f, -0.5f);

                        Gl.glEnd();

                        Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[1]);

                        Gl.glBegin(Gl.GL_QUADS);

                        float yOffset = 8.0f / 32.0f;

                        //top face
                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(-0.5f, 0.5f - yOffset, -0.5f);

                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(-0.5f, 0.5f - yOffset, 0.5f);

                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(0.5f, 0.5f - yOffset, 0.5f);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(0.5f, 0.5f - yOffset, -0.5f);

                        Gl.glEnd();

                        Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[2]);

                        Gl.glBegin(Gl.GL_QUADS);

                        //bottom face
                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(-0.5f, -0.5f, -0.5f);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(0.5f, -0.5f, -0.5f);

                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(0.5f, -0.5f, 0.5f);

                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(-0.5f, -0.5f, 0.5f);

                        Gl.glEnd();
                    }
                    else if (modelType == ModelType.RedstoneRepeaterOff)
                    {
                        drawModelTextureMapped(0, 0, 0, 16, 2, 16,
                            0.0f, 0.0f, 0.0f, true);

                        float xOffset = 8.0f;
                        float yOffset = 4.0f;
                        float zOffset = 7.0f;

                        UV torchFront = new UV(7, 6, 8, 10, 1, 16, 16);
                        UV torchBack = new UV(7, 6, 8, 10, 1, 16, 16);
                        UV torchLeft = new UV(7, 6, 8, 10, 1, 16, 16);
                        UV torchRight = new UV(7, 6, 8, 10, 1, 16, 16);
                        UV torchTop = new UV(7, 6, 8, 7, 1, 16, 16);
                        UV torchBottom = new UV(7, 6, 8, 7, 1, 16, 16);
                        UVinfo torch = new UVinfo(torchFront, torchBack, torchLeft, torchRight,
                            torchTop, torchBottom);

                        drawModel(2.0f, 5.0f, 2.0f,
                            (xOffset - 8.0f) / 16.0f, (yOffset - 0.5f) / 16.0f, (zOffset - 8.0f) / 16.0f, torch);

                        drawModel(2.0f, 5.0f, 2.0f,
                            (xOffset - 8.0f) / 16.0f, (yOffset - 0.5f) / 16.0f, (zOffset - 12.0f) / 16.0f, torch);
                    }
                    else if (modelType == ModelType.RedstoneRepeaterOn)
                    {
                        drawModelTextureMapped(0, 0, 0, 16, 2, 16,
                            0.0f, 0.0f, 0.0f, true);

                        float xOffset = 8.0f;
                        float yOffset = 4.0f;
                        float zOffset = 7.0f;

                        UV torchFront = new UV(7, 6, 8, 10, 1, 16, 16);
                        UV torchBack = new UV(7, 6, 8, 10, 1, 16, 16);
                        UV torchLeft = new UV(7, 6, 8, 10, 1, 16, 16);
                        UV torchRight = new UV(7, 6, 8, 10, 1, 16, 16);
                        UV torchTop = new UV(7, 6, 8, 7, 1, 16, 16);
                        UV torchBottom = new UV(7, 6, 8, 7, 1, 16, 16);
                        UVinfo torch = new UVinfo(torchFront, torchBack, torchLeft, torchRight,
                            torchTop, torchBottom);

                        Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[1]);

                        float torchPlaneYOffset = 1.0f;

                        //draw torch planes
                        drawTorchPlanes(1.0f, 0.0f, torchPlaneYOffset / 16.0f, -1.0f / 16.0f);

                        drawModel(2.0f, 5.0f, 2.0f,
                            (xOffset - 8.0f) / 16.0f, (yOffset - 0.5f) / 16.0f, (zOffset - 8.0f) / 16.0f, torch);

                        //Gl.glTranslatef(0.0f, 0.0f, -4.0f / 16.0f);

                        Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[1]);

                        //draw torch planes
                        drawTorchPlanes(1.0f, 0.0f, torchPlaneYOffset / 16.0f, -5.0f / 16.0f);

                        drawModel(2.0f, 5.0f, 2.0f,
                            (xOffset - 8.0f) / 16.0f, (yOffset - 0.5f) / 16.0f, (zOffset - 12.0f) / 16.0f, torch);
                    }
                    else if (modelType == ModelType.Cauldron)
                    {
                        Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[0]);

                        Gl.glBegin(Gl.GL_QUADS);

                        //front face
                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(-0.5f, -0.5f, 0.5f);

                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(0.5f, -0.5f, 0.5f);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(0.5f, 0.5f, 0.5f);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(-0.5f, 0.5f, 0.5f);

                        //back face
                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(-0.5f, -0.5f, -0.5f);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(-0.5f, 0.5f, -0.5f);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(0.5f, 0.5f, -0.5f);

                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(0.5f, -0.5f, -0.5f);

                        //right face
                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(0.5f, -0.5f, -0.5f);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(0.5f, 0.5f, -0.5f);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(0.5f, 0.5f, 0.5f);

                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(0.5f, -0.5f, 0.5f);

                        //left face
                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(-0.5f, -0.5f, -0.5f);

                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(-0.5f, -0.5f, 0.5f);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(-0.5f, 0.5f, 0.5f);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(-0.5f, 0.5f, -0.5f);

                        Gl.glEnd();

                        Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[1]);

                        Gl.glBegin(Gl.GL_QUADS);

                        //top face
                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(-0.5f, 0.5f, -0.5f);

                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(-0.5f, 0.5f, 0.5f);

                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(0.5f, 0.5f, 0.5f);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(0.5f, 0.5f, -0.5f);

                        Gl.glEnd();

                        Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[2]);

                        float yOffset = 4.0f / 16.0f;

                        Gl.glBegin(Gl.GL_QUADS);

                        //bottom face
                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(-0.5f, -0.5f + yOffset, -0.5f);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(0.5f, -0.5f + yOffset, -0.5f);

                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(0.5f, -0.5f + yOffset, 0.5f);

                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(-0.5f, -0.5f + yOffset, 0.5f);

                        Gl.glEnd();

                        Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[0]);

                        //inside
                        float offset = 2.0f / 16.0f;

                        Gl.glBegin(Gl.GL_QUADS);

                        //front face
                        Gl.glTexCoord2f(0, 4.0f / 16.0f);
                        Gl.glVertex3f(-0.5f, -0.5f + 4.0f / 16.0f, 0.5f - offset);

                        Gl.glTexCoord2f(1, 4.0f / 16.0f);
                        Gl.glVertex3f(0.5f, -0.5f + 4.0f / 16.0f, 0.5f - offset);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(0.5f, 0.5f, 0.5f - offset);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(-0.5f, 0.5f, 0.5f - offset);

                        //back face
                        Gl.glTexCoord2f(1, 4.0f / 16.0f);
                        Gl.glVertex3f(-0.5f, -0.5f + 4.0f / 16.0f, -0.5f + offset);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(-0.5f, 0.5f, -0.5f + offset);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(0.5f, 0.5f, -0.5f + offset);

                        Gl.glTexCoord2f(0, 4.0f / 16.0f);
                        Gl.glVertex3f(0.5f, -0.5f + 4.0f / 16.0f, -0.5f + offset);

                        //right face
                        Gl.glTexCoord2f(1, 4.0f / 16.0f);
                        Gl.glVertex3f(0.5f - offset, -0.5f + 4.0f / 16.0f, -0.5f);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(0.5f - offset, 0.5f, -0.5f);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(0.5f - offset, 0.5f, 0.5f);

                        Gl.glTexCoord2f(0, 4.0f / 16.0f);
                        Gl.glVertex3f(0.5f - offset, -0.5f + 4.0f / 16.0f, 0.5f);

                        //left face
                        Gl.glTexCoord2f(0, 4.0f / 16.0f);
                        Gl.glVertex3f(-0.5f + offset, -0.5f + 4.0f / 16.0f, -0.5f);

                        Gl.glTexCoord2f(1, 4.0f / 16.0f);
                        Gl.glVertex3f(-0.5f + offset, -0.5f + 4.0f / 16.0f, 0.5f);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(-0.5f + offset, 0.5f, 0.5f);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(-0.5f + offset, 0.5f, -0.5f);

                        Gl.glEnd();
                    }
                    else if (modelType == ModelType.BrewingStandEmpty)
                    {
                        Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[0]);

                        float startU = 0.5f;
                        float endU = 1.0f;

                        float startV = 0.0f;
                        float endV = 1.0f;

                        Gl.glPushMatrix();

                        drawBrewingArms(startU, endU, startV, endV);

                        Gl.glPopMatrix();

                        //bases
                        Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[1]);

                        drawModelTextureMapped(2, 0, 1, 6, 2, 6,
                            -8.0f / 16.0f, -8.0f / 16.0f, -8.0f / 16.0f, false);

                        drawModelTextureMapped(2, 0, 9, 6, 2, 6,
                            -8.0f / 16.0f, -8.0f / 16.0f, -8.0f / 16.0f, false);

                        drawModelTextureMapped(9, 0, 5, 6, 2, 6,
                            -8.0f / 16.0f, -8.0f / 16.0f, -8.0f / 16.0f, false);

                        Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[0]);

                        drawModelTextureMapped(7, 0, 7, 2, 12, 2,
                            -8.0f / 16.0f, -8.0f / 16.0f, -8.0f / 16.0f, false);
                    }
                    else if (modelType == ModelType.BrewingStandPotion)
                    {
                        float startU = 0.5f;
                        float endU = 0.0f;

                        float startV = 0.0f;
                        float endV = 1.0f;

                        Gl.glPushMatrix();

                        drawBrewingArms(startU, endU, startV, endV);

                        Gl.glPopMatrix();

                        //bases
                        Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[1]);

                        drawModelTextureMapped(2, 0, 1, 6, 2, 6,
                            -8.0f / 16.0f, -8.0f / 16.0f, -8.0f / 16.0f, false);

                        drawModelTextureMapped(2, 0, 9, 6, 2, 6,
                            -8.0f / 16.0f, -8.0f / 16.0f, -8.0f / 16.0f, false);

                        drawModelTextureMapped(9, 0, 5, 6, 2, 6,
                            -8.0f / 16.0f, -8.0f / 16.0f, -8.0f / 16.0f, false);

                        Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[0]);

                        drawModelTextureMapped(7, 0, 7, 2, 12, 2,
                            -8.0f / 16.0f, -8.0f / 16.0f, -8.0f / 16.0f, false);
                    }
                    else if (modelType == ModelType.FenceGate)
                    {
                        //left and right vertical posts
                        drawModelTextureMapped(0, 5, 7, 2, 11, 2,
                            -0.5f + 1.0f / 16.0f, -0.5f, -0.5f, false);

                        drawModelTextureMapped(14, 5, 7, 2, 11, 2,
                            -0.5f + 1.0f / 16.0f, -0.5f, -0.5f, false);

                        //top and bottom horizontal posts
                        drawModelTextureMapped(2, 12, 7, 12, 3, 2,
                            -0.5f + 1.0f / 16.0f, -0.5f, -0.5f, false);

                        drawModelTextureMapped(2, 6, 7, 12, 3, 2,
                            -0.5f + 1.0f / 16.0f, -0.5f, -0.5f, false);

                        //middle
                        drawModelTextureMapped(6, 9, 7, 4, 3, 2,
                            -0.5f + 1.0f / 16.0f, -0.5f, -0.5f, false);
                    }
                    else if (modelType == ModelType.WeightedPressurePlateLight)
                    {
                        //Gl.glTranslatef(0.0f, 1.0f / 32.0f, 0.0f);

                        drawModelTextureMapped(1, 0, 1, 14, 1, 14,
                            0.0f, 1.0f / 32.0f, 0.0f, true);
                    }
                    else if (modelType == ModelType.WeightedPressurePlateHeavy)
                    {
                        //Gl.glTranslatef(0.0f, 1.0f / 32.0f, 0.0f);

                        drawModelTextureMapped(1, 0, 1, 14, 1, 14,
                            0.0f, 1.0f / 32.0f, 0.0f, true);
                    }
                    else if (modelType == ModelType.Hopper)
                    {
                        Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[2]);

                        Gl.glBegin(Gl.GL_QUADS);
                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(-0.5f, 0.5f - 1.0f / 16.0f, -0.5f);

                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(-0.5f, 0.5f - 1.0f / 16.0f, 0.5f);

                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(0.5f, 0.5f - 1.0f / 16.0f, 0.5f);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(0.5f, 0.5f - 1.0f / 16.0f, -0.5f);
                        Gl.glEnd();

                        Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[1]);

                        float yOffset = (7.0f - 0.1f) / 16.0f;

                        //bottom of hopper cauldron
                        Gl.glBegin(Gl.GL_QUADS);
                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(-0.5f, 0.5f - yOffset, -0.5f);

                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(-0.5f, 0.5f - yOffset, 0.5f);

                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(0.5f, 0.5f - yOffset, 0.5f);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(0.5f, 0.5f - yOffset, -0.5f);
                        Gl.glEnd();

                        Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[0]);

                        //draw insides of hopper cauldron
                        float sideYOffset = -1.0f / 16.0f;
                        float sideHeight = 10.0f / 16.0f;

                        float offset = 2.0f / 16.0f;

                        //left face
                        Gl.glBegin(Gl.GL_QUADS);
                        Gl.glTexCoord2f(1, 10.0f / 16.0f); //0, 0
                        Gl.glVertex3f(-0.5f + offset, -0.5f + sideYOffset + sideHeight, -0.5f);

                        Gl.glTexCoord2f(0, 10.0f / 16.0f); //1, 0
                        Gl.glVertex3f(-0.5f + offset, -0.5f + sideYOffset + sideHeight, 0.5f);

                        Gl.glTexCoord2f(0, 16.0f / 16.0f); //1, 1
                        Gl.glVertex3f(-0.5f + offset, 0.5f + sideYOffset, 0.5f);

                        Gl.glTexCoord2f(1, 16.0f / 16.0f); //0, 1
                        Gl.glVertex3f(-0.5f + offset, 0.5f + sideYOffset, -0.5f);
                        Gl.glEnd();

                        //right face
                        Gl.glBegin(Gl.GL_QUADS);
                        Gl.glTexCoord2f(0, 10.0f / 16.0f); //1, 0
                        Gl.glVertex3f(0.5f - offset, -0.5f + sideYOffset + sideHeight, -0.5f);

                        Gl.glTexCoord2f(0, 16.0f / 16.0f); //1, 1
                        Gl.glVertex3f(0.5f - offset, 0.5f + sideYOffset, -0.5f);

                        Gl.glTexCoord2f(1, 16.0f / 16.0f); //0, 1
                        Gl.glVertex3f(0.5f - offset, 0.5f + sideYOffset, 0.5f);

                        Gl.glTexCoord2f(1, 10.0f / 16.0f); //0, 0
                        Gl.glVertex3f(0.5f - offset, -0.5f + sideYOffset + sideHeight, 0.5f);
                        Gl.glEnd();

                        //front face
                        Gl.glBegin(Gl.GL_QUADS);
                        Gl.glTexCoord2f(1, 10.0f / 16.0f); //0, 0
                        Gl.glVertex3f(-0.5f, -0.5f + sideYOffset + sideHeight, 0.5f - offset);

                        Gl.glTexCoord2f(0, 10.0f / 16.0f); //1, 0
                        Gl.glVertex3f(0.5f, -0.5f + sideYOffset + sideHeight, 0.5f - offset);

                        Gl.glTexCoord2f(0, 16.0f / 16.0f); //1, 1
                        Gl.glVertex3f(0.5f, 0.5f + sideYOffset, 0.5f - offset);

                        Gl.glTexCoord2f(1, 16.0f / 16.0f); //0, 1
                        Gl.glVertex3f(-0.5f, 0.5f + sideYOffset, 0.5f - offset);
                        Gl.glEnd();

                        //back face
                        Gl.glBegin(Gl.GL_QUADS);
                        Gl.glTexCoord2f(0, 10.0f / 16.0f); //1, 0
                        Gl.glVertex3f(-0.5f, -0.5f + sideYOffset + sideHeight, -0.5f + offset);

                        Gl.glTexCoord2f(0, 16.0f / 16.0f); //1, 1
                        Gl.glVertex3f(-0.5f, 0.5f + sideYOffset, -0.5f + offset);

                        Gl.glTexCoord2f(1, 16.0f / 16.0f); //0, 1
                        Gl.glVertex3f(0.5f, 0.5f + sideYOffset, -0.5f + offset);

                        Gl.glTexCoord2f(1, 10.0f / 16.0f); //0, 0
                        Gl.glVertex3f(0.5f, -0.5f + sideYOffset + sideHeight, -0.5f + offset);
                        Gl.glEnd();

                        //top
                        drawModelTextureMappedNoTop(0, 10, 0, 16, 6, 16,
                            -0.5f, -0.5f - 1.0f / 16.0f, -0.5f, false);

                        //middle
                        drawModelTextureMapped(4, 4, 4, 8, 6, 8,
                            -0.5f, -0.5f - 1.0f / 16.0f, -0.5f, false);

                        //bottom
                        drawModelTextureMapped(6, 0, 6, 4, 4, 4,
                            -0.5f, -0.5f - 1.0f / 16.0f, -0.5f, false);
                    }
                    else if (modelType == ModelType.Carpet)
                    {
                        drawModelTextureMapped(0, 0, 0, 16, 1, 16,
                            0.0f, 0.5f / 16.0f, 0.0f, true);
                    }
                    else if (modelType == ModelType.Sunflower)
                    {
                        //bottom
                        Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[0]);

                        Gl.glTranslatef(0.0f, -0.5f, 0.0f);

                        Gl.glBegin(Gl.GL_QUADS);

                        float sqrt2invert = (float)(1 / Math.Sqrt(2)) / 2;

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(-sqrt2invert, 0.5f, -sqrt2invert);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(sqrt2invert, 0.5f, sqrt2invert);

                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(sqrt2invert, -0.5f, sqrt2invert);

                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(-sqrt2invert, -0.5f, -sqrt2invert);

                        Gl.glEnd();

                        Gl.glBegin(Gl.GL_QUADS);

                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(sqrt2invert, -0.5f, -sqrt2invert);

                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(-sqrt2invert, -0.5f, sqrt2invert);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(-sqrt2invert, 0.5f, sqrt2invert);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(sqrt2invert, 0.5f, -sqrt2invert);

                        Gl.glEnd();

                        //top
                        Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[1]);

                        Gl.glTranslatef(0.0f, 0.5f + 8.0f / 16.0f, 0.0f);

                        Gl.glBegin(Gl.GL_QUADS);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(-sqrt2invert, 0.5f, -sqrt2invert);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(sqrt2invert, 0.5f, sqrt2invert);

                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(sqrt2invert, -0.5f, sqrt2invert);

                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(-sqrt2invert, -0.5f, -sqrt2invert);

                        Gl.glEnd();

                        Gl.glBegin(Gl.GL_QUADS);

                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(sqrt2invert, -0.5f, -sqrt2invert);

                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(-sqrt2invert, -0.5f, sqrt2invert);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(-sqrt2invert, 0.5f, sqrt2invert);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(sqrt2invert, 0.5f, -sqrt2invert);

                        Gl.glEnd();

                        //sunflower
                        Gl.glRotatef(330.0f, 0.0f, 1.0f, 0.0f);
                        Gl.glRotatef(18.0f, 0.0f, 0.0f, 1.0f);

                        Gl.glTranslatef(2.0f / 16.0f + 0.01f, -0.075f, 0.0f);

                        //front
                        Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[2]);

                        Gl.glBegin(Gl.GL_QUADS);
                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(0, -0.5f, -0.5f);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(0, 0.5f, -0.5f);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(0, 0.5f, 0.5f);

                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(0, -0.5f, 0.5f);
                        Gl.glEnd();

                        Gl.glTranslatef(-0.001f, 0.0f, 0.0f);
                        float offset = 0.005f;

                        //back
                        Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[3]);
                        Gl.glBegin(Gl.GL_QUADS);
                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(0, -0.5f - offset, -0.5f - offset);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(0, 0.5f + offset, -0.5f - offset);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(0, 0.5f + offset, 0.5f + offset);

                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(0, -0.5f - offset, 0.5f + offset);
                        Gl.glEnd();
                    }
                    else if (modelType == ModelType.TallPlant)
                    {
                        //bottom
                        Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[0]);

                        Gl.glTranslatef(0.0f, -0.5f, 0.0f);

                        Gl.glBegin(Gl.GL_QUADS);

                        float sqrt2invert = (float)(1 / Math.Sqrt(2)) / 2;

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(-sqrt2invert, 0.5f, -sqrt2invert);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(sqrt2invert, 0.5f, sqrt2invert);

                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(sqrt2invert, -0.5f, sqrt2invert);

                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(-sqrt2invert, -0.5f, -sqrt2invert);

                        Gl.glEnd();

                        Gl.glBegin(Gl.GL_QUADS);

                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(sqrt2invert, -0.5f, -sqrt2invert);

                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(-sqrt2invert, -0.5f, sqrt2invert);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(-sqrt2invert, 0.5f, sqrt2invert);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(sqrt2invert, 0.5f, -sqrt2invert);

                        Gl.glEnd();

                        //top
                        Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[1]);

                        Gl.glTranslatef(0.0f, 0.5f + 8.0f / 16.0f, 0.0f);

                        Gl.glBegin(Gl.GL_QUADS);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(-sqrt2invert, 0.5f, -sqrt2invert);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(sqrt2invert, 0.5f, sqrt2invert);

                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(sqrt2invert, -0.5f, sqrt2invert);

                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(-sqrt2invert, -0.5f, -sqrt2invert);

                        Gl.glEnd();

                        Gl.glBegin(Gl.GL_QUADS);

                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(sqrt2invert, -0.5f, -sqrt2invert);

                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(-sqrt2invert, -0.5f, sqrt2invert);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(-sqrt2invert, 0.5f, sqrt2invert);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(sqrt2invert, 0.5f, -sqrt2invert);

                        Gl.glEnd();
                    }
                    else if (modelType == ModelType.RedstoneComparatorOff)
                    {
                        drawModelTextureMapped(0, 0, 0, 16, 2, 16,
                            0.0f, 0.0f, 0.0f, true);

                        float xOffset = 8.0f;
                        float yOffset = 4.0f;
                        float zOffset = 7.0f;

                        UV torchFront = new UV(7, 6, 8, 10, 1, 16, 16);
                        UV torchBack = new UV(7, 6, 8, 10, 1, 16, 16);
                        UV torchLeft = new UV(7, 6, 8, 10, 1, 16, 16);
                        UV torchRight = new UV(7, 6, 8, 10, 1, 16, 16);
                        UV torchTop = new UV(7, 6, 8, 7, 1, 16, 16);
                        UV torchBottom = new UV(7, 6, 8, 7, 1, 16, 16);
                        UVinfo torch = new UVinfo(torchFront, torchBack, torchLeft, torchRight,
                            torchTop, torchBottom);

                        drawModel(2.0f, 5.0f, 2.0f, (xOffset - 5.0f) / 16.0f, (yOffset - 0.5f) / 16.0f, (zOffset - 3.0f) / 16.0f, torch);
                        drawModel(2.0f, 5.0f, 2.0f, (xOffset - 11.0f) / 16.0f, (yOffset - 0.5f) / 16.0f, (zOffset - 3.0f) / 16.0f, torch);

                        //front
                        UV smallFront = new UV(7, 6, 8, 7, 1, 16, 16);
                        UV smallBack = new UV(7, 6, 8, 7, 1, 16, 16);
                        UV smallLeft = new UV(7, 6, 8, 7, 1, 16, 16);
                        UV smallRight = new UV(7, 6, 8, 7, 1, 16, 16);
                        UV smallTop = new UV(7, 6, 8, 7, 1, 16, 16);
                        UV smallBottom = new UV(7, 6, 8, 7, 1, 16, 16);
                        UVinfo small = new UVinfo(smallFront, smallBack, smallLeft, smallRight,
                            smallTop, smallBottom);

                        drawModel(2.0f, 2.0f, 2.0f, (xOffset - 8.0f) / 16.0f, (yOffset - 2.0f) / 16.0f, (zOffset - 12.0f) / 16.0f, small);
                    }
                    else if (modelType == ModelType.RedstoneComparatorOn)
                    {
                        drawModelTextureMapped(0, 0, 0, 16, 2, 16,
                            0.0f, 0.0f, 0.0f, true);

                        float xOffset = 8.0f;
                        float yOffset = 4.0f;
                        float zOffset = 7.0f;

                        UV torchFront = new UV(7, 6, 8, 10, 2, 16, 16);
                        UV torchBack = new UV(7, 6, 8, 10, 2, 16, 16);
                        UV torchLeft = new UV(7, 6, 8, 10, 2, 16, 16);
                        UV torchRight = new UV(7, 6, 8, 10, 2, 16, 16);
                        UV torchTop = new UV(7, 6, 8, 7, 2, 16, 16);
                        UV torchBottom = new UV(7, 6, 8, 7, 2, 16, 16);
                        UVinfo torch = new UVinfo(torchFront, torchBack, torchLeft, torchRight,
                            torchTop, torchBottom);

                        drawModel(2.0f, 5.0f, 2.0f, (xOffset - 5.0f) / 16.0f, (yOffset - 0.5f) / 16.0f, (zOffset - 3.0f) / 16.0f, torch);
                        drawModel(2.0f, 5.0f, 2.0f, (xOffset - 11.0f) / 16.0f, (yOffset - 0.5f) / 16.0f, (zOffset - 3.0f) / 16.0f, torch);

                        UV smallFront = new UV(7, 6, 8, 7, 1, 16, 16);
                        UV smallBack = new UV(7, 6, 8, 7, 1, 16, 16);
                        UV smallLeft = new UV(7, 6, 8, 7, 1, 16, 16);
                        UV smallRight = new UV(7, 6, 8, 7, 1, 16, 16);
                        UV smallTop = new UV(7, 6, 8, 7, 1, 16, 16);
                        UV smallBottom = new UV(7, 6, 8, 7, 1, 16, 16);
                        UVinfo small = new UVinfo(smallFront, smallBack, smallLeft, smallRight,
                            smallTop, smallBottom);

                        drawModel(2.0f, 2.0f, 2.0f, (xOffset - 8.0f) / 16.0f, (yOffset - 2.0f) / 16.0f, (zOffset - 12.0f) / 16.0f, small);

                        Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[2]);
                        drawTorchPlanes(1.0f, (xOffset - 5.0f) / 16.0f, (yOffset - 3.0f) / 16.0f, (zOffset - 3.0f) / 16.0f);
                        drawTorchPlanes(1.0f, (xOffset - 11.0f) / 16.0f, (yOffset - 3.0f) / 16.0f, (zOffset - 3.0f) / 16.0f);
                    }
                    else if (modelType == ModelType.TripWireHook)
                    {
                        drawModelTextureMapped(6, 1, 0, 4, 8, 2,
                            0.0f, 0.0f, 0.0f, true);

                        Gl.glRotatef(270.0f, 0.0f, 1.0f, 0.0f);
                        Gl.glScalef(1.6f, 1.6f, 1.6f);
                        Gl.glTranslatef(0.125f, 0.0f, 0.0f);

                        Gl.glPushMatrix();

                        Gl.glRotatef(85.0f, 0.0f, 0.0f, 1.0f);

                        //arm
                        UV armFront = new UV(7, 9, 8, 15, 1, 16, 16);
                        UV armBack = new UV(7, 9, 8, 15, 1, 16, 16);
                        UV armLeft = new UV(7, 9, 8, 15, 1, 16, 16);
                        UV armRight = new UV(7, 9, 8, 15, 1, 16, 16);
                        UV armTop = new UV(7, 9, 8, 10, 1, 16, 16);
                        UV armBottom = new UV(7, 9, 8, 10, 1, 16, 16);
                        UVinfo arm = new UVinfo(armFront, armBack, armLeft, armRight,
                            armTop, armBottom);

                        drawModelDoor(1, 3.5f, 1, 0.0f, 0.0f, 0.0f, arm, true, true);

                        Gl.glPopMatrix();

                        float xOffset = 0.25f;

                        Gl.glScalef(0.6667f, 0.6667f, 0.6667f);
                        Gl.glTranslatef(xOffset, -0.0025f, 0.0f);
                        Gl.glRotatef(-10.0f, 0.0f, 0.0f, 1.0f);

                        //hook
                        UV hookFront = new UV(5, 3, 10, 4, 1, 16, 16);
                        UV hookBack = new UV(5, 3, 10, 4, 1, 16, 16);
                        UV hookLeft = new UV(5, 3, 10, 4, 1, 16, 16);
                        UV hookRight = new UV(5, 3, 10, 4, 1, 16, 16);
                        UV hookTop = new UV(5, 3, 10, 8, 1, 16, 16);
                        UV hookBottom = new UV(5, 3, 10, 8, 1, 16, 16);
                        UVinfo hook = new UVinfo(hookFront, hookBack, hookLeft, hookRight,
                            hookTop, hookBottom);

                        drawModelDoor(3, 0.5f, 3, 0.0f, 0.0f, 0.0f, hook, true, true);
                    }
                    else if (modelType == ModelType.TripWire)
                    {
                        Gl.glBegin(Gl.GL_QUADS);

                        float zOffset = 0.5f + 1.0f / 8.0f;

                        //top face
                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(-1, 0, -1 + zOffset);

                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(-1, 0, 1 + zOffset);

                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(1, 0, 1 + zOffset);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(1, 0, -1 + zOffset);

                        Gl.glEnd();
                    }
                    else if (modelType == ModelType.Beacon)
                    {
                        UV glassFront = new UV(0, 0, 16, 16, 0, 16, 16);
                        UV glassBack = new UV(0, 0, 16, 16, 0, 16, 16);
                        UV glassLeft = new UV(0, 0, 16, 16, 0, 16, 16);
                        UV glassRight = new UV(0, 0, 16, 16, 0, 16, 16);
                        UV glassTop = new UV(0, 0, 16, 16, 0, 16, 16);
                        UV glassBottom = new UV(0, 0, 16, 16, 0, 16, 16);
                        UVinfo glass = new UVinfo(glassFront, glassBack, glassLeft, glassRight,
                            glassTop, glassBottom);

                        drawModelDoor(16, 16, 16, 0.0f, 0.0f, 0.0f, glass, true, true);

                        Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[1]);

                        drawModelTextureMapped(3, 3, 3, 10, 10, 10,
                            0.0f, 0.0f, 0.0f, true);

                        Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[2]);

                        drawModelTextureMapped(2, 0.01f, 2, 12, 3, 12,
                            -8.0f / 16.0f, -8.0f / 16.0f, -8.0f / 16.0f, false);
                    }
                    else if (modelType == ModelType.Wall)
                    {
                        drawModelTextureMapped(4, 0, 4, 8, 16, 8,
                            -1.0f, -0.5f, -0.5f, false);

                        drawModelTextureMapped(12, 0, 5, 8, 13, 6,
                            -1.0f, -0.5f, -0.5f, false);

                        drawModelTextureMapped(20, 0, 4, 8, 16, 8,
                            -1.0f, -0.5f, -0.5f, false);
                    }
                    else if (modelType == ModelType.FlowerPot)
                    {
                        UV flowerPotFront = new UV(5, 10, 10, 15, 0, 16, 16);
                        UV flowerPotBack = new UV(5, 10, 10, 15, 0, 16, 16);
                        UV flowerPotLeft = new UV(5, 10, 10, 15, 0, 16, 16);
                        UV flowerPotRight = new UV(5, 10, 10, 15, 0, 16, 16);
                        UV flowerPotTop = new UV(5, 5, 10, 10, 0, 16, 16);
                        UV flowerPotBottom = new UV(5, 10, 10, 15, 0, 16, 16);
                        UVinfo flowerPot = new UVinfo(flowerPotFront, flowerPotBack, flowerPotLeft, flowerPotRight,
                            flowerPotTop, flowerPotBottom);

                        drawModel(6, 6, 6, flowerPot);

                        Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[0]);

                        //draw insides of flower cauldron
                        float offset = 2.0f / 32.0f;
                        float size = 6.0f / 32.0f;

                        //left face
                        Gl.glBegin(Gl.GL_QUADS);
                        Gl.glTexCoord2f(5.0f / 16.0f, 0.0f / 16.0f); //0, 0
                        Gl.glVertex3f(-size + offset, size, -size);

                        Gl.glTexCoord2f(5.0f / 16.0f, 6.0f / 16.0f); //0, 1
                        Gl.glVertex3f(-size + offset, size, -size);

                        Gl.glTexCoord2f(11.0f / 16.0f, 0.0f / 16.0f); //1, 0
                        Gl.glVertex3f(-size + offset, size, size);

                        Gl.glTexCoord2f(11.0f / 16.0f, 6.0f / 16.0f); //1, 1
                        Gl.glVertex3f(-size + offset, size, size);

                        Gl.glEnd();

                        Gl.glBegin(Gl.GL_QUADS);
                        Gl.glTexCoord2f(11.0f / 16.0f, 0.0f / 16.0f); //1, 0
                        Gl.glVertex3f(-size + offset, -size, -size);

                        Gl.glTexCoord2f(11.0f / 16.0f, 6.0f / 16.0f); //1, 1
                        Gl.glVertex3f(-size + offset, size, -size);

                        Gl.glTexCoord2f(5.0f / 16.0f, 6.0f / 16.0f); //0, 1
                        Gl.glVertex3f(-size + offset, size, size);

                        Gl.glTexCoord2f(5.0f / 16.0f, 0.0f / 16.0f); //0, 0
                        Gl.glVertex3f(-size + offset, -size, size);
                        Gl.glEnd();

                        //right face
                        Gl.glBegin(Gl.GL_QUADS);
                        Gl.glTexCoord2f(11.0f / 16.0f, 0.0f / 16.0f); //1, 0
                        Gl.glVertex3f(size - offset, -size, -size);

                        Gl.glTexCoord2f(11.0f / 16.0f, 6.0f / 16.0f); //1, 1
                        Gl.glVertex3f(size - offset, size, -size);

                        Gl.glTexCoord2f(5.0f / 16.0f, 6.0f / 16.0f); //0, 1
                        Gl.glVertex3f(size - offset, size, size);

                        Gl.glTexCoord2f(5.0f / 16.0f, 0.0f / 16.0f); //0, 0
                        Gl.glVertex3f(size - offset, -size, size);
                        Gl.glEnd();

                        //front face
                        Gl.glBegin(Gl.GL_QUADS);
                        Gl.glTexCoord2f(5.0f / 16.0f, 0.0f / 16.0f); //0, 0
                        Gl.glVertex3f(-size, -size, size - offset);

                        Gl.glTexCoord2f(11.0f / 16.0f, 0.0f / 16.0f); //1, 0
                        Gl.glVertex3f(size, -size, size - offset);

                        Gl.glTexCoord2f(11.0f / 16.0f, 6.0f / 16.0f); //1, 1
                        Gl.glVertex3f(size, size, size - offset);

                        Gl.glTexCoord2f(5.0f / 16.0f, 6.0f / 16.0f); //0, 1
                        Gl.glVertex3f(-size, size, size - offset);
                        Gl.glEnd();

                        //back face
                        Gl.glBegin(Gl.GL_QUADS);
                        Gl.glTexCoord2f(11.0f / 16.0f, 0.0f / 16.0f); //1, 0
                        Gl.glVertex3f(-size, -size, -size + offset);

                        Gl.glTexCoord2f(11.0f / 16.0f, 6.0f / 16.0f); //1, 1
                        Gl.glVertex3f(-size, size, -size + offset);

                        Gl.glTexCoord2f(5.0f / 16.0f, 6.0f / 16.0f); //0, 1
                        Gl.glVertex3f(size, size, -size + offset);

                        Gl.glTexCoord2f(5.0f / 16.0f, 0.0f / 16.0f); //0, 0
                        Gl.glVertex3f(size, -size, -size + offset);
                        Gl.glEnd();

                        Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[1]);

                        //draw dirt in pot
                        float scale = 0.5f;

                        Gl.glBegin(Gl.GL_QUADS);
                        Gl.glTexCoord2f(10.0f / 16.0f, 6.0f / 16.0f); //0, 1
                        Gl.glVertex3f(-4.0f / 16.0f * scale, 2.25f / 16.0f * scale, -4.0f / 16.0f * scale); //-1 1 -1

                        Gl.glTexCoord2f(10.0f / 16.0f, 10.0f / 16.0f); //0, 0
                        Gl.glVertex3f(-4.0f / 16.0f * scale, 2.25f / 16.0f * scale, 4.0f / 16.0f * scale); //-1 1 1

                        Gl.glTexCoord2f(6.0f / 16.0f, 10.0f / 16.0f); //1, 0
                        Gl.glVertex3f(4.0f / 16.0f * scale, 2.25f / 16.0f * scale, 4.0f / 16.0f * scale); //1 1 1

                        Gl.glTexCoord2f(6.0f / 16.0f, 6.0f / 16.0f); //1, 1
                        Gl.glVertex3f(4.0f / 16.0f * scale, 2.25f / 16.0f * scale, -4.0f / 16.0f * scale); //1 1 -1
                        Gl.glEnd();
                    }
                    else if (modelType == ModelType.Anvil)
                    {
                        float xOffset = -8.0f / 16.0f;
                        float yOffset = -2.0f / 16.0f;
                        float zOffset = -8.0f / 16.0f;

                        drawModelTextureMapped(2, 0, 2, 12, 4, 12,
                            xOffset, -7.0f / 16.0f + yOffset, zOffset, false);

                        drawModelTextureMapped(4, 4, 3, 8, 1, 10,
                            xOffset, -7.0f / 16.0f + yOffset, zOffset, false);

                        drawModelTextureMapped(6, 5, 4, 4, 5, 8,
                            xOffset, -7.0f / 16.0f + yOffset, zOffset, false);

                        drawModelTextureMapped(3, 10, 0, 10, 6, 16,
                            xOffset, -7.0f / 16.0f + yOffset, zOffset, false);
                    }
                    else if (modelType == ModelType.MobHead)
                    {
                        UV mobHeadFront = new UV(8, 8, 15, 15, 0, 64, 32);
                        UV mobHeadBack = new UV(24, 8, 31, 15, 0, 64, 32);
                        UV mobHeadLeft = new UV(0, 8, 7, 15, 0, 64, 32);
                        UV mobHeadRight = new UV(16, 8, 23, 15, 0, 64, 32);
                        UV mobHeadTop = new UV(8, 0, 15, 7, 0, 64, 32);
                        UV mobHeadBottom = new UV(16, 0, 23, 7, 0, 64, 32);
                        UVinfo mobHead = new UVinfo(mobHeadFront, mobHeadBack, mobHeadLeft, mobHeadRight,
                            mobHeadTop, mobHeadBottom);

                        drawModel(8, 8, 8, mobHead);
                    }
                    else if (modelType == ModelType.ZombieHead)
                    {
                        UV mobHeadFront = new UV(8, 8, 15, 15, 0, 64, 64);
                        UV mobHeadBack = new UV(24, 8, 31, 15, 0, 64, 64);
                        UV mobHeadLeft = new UV(0, 8, 7, 15, 0, 64, 64);
                        UV mobHeadRight = new UV(16, 8, 23, 15, 0, 64, 64);
                        UV mobHeadTop = new UV(8, 0, 15, 7, 0, 64, 64);
                        UV mobHeadBottom = new UV(16, 0, 23, 7, 0, 64, 64);
                        UVinfo mobHead = new UVinfo(mobHeadFront, mobHeadBack, mobHeadLeft, mobHeadRight,
                            mobHeadTop, mobHeadBottom);

                        drawModel(8, 8, 8, mobHead);
                    }
                    else if (modelType == ModelType.Destroy)
                    {
                        Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[frameIndex]);

                        Gl.glBegin(Gl.GL_QUADS);

                        //front face
                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(-0.5f, -0.5f, 0.5f);

                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(0.5f, -0.5f, 0.5f);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(0.5f, 0.5f, 0.5f);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(-0.5f, 0.5f, 0.5f);

                        Gl.glEnd();

                        Gl.glBegin(Gl.GL_QUADS);

                        //back face
                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(-0.5f, -0.5f, -0.5f);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(-0.5f, 0.5f, -0.5f);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(0.5f, 0.5f, -0.5f);

                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(0.5f, -0.5f, -0.5f);

                        //right face
                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(0.5f, -0.5f, -0.5f);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(0.5f, 0.5f, -0.5f);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(0.5f, 0.5f, 0.5f);

                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(0.5f, -0.5f, 0.5f);

                        //left face
                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(-0.5f, -0.5f, -0.5f);

                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(-0.5f, -0.5f, 0.5f);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(-0.5f, 0.5f, 0.5f);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(-0.5f, 0.5f, -0.5f);

                        Gl.glEnd();

                        Gl.glBegin(Gl.GL_QUADS);

                        //top face
                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(-0.5f, 0.5f, -0.5f);

                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(-0.5f, 0.5f, 0.5f);

                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(0.5f, 0.5f, 0.5f);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(0.5f, 0.5f, -0.5f);

                        Gl.glEnd();

                        Gl.glBegin(Gl.GL_QUADS);

                        //bottom face
                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(-0.5f, -0.5f, -0.5f);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(0.5f, -0.5f, -0.5f);

                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(0.5f, -0.5f, 0.5f);

                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(-0.5f, -0.5f, 0.5f);

                        Gl.glEnd();
                    }
                    else if (modelType == ModelType.CraftingTable)
                    {
                        Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[0]);

                        Gl.glBegin(Gl.GL_QUADS);

                        //front face
                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(-0.5f, -0.5f, 0.5f);

                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(0.5f, -0.5f, 0.5f);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(0.5f, 0.5f, 0.5f);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(-0.5f, 0.5f, 0.5f);

                        //right face
                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(0.5f, -0.5f, -0.5f);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(0.5f, 0.5f, -0.5f);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(0.5f, 0.5f, 0.5f);

                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(0.5f, -0.5f, 0.5f);

                        Gl.glEnd();

                        Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[1]);

                        Gl.glBegin(Gl.GL_QUADS);

                        //top face
                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(-0.5f, 0.5f, -0.5f);

                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(-0.5f, 0.5f, 0.5f);

                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(0.5f, 0.5f, 0.5f);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(0.5f, 0.5f, -0.5f);

                        Gl.glEnd();

                        Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[2]);

                        Gl.glBegin(Gl.GL_QUADS);

                        //bottom face
                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(-0.5f, -0.5f, -0.5f);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(0.5f, -0.5f, -0.5f);

                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(0.5f, -0.5f, 0.5f);

                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(-0.5f, -0.5f, 0.5f);

                        Gl.glEnd();

                        Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[3]);

                        Gl.glBegin(Gl.GL_QUADS);

                        //back face
                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(-0.5f, -0.5f, -0.5f);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(-0.5f, 0.5f, -0.5f);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(0.5f, 0.5f, -0.5f);

                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(0.5f, -0.5f, -0.5f);

                        //left face
                        Gl.glTexCoord2f(0, 0);
                        Gl.glVertex3f(-0.5f, -0.5f, -0.5f);

                        Gl.glTexCoord2f(1, 0);
                        Gl.glVertex3f(-0.5f, -0.5f, 0.5f);

                        Gl.glTexCoord2f(1, 1);
                        Gl.glVertex3f(-0.5f, 0.5f, 0.5f);

                        Gl.glTexCoord2f(0, 1);
                        Gl.glVertex3f(-0.5f, 0.5f, -0.5f);

                        Gl.glEnd();
                    }
                } /**/

                if (loadNewTextures)
                {
                    if (!String.IsNullOrEmpty(FrmMain.directory))
                    {
                        loadOpenGLTextures();
                    }
                    loadNewTextures = false;
                }

                if (boolUpdateTextures)
                {
                    updateTextures();
                }

                Gl.glFlush();

                return true;
            }
            catch (Exception exception)
            {
                MessageBox.Show("Exception occured during render step: " + exception.Message + "\n" +
                    exception.StackTrace);
                return false;
            }
        }

        private static void setEyePosition()
        {
            eyePosition = new Vector3();

            eyePosition.x -= (float)(Math.Cos(MathUtil.toRad(rotX)) * orbitDistance *
                Math.Cos(MathUtil.toRad(rotY)));
            eyePosition.y += (float)(Math.Sin(MathUtil.toRad(rotY)) * orbitDistance);
            eyePosition.z -= (float)(Math.Sin(MathUtil.toRad(rotX)) * orbitDistance *
                Math.Cos(MathUtil.toRad(rotY)));
        }

        public static void renderBlock()
        {
            /**/
            if (textureCount > 1)
            {
                Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[63]);
            }

            Gl.glBegin(Gl.GL_QUADS);

            //front face
            Gl.glTexCoord2f(0, 0);
            Gl.glVertex3f(-0.5f, -0.5f, 0.5f);

            Gl.glTexCoord2f(1, 0);
            Gl.glVertex3f(0.5f, -0.5f, 0.5f);

            Gl.glTexCoord2f(1, 1);
            Gl.glVertex3f(0.5f, 0.5f, 0.5f);

            Gl.glTexCoord2f(0, 1);
            Gl.glVertex3f(-0.5f, 0.5f, 0.5f);

            //back face
            Gl.glTexCoord2f(1, 0);
            Gl.glVertex3f(-0.5f, -0.5f, -0.5f);

            Gl.glTexCoord2f(1, 1);
            Gl.glVertex3f(-0.5f, 0.5f, -0.5f);

            Gl.glTexCoord2f(0, 1);
            Gl.glVertex3f(0.5f, 0.5f, -0.5f);

            Gl.glTexCoord2f(0, 0);
            Gl.glVertex3f(0.5f, -0.5f, -0.5f);

            //right face
            Gl.glTexCoord2f(1, 0);
            Gl.glVertex3f(0.5f, -0.5f, -0.5f);

            Gl.glTexCoord2f(1, 1);
            Gl.glVertex3f(0.5f, 0.5f, -0.5f);

            Gl.glTexCoord2f(0, 1);
            Gl.glVertex3f(0.5f, 0.5f, 0.5f);

            Gl.glTexCoord2f(0, 0);
            Gl.glVertex3f(0.5f, -0.5f, 0.5f);

            //left face
            Gl.glTexCoord2f(0, 0);
            Gl.glVertex3f(-0.5f, -0.5f, -0.5f);

            Gl.glTexCoord2f(1, 0);
            Gl.glVertex3f(-0.5f, -0.5f, 0.5f);

            Gl.glTexCoord2f(1, 1);
            Gl.glVertex3f(-0.5f, 0.5f, 0.5f);

            Gl.glTexCoord2f(0, 1);
            Gl.glVertex3f(-0.5f, 0.5f, -0.5f);

            //top face
            Gl.glTexCoord2f(0, 1);
            Gl.glVertex3f(-0.5f, 0.5f, -0.5f);

            Gl.glTexCoord2f(0, 0);
            Gl.glVertex3f(-0.5f, 0.5f, 0.5f);

            Gl.glTexCoord2f(1, 0);
            Gl.glVertex3f(0.5f, 0.5f, 0.5f);

            Gl.glTexCoord2f(1, 1);
            Gl.glVertex3f(0.5f, 0.5f, -0.5f);

            //bottom face
            Gl.glTexCoord2f(1, 1);
            Gl.glVertex3f(-0.5f, -0.5f, -0.5f);

            Gl.glTexCoord2f(0, 1);
            Gl.glVertex3f(0.5f, -0.5f, -0.5f);

            Gl.glTexCoord2f(0, 0);
            Gl.glVertex3f(0.5f, -0.5f, 0.5f);

            Gl.glTexCoord2f(1, 0);
            Gl.glVertex3f(-0.5f, -0.5f, 0.5f);

            Gl.glEnd();
        }

        public static void drawBrewingArms(float startU, float endU, float startV, float endV)
        {
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[0]);

            Gl.glBegin(Gl.GL_QUADS);

            //first arm
            Gl.glTexCoord2f(startU, startV);
            Gl.glVertex3f(0, -0.5f, 0); //-1 -1 0

            Gl.glTexCoord2f(endU, startV);
            Gl.glVertex3f(0.5f, -0.5f, 0); //1 -1 0

            Gl.glTexCoord2f(endU, endV);
            Gl.glVertex3f(0.5f, 0.5f, 0); //1 1 0

            Gl.glTexCoord2f(startU, endV);
            Gl.glVertex3f(0, 0.5f, 0); //-1 1 0

            Gl.glEnd();

            Gl.glRotatef(120.0f, 0.0f, 1.0f, 0.0f);

            Gl.glBegin(Gl.GL_QUADS);

            //second arm
            Gl.glTexCoord2f(startU, startV);
            Gl.glVertex3f(0, -0.5f, 0); //-1 -1 0

            Gl.glTexCoord2f(endU, startV);
            Gl.glVertex3f(0.5f, -0.5f, 0); //1 -1 0

            Gl.glTexCoord2f(endU, endV);
            Gl.glVertex3f(0.5f, 0.5f, 0); //1 1 0

            Gl.glTexCoord2f(startU, endV);
            Gl.glVertex3f(0, 0.5f, 0); //-1 1 0

            Gl.glEnd();

            Gl.glRotatef(120.0f, 0.0f, 1.0f, 0.0f);

            Gl.glBegin(Gl.GL_QUADS);

            //third arm
            Gl.glTexCoord2f(startU, startV);
            Gl.glVertex3f(0, -0.5f, 0); //-1 -1 0

            Gl.glTexCoord2f(endU, startV);
            Gl.glVertex3f(0.5f, -0.5f, 0); //1 -1 0

            Gl.glTexCoord2f(endU, endV);
            Gl.glVertex3f(0.5f, 0.5f, 0); //1 1 0

            Gl.glTexCoord2f(startU, endV);
            Gl.glVertex3f(0, 0.5f, 0); //-1 1 0

            Gl.glEnd();
        }

        public static void drawTorchPlanes(float scale, float xOffset, float yOffset, float zOffset)
        {
            UV front = new UV(6, 6, 9, 7, 16, 16);
            float saveXoffset = xOffset;
            float saveYoffset = yOffset;
            float saveZoffset = zOffset;

            //right horizontal
            Gl.glBegin(Gl.GL_QUADS);

            yOffset = saveYoffset + 8.0f / 32.0f * scale;
            zOffset = saveZoffset + 2.1f / 32.0f * scale;

            Gl.glTexCoord2f(front.startU, front.startV); //0, 0
            Gl.glVertex3f(-4.0f / 32.0f * scale + xOffset, -2.0f / 32.0f * scale + yOffset, zOffset); //-1 -1 1

            Gl.glTexCoord2f(front.endU, front.startV); //1, 0
            Gl.glVertex3f(4.0f / 32.0f * scale + xOffset, -2.0f / 32.0f * scale + yOffset, zOffset); //1 -1 1

            Gl.glTexCoord2f(front.endU, front.endV); //1, 1
            Gl.glVertex3f(4.0f / 32.0f * scale + xOffset, 2.0f / 32.0f * scale + yOffset, zOffset); //1 1 1

            Gl.glTexCoord2f(front.startU, front.endV); //0, 1
            Gl.glVertex3f(-4.0f / 32.0f * scale + xOffset, 2.0f / 32.0f * scale + yOffset, zOffset); //-1 1 1

            Gl.glEnd();

            //left horizontal
            Gl.glBegin(Gl.GL_QUADS);

            yOffset = saveYoffset + 8.0f / 32.0f * scale;
            zOffset = saveZoffset - 2.1f / 32.0f * scale;

            Gl.glTexCoord2f(front.startU, front.startV); //1, 0
            Gl.glVertex3f(4.0f / 32.0f * scale + xOffset, -2.0f / 32.0f * scale + yOffset, zOffset); //1 -1 1

            Gl.glTexCoord2f(front.endU, front.startV); //0, 0
            Gl.glVertex3f(-4.0f / 32.0f * scale + xOffset, -2.0f / 32.0f * scale + yOffset, zOffset); //-1 -1 1

            Gl.glTexCoord2f(front.endU, front.endV); //0, 1
            Gl.glVertex3f(-4.0f / 32.0f * scale + xOffset, 2.0f / 32.0f * scale + yOffset, zOffset); //-1 1 1

            Gl.glTexCoord2f(front.startU, front.endV); //1, 1
            Gl.glVertex3f(4.0f / 32.0f * scale + xOffset, 2.0f / 32.0f * scale + yOffset, zOffset); //1 1 1

            Gl.glEnd();

            //right vertical
            Gl.glBegin(Gl.GL_QUADS);

            front = new UV(7, 5, 8, 8, 16, 16);

            yOffset = saveYoffset + 8.0f / 32.0f * scale;
            zOffset = saveZoffset + 2.1f / 32.0f * scale;

            Gl.glTexCoord2f(front.startU, front.startV); //0, 0
            Gl.glVertex3f(-2.0f / 32.0f * scale + xOffset, -4.0f / 32.0f * scale + yOffset, zOffset); //-1 -1 1

            Gl.glTexCoord2f(front.endU, front.startV); //1, 0
            Gl.glVertex3f(2.0f / 32.0f * scale + xOffset, -4.0f / 32.0f * scale + yOffset, zOffset); //1 -1 1

            Gl.glTexCoord2f(front.endU, front.endV); //1, 1
            Gl.glVertex3f(2.0f / 32.0f * scale + xOffset, 4.0f / 32.0f * scale + yOffset, zOffset); //1 1 1

            Gl.glTexCoord2f(front.startU, front.endV); //0, 1
            Gl.glVertex3f(-2.0f / 32.0f * scale + xOffset, 4.0f / 32.0f * scale + yOffset, zOffset); //-1 1 1

            Gl.glEnd();

            //left vertical
            Gl.glBegin(Gl.GL_QUADS);

            yOffset = saveYoffset + 8.0f / 32.0f * scale;
            zOffset = saveZoffset - 2.1f / 32.0f * scale;

            Gl.glTexCoord2f(front.startU, front.startV); //1, 0
            Gl.glVertex3f(2.0f / 32.0f * scale + xOffset, -4.0f / 32.0f * scale + yOffset, zOffset); //1 -1 1

            Gl.glTexCoord2f(front.endU, front.startV); //0, 0
            Gl.glVertex3f(-2.0f / 32.0f * scale + xOffset, -4.0f / 32.0f * scale + yOffset, zOffset); //-1 -1 1

            Gl.glTexCoord2f(front.endU, front.endV); //0, 1
            Gl.glVertex3f(-2.0f / 32.0f * scale + xOffset, 4.0f / 32.0f * scale + yOffset, zOffset); //-1 1 1

            Gl.glTexCoord2f(front.startU, front.endV); //1, 1
            Gl.glVertex3f(2.0f / 32.0f * scale + xOffset, 4.0f / 32.0f * scale + yOffset, zOffset); //1 1 1

            Gl.glEnd();

            //front horizontal
            Gl.glBegin(Gl.GL_QUADS);

            UV side = new UV(8, 6, 9, 9, 16, 16, true);

            xOffset = saveXoffset - 2.05f / 32.0f * scale;
            yOffset = saveYoffset + 8.0f / 32.0f * scale;

            Gl.glTexCoord2f(side.startU, side.startV); //0, 0
            Gl.glVertex3f(xOffset, -2.0f / 32.0f * scale + yOffset, zOffset - 4.0f / 32.0f * scale + 1.0f / 16.0f); //-1 -1 -1

            Gl.glTexCoord2f(side.endU, side.startV); //1, 0
            Gl.glVertex3f(xOffset, -2.0f / 32.0f * scale + yOffset, zOffset + 4.0f / 32.0f * scale + 1.0f / 16.0f); //-1 -1 1

            Gl.glTexCoord2f(side.endU, side.endV); //1, 1
            Gl.glVertex3f(xOffset, 2.0f / 32.0f * scale + yOffset, zOffset + 4.0f / 32.0f * scale + 1.0f / 16.0f); //-1 1 1

            Gl.glTexCoord2f(side.startU, side.endV); //0, 1
            Gl.glVertex3f(xOffset, 2.0f / 32.0f * scale + yOffset, zOffset - 4.0f / 32.0f * scale + 1.0f / 16.0f); //-1 1 -1

            Gl.glEnd();

            //front vertical
            Gl.glBegin(Gl.GL_QUADS);

            side = new UV(7, 5, 8, 8, 16, 16, false);

            Gl.glTexCoord2f(side.startU, side.startV); //0, 0
            Gl.glVertex3f(xOffset + 0.01f * scale, -4.0f / 32.0f * scale + yOffset, zOffset - 2.0f / 32.0f * scale + 1.0f / 16.0f); //-1 -1 -1

            Gl.glTexCoord2f(side.endU, side.startV); //1, 0
            Gl.glVertex3f(xOffset + 0.01f * scale, -4.0f / 32.0f * scale + yOffset, zOffset + 2.0f / 32.0f * scale + 1.0f / 16.0f); //-1 -1 1

            Gl.glTexCoord2f(side.endU, side.endV); //1, 1
            Gl.glVertex3f(xOffset + 0.01f * scale, 4.0f / 32.0f * scale + yOffset, zOffset + 2.0f / 32.0f * scale + 1.0f / 16.0f); //-1 1 1

            Gl.glTexCoord2f(side.startU, side.endV); //0, 1
            Gl.glVertex3f(xOffset + 0.01f * scale, 4.0f / 32.0f * scale + yOffset, zOffset - 2.0f / 32.0f * scale + 1.0f / 16.0f); //-1 1 -1

            Gl.glEnd();

            //back horizontal
            Gl.glBegin(Gl.GL_QUADS);

            side = new UV(8, 6, 9, 9, 16, 16, true);

            xOffset = saveXoffset + 1.95f / 32.0f * scale;

            Gl.glTexCoord2f(side.startU, side.startV); //1, 0
            Gl.glVertex3f(xOffset, -2.0f / 32.0f * scale + yOffset, zOffset + 4.0f / 32.0f * scale + 1.0f / 16.0f); //-1 -1 1

            Gl.glTexCoord2f(side.endU, side.startV); //0, 0
            Gl.glVertex3f(xOffset, -2.0f / 32.0f * scale + yOffset, zOffset - 4.0f / 32.0f * scale + 1.0f / 16.0f); //-1 -1 -1

            Gl.glTexCoord2f(side.endU, side.endV); //0, 1
            Gl.glVertex3f(xOffset, 2.0f / 32.0f * scale + yOffset, zOffset - 4.0f / 32.0f * scale + 1.0f / 16.0f); //-1 1 -1

            Gl.glTexCoord2f(side.startU, side.endV); //1, 1
            Gl.glVertex3f(xOffset, 2.0f / 32.0f * scale + yOffset, zOffset + 4.0f / 32.0f * scale + 1.0f / 16.0f); //-1 1 1

            Gl.glEnd();

            //back vertical
            Gl.glBegin(Gl.GL_QUADS);

            side = new UV(7, 5, 8, 8, 16, 16, false);

            Gl.glTexCoord2f(side.startU, side.startV); //1, 0
            Gl.glVertex3f(xOffset + 0.01f * scale, -4.0f / 32.0f * scale + yOffset, zOffset + 2.0f / 32.0f * scale + 1.0f / 16.0f); //-1 -1 1

            Gl.glTexCoord2f(side.endU, side.startV); //0, 0
            Gl.glVertex3f(xOffset + 0.01f * scale, -4.0f / 32.0f * scale + yOffset, zOffset - 2.0f / 32.0f * scale + 1.0f / 16.0f); //-1 -1 -1

            Gl.glTexCoord2f(side.endU, side.endV); //0, 1
            Gl.glVertex3f(xOffset + 0.01f * scale, 4.0f / 32.0f * scale + yOffset, zOffset - 2.0f / 32.0f * scale + 1.0f / 16.0f); //-1 1 -1

            Gl.glTexCoord2f(side.startU, side.endV); //1, 1
            Gl.glVertex3f(xOffset + 0.01f * scale, 4.0f / 32.0f * scale + yOffset, zOffset + 2.0f / 32.0f * scale + 1.0f / 16.0f); //-1 1 1

            Gl.glEnd();
        }

        private static void updateTextures()
        {
            FrmTexturePreview.boolUpdateTextures = false;
            List<string> textures = Blocks.getTextures(blockName);

            try
            {
                frameIndex = 0;

                if (blockName == "Grass Block")
                {
                    loadGrassBlock();
                }
                else if (blockName == "Fire")
                {
                    loadFireTextures();
                }
                else if (blockName == "Water Still")
                {
                    loadTextureStrip(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\water_still.png", 32);
                }
                else if (blockName == "Water Flowing")
                {
                    loadTextureStrip(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\water_flow.png", 64);
                }
                else if (blockName == "Lava Still")
                {
                    loadTextureStrip(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\lava_still.png", 20);
                }
                else if (blockName == "Lava Flowing")
                {
                    loadTextureStrip(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\lava_flow.png", 32);
                }
                else if (blockName == "Portal")
                {
                    loadTextureStrip(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\portal.png", 32);
                }
                else if (blockName == "Destroy")
                {
                    loadDestroyAnimation();
                }
                else
                {
                    Bitmap bitmap = null;

                    if (FrmMain.texture1 == null)
                    {
                        Console.WriteLine("FrmMain.texture1 is null");
                        FrmTexturePreview.boolUpdateTextures = true;
                        return;
                    }

                    lock (FrmMain.texture1)
                    {
                        bitmap = new Bitmap(FrmMain.texture1);
                        loadOpenGLTexture(bitmap, FrmMain.texture1Filename, 0);
                    }

                    if (textures.Count > 1)
                    {
                        if (FrmMain.texture2 == null)
                        {
                            Console.WriteLine("FrmMain.texture2 is null");
                            FrmTexturePreview.boolUpdateTextures = true;
                            return;
                        }

                        lock (FrmMain.texture2)
                        {
                            bitmap = new Bitmap(FrmMain.texture2);
                            loadOpenGLTexture(bitmap, FrmMain.texture2Filename, 1);
                        }
                    }

                    if (textures.Count > 2)
                    {
                        if (FrmMain.texture3 == null)
                        {
                            Console.WriteLine("FrmMain.texture3 is null");
                            FrmTexturePreview.boolUpdateTextures = true;
                            return;
                        }

                        lock (FrmMain.texture3)
                        {
                            bitmap = new Bitmap(FrmMain.texture3);
                            loadOpenGLTexture(bitmap, FrmMain.texture3Filename, 2);
                        }
                    }

                    if (textures.Count > 3)
                    {
                        if (FrmMain.texture4 == null)
                        {
                            Console.WriteLine("FrmMain.texture4 is null");
                            FrmTexturePreview.boolUpdateTextures = true;
                            return;
                        }

                        lock (FrmMain.texture4)
                        {
                            bitmap = new Bitmap(FrmMain.texture4);
                            loadOpenGLTexture(bitmap, FrmMain.texture4Filename, 3);
                        }
                    }

                    if (textures.Count > 4)
                    {
                        if (FrmMain.texture5 == null)
                        {
                            Console.WriteLine("FrmMain.texture5 is null");
                            FrmTexturePreview.boolUpdateTextures = true;
                            return;
                        }

                        lock (FrmMain.texture5)
                        {
                            bitmap = new Bitmap(FrmMain.texture5);
                            loadOpenGLTexture(bitmap, FrmMain.texture5Filename, 4);
                        }
                    }

                    if (textures.Count > 5)
                    {
                        if (FrmMain.texture6 == null)
                        {
                            Console.WriteLine("FrmMain.texture6 is null");
                            FrmTexturePreview.boolUpdateTextures = true;
                            return;
                        }

                        lock (FrmMain.texture6)
                        {
                            bitmap = new Bitmap(FrmMain.texture6);
                            loadOpenGLTexture(bitmap, FrmMain.texture6Filename, 5);
                        }
                    }

                    if (textures.Count > 6)
                    {
                        if (FrmMain.texture7 == null)
                        {
                            Console.WriteLine("FrmMain.texture7 is null");
                            FrmTexturePreview.boolUpdateTextures = true;
                            return;
                        }

                        lock (FrmMain.texture7)
                        {
                            bitmap = new Bitmap(FrmMain.texture7);
                            loadOpenGLTexture(bitmap, FrmMain.texture7Filename, 6);
                        }
                    }

                    if (textures.Count > 7)
                    {
                        if (FrmMain.texture8 == null)
                        {
                            Console.WriteLine("FrmMain.texture8 is null");
                            FrmTexturePreview.boolUpdateTextures = true;
                            return;
                        }

                        lock (FrmMain.texture8)
                        {
                            bitmap = new Bitmap(FrmMain.texture8);
                            loadOpenGLTexture(bitmap, FrmMain.texture8Filename, 7);
                        }
                    }

                    if (textures.Count > 8)
                    {
                        if (FrmMain.texture9 == null)
                        {
                            Console.WriteLine("FrmMain.texture9 is null");
                            FrmTexturePreview.boolUpdateTextures = true;
                            return;
                        }

                        lock (FrmMain.texture9)
                        {
                            bitmap = new Bitmap(FrmMain.texture9);
                            loadOpenGLTexture(bitmap, FrmMain.texture9Filename, 8);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("Exception occured updating textures: " + exception.Message);
                FrmTexturePreview.boolUpdateTextures = true;
            }
        }

        public static void drawModel(float width, float height, float depth, UVinfo modelUVs)
        {
            drawModel(width, height, depth, 0, 0, 0, modelUVs);
        }

        public static void drawModel(float width, float height, float depth, float xOffset, float yOffset, float zOffset, UVinfo modelUVs)
        {
            //front face
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[modelUVs.front.textureIndex]);

            Gl.glBegin(Gl.GL_QUADS);

            float startU = modelUVs.front.startU;
            float endU = modelUVs.front.endU;

            float startV = modelUVs.front.startV;
            float endV = modelUVs.front.endV;

            if (modelUVs.front.flipU)
            {
                float saveStartU = startU;
                float saveEndU = endU;

                startU = saveEndU;
                endU = saveStartU;
            }

            if (modelUVs.front.flipV)
            {
                float saveStartV = startV;
                float saveEndV = endV;

                startV = saveEndV;
                endV = saveStartV;
            }

            if (modelUVs.front.rotateRight)
            {
                Gl.glTexCoord2f(1 - startV, startU); //startU, startV
                Gl.glVertex3f(-width / 32.0f + xOffset, -height / 32.0f + yOffset, depth / 32.0f + zOffset);

                Gl.glTexCoord2f(1 - startV, endU); //endU, startV
                Gl.glVertex3f(width / 32.0f + xOffset, -height / 32.0f + yOffset, depth / 32.0f + zOffset);

                Gl.glTexCoord2f(1 - endV, endU); //endU, endV
                Gl.glVertex3f(width / 32.0f + xOffset, height / 32.0f + yOffset, depth / 32.0f + zOffset);

                Gl.glTexCoord2f(1 - endV, startU); //startU, endV
                Gl.glVertex3f(-width / 32.0f + xOffset, height / 32.0f + yOffset, depth / 32.0f + zOffset);
            }
            else
            {
                Gl.glTexCoord2f(startU, startV); //0, 0
                Gl.glVertex3f(-width / 32.0f + xOffset, -height / 32.0f + yOffset, depth / 32.0f + zOffset);

                Gl.glTexCoord2f(endU, startV); //1, 0
                Gl.glVertex3f(width / 32.0f + xOffset, -height / 32.0f + yOffset, depth / 32.0f + zOffset);

                Gl.glTexCoord2f(endU, endV); //1, 1
                Gl.glVertex3f(width / 32.0f + xOffset, height / 32.0f + yOffset, depth / 32.0f + zOffset);

                Gl.glTexCoord2f(startU, endV); //0, 1
                Gl.glVertex3f(-width / 32.0f + xOffset, height / 32.0f + yOffset, depth / 32.0f + zOffset);
            }

            Gl.glEnd();

            //back face
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[modelUVs.back.textureIndex]);

            Gl.glBegin(Gl.GL_QUADS);

            startU = modelUVs.back.startU;
            endU = modelUVs.back.endU;

            startV = modelUVs.back.startV;
            endV = modelUVs.back.endV;

            if (modelUVs.back.flipU)
            {
                float saveStartU = startU;
                float saveEndU = endU;

                startU = saveEndU;
                endU = saveStartU;
            }

            if (modelUVs.back.flipV)
            {
                float saveStartV = startV;
                float saveEndV = endV;

                startV = saveEndV;
                endV = saveStartV;
            }

            if (modelUVs.back.rotateRight)
            {
                Gl.glTexCoord2f(1 - startV, endU);
                Gl.glVertex3f(-width / 32.0f + xOffset, -height / 32.0f + yOffset, -depth / 32.0f + zOffset);

                Gl.glTexCoord2f(1 - startV, startU);
                Gl.glVertex3f(width / 32.0f + xOffset, -height / 32.0f + yOffset, -depth / 32.0f + zOffset);

                Gl.glTexCoord2f(1 - endV, startU);
                Gl.glVertex3f(width / 32.0f + xOffset, height / 32.0f + yOffset, -depth / 32.0f + zOffset);

                Gl.glTexCoord2f(1 - endV, endU);
                Gl.glVertex3f(-width / 32.0f + xOffset, height / 32.0f + yOffset, -depth / 32.0f + zOffset);
            }
            else
            {
                /*Gl.glTexCoord2f(endU, startV); //1, 0
                Gl.glVertex3f(-width / 32.0f + xOffset, -height / 32.0f + yOffset, -depth / 32.0f + zOffset);

                Gl.glTexCoord2f(startU, startV); //0, 0
                Gl.glVertex3f(width / 32.0f + xOffset, -height / 32.0f + yOffset, -depth / 32.0f + zOffset);

                Gl.glTexCoord2f(startU, endV); //0, 1
                Gl.glVertex3f(width / 32.0f + xOffset, height / 32.0f + yOffset, -depth / 32.0f + zOffset);

                Gl.glTexCoord2f(endU, endV); //1, 1
                Gl.glVertex3f(-width / 32.0f + xOffset, height / 32.0f + yOffset, -depth / 32.0f + zOffset);*/

                Gl.glTexCoord2f(startU, startV); //0, 0
                Gl.glVertex3f(width / 32.0f + xOffset, -height / 32.0f + yOffset, -depth / 32.0f + zOffset);

                Gl.glTexCoord2f(endU, startV); //1, 0
                Gl.glVertex3f(-width / 32.0f + xOffset, -height / 32.0f + yOffset, -depth / 32.0f + zOffset);

                Gl.glTexCoord2f(endU, endV); //1, 1
                Gl.glVertex3f(-width / 32.0f + xOffset, height / 32.0f + yOffset, -depth / 32.0f + zOffset);

                Gl.glTexCoord2f(startU, endV); //0, 1
                Gl.glVertex3f(width / 32.0f + xOffset, height / 32.0f + yOffset, -depth / 32.0f + zOffset);
            }

            Gl.glEnd();

            //right face
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[modelUVs.right.textureIndex]);

            Gl.glBegin(Gl.GL_QUADS);

            startU = modelUVs.right.startU;
            endU = modelUVs.right.endU;

            startV = modelUVs.right.startV;
            endV = modelUVs.right.endV;

            if (modelUVs.right.flipU)
            {
                float saveStartU = startU;
                float saveEndU = endU;

                startU = saveEndU;
                endU = saveStartU;
            }

            if (modelUVs.right.flipV)
            {
                float saveStartV = startV;
                float saveEndV = endV;

                startV = saveEndV;
                endV = saveStartV;
            }

            if (modelUVs.right.rotateRight)
            {
                Gl.glTexCoord2f(1 - startV, endU); //1, 0
                Gl.glVertex3f(width / 32.0f + xOffset, -height / 32.0f + yOffset, -depth / 32.0f + zOffset);

                Gl.glTexCoord2f(1 - endV, endU); //1, 1
                Gl.glVertex3f(width / 32.0f + xOffset, height / 32.0f + yOffset, -depth / 32.0f + zOffset);

                Gl.glTexCoord2f(1 - endV, startU); //0, 1
                Gl.glVertex3f(width / 32.0f + xOffset, height / 32.0f + yOffset, depth / 32.0f + zOffset);

                Gl.glTexCoord2f(1 - startV, startU); //0, 0
                Gl.glVertex3f(width / 32.0f + xOffset, -height / 32.0f + yOffset, depth / 32.0f + zOffset);
            }
            else
            {
                Gl.glTexCoord2f(endU, startV); //1, 0
                Gl.glVertex3f(width / 32.0f + xOffset, -height / 32.0f + yOffset, -depth / 32.0f + zOffset);

                Gl.glTexCoord2f(endU, endV); //1, 1
                Gl.glVertex3f(width / 32.0f + xOffset, height / 32.0f + yOffset, -depth / 32.0f + zOffset);

                Gl.glTexCoord2f(startU, endV); //0, 1
                Gl.glVertex3f(width / 32.0f + xOffset, height / 32.0f + yOffset, depth / 32.0f + zOffset);

                Gl.glTexCoord2f(startU, startV); //0, 0
                Gl.glVertex3f(width / 32.0f + xOffset, -height / 32.0f + yOffset, depth / 32.0f + zOffset);
            }

            Gl.glEnd();

            //left face
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[modelUVs.left.textureIndex]);

            Gl.glBegin(Gl.GL_QUADS);

            startU = modelUVs.left.startU;
            endU = modelUVs.left.endU;

            startV = modelUVs.left.startV;
            endV = modelUVs.left.endV;

            if (modelUVs.left.flipU)
            {
                float saveStartU = startU;
                float saveEndU = endU;

                startU = saveEndU;
                endU = saveStartU;
            }

            if (modelUVs.left.flipV)
            {
                float saveStartV = startV;
                float saveEndV = endV;

                startV = saveEndV;
                endV = saveStartV;
            }

            if (modelUVs.left.rotateRight)
            {
                Gl.glTexCoord2f(1 - startV, startU); //0, 0
                Gl.glVertex3f(-width / 32.0f + xOffset, -height / 32.0f + yOffset, -depth / 32.0f + zOffset);

                Gl.glTexCoord2f(1 - startV, endU); //1, 0
                Gl.glVertex3f(-width / 32.0f + xOffset, -height / 32.0f + yOffset, depth / 32.0f + zOffset);

                Gl.glTexCoord2f(1 - endV, endU); //1, 1
                Gl.glVertex3f(-width / 32.0f + xOffset, height / 32.0f + yOffset, depth / 32.0f + zOffset);

                Gl.glTexCoord2f(1 - endV, startU); //0, 1
                Gl.glVertex3f(-width / 32.0f + xOffset, height / 32.0f + yOffset, -depth / 32.0f + zOffset);
            }
            else
            {
                Gl.glTexCoord2f(startU, startV); //0, 0
                Gl.glVertex3f(-width / 32.0f + xOffset, -height / 32.0f + yOffset, -depth / 32.0f + zOffset);

                Gl.glTexCoord2f(endU, startV); //1, 0
                Gl.glVertex3f(-width / 32.0f + xOffset, -height / 32.0f + yOffset, depth / 32.0f + zOffset);

                Gl.glTexCoord2f(endU, endV); //1, 1
                Gl.glVertex3f(-width / 32.0f + xOffset, height / 32.0f + yOffset, depth / 32.0f + zOffset);

                Gl.glTexCoord2f(startU, endV); //0, 1
                Gl.glVertex3f(-width / 32.0f + xOffset, height / 32.0f + yOffset, -depth / 32.0f + zOffset);

            }

            Gl.glEnd();

            //top face
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[modelUVs.top.textureIndex]);

            Gl.glBegin(Gl.GL_QUADS);

            startU = modelUVs.top.startU;
            endU = modelUVs.top.endU;

            startV = modelUVs.top.startV;
            endV = modelUVs.top.endV;

            if (modelUVs.top.flipU)
            {
                float saveStartU = startU;
                float saveEndU = endU;

                startU = saveEndU;
                endU = saveStartU;
            }

            if (modelUVs.top.flipV)
            {
                float saveStartV = startV;
                float saveEndV = endV;

                startV = saveEndV;
                endV = saveStartV;
            }

            if (modelUVs.top.rotateRight)
            {
                Gl.glTexCoord2f(1 - endV, startU); //0, 1
                Gl.glVertex3f(-width / 32.0f + xOffset, height / 32.0f + yOffset, -depth / 32.0f + zOffset);

                Gl.glTexCoord2f(1 - startV, startU); //0, 0
                Gl.glVertex3f(-width / 32.0f + xOffset, height / 32.0f + yOffset, depth / 32.0f + zOffset);

                Gl.glTexCoord2f(1 - startV, endU); //1, 0
                Gl.glVertex3f(width / 32.0f + xOffset, height / 32.0f + yOffset, depth / 32.0f + zOffset);

                Gl.glTexCoord2f(1 - endV, endU); //1, 1
                Gl.glVertex3f(width / 32.0f + xOffset, height / 32.0f + yOffset, -depth / 32.0f + zOffset);
            }
            else
            {
                Gl.glTexCoord2f(startU, endV); //0, 1
                Gl.glVertex3f(-width / 32.0f + xOffset, height / 32.0f + yOffset, -depth / 32.0f + zOffset);

                Gl.glTexCoord2f(startU, startV); //0, 0
                Gl.glVertex3f(-width / 32.0f + xOffset, height / 32.0f + yOffset, depth / 32.0f + zOffset);

                Gl.glTexCoord2f(endU, startV); //1, 0
                Gl.glVertex3f(width / 32.0f + xOffset, height / 32.0f + yOffset, depth / 32.0f + zOffset);

                Gl.glTexCoord2f(endU, endV); //1, 1
                Gl.glVertex3f(width / 32.0f + xOffset, height / 32.0f + yOffset, -depth / 32.0f + zOffset);
            }

            Gl.glEnd();

            //bottom face
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[modelUVs.bottom.textureIndex]);

            Gl.glBegin(Gl.GL_QUADS);

            startU = modelUVs.bottom.startU;
            endU = modelUVs.bottom.endU;

            startV = modelUVs.bottom.startV;
            endV = modelUVs.bottom.endV;

            if (modelUVs.bottom.flipU)
            {
                float saveStartU = startU;
                float saveEndU = endU;

                startU = saveEndU;
                endU = saveStartU;
            }

            if (modelUVs.bottom.flipV)
            {
                float saveStartV = startV;
                float saveEndV = endV;

                startV = saveEndV;
                endV = saveStartV;
            }

            if (modelUVs.bottom.rotateRight)
            {
                Gl.glTexCoord2f(1 - endV, endU); //1, 1
                Gl.glVertex3f(-width / 32.0f + xOffset, -height / 32.0f + yOffset, -depth / 32.0f + zOffset);

                Gl.glTexCoord2f(1 - endV, startU); //0, 1
                Gl.glVertex3f(width / 32.0f + xOffset, -height / 32.0f + yOffset, -depth / 32.0f + zOffset);

                Gl.glTexCoord2f(1 - startV, startU); //0, 0
                Gl.glVertex3f(width / 32.0f + xOffset, -height / 32.0f + yOffset, depth / 32.0f + zOffset);

                Gl.glTexCoord2f(1 - startV, endU); //1, 0
                Gl.glVertex3f(-width / 32.0f + xOffset, -height / 32.0f + yOffset, depth / 32.0f + zOffset);
            }
            else
            {
                Gl.glTexCoord2f(endU, endV); //1, 1
                Gl.glVertex3f(-width / 32.0f + xOffset, -height / 32.0f + yOffset, -depth / 32.0f + zOffset);

                Gl.glTexCoord2f(startU, endV); //0, 1
                Gl.glVertex3f(width / 32.0f + xOffset, -height / 32.0f + yOffset, -depth / 32.0f + zOffset);

                Gl.glTexCoord2f(startU, startV); //0, 0
                Gl.glVertex3f(width / 32.0f + xOffset, -height / 32.0f + yOffset, depth / 32.0f + zOffset);

                Gl.glTexCoord2f(endU, startV); //1, 0
                Gl.glVertex3f(-width / 32.0f + xOffset, -height / 32.0f + yOffset, depth / 32.0f + zOffset);
            }

            Gl.glEnd();
        }

        public static void drawModel(float width, float height, float depth,
            float xOffset, float yOffset, float zOffset, UVinfo modelUVs, Cube cube)
        {
            //front face /**///right face
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[modelUVs.right.textureIndex]);

            Gl.glBegin(Gl.GL_QUADS);

            float startU = modelUVs.right.startU;
            float endU = modelUVs.right.endU;

            float startV = modelUVs.right.startV;
            float endV = modelUVs.right.endV;

            if (modelUVs.right.flipU)
            {
                float saveStartU = startU;
                float saveEndU = endU;

                startU = saveEndU;
                endU = saveStartU;
            }

            if (modelUVs.right.flipV)
            {
                float saveStartV = startV;
                float saveEndV = endV;

                startV = saveEndV;
                endV = saveStartV;
            }

            if (cube.right)
            {
                if (modelUVs.front.rotateRight)
                {
                    Gl.glTexCoord2f(1 - startV, startU); //startU, startV
                    Gl.glVertex3f(-width / 32.0f + xOffset, -height / 32.0f + yOffset, depth / 32.0f + zOffset);

                    Gl.glTexCoord2f(1 - startV, endU); //endU, startV
                    Gl.glVertex3f(width / 32.0f + xOffset, -height / 32.0f + yOffset, depth / 32.0f + zOffset);

                    Gl.glTexCoord2f(1 - endV, endU); //endU, endV
                    Gl.glVertex3f(width / 32.0f + xOffset, height / 32.0f + yOffset, depth / 32.0f + zOffset);

                    Gl.glTexCoord2f(1 - endV, startU); //startU, endV
                    Gl.glVertex3f(-width / 32.0f + xOffset, height / 32.0f + yOffset, depth / 32.0f + zOffset);
                }
                else
                {
                    Gl.glTexCoord2f(startU, startV); //0, 0
                    Gl.glVertex3f(-width / 32.0f + xOffset, -height / 32.0f + yOffset, depth / 32.0f + zOffset);

                    Gl.glTexCoord2f(endU, startV); //1, 0
                    Gl.glVertex3f(width / 32.0f + xOffset, -height / 32.0f + yOffset, depth / 32.0f + zOffset);

                    Gl.glTexCoord2f(endU, endV); //1, 1
                    Gl.glVertex3f(width / 32.0f + xOffset, height / 32.0f + yOffset, depth / 32.0f + zOffset);

                    Gl.glTexCoord2f(startU, endV); //0, 1
                    Gl.glVertex3f(-width / 32.0f + xOffset, height / 32.0f + yOffset, depth / 32.0f + zOffset);
                }
            }

            Gl.glEnd();

            //back face /**///left face
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[modelUVs.left.textureIndex]);

            Gl.glBegin(Gl.GL_QUADS);

            startU = modelUVs.left.startU;
            endU = modelUVs.left.endU;

            startV = modelUVs.left.startV;
            endV = modelUVs.left.endV;

            if (modelUVs.left.flipU)
            {
                float saveStartU = startU;
                float saveEndU = endU;

                startU = saveEndU;
                endU = saveStartU;
            }

            if (modelUVs.left.flipV)
            {
                float saveStartV = startV;
                float saveEndV = endV;

                startV = saveEndV;
                endV = saveStartV;
            }

            if (cube.left)
            {
                if (modelUVs.left.rotateRight)
                {
                    Gl.glTexCoord2f(1 - startV, endU);
                    Gl.glVertex3f(-width / 32.0f + xOffset, -height / 32.0f + yOffset, -depth / 32.0f + zOffset);

                    Gl.glTexCoord2f(1 - startV, startU);
                    Gl.glVertex3f(width / 32.0f + xOffset, -height / 32.0f + yOffset, -depth / 32.0f + zOffset);

                    Gl.glTexCoord2f(1 - endV, startU);
                    Gl.glVertex3f(width / 32.0f + xOffset, height / 32.0f + yOffset, -depth / 32.0f + zOffset);

                    Gl.glTexCoord2f(1 - endV, endU);
                    Gl.glVertex3f(-width / 32.0f + xOffset, height / 32.0f + yOffset, -depth / 32.0f + zOffset);
                }
                else
                {
                    Gl.glTexCoord2f(startU, startV); //0, 0
                    Gl.glVertex3f(width / 32.0f + xOffset, -height / 32.0f + yOffset, -depth / 32.0f + zOffset);

                    Gl.glTexCoord2f(endU, startV); //1, 0
                    Gl.glVertex3f(-width / 32.0f + xOffset, -height / 32.0f + yOffset, -depth / 32.0f + zOffset);

                    Gl.glTexCoord2f(endU, endV); //1, 1
                    Gl.glVertex3f(-width / 32.0f + xOffset, height / 32.0f + yOffset, -depth / 32.0f + zOffset);

                    Gl.glTexCoord2f(startU, endV); //0, 1
                    Gl.glVertex3f(width / 32.0f + xOffset, height / 32.0f + yOffset, -depth / 32.0f + zOffset);
                }
            }

            Gl.glEnd();

            //right face /**///back face
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[modelUVs.back.textureIndex]);

            Gl.glBegin(Gl.GL_QUADS);

            startU = modelUVs.back.startU;
            endU = modelUVs.back.endU;

            startV = modelUVs.back.startV;
            endV = modelUVs.back.endV;

            if (modelUVs.back.flipU)
            {
                float saveStartU = startU;
                float saveEndU = endU;

                startU = saveEndU;
                endU = saveStartU;
            }

            if (modelUVs.back.flipV)
            {
                float saveStartV = startV;
                float saveEndV = endV;

                startV = saveEndV;
                endV = saveStartV;
            }

            if (cube.back)
            {
                if (modelUVs.back.rotateRight)
                {
                    Gl.glTexCoord2f(1 - startV, endU); //1, 0
                    Gl.glVertex3f(width / 32.0f + xOffset, -height / 32.0f + yOffset, -depth / 32.0f + zOffset);

                    Gl.glTexCoord2f(1 - endV, endU); //1, 1
                    Gl.glVertex3f(width / 32.0f + xOffset, height / 32.0f + yOffset, -depth / 32.0f + zOffset);

                    Gl.glTexCoord2f(1 - endV, startU); //0, 1
                    Gl.glVertex3f(width / 32.0f + xOffset, height / 32.0f + yOffset, depth / 32.0f + zOffset);

                    Gl.glTexCoord2f(1 - startV, startU); //0, 0
                    Gl.glVertex3f(width / 32.0f + xOffset, -height / 32.0f + yOffset, depth / 32.0f + zOffset);
                }
                else
                {
                    Gl.glTexCoord2f(endU, startV); //1, 0
                    Gl.glVertex3f(width / 32.0f + xOffset, -height / 32.0f + yOffset, -depth / 32.0f + zOffset);

                    Gl.glTexCoord2f(endU, endV); //1, 1
                    Gl.glVertex3f(width / 32.0f + xOffset, height / 32.0f + yOffset, -depth / 32.0f + zOffset);

                    Gl.glTexCoord2f(startU, endV); //0, 1
                    Gl.glVertex3f(width / 32.0f + xOffset, height / 32.0f + yOffset, depth / 32.0f + zOffset);

                    Gl.glTexCoord2f(startU, startV); //0, 0
                    Gl.glVertex3f(width / 32.0f + xOffset, -height / 32.0f + yOffset, depth / 32.0f + zOffset);
                }
            }

            Gl.glEnd();

            //left face/**///front face
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[modelUVs.front.textureIndex]);

            Gl.glBegin(Gl.GL_QUADS);

            startU = modelUVs.front.startU;
            endU = modelUVs.front.endU;

            startV = modelUVs.front.startV;
            endV = modelUVs.front.endV;

            if (modelUVs.front.flipU)
            {
                float saveStartU = startU;
                float saveEndU = endU;

                startU = saveEndU;
                endU = saveStartU;
            }

            if (modelUVs.front.flipV)
            {
                float saveStartV = startV;
                float saveEndV = endV;

                startV = saveEndV;
                endV = saveStartV;
            }

            if (cube.front)
            {
                if (modelUVs.front.rotateRight)
                {
                    Gl.glTexCoord2f(1 - startV, startU); //0, 0
                    Gl.glVertex3f(-width / 32.0f + xOffset, -height / 32.0f + yOffset, -depth / 32.0f + zOffset);

                    Gl.glTexCoord2f(1 - startV, endU); //1, 0
                    Gl.glVertex3f(-width / 32.0f + xOffset, -height / 32.0f + yOffset, depth / 32.0f + zOffset);

                    Gl.glTexCoord2f(1 - endV, endU); //1, 1
                    Gl.glVertex3f(-width / 32.0f + xOffset, height / 32.0f + yOffset, depth / 32.0f + zOffset);

                    Gl.glTexCoord2f(1 - endV, startU); //0, 1
                    Gl.glVertex3f(-width / 32.0f + xOffset, height / 32.0f + yOffset, -depth / 32.0f + zOffset);
                }
                else
                {
                    Gl.glTexCoord2f(startU, startV); //0, 0
                    Gl.glVertex3f(-width / 32.0f + xOffset, -height / 32.0f + yOffset, -depth / 32.0f + zOffset);

                    Gl.glTexCoord2f(endU, startV); //1, 0
                    Gl.glVertex3f(-width / 32.0f + xOffset, -height / 32.0f + yOffset, depth / 32.0f + zOffset);

                    Gl.glTexCoord2f(endU, endV); //1, 1
                    Gl.glVertex3f(-width / 32.0f + xOffset, height / 32.0f + yOffset, depth / 32.0f + zOffset);

                    Gl.glTexCoord2f(startU, endV); //0, 1
                    Gl.glVertex3f(-width / 32.0f + xOffset, height / 32.0f + yOffset, -depth / 32.0f + zOffset);
                }
            }

            Gl.glEnd();

            //top face
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[modelUVs.top.textureIndex]);

            Gl.glBegin(Gl.GL_QUADS);

            startU = modelUVs.top.startU;
            endU = modelUVs.top.endU;

            startV = modelUVs.top.startV;
            endV = modelUVs.top.endV;

            if (modelUVs.top.flipU)
            {
                float saveStartU = startU;
                float saveEndU = endU;

                startU = saveEndU;
                endU = saveStartU;
            }

            if (modelUVs.top.flipV)
            {
                float saveStartV = startV;
                float saveEndV = endV;

                startV = saveEndV;
                endV = saveStartV;
            }

            if (cube.top)
            {
                if (modelUVs.top.rotateRight)
                {
                    Gl.glTexCoord2f(1 - endV, startU); //0, 1
                    Gl.glVertex3f(-width / 32.0f + xOffset, height / 32.0f + yOffset, -depth / 32.0f + zOffset);

                    Gl.glTexCoord2f(1 - startV, startU); //0, 0
                    Gl.glVertex3f(-width / 32.0f + xOffset, height / 32.0f + yOffset, depth / 32.0f + zOffset);

                    Gl.glTexCoord2f(1 - startV, endU); //1, 0
                    Gl.glVertex3f(width / 32.0f + xOffset, height / 32.0f + yOffset, depth / 32.0f + zOffset);

                    Gl.glTexCoord2f(1 - endV, endU); //1, 1
                    Gl.glVertex3f(width / 32.0f + xOffset, height / 32.0f + yOffset, -depth / 32.0f + zOffset);
                }
                else
                {
                    Gl.glTexCoord2f(startU, endV); //0, 1
                    Gl.glVertex3f(-width / 32.0f + xOffset, height / 32.0f + yOffset, -depth / 32.0f + zOffset);

                    Gl.glTexCoord2f(startU, startV); //0, 0
                    Gl.glVertex3f(-width / 32.0f + xOffset, height / 32.0f + yOffset, depth / 32.0f + zOffset);

                    Gl.glTexCoord2f(endU, startV); //1, 0
                    Gl.glVertex3f(width / 32.0f + xOffset, height / 32.0f + yOffset, depth / 32.0f + zOffset);

                    Gl.glTexCoord2f(endU, endV); //1, 1
                    Gl.glVertex3f(width / 32.0f + xOffset, height / 32.0f + yOffset, -depth / 32.0f + zOffset);
                }
            }

            Gl.glEnd();

            //bottom face
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[modelUVs.bottom.textureIndex]);

            Gl.glBegin(Gl.GL_QUADS);

            startU = modelUVs.bottom.startU;
            endU = modelUVs.bottom.endU;

            startV = modelUVs.bottom.startV;
            endV = modelUVs.bottom.endV;

            if (modelUVs.bottom.flipU)
            {
                float saveStartU = startU;
                float saveEndU = endU;

                startU = saveEndU;
                endU = saveStartU;
            }

            if (modelUVs.bottom.flipV)
            {
                float saveStartV = startV;
                float saveEndV = endV;

                startV = saveEndV;
                endV = saveStartV;
            }

            if (cube.bottom)
            {
                if (modelUVs.bottom.rotateRight)
                {
                    Gl.glTexCoord2f(1 - endV, endU); //1, 1
                    Gl.glVertex3f(-width / 32.0f + xOffset, -height / 32.0f + yOffset, -depth / 32.0f + zOffset);

                    Gl.glTexCoord2f(1 - endV, startU); //0, 1
                    Gl.glVertex3f(width / 32.0f + xOffset, -height / 32.0f + yOffset, -depth / 32.0f + zOffset);

                    Gl.glTexCoord2f(1 - startV, startU); //0, 0
                    Gl.glVertex3f(width / 32.0f + xOffset, -height / 32.0f + yOffset, depth / 32.0f + zOffset);

                    Gl.glTexCoord2f(1 - startV, endU); //1, 0
                    Gl.glVertex3f(-width / 32.0f + xOffset, -height / 32.0f + yOffset, depth / 32.0f + zOffset);
                }
                else
                {
                    Gl.glTexCoord2f(endU, endV); //1, 1
                    Gl.glVertex3f(-width / 32.0f + xOffset, -height / 32.0f + yOffset, -depth / 32.0f + zOffset);

                    Gl.glTexCoord2f(startU, endV); //0, 1
                    Gl.glVertex3f(width / 32.0f + xOffset, -height / 32.0f + yOffset, -depth / 32.0f + zOffset);

                    Gl.glTexCoord2f(startU, startV); //0, 0
                    Gl.glVertex3f(width / 32.0f + xOffset, -height / 32.0f + yOffset, depth / 32.0f + zOffset);

                    Gl.glTexCoord2f(endU, startV); //1, 0
                    Gl.glVertex3f(-width / 32.0f + xOffset, -height / 32.0f + yOffset, depth / 32.0f + zOffset);
                }
            }

            Gl.glEnd();
        }

        public static void drawModelNoTop(float width, float height, float depth,
            float xOffset, float yOffset, float zOffset, UVinfo modelUVs)
        {
            //front face
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[modelUVs.front.textureIndex]);

            Gl.glBegin(Gl.GL_QUADS);

            float startU = modelUVs.front.startU;
            float endU = modelUVs.front.endU;

            float startV = modelUVs.front.startV;
            float endV = modelUVs.front.endV;

            if (modelUVs.front.flipU)
            {
                float saveStartU = startU;
                float saveEndU = endU;

                startU = saveEndU;
                endU = saveStartU;
            }

            if (modelUVs.front.flipV)
            {
                float saveStartV = startV;
                float saveEndV = endV;

                startV = saveEndV;
                endV = saveStartV;
            }

            if (modelUVs.front.rotateRight)
            {
                Gl.glTexCoord2f(1 - startV, startU); //startU, startV
                Gl.glVertex3f(-width / 32.0f + xOffset, -height / 32.0f + yOffset, depth / 32.0f + zOffset);

                Gl.glTexCoord2f(1 - startV, endU); //endU, startV
                Gl.glVertex3f(width / 32.0f + xOffset, -height / 32.0f + yOffset, depth / 32.0f + zOffset);

                Gl.glTexCoord2f(1 - endV, endU); //endU, endV
                Gl.glVertex3f(width / 32.0f + xOffset, height / 32.0f + yOffset, depth / 32.0f + zOffset);

                Gl.glTexCoord2f(1 - endV, startU); //startU, endV
                Gl.glVertex3f(-width / 32.0f + xOffset, height / 32.0f + yOffset, depth / 32.0f + zOffset);
            }
            else
            {
                Gl.glTexCoord2f(startU, startV); //0, 0
                Gl.glVertex3f(-width / 32.0f + xOffset, -height / 32.0f + yOffset, depth / 32.0f + zOffset);

                Gl.glTexCoord2f(endU, startV); //1, 0
                Gl.glVertex3f(width / 32.0f + xOffset, -height / 32.0f + yOffset, depth / 32.0f + zOffset);

                Gl.glTexCoord2f(endU, endV); //1, 1
                Gl.glVertex3f(width / 32.0f + xOffset, height / 32.0f + yOffset, depth / 32.0f + zOffset);

                Gl.glTexCoord2f(startU, endV); //0, 1
                Gl.glVertex3f(-width / 32.0f + xOffset, height / 32.0f + yOffset, depth / 32.0f + zOffset);
            }

            Gl.glEnd();

            //back face
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[modelUVs.back.textureIndex]);

            Gl.glBegin(Gl.GL_QUADS);

            startU = modelUVs.back.startU;
            endU = modelUVs.back.endU;

            startV = modelUVs.back.startV;
            endV = modelUVs.back.endV;

            if (modelUVs.back.flipU)
            {
                float saveStartU = startU;
                float saveEndU = endU;

                startU = saveEndU;
                endU = saveStartU;
            }

            if (modelUVs.back.flipV)
            {
                float saveStartV = startV;
                float saveEndV = endV;

                startV = saveEndV;
                endV = saveStartV;
            }

            if (modelUVs.back.rotateRight)
            {
                Gl.glTexCoord2f(1 - startV, endU);
                Gl.glVertex3f(-width / 32.0f + xOffset, -height / 32.0f + yOffset, -depth / 32.0f + zOffset);

                Gl.glTexCoord2f(1 - startV, startU);
                Gl.glVertex3f(width / 32.0f + xOffset, -height / 32.0f + yOffset, -depth / 32.0f + zOffset);

                Gl.glTexCoord2f(1 - endV, startU);
                Gl.glVertex3f(width / 32.0f + xOffset, height / 32.0f + yOffset, -depth / 32.0f + zOffset);

                Gl.glTexCoord2f(1 - endV, endU);
                Gl.glVertex3f(-width / 32.0f + xOffset, height / 32.0f + yOffset, -depth / 32.0f + zOffset);
            }
            else
            {
                Gl.glTexCoord2f(endU, startV); //1, 0
                Gl.glVertex3f(-width / 32.0f + xOffset, -height / 32.0f + yOffset, -depth / 32.0f + zOffset);

                Gl.glTexCoord2f(startU, startV); //0, 0
                Gl.glVertex3f(width / 32.0f + xOffset, -height / 32.0f + yOffset, -depth / 32.0f + zOffset);

                Gl.glTexCoord2f(startU, endV); //0, 1
                Gl.glVertex3f(width / 32.0f + xOffset, height / 32.0f + yOffset, -depth / 32.0f + zOffset);

                Gl.glTexCoord2f(endU, endV); //1, 1
                Gl.glVertex3f(-width / 32.0f + xOffset, height / 32.0f + yOffset, -depth / 32.0f + zOffset);
            }

            Gl.glEnd();

            //right face
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[modelUVs.right.textureIndex]);

            Gl.glBegin(Gl.GL_QUADS);

            startU = modelUVs.right.startU;
            endU = modelUVs.right.endU;

            startV = modelUVs.right.startV;
            endV = modelUVs.right.endV;

            if (modelUVs.right.flipU)
            {
                float saveStartU = startU;
                float saveEndU = endU;

                startU = saveEndU;
                endU = saveStartU;
            }

            if (modelUVs.right.flipV)
            {
                float saveStartV = startV;
                float saveEndV = endV;

                startV = saveEndV;
                endV = saveStartV;
            }

            if (modelUVs.right.rotateRight)
            {
                Gl.glTexCoord2f(1 - startV, endU); //1, 0
                Gl.glVertex3f(width / 32.0f + xOffset, -height / 32.0f + yOffset, -depth / 32.0f + zOffset);

                Gl.glTexCoord2f(1 - endV, endU); //1, 1
                Gl.glVertex3f(width / 32.0f + xOffset, height / 32.0f + yOffset, -depth / 32.0f + zOffset);

                Gl.glTexCoord2f(1 - endV, startU); //0, 1
                Gl.glVertex3f(width / 32.0f + xOffset, height / 32.0f + yOffset, depth / 32.0f + zOffset);

                Gl.glTexCoord2f(1 - startV, startU); //0, 0
                Gl.glVertex3f(width / 32.0f + xOffset, -height / 32.0f + yOffset, depth / 32.0f + zOffset);
            }
            else
            {
                Gl.glTexCoord2f(endU, startV); //1, 0
                Gl.glVertex3f(width / 32.0f + xOffset, -height / 32.0f + yOffset, -depth / 32.0f + zOffset);

                Gl.glTexCoord2f(endU, endV); //1, 1
                Gl.glVertex3f(width / 32.0f + xOffset, height / 32.0f + yOffset, -depth / 32.0f + zOffset);

                Gl.glTexCoord2f(startU, endV); //0, 1
                Gl.glVertex3f(width / 32.0f + xOffset, height / 32.0f + yOffset, depth / 32.0f + zOffset);

                Gl.glTexCoord2f(startU, startV); //0, 0
                Gl.glVertex3f(width / 32.0f + xOffset, -height / 32.0f + yOffset, depth / 32.0f + zOffset);
            }

            Gl.glEnd();

            //left face
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[modelUVs.left.textureIndex]);

            Gl.glBegin(Gl.GL_QUADS);

            startU = modelUVs.left.startU;
            endU = modelUVs.left.endU;

            startV = modelUVs.left.startV;
            endV = modelUVs.left.endV;

            if (modelUVs.left.flipU)
            {
                float saveStartU = startU;
                float saveEndU = endU;

                startU = saveEndU;
                endU = saveStartU;
            }

            if (modelUVs.left.flipV)
            {
                float saveStartV = startV;
                float saveEndV = endV;

                startV = saveEndV;
                endV = saveStartV;
            }

            if (modelUVs.left.rotateRight)
            {
                Gl.glTexCoord2f(1 - startV, startU); //0, 0
                Gl.glVertex3f(-width / 32.0f + xOffset, -height / 32.0f + yOffset, -depth / 32.0f + zOffset);

                Gl.glTexCoord2f(1 - startV, endU); //1, 0
                Gl.glVertex3f(-width / 32.0f + xOffset, -height / 32.0f + yOffset, depth / 32.0f + zOffset);

                Gl.glTexCoord2f(1 - endV, endU); //1, 1
                Gl.glVertex3f(-width / 32.0f + xOffset, height / 32.0f + yOffset, depth / 32.0f + zOffset);

                Gl.glTexCoord2f(1 - endV, startU); //0, 1
                Gl.glVertex3f(-width / 32.0f + xOffset, height / 32.0f + yOffset, -depth / 32.0f + zOffset);
            }
            else
            {
                Gl.glTexCoord2f(startU, startV); //0, 0
                Gl.glVertex3f(-width / 32.0f + xOffset, -height / 32.0f + yOffset, -depth / 32.0f + zOffset);

                Gl.glTexCoord2f(endU, startV); //1, 0
                Gl.glVertex3f(-width / 32.0f + xOffset, -height / 32.0f + yOffset, depth / 32.0f + zOffset);

                Gl.glTexCoord2f(endU, endV); //1, 1
                Gl.glVertex3f(-width / 32.0f + xOffset, height / 32.0f + yOffset, depth / 32.0f + zOffset);

                Gl.glTexCoord2f(startU, endV); //0, 1
                Gl.glVertex3f(-width / 32.0f + xOffset, height / 32.0f + yOffset, -depth / 32.0f + zOffset);
            }

            Gl.glEnd();

            //bottom face
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[modelUVs.bottom.textureIndex]);

            Gl.glBegin(Gl.GL_QUADS);

            startU = modelUVs.bottom.startU;
            endU = modelUVs.bottom.endU;

            startV = modelUVs.bottom.startV;
            endV = modelUVs.bottom.endV;

            if (modelUVs.bottom.flipU)
            {
                float saveStartU = startU;
                float saveEndU = endU;

                startU = saveEndU;
                endU = saveStartU;
            }

            if (modelUVs.bottom.flipV)
            {
                float saveStartV = startV;
                float saveEndV = endV;

                startV = saveEndV;
                endV = saveStartV;
            }

            if (modelUVs.bottom.rotateRight)
            {
                Gl.glTexCoord2f(1 - endV, endU); //1, 1
                Gl.glVertex3f(-width / 32.0f + xOffset, -height / 32.0f + yOffset, -depth / 32.0f + zOffset);

                Gl.glTexCoord2f(1 - endV, startU); //0, 1
                Gl.glVertex3f(width / 32.0f + xOffset, -height / 32.0f + yOffset, -depth / 32.0f + zOffset);

                Gl.glTexCoord2f(1 - startV, startU); //0, 0
                Gl.glVertex3f(width / 32.0f + xOffset, -height / 32.0f + yOffset, depth / 32.0f + zOffset);

                Gl.glTexCoord2f(1 - startV, endU); //1, 0
                Gl.glVertex3f(-width / 32.0f + xOffset, -height / 32.0f + yOffset, depth / 32.0f + zOffset);
            }
            else
            {
                Gl.glTexCoord2f(endU, endV); //1, 1
                Gl.glVertex3f(-width / 32.0f + xOffset, -height / 32.0f + yOffset, -depth / 32.0f + zOffset);

                Gl.glTexCoord2f(startU, endV); //0, 1
                Gl.glVertex3f(width / 32.0f + xOffset, -height / 32.0f + yOffset, -depth / 32.0f + zOffset);

                Gl.glTexCoord2f(startU, startV); //0, 0
                Gl.glVertex3f(width / 32.0f + xOffset, -height / 32.0f + yOffset, depth / 32.0f + zOffset);

                Gl.glTexCoord2f(endU, startV); //1, 0
                Gl.glVertex3f(-width / 32.0f + xOffset, -height / 32.0f + yOffset, depth / 32.0f + zOffset);
            }

            Gl.glEnd();
        }

        public static void drawModelDoor(float width, float height, float depth,
            float xOffset, float yOffset, float zOffset, UVinfo modelUVs, bool drawTop, bool drawBottom)
        {
            //front face
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[modelUVs.front.textureIndex]);

            Gl.glBegin(Gl.GL_QUADS);

            float startU = modelUVs.front.startU;
            float endU = modelUVs.front.endU;

            float startV = modelUVs.front.startV;
            float endV = modelUVs.front.endV;

            if (modelUVs.front.flipU)
            {
                float saveStartU = startU;
                float saveEndU = endU;

                startU = saveEndU;
                endU = saveStartU;
            }

            if (modelUVs.front.flipV)
            {
                float saveStartV = startV;
                float saveEndV = endV;

                startV = saveEndV;
                endV = saveStartV;
            }

            if (modelUVs.front.rotateRight)
            {
                Gl.glTexCoord2f(1 - startV, startU); //startU, startV
                Gl.glVertex3f(-width / 32.0f + xOffset, -height / 32.0f + yOffset, depth / 32.0f + zOffset);

                Gl.glTexCoord2f(1 - startV, endU); //endU, startV
                Gl.glVertex3f(width / 32.0f + xOffset, -height / 32.0f + yOffset, depth / 32.0f + zOffset);

                Gl.glTexCoord2f(1 - endV, endU); //endU, endV
                Gl.glVertex3f(width / 32.0f + xOffset, height / 32.0f + yOffset, depth / 32.0f + zOffset);

                Gl.glTexCoord2f(1 - endV, startU); //startU, endV
                Gl.glVertex3f(-width / 32.0f + xOffset, height / 32.0f + yOffset, depth / 32.0f + zOffset);
            }
            else
            {
                Gl.glTexCoord2f(startU, startV); //0, 0
                Gl.glVertex3f(-width / 32.0f + xOffset, -height / 32.0f + yOffset, depth / 32.0f + zOffset);

                Gl.glTexCoord2f(endU, startV); //1, 0
                Gl.glVertex3f(width / 32.0f + xOffset, -height / 32.0f + yOffset, depth / 32.0f + zOffset);

                Gl.glTexCoord2f(endU, endV); //1, 1
                Gl.glVertex3f(width / 32.0f + xOffset, height / 32.0f + yOffset, depth / 32.0f + zOffset);

                Gl.glTexCoord2f(startU, endV); //0, 1
                Gl.glVertex3f(-width / 32.0f + xOffset, height / 32.0f + yOffset, depth / 32.0f + zOffset);
            }

            Gl.glEnd();

            //back face
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[modelUVs.back.textureIndex]);

            Gl.glBegin(Gl.GL_QUADS);

            startU = modelUVs.back.startU;
            endU = modelUVs.back.endU;

            startV = modelUVs.back.startV;
            endV = modelUVs.back.endV;

            if (modelUVs.back.flipU)
            {
                float saveStartU = startU;
                float saveEndU = endU;

                startU = saveEndU;
                endU = saveStartU;
            }

            if (modelUVs.back.flipV)
            {
                float saveStartV = startV;
                float saveEndV = endV;

                startV = saveEndV;
                endV = saveStartV;
            }

            /*if (modelUVs.back.rotateRight)
            {
                Gl.glTexCoord2f(1 - startV, endU);
                Gl.glVertex3f(-width / 32.0f, -height / 32.0f, -depth / 32.0f);

                Gl.glTexCoord2f(1 - startV, startU);
                Gl.glVertex3f(width / 32.0f, -height / 32.0f, -depth / 32.0f);

                Gl.glTexCoord2f(1 - endV, startU);
                Gl.glVertex3f(width / 32.0f, height / 32.0f, -depth / 32.0f);

                Gl.glTexCoord2f(1 - endV, endU);
                Gl.glVertex3f(-width / 32.0f, height / 32.0f, -depth / 32.0f);
            }
            else
            {*/
            Gl.glTexCoord2f(startU, startV); //0, 0
            Gl.glVertex3f(width / 32.0f + xOffset, -height / 32.0f + yOffset, -depth / 32.0f + zOffset); // 1 -1 -1

            Gl.glTexCoord2f(endU, startV); //1, 0
            Gl.glVertex3f(-width / 32.0f + xOffset, -height / 32.0f + yOffset, -depth / 32.0f + zOffset); //-1 -1 -1

            Gl.glTexCoord2f(endU, endV); //1, 1
            Gl.glVertex3f(-width / 32.0f + xOffset, height / 32.0f + yOffset, -depth / 32.0f + zOffset);//-1  1 -1

            Gl.glTexCoord2f(startU, endV); //0, 1
            Gl.glVertex3f(width / 32.0f + xOffset, height / 32.0f + yOffset, -depth / 32.0f + zOffset); // 1  1 -1
            //}

            Gl.glEnd();

            //right face
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[modelUVs.right.textureIndex]);

            Gl.glBegin(Gl.GL_QUADS);

            startU = modelUVs.right.startU;
            endU = modelUVs.right.endU;

            startV = modelUVs.right.startV;
            endV = modelUVs.right.endV;

            if (modelUVs.right.flipU)
            {
                float saveStartU = startU;
                float saveEndU = endU;

                startU = saveEndU;
                endU = saveStartU;
            }

            if (modelUVs.right.flipV)
            {
                float saveStartV = startV;
                float saveEndV = endV;

                startV = saveEndV;
                endV = saveStartV;
            }

            if (modelUVs.right.rotateRight)
            {
                Gl.glTexCoord2f(1 - startV, endU); //1, 0
                Gl.glVertex3f(width / 32.0f + xOffset, -height / 32.0f + yOffset, -depth / 32.0f + zOffset);

                Gl.glTexCoord2f(1 - endV, endU); //1, 1
                Gl.glVertex3f(width / 32.0f + xOffset, height / 32.0f + yOffset, -depth / 32.0f + zOffset);

                Gl.glTexCoord2f(1 - endV, startU); //0, 1
                Gl.glVertex3f(width / 32.0f + xOffset, height / 32.0f + yOffset, depth / 32.0f + zOffset);

                Gl.glTexCoord2f(1 - startV, startU); //0, 0
                Gl.glVertex3f(width / 32.0f + xOffset, -height / 32.0f + yOffset, depth / 32.0f + zOffset);
            }
            else
            {
                Gl.glTexCoord2f(endU, startV); //1, 0
                Gl.glVertex3f(width / 32.0f + xOffset, -height / 32.0f + yOffset, -depth / 32.0f + zOffset);

                Gl.glTexCoord2f(endU, endV); //1, 1
                Gl.glVertex3f(width / 32.0f + xOffset, height / 32.0f + yOffset, -depth / 32.0f + zOffset);

                Gl.glTexCoord2f(startU, endV); //0, 1
                Gl.glVertex3f(width / 32.0f + xOffset, height / 32.0f + yOffset, depth / 32.0f + zOffset);

                Gl.glTexCoord2f(startU, startV); //0, 0
                Gl.glVertex3f(width / 32.0f + xOffset, -height / 32.0f + yOffset, depth / 32.0f + zOffset);
            }

            Gl.glEnd();

            //left face
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[modelUVs.left.textureIndex]);

            Gl.glBegin(Gl.GL_QUADS);

            startU = modelUVs.left.startU;
            endU = modelUVs.left.endU;

            startV = modelUVs.left.startV;
            endV = modelUVs.left.endV;

            if (modelUVs.left.flipU)
            {
                float saveStartU = startU;
                float saveEndU = endU;

                startU = saveEndU;
                endU = saveStartU;
            }

            if (modelUVs.left.flipV)
            {
                float saveStartV = startV;
                float saveEndV = endV;

                startV = saveEndV;
                endV = saveStartV;
            }

            if (modelUVs.left.rotateRight)
            {
                Gl.glTexCoord2f(1 - startV, startU); //0, 0
                Gl.glVertex3f(-width / 32.0f + xOffset, -height / 32.0f + yOffset, -depth / 32.0f + zOffset);

                Gl.glTexCoord2f(1 - startV, endU); //1, 0
                Gl.glVertex3f(-width / 32.0f + xOffset, -height / 32.0f + yOffset, depth / 32.0f + zOffset);

                Gl.glTexCoord2f(1 - endV, endU); //1, 1
                Gl.glVertex3f(-width / 32.0f + xOffset, height / 32.0f + yOffset, depth / 32.0f + zOffset);

                Gl.glTexCoord2f(1 - endV, startU); //0, 1
                Gl.glVertex3f(-width / 32.0f + xOffset, height / 32.0f + yOffset, -depth / 32.0f + zOffset);
            }
            else
            {
                Gl.glTexCoord2f(startU, startV); //0, 0
                Gl.glVertex3f(-width / 32.0f + xOffset, -height / 32.0f + yOffset, -depth / 32.0f + zOffset);

                Gl.glTexCoord2f(endU, startV); //1, 0
                Gl.glVertex3f(-width / 32.0f + xOffset, -height / 32.0f + yOffset, depth / 32.0f + zOffset);

                Gl.glTexCoord2f(endU, endV); //1, 1
                Gl.glVertex3f(-width / 32.0f + xOffset, height / 32.0f + yOffset, depth / 32.0f + zOffset);

                Gl.glTexCoord2f(startU, endV); //0, 1
                Gl.glVertex3f(-width / 32.0f + xOffset, height / 32.0f + yOffset, -depth / 32.0f + zOffset);
            }

            Gl.glEnd();

            //top face
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[modelUVs.top.textureIndex]);

            Gl.glBegin(Gl.GL_QUADS);

            startU = modelUVs.top.startU;
            endU = modelUVs.top.endU;

            startV = modelUVs.top.startV;
            endV = modelUVs.top.endV;

            if (modelUVs.top.flipU)
            {
                float saveStartU = startU;
                float saveEndU = endU;

                startU = saveEndU;
                endU = saveStartU;
            }

            if (modelUVs.top.flipV)
            {
                float saveStartV = startV;
                float saveEndV = endV;

                startV = saveEndV;
                endV = saveStartV;
            }

            if (drawTop)
            {
                if (modelUVs.top.rotateRight)
                {
                    Gl.glTexCoord2f(1 - endV, startU); //0, 1
                    Gl.glVertex3f(-width / 32.0f + xOffset, height / 32.0f + yOffset, -depth / 32.0f + zOffset);

                    Gl.glTexCoord2f(1 - startV, startU); //0, 0
                    Gl.glVertex3f(-width / 32.0f + xOffset, height / 32.0f + yOffset, depth / 32.0f + zOffset);

                    Gl.glTexCoord2f(1 - startV, endU); //1, 0
                    Gl.glVertex3f(width / 32.0f + xOffset, height / 32.0f + yOffset, depth / 32.0f + zOffset);

                    Gl.glTexCoord2f(1 - endV, endU); //1, 1
                    Gl.glVertex3f(width / 32.0f + xOffset, height / 32.0f + yOffset, -depth / 32.0f + zOffset);
                }
                else
                {
                    Gl.glTexCoord2f(startU, endV); //0, 1
                    Gl.glVertex3f(-width / 32.0f + xOffset, height / 32.0f + yOffset, -depth / 32.0f + zOffset);

                    Gl.glTexCoord2f(startU, startV); //0, 0
                    Gl.glVertex3f(-width / 32.0f + xOffset, height / 32.0f + yOffset, depth / 32.0f + zOffset);

                    Gl.glTexCoord2f(endU, startV); //1, 0
                    Gl.glVertex3f(width / 32.0f + xOffset, height / 32.0f + yOffset, depth / 32.0f + zOffset);

                    Gl.glTexCoord2f(endU, endV); //1, 1
                    Gl.glVertex3f(width / 32.0f + xOffset, height / 32.0f + yOffset, -depth / 32.0f + zOffset);
                }
            }

            Gl.glEnd();

            //bottom face
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[modelUVs.bottom.textureIndex]);

            Gl.glBegin(Gl.GL_QUADS);

            startU = modelUVs.bottom.startU;
            endU = modelUVs.bottom.endU;

            startV = modelUVs.bottom.startV;
            endV = modelUVs.bottom.endV;

            if (modelUVs.bottom.flipU)
            {
                float saveStartU = startU;
                float saveEndU = endU;

                startU = saveEndU;
                endU = saveStartU;
            }

            if (modelUVs.bottom.flipV)
            {
                float saveStartV = startV;
                float saveEndV = endV;

                startV = saveEndV;
                endV = saveStartV;
            }

            if (drawBottom)
            {
                if (modelUVs.bottom.rotateRight)
                {
                    Gl.glTexCoord2f(1 - endV, endU); //1, 1
                    Gl.glVertex3f(-width / 32.0f + xOffset, -height / 32.0f + yOffset, -depth / 32.0f + zOffset);

                    Gl.glTexCoord2f(1 - endV, startU); //0, 1
                    Gl.glVertex3f(width / 32.0f + xOffset, -height / 32.0f + yOffset, -depth / 32.0f + zOffset);

                    Gl.glTexCoord2f(1 - startV, startU); //0, 0
                    Gl.glVertex3f(width / 32.0f + xOffset, -height / 32.0f + yOffset, depth / 32.0f + zOffset);

                    Gl.glTexCoord2f(1 - startV, endU); //1, 0
                    Gl.glVertex3f(-width / 32.0f + xOffset, -height / 32.0f + yOffset, depth / 32.0f + zOffset);
                }
                else
                {
                    Gl.glTexCoord2f(endU, endV); //1, 1
                    Gl.glVertex3f(-width / 32.0f + xOffset, -height / 32.0f + yOffset, -depth / 32.0f + zOffset);

                    Gl.glTexCoord2f(startU, endV); //0, 1
                    Gl.glVertex3f(width / 32.0f + xOffset, -height / 32.0f + yOffset, -depth / 32.0f + zOffset);

                    Gl.glTexCoord2f(startU, startV); //0, 0
                    Gl.glVertex3f(width / 32.0f + xOffset, -height / 32.0f + yOffset, depth / 32.0f + zOffset);

                    Gl.glTexCoord2f(endU, startV); //1, 0
                    Gl.glVertex3f(-width / 32.0f + xOffset, -height / 32.0f + yOffset, depth / 32.0f + zOffset);
                }
            }

            Gl.glEnd();
        }

        public static void drawModelTextureMapped(float x, float y, float z, float width, float height, float depth)
        {
            drawModelTextureMapped(x, y, z, width, height, depth, 0.0f, 0.0f, 0.0f, false);
        }

        public static void drawModelTextureMapped(float x, float y, float z, float width, float height, float depth, 
            float xOffset, float yOffset, float zOffset, bool centred)
        {
            if (centred)
            {
                xOffset -= (x + width / 2) / 16.0f;
                yOffset -= (y + height / 2) / 16.0f;
                zOffset -= (z + depth / 2) / 16.0f;
            }

            //front face
            Gl.glBegin(Gl.GL_QUADS);

            Gl.glTexCoord2f(x / 16.0f, y / 16.0f); //0, 0
            Gl.glVertex3f(x / 16.0f + xOffset, y / 16.0f + yOffset, (z + depth) / 16.0f + zOffset); //-1 -1 1

            Gl.glTexCoord2f((x + width) / 16.0f, y / 16.0f); //1, 0
            Gl.glVertex3f((x + width) / 16.0f + xOffset, y / 16.0f + yOffset, (z + depth) / 16.0f + zOffset); //1 -1 1

            Gl.glTexCoord2f((x + width) / 16.0f, (y + height) / 16.0f); //1, 1
            Gl.glVertex3f((x + width) / 16.0f + xOffset, (y + height) / 16.0f + yOffset, (z + depth) / 16.0f + zOffset); //1 1 1

            Gl.glTexCoord2f(x / 16.0f, (y + height) / 16.0f); //0, 1
            Gl.glVertex3f(x / 16.0f + xOffset, (y + height) / 16.0f + yOffset, (z + depth) / 16.0f + zOffset); //-1 1 1

            Gl.glEnd();

            //back face
            Gl.glBegin(Gl.GL_QUADS);

            Gl.glTexCoord2f((x + width) / 16.0f, y / 16.0f); //0, 0
            Gl.glVertex3f((x + width) / 16.0f + xOffset, y / 16.0f + yOffset, z / 16.0f + zOffset); // 1 -1 -1

            Gl.glTexCoord2f(x / 16.0f, y / 16.0f); //1, 0
            Gl.glVertex3f(x / 16.0f + xOffset, y / 16.0f + yOffset, z / 16.0f + zOffset); //-1 -1 -1

            Gl.glTexCoord2f(x / 16.0f, (y + height) / 16.0f); //1, 1
            Gl.glVertex3f(x / 16.0f + xOffset, (y + height) / 16.0f + yOffset, z / 16.0f + zOffset);//-1  1 -1

            Gl.glTexCoord2f((x + width) / 16.0f, (y + height) / 16.0f); //0, 1
            Gl.glVertex3f((x + width) / 16.0f + xOffset, (y + height) / 16.0f + yOffset, z / 16.0f + zOffset); // 1  1 -1

            Gl.glEnd();

            //right face
            Gl.glBegin(Gl.GL_QUADS);

            Gl.glTexCoord2f((z + depth) / 16.0f, y / 16.0f); //1, 0
            Gl.glVertex3f((x + width) / 16.0f + xOffset, y / 16.0f + yOffset, z / 16.0f + zOffset); //1 -1 -1

            Gl.glTexCoord2f((z + depth) / 16.0f, (y + height) / 16.0f); //1, 1
            Gl.glVertex3f((x + width) / 16.0f + xOffset, (y + height) / 16.0f + yOffset, z / 16.0f + zOffset); //1 1 -1

            Gl.glTexCoord2f(z / 16.0f, (y + height) / 16.0f); //0, 1
            Gl.glVertex3f((x + width) / 16.0f + xOffset, (y + height) / 16.0f + yOffset, (z + depth) / 16.0f + zOffset); //1 1 1

            Gl.glTexCoord2f(z / 16.0f, y / 16.0f); //0, 0
            Gl.glVertex3f((x + width) / 16.0f + xOffset, y / 16.0f + yOffset, (z + depth) / 16.0f + zOffset); //1 -1 1
            Gl.glEnd();

            //left face
            Gl.glBegin(Gl.GL_QUADS);

            Gl.glTexCoord2f(z / 16.0f, y / 16.0f); //0, 0
            Gl.glVertex3f(x / 16.0f + xOffset, y / 16.0f + yOffset, z / 16.0f + zOffset); //-1 -1 -1

            Gl.glTexCoord2f((z + depth) / 16.0f, y / 16.0f); //1, 0
            Gl.glVertex3f(x / 16.0f + xOffset, y / 16.0f + yOffset, (z + depth) / 16.0f + zOffset); //-1 -1 1

            Gl.glTexCoord2f((z + depth) / 16.0f, (y + height) / 16.0f); //1, 1
            Gl.glVertex3f(x / 16.0f + xOffset, (y + height) / 16.0f + yOffset, (z + depth) / 16.0f + zOffset); //-1 1 1

            Gl.glTexCoord2f(z / 16.0f, (y + height) / 16.0f); //0, 1
            Gl.glVertex3f(x / 16.0f + xOffset, (y + height) / 16.0f + yOffset, z / 16.0f + zOffset); //-1 1 -1

            Gl.glEnd();

            //top face
            Gl.glBegin(Gl.GL_QUADS);

            Gl.glTexCoord2f(x / 16.0f, (16 - z) / 16.0f); //0, 1
            Gl.glVertex3f(x / 16.0f + xOffset, (y + height) / 16.0f + yOffset, z / 16.0f + zOffset); //-1 1 -1

            Gl.glTexCoord2f(x / 16.0f, (16 - (z + depth)) / 16.0f); //0, 0
            Gl.glVertex3f(x / 16.0f + xOffset, (y + height) / 16.0f + yOffset, (z + depth) / 16.0f + zOffset); //-1 1 1

            Gl.glTexCoord2f((x + width) / 16.0f, (16 - (z + depth)) / 16.0f); //1, 0
            Gl.glVertex3f((x + width) / 16.0f + xOffset, (y + height) / 16.0f + yOffset, (z + depth) / 16.0f + zOffset); //1 1 1

            Gl.glTexCoord2f((x + width) / 16.0f, (16 - z) / 16.0f); //1, 1
            Gl.glVertex3f((x + width) / 16.0f + xOffset, (y + height) / 16.0f + yOffset, z / 16.0f + zOffset); //1 1 -1

            Gl.glEnd();

            //bottom face
            Gl.glBegin(Gl.GL_QUADS);

            Gl.glTexCoord2f(x / 16.0f, (16 - z) / 16.0f); //1, 1
            Gl.glVertex3f(x / 16.0f + xOffset, y / 16.0f + yOffset, z / 16.0f + zOffset); //-1 -1 -1

            Gl.glTexCoord2f((x + width) / 16.0f, (16 - z) / 16.0f); //0, 1
            Gl.glVertex3f((x + width) / 16.0f + xOffset, y / 16.0f + yOffset, z / 16.0f + zOffset); //1 -1 -1

            Gl.glTexCoord2f((x + width) / 16.0f, (16 - (z + depth)) / 16.0f); //0, 0
            Gl.glVertex3f((x + width) / 16.0f + xOffset, y / 16.0f + yOffset, (z + depth) / 16.0f + zOffset); //1 -1 1

            Gl.glTexCoord2f(x / 16.0f, (16 - (z + depth)) / 16.0f); //1, 0
            Gl.glVertex3f(x / 16.0f + xOffset, y / 16.0f + yOffset, (z + depth) / 16.0f + zOffset); //-1 -1 1

            Gl.glEnd();
        }

        public static void drawModelTextureMappedNoTop(float x, float y, float z, float width, float height, float depth, 
            float xOffset, float yOffset, float zOffset, bool centred)
        {
            if (centred)
            {
                xOffset -= (x + width / 2) / 16.0f;
                yOffset -= (y + height / 2) / 16.0f;
                zOffset -= (z + depth / 2) / 16.0f;
            }

            //front face
            Gl.glBegin(Gl.GL_QUADS);

            Gl.glTexCoord2f(x / 16.0f, y / 16.0f); //0, 0
            Gl.glVertex3f(x / 16.0f + xOffset, y / 16.0f + yOffset, (z + depth) / 16.0f + zOffset); //-1 -1 1

            Gl.glTexCoord2f((x + width) / 16.0f, y / 16.0f); //1, 0
            Gl.glVertex3f((x + width) / 16.0f + xOffset, y / 16.0f + yOffset, (z + depth) / 16.0f + zOffset); //1 -1 1

            Gl.glTexCoord2f((x + width) / 16.0f, (y + height) / 16.0f); //1, 1
            Gl.glVertex3f((x + width) / 16.0f + xOffset, (y + height) / 16.0f + yOffset, (z + depth) / 16.0f + zOffset); //1 1 1

            Gl.glTexCoord2f(x / 16.0f, (y + height) / 16.0f); //0, 1
            Gl.glVertex3f(x / 16.0f + xOffset, (y + height) / 16.0f + yOffset, (z + depth) / 16.0f + zOffset); //-1 1 1

            Gl.glEnd();

            //back face
            Gl.glBegin(Gl.GL_QUADS);

            Gl.glTexCoord2f((x + width) / 16.0f, y / 16.0f); //0, 0
            Gl.glVertex3f((x + width) / 16.0f + xOffset, y / 16.0f + yOffset, z / 16.0f + zOffset); // 1 -1 -1

            Gl.glTexCoord2f(x / 16.0f, y / 16.0f); //1, 0
            Gl.glVertex3f(x / 16.0f + xOffset, y / 16.0f + yOffset, z / 16.0f + zOffset); //-1 -1 -1

            Gl.glTexCoord2f(x / 16.0f, (y + height) / 16.0f); //1, 1
            Gl.glVertex3f(x / 16.0f + xOffset, (y + height) / 16.0f + yOffset, z / 16.0f + zOffset);//-1  1 -1

            Gl.glTexCoord2f((x + width) / 16.0f, (y + height) / 16.0f); //0, 1
            Gl.glVertex3f((x + width) / 16.0f + xOffset, (y + height) / 16.0f + yOffset, z / 16.0f + zOffset); // 1  1 -1

            Gl.glEnd();

            //right face
            Gl.glBegin(Gl.GL_QUADS);

            Gl.glTexCoord2f((z + depth) / 16.0f, y / 16.0f); //1, 0
            Gl.glVertex3f((x + width) / 16.0f + xOffset, y / 16.0f + yOffset, z / 16.0f + zOffset); //1 -1 -1

            Gl.glTexCoord2f((z + depth) / 16.0f, (y + height) / 16.0f); //1, 1
            Gl.glVertex3f((x + width) / 16.0f + xOffset, (y + height) / 16.0f + yOffset, z / 16.0f + zOffset); //1 1 -1

            Gl.glTexCoord2f(z / 16.0f, (y + height) / 16.0f); //0, 1
            Gl.glVertex3f((x + width) / 16.0f + xOffset, (y + height) / 16.0f + yOffset, (z + depth) / 16.0f + zOffset); //1 1 1

            Gl.glTexCoord2f(z / 16.0f, y / 16.0f); //0, 0
            Gl.glVertex3f((x + width) / 16.0f + xOffset, y / 16.0f + yOffset, (z + depth) / 16.0f + zOffset); //1 -1 1
            Gl.glEnd();

            //left face
            Gl.glBegin(Gl.GL_QUADS);

            Gl.glTexCoord2f(z / 16.0f, y / 16.0f); //0, 0
            Gl.glVertex3f(x / 16.0f + xOffset, y / 16.0f + yOffset, z / 16.0f + zOffset); //-1 -1 -1

            Gl.glTexCoord2f((z + depth) / 16.0f, y / 16.0f); //1, 0
            Gl.glVertex3f(x / 16.0f + xOffset, y / 16.0f + yOffset, (z + depth) / 16.0f + zOffset); //-1 -1 1

            Gl.glTexCoord2f((z + depth) / 16.0f, (y + height) / 16.0f); //1, 1
            Gl.glVertex3f(x / 16.0f + xOffset, (y + height) / 16.0f + yOffset, (z + depth) / 16.0f + zOffset); //-1 1 1

            Gl.glTexCoord2f(z / 16.0f, (y + height) / 16.0f); //0, 1
            Gl.glVertex3f(x / 16.0f + xOffset, (y + height) / 16.0f + yOffset, z / 16.0f + zOffset); //-1 1 -1

            Gl.glEnd();

            //bottom face
            Gl.glBegin(Gl.GL_QUADS);

            Gl.glTexCoord2f(x / 16.0f, (16 - z) / 16.0f); //1, 1
            Gl.glVertex3f(x / 16.0f + xOffset, y / 16.0f + yOffset, z / 16.0f + zOffset); //-1 -1 -1

            Gl.glTexCoord2f((x + width) / 16.0f, (16 - z) / 16.0f); //0, 1
            Gl.glVertex3f((x + width) / 16.0f + xOffset, y / 16.0f + yOffset, z / 16.0f + zOffset); //1 -1 -1

            Gl.glTexCoord2f((x + width) / 16.0f, (16 - (z + depth)) / 16.0f); //0, 0
            Gl.glVertex3f((x + width) / 16.0f + xOffset, y / 16.0f + yOffset, (z + depth) / 16.0f + zOffset); //1 -1 1

            Gl.glTexCoord2f(x / 16.0f, (16 - (z + depth)) / 16.0f); //1, 0
            Gl.glVertex3f(x / 16.0f + xOffset, y / 16.0f + yOffset, (z + depth) / 16.0f + zOffset); //-1 -1 1

            Gl.glEnd();
        }

        public static void drawModelTextureMappedDragonEgg(float x, float y, float z, float width, float height, float depth, 
            float xOffset, float yOffset, float zOffset, bool centred)
        {
            if (centred)
            {
                xOffset -= (x + width / 2) / 16.0f;
                yOffset -= (y + height / 2) / 16.0f;
                zOffset -= (z + depth / 2) / 16.0f;
            }

            //front face
            Gl.glBegin(Gl.GL_QUADS);

            Gl.glTexCoord2f(x / 16.0f, y / 16.0f); //0, 0
            Gl.glVertex3f(x / 16.0f + xOffset, y / 16.0f + yOffset, (z + depth) / 16.0f + zOffset); //-1 -1 1

            Gl.glTexCoord2f((x + width) / 16.0f, y / 16.0f); //1, 0
            Gl.glVertex3f((x + width) / 16.0f + xOffset, y / 16.0f + yOffset, (z + depth) / 16.0f + zOffset); //1 -1 1

            Gl.glTexCoord2f((x + width) / 16.0f, (y + height) / 16.0f); //1, 1
            Gl.glVertex3f((x + width) / 16.0f + xOffset, (y + height) / 16.0f + yOffset, (z + depth) / 16.0f + zOffset); //1 1 1

            Gl.glTexCoord2f(x / 16.0f, (y + height) / 16.0f); //0, 1
            Gl.glVertex3f(x / 16.0f + xOffset, (y + height) / 16.0f + yOffset, (z + depth) / 16.0f + zOffset); //-1 1 1

            Gl.glEnd();

            //back face
            Gl.glBegin(Gl.GL_QUADS);

            Gl.glTexCoord2f((16 - (x + width)) / 16.0f, y / 16.0f); //0, 0
            Gl.glVertex3f((x + width) / 16.0f + xOffset, y / 16.0f + yOffset, z / 16.0f + zOffset); // 1 -1 -1

            Gl.glTexCoord2f((16 - x) / 16.0f, y / 16.0f); //1, 0
            Gl.glVertex3f(x / 16.0f + xOffset, y / 16.0f + yOffset, z / 16.0f + zOffset); //-1 -1 -1

            Gl.glTexCoord2f((16 - x) / 16.0f, (y + height) / 16.0f); //1, 1
            Gl.glVertex3f(x / 16.0f + xOffset, (y + height) / 16.0f + yOffset, z / 16.0f + zOffset);//-1  1 -1

            Gl.glTexCoord2f((16 - (x + width)) / 16.0f, (y + height) / 16.0f); //0, 1
            Gl.glVertex3f((x + width) / 16.0f + xOffset, (y + height) / 16.0f + yOffset, z / 16.0f + zOffset); // 1  1 -1

            Gl.glEnd();

            //right face
            Gl.glBegin(Gl.GL_QUADS);

            Gl.glTexCoord2f((z + depth) / 16.0f, y / 16.0f); //1, 0
            Gl.glVertex3f((x + width) / 16.0f + xOffset, y / 16.0f + yOffset, z / 16.0f + zOffset); //1 -1 -1

            Gl.glTexCoord2f((z + depth) / 16.0f, (y + height) / 16.0f); //1, 1
            Gl.glVertex3f((x + width) / 16.0f + xOffset, (y + height) / 16.0f + yOffset, z / 16.0f + zOffset); //1 1 -1

            Gl.glTexCoord2f(z / 16.0f, (y + height) / 16.0f); //0, 1
            Gl.glVertex3f((x + width) / 16.0f + xOffset, (y + height) / 16.0f + yOffset, (z + depth) / 16.0f + zOffset); //1 1 1

            Gl.glTexCoord2f(z / 16.0f, y / 16.0f); //0, 0
            Gl.glVertex3f((x + width) / 16.0f + xOffset, y / 16.0f + yOffset, (z + depth) / 16.0f + zOffset); //1 -1 1
            Gl.glEnd();

            //left face
            Gl.glBegin(Gl.GL_QUADS);

            Gl.glTexCoord2f(z / 16.0f, y / 16.0f); //0, 0
            Gl.glVertex3f(x / 16.0f + xOffset, y / 16.0f + yOffset, z / 16.0f + zOffset); //-1 -1 -1

            Gl.glTexCoord2f((z + depth) / 16.0f, y / 16.0f); //1, 0
            Gl.glVertex3f(x / 16.0f + xOffset, y / 16.0f + yOffset, (z + depth) / 16.0f + zOffset); //-1 -1 1

            Gl.glTexCoord2f((z + depth) / 16.0f, (y + height) / 16.0f); //1, 1
            Gl.glVertex3f(x / 16.0f + xOffset, (y + height) / 16.0f + yOffset, (z + depth) / 16.0f + zOffset); //-1 1 1

            Gl.glTexCoord2f(z / 16.0f, (y + height) / 16.0f); //0, 1
            Gl.glVertex3f(x / 16.0f + xOffset, (y + height) / 16.0f + yOffset, z / 16.0f + zOffset); //-1 1 -1

            Gl.glEnd();

            //top face
            Gl.glBegin(Gl.GL_QUADS);

            Gl.glTexCoord2f(x / 16.0f, (16 - z) / 16.0f); //0, 1
            Gl.glVertex3f(x / 16.0f + xOffset, (y + height) / 16.0f + yOffset, z / 16.0f + zOffset); //-1 1 -1

            Gl.glTexCoord2f(x / 16.0f, (16 - (z + depth)) / 16.0f); //0, 0
            Gl.glVertex3f(x / 16.0f + xOffset, (y + height) / 16.0f + yOffset, (z + depth) / 16.0f + zOffset); //-1 1 1

            Gl.glTexCoord2f((x + width) / 16.0f, (16 - (z + depth)) / 16.0f); //1, 0
            Gl.glVertex3f((x + width) / 16.0f + xOffset, (y + height) / 16.0f + yOffset, (z + depth) / 16.0f + zOffset); //1 1 1

            Gl.glTexCoord2f((x + width) / 16.0f, (16 - z) / 16.0f); //1, 1
            Gl.glVertex3f((x + width) / 16.0f + xOffset, (y + height) / 16.0f + yOffset, z / 16.0f + zOffset); //1 1 -1

            Gl.glEnd();

            //bottom face
            Gl.glBegin(Gl.GL_QUADS);

            Gl.glTexCoord2f(x / 16.0f, (16 - z) / 16.0f); //1, 1
            Gl.glVertex3f(x / 16.0f + xOffset, y / 16.0f + yOffset, z / 16.0f + zOffset); //-1 -1 -1

            Gl.glTexCoord2f((x + width) / 16.0f, (16 - z) / 16.0f); //0, 1
            Gl.glVertex3f((x + width) / 16.0f + xOffset, y / 16.0f + yOffset, z / 16.0f + zOffset); //1 -1 -1

            Gl.glTexCoord2f((x + width) / 16.0f, (16 - (z + depth)) / 16.0f); //0, 0
            Gl.glVertex3f((x + width) / 16.0f + xOffset, y / 16.0f + yOffset, (z + depth) / 16.0f + zOffset); //1 -1 1

            Gl.glTexCoord2f(x / 16.0f, (16 - (z + depth)) / 16.0f); //1, 0
            Gl.glVertex3f(x / 16.0f + xOffset, y / 16.0f + yOffset, (z + depth) / 16.0f + zOffset); //-1 -1 1

            Gl.glEnd();
        }

        public static void drawModelTextureMappedLever(float x, float y, float z, float width, float height, float depth)
        {
            //front face
            Gl.glBegin(Gl.GL_QUADS);

            Gl.glTexCoord2f(x / 16.0f, y / 16.0f); //0, 0
            Gl.glVertex3f(x / 16.0f, y / 16.0f, (z + depth) / 16.0f); //-1 -1 1

            Gl.glTexCoord2f((x + width) / 16.0f, y / 16.0f); //1, 0
            Gl.glVertex3f((x + width) / 16.0f, y / 16.0f, (z + depth) / 16.0f); //1 -1 1

            Gl.glTexCoord2f((x + width) / 16.0f, (y + height) / 16.0f); //1, 1
            Gl.glVertex3f((x + width) / 16.0f, (y + height) / 16.0f, (z + depth) / 16.0f); //1 1 1

            Gl.glTexCoord2f(x / 16.0f, (y + height) / 16.0f); //0, 1
            Gl.glVertex3f(x / 16.0f, (y + height) / 16.0f, (z + depth) / 16.0f); //-1 1 1

            Gl.glEnd();

            //back face
            Gl.glBegin(Gl.GL_QUADS);

            Gl.glTexCoord2f((x + width) / 16.0f, y / 16.0f); //0, 0
            Gl.glVertex3f((x + width) / 16.0f, y / 16.0f, z / 16.0f); // 1 -1 -1

            Gl.glTexCoord2f(x / 16.0f, y / 16.0f); //1, 0
            Gl.glVertex3f(x / 16.0f, y / 16.0f, z / 16.0f); //-1 -1 -1

            Gl.glTexCoord2f(x / 16.0f, (y + height) / 16.0f); //1, 1
            Gl.glVertex3f(x / 16.0f, (y + height) / 16.0f, z / 16.0f);//-1  1 -1

            Gl.glTexCoord2f((x + width) / 16.0f, (y + height) / 16.0f); //0, 1
            Gl.glVertex3f((x + width) / 16.0f, (y + height) / 16.0f, z / 16.0f); // 1  1 -1

            Gl.glEnd();

            //right face
            Gl.glBegin(Gl.GL_QUADS);

            Gl.glTexCoord2f((z + depth) / 16.0f, y / 16.0f); //1, 0
            Gl.glVertex3f((x + width) / 16.0f, y / 16.0f, z / 16.0f); //1 -1 -1

            Gl.glTexCoord2f((z + depth) / 16.0f, (y + height) / 16.0f); //1, 1
            Gl.glVertex3f((x + width) / 16.0f, (y + height) / 16.0f, z / 16.0f); //1 1 -1

            Gl.glTexCoord2f(z / 16.0f, (y + height) / 16.0f); //0, 1
            Gl.glVertex3f((x + width) / 16.0f, (y + height) / 16.0f, (z + depth) / 16.0f); //1 1 1

            Gl.glTexCoord2f(z / 16.0f, y / 16.0f); //0, 0
            Gl.glVertex3f((x + width) / 16.0f, y / 16.0f, (z + depth) / 16.0f); //1 -1 1
            Gl.glEnd();

            //left face
            Gl.glBegin(Gl.GL_QUADS);

            Gl.glTexCoord2f(z / 16.0f, y / 16.0f); //0, 0
            Gl.glVertex3f(x / 16.0f, y / 16.0f, z / 16.0f); //-1 -1 -1

            Gl.glTexCoord2f((z + depth) / 16.0f, y / 16.0f); //1, 0
            Gl.glVertex3f(x / 16.0f, y / 16.0f, (z + depth) / 16.0f); //-1 -1 1

            Gl.glTexCoord2f((z + depth) / 16.0f, (y + height) / 16.0f); //1, 1
            Gl.glVertex3f(x / 16.0f, (y + height) / 16.0f, (z + depth) / 16.0f); //-1 1 1

            Gl.glTexCoord2f(z / 16.0f, (y + height) / 16.0f); //0, 1
            Gl.glVertex3f(x / 16.0f, (y + height) / 16.0f, z / 16.0f); //-1 1 -1

            Gl.glEnd();

            //top face
            Gl.glBegin(Gl.GL_QUADS);

            Gl.glTexCoord2f((x + width) / 16.0f, (17 - z) / 16.0f); //0, 1
            Gl.glVertex3f(x / 16.0f, (y + height) / 16.0f, z / 16.0f); //-1 1 -1

            Gl.glTexCoord2f((x + width) / 16.0f, (17 - (z + depth)) / 16.0f); //0, 0
            Gl.glVertex3f(x / 16.0f, (y + height) / 16.0f, (z + depth) / 16.0f); //-1 1 1

            Gl.glTexCoord2f(x / 16.0f, (17 - (z + depth)) / 16.0f); //1, 0
            Gl.glVertex3f((x + width) / 16.0f, (y + height) / 16.0f, (z + depth) / 16.0f); //1 1 1

            Gl.glTexCoord2f(x / 16.0f, (17 - z) / 16.0f); //1, 1
            Gl.glVertex3f((x + width) / 16.0f, (y + height) / 16.0f, z / 16.0f); //1 1 -1

            Gl.glEnd();

            //bottom face
            Gl.glBegin(Gl.GL_QUADS);

            Gl.glTexCoord2f(x / 16.0f, (16 - z) / 16.0f); //1, 1
            Gl.glVertex3f(x / 16.0f, y / 16.0f, z / 16.0f); //-1 -1 -1

            Gl.glTexCoord2f((x + width) / 16.0f, (16 - z) / 16.0f); //0, 1
            Gl.glVertex3f((x + width) / 16.0f, y / 16.0f, z / 16.0f); //1 -1 -1

            Gl.glTexCoord2f((x + width) / 16.0f, (16 - (z + depth)) / 16.0f); //0, 0
            Gl.glVertex3f((x + width) / 16.0f, y / 16.0f, (z + depth) / 16.0f); //1 -1 1

            Gl.glTexCoord2f(x / 16.0f, (16 - (z + depth)) / 16.0f); //1, 0
            Gl.glVertex3f(x / 16.0f, y / 16.0f, (z + depth) / 16.0f); //-1 -1 1

            Gl.glEnd();
        }

        public static bool initialiseOpenGL()
        {
            if (!loadOpenGLTextures())
            {
                return false;
            }

            Gl.glEnable(Gl.GL_TEXTURE_2D);
            Gl.glShadeModel(Gl.GL_SMOOTH);
            Gl.glClearColor(0, 0, 0, 0.5f);
            Gl.glClearDepth(1);
            Gl.glEnable(Gl.GL_DEPTH_TEST);
            Gl.glDepthFunc(Gl.GL_LEQUAL);
            Gl.glHint(Gl.GL_PERSPECTIVE_CORRECTION_HINT, Gl.GL_NICEST);

            Gl.glEnable(Gl.GL_BLEND);
            Gl.glBlendFunc(Gl.GL_SRC_ALPHA, Gl.GL_ONE_MINUS_SRC_ALPHA);
            Gl.glAlphaFunc(Gl.GL_GREATER, 0.1f);
            Gl.glEnable(Gl.GL_ALPHA_TEST);

            return true;
        }

        public static void closeOpenGLwindow()
        {
            if (hRC != IntPtr.Zero)
            {
                if (!Wgl.wglMakeCurrent(IntPtr.Zero, IntPtr.Zero))
                {
                    MessageBox.Show("Failed to release device context", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (!Wgl.wglDeleteContext(hRC))
                {
                    MessageBox.Show("Failed to release rendering context", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                hRC = IntPtr.Zero;
            }

            if (hDC != IntPtr.Zero)
            {
                if (form != null && !form.IsDisposed)
                {
                    if (form.Handle != IntPtr.Zero)
                    {
                        if (!User.ReleaseDC(form.Handle, hDC))
                        {
                            MessageBox.Show("Failed to release device context", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

                hDC = IntPtr.Zero;
            }

            if (form != null)
            {
                form.Hide();
                form.Close();
                form = null;
            }
        }

        public static ModelType getModelType(string blockName)
        {
            if (blockName == "Grass Block")
            {
                return ModelType.GrassBlock;
            }
            else if (blockName == "Dirt (Snow)")
            {
                return ModelType.GrassBlock;
            }
            else if (blockName == "Acacia Sapling")
            {
                return ModelType.PlaneCross;
            }
            else if (blockName == "Birch Sapling")
            {
                return ModelType.PlaneCross;
            }
            else if (blockName == "Jungle Sapling")
            {
                return ModelType.PlaneCross;
            }
            else if (blockName == "Oak Sapling")
            {
                return ModelType.PlaneCross;
            }
            else if (blockName == "Dark Oak Sapling")
            {
                return ModelType.PlaneCross;
            }
            else if (blockName == "Spruce Sapling")
            {
                return ModelType.PlaneCross;
            }
            else if (blockName == "Water Still")
            {
                return ModelType.AnimatedStrip;
            }
            else if (blockName == "Water Flowing")
            {
                return ModelType.AnimatedStrip;
            }
            else if (blockName == "Lava Still")
            {
                return ModelType.AnimatedStrip;
            }
            else if (blockName == "Lava Flowing")
            {
                return ModelType.AnimatedStrip;
            }
            else if (blockName == "Oak")
            {
                return ModelType.BlockSameTopAndBottom;
            }
            else if (blockName == "Birch")
            {
                return ModelType.BlockSameTopAndBottom;
            }
            else if (blockName == "Jungle Wood")
            {
                return ModelType.BlockSameTopAndBottom;
            }
            else if (blockName == "Spruce")
            {
                return ModelType.BlockSameTopAndBottom;
            }
            else if (blockName == "Acacia")
            {
                return ModelType.BlockSameTopAndBottom;
            }
            else if (blockName == "Big Oak")
            {
                return ModelType.BlockSameTopAndBottom;
            }
            else if (blockName == "Dispenser Horizontal")
            {
                return ModelType.BlockFrontTopAndBottom;
            }
            else if (blockName == "Dispenser Vertical")
            {
                return ModelType.BlockTop;
            }
            else if (blockName == "Sandstone")
            {
                return ModelType.BlockDiffTopAndBottom;
            }
            else if (blockName == "Smooth Sandstone")
            {
                return ModelType.BlockDiffTopAndBottom;
            }
            else if (blockName == "Carved Sandstone")
            {
                return ModelType.BlockDiffTopAndBottom;
            }
            else if (blockName == "Sticky Piston")
            {
                return ModelType.BlockDiffTopAndBottom;
            }
            else if (blockName == "Bed")
            {
                return ModelType.Bed;
            }
            else if (blockName == "Golden Rail")
            {
                return ModelType.TopFace;
            }
            else if (blockName == "Detector Rail")
            {
                return ModelType.TopFace;
            }
            else if (blockName == "Grass")
            {
                return ModelType.PlaneCross;
            }
            else if (blockName == "Cobweb")
            {
                return ModelType.PlaneCross;
            }
            else if (blockName == "Dead Bush")
            {
                return ModelType.PlaneCross;
            }
            else if (blockName == "Piston")
            {
                return ModelType.BlockDiffTopAndBottom;
            }
            else if (blockName == "Piston Extended")
            {
                return ModelType.PistonExtended;
            }
            else if (blockName == "Dandelion")
            {
                return ModelType.PlaneCross;
            }
            else if (blockName == "Poppy")
            {
                return ModelType.PlaneCross;
            }
            else if (blockName == "Blue Orchid")
            {
                return ModelType.PlaneCross;
            }
            else if (blockName == "Allium")
            {
                return ModelType.PlaneCross;
            }
            else if (blockName == "Azure Bluet")
            {
                return ModelType.PlaneCross;
            }
            else if (blockName == "Red Tulip")
            {
                return ModelType.PlaneCross;
            }
            else if (blockName == "Orange Tulip")
            {
                return ModelType.PlaneCross;
            }
            else if (blockName == "White Tulip")
            {
                return ModelType.PlaneCross;
            }
            else if (blockName == "Pink Tulip")
            {
                return ModelType.PlaneCross;
            }
            else if (blockName == "Oxeye Daisy")
            {
                return ModelType.PlaneCross;
            }
            else if (blockName == "Brown Mushroom")
            {
                return ModelType.PlaneCross;
            }
            else if (blockName == "Red Mushroom")
            {
                return ModelType.PlaneCross;
            }
            else if (blockName == "Double Stone Slab")
            {
                return ModelType.DoubleStoneSlab;
            }
            else if (blockName == "Stone Slab")
            {
                return ModelType.StoneSlab;
            }
            else if (blockName == "Sandstone Slab")
            {
                return ModelType.StoneSlab;
            }
            else if (blockName == "Cobblestone Slab")
            {
                return ModelType.Slab;
            }
            else if (blockName == "Bricks Slab")
            {
                return ModelType.Slab;
            }
            else if (blockName == "Stone Bricks Slab")
            {
                return ModelType.Slab;
            }
            else if (blockName == "Nether Brick Slab")
            {
                return ModelType.Slab;
            }
            else if (blockName == "Quartz Slab")
            {
                return ModelType.Slab;
            }
            else if (blockName == "Oak Wood Slab")
            {
                return ModelType.Slab;
            }
            else if (blockName == "Spruce Wood Slab")
            {
                return ModelType.Slab;
            }
            else if (blockName == "Birch Wood Slab")
            {
                return ModelType.Slab;
            }
            else if (blockName == "Jungle Wood Slab")
            {
                return ModelType.Slab;
            }
            else if (blockName == "Acacia Wood Slab")
            {
                return ModelType.Slab;
            }
            else if (blockName == "Dark Oak Wood Slab")
            {
                return ModelType.Slab;
            }
            else if (blockName == "TNT")
            {
                return ModelType.BlockDiffTopAndBottom;
            }
            else if (blockName == "Bookshelf")
            {
                return ModelType.BlockSameTopAndBottom;
            }
            else if (blockName == "Torch")
            {
                return ModelType.Torch;
            }
            else if (blockName == "Fire")
            {
                return ModelType.Fire;
            }
            else if (blockName == "Oak Wood Stairs")
            {
                return ModelType.Stairs;
            }
            else if (blockName == "Stone Stairs")
            {
                return ModelType.Stairs;
            }
            else if (blockName == "Brick Stairs")
            {
                return ModelType.Stairs;
            }
            else if (blockName == "Stone Brick Stairs")
            {
                return ModelType.Stairs;
            }
            else if (blockName == "Mycelium")
            {
                return ModelType.BlockDiffTopAndBottom;
            }
            else if (blockName == "Quartz Stairs")
            {
                return ModelType.MultiTextureStairs;
            }
            else if (blockName == "Chest")
            {
                return ModelType.Chest;
            }
            else if (blockName == "Double Chest")
            {
                return ModelType.DoubleChest;
            }
            else if (blockName == "Redstone Cross")
            {
                return ModelType.TopFace;
            }
            else if (blockName == "Redstone Line")
            {
                return ModelType.TopFace;
            }
            else if (blockName == "Crafting Table")
            {
                return ModelType.CraftingTable;
            }
            else if (blockName == "Wheat Stage 0")
            {
                return ModelType.Wheat;
            }
            else if (blockName == "Wheat Stage 1")
            {
                return ModelType.Wheat;
            }
            else if (blockName == "Wheat Stage 2")
            {
                return ModelType.Wheat;
            }
            else if (blockName == "Wheat Stage 3")
            {
                return ModelType.Wheat;
            }
            else if (blockName == "Wheat Stage 4")
            {
                return ModelType.Wheat;
            }
            else if (blockName == "Wheat Stage 5")
            {
                return ModelType.Wheat;
            }
            else if (blockName == "Wheat Stage 6")
            {
                return ModelType.Wheat;
            }
            else if (blockName == "Wheat Stage 7")
            {
                return ModelType.Wheat;
            }
            else if (blockName == "Farmland Dry")
            {
                return ModelType.BlockTop;
            }
            else if (blockName == "Farmland Wet")
            {
                return ModelType.BlockTop;
            }
            else if (blockName == "Furnace Off")
            {
                return ModelType.BlockFrontTopAndBottom;
            }
            else if (blockName == "Furnace On")
            {
                return ModelType.BlockFrontTopAndBottom;
            }
            else if (blockName == "Furnace On")
            {
                return ModelType.BlockFrontTopAndBottom;
            }
            else if (blockName == "Standing Sign")
            {
                return ModelType.StandingSign;
            }
            else if (blockName == "Wall Sign")
            {
                return ModelType.WallSign;
            }
            else if (blockName == "Lever")
            {
                return ModelType.Lever;
            }
            else if (blockName == "Stone Pressure Plate")
            {
                return ModelType.PressurePlate;
            }
            else if (blockName == "Wooden Pressure Plate")
            {
                return ModelType.PressurePlate;
            }
            else if (blockName == "Wooden Door")
            {
                return ModelType.Door;
            }
            else if (blockName == "Iron Door")
            {
                return ModelType.Door;
            }
            else if (blockName == "Ladders")
            {
                return ModelType.FrontFace;
            }
            else if (blockName == "Rail")
            {
                return ModelType.TopFace;
            }
            else if (blockName == "Rail Turned")
            {
                return ModelType.TopFace;
            }
            else if (blockName == "Redstone Torch Off")
            {
                return ModelType.Torch;
            }
            else if (blockName == "Redstone Torch On")
            {
                return ModelType.RedstoneTorchOn;
            }
            else if (blockName == "Button")
            {
                return ModelType.Button;
            }
            else if (blockName == "Snow")
            {
                return ModelType.Snow;
            }
            else if (blockName == "Cactus")
            {
                return ModelType.Cactus;
            }
            else if (blockName == "Sugar Cane")
            {
                return ModelType.PlaneCross;
            }
            else if (blockName == "Jukebox")
            {
                return ModelType.BlockTop;
            }
            else if (blockName == "Fence")
            {
                return ModelType.Fence;
            }
            else if (blockName == "Pumpkin Off")
            {
                return ModelType.BlockFrontTopAndBottom;
            }
            else if (blockName == "Portal")
            {
                return ModelType.AnimatedStripFront;
            }
            else if (blockName == "Pumpkin On")
            {
                return ModelType.BlockFrontTopAndBottom;
            }
            else if (blockName == "Cake")
            {
                return ModelType.Cake;
            }
            else if (blockName == "Redstone Repeater Off")
            {
                return ModelType.RedstoneRepeaterOff;
            }
            else if (blockName == "Redstone Repeater On")
            {
                return ModelType.RedstoneRepeaterOn;
            }
            else if (blockName == "Trapdoor")
            {
                return ModelType.Trapdoor;
            }
            else if (blockName == "Huge Brown Mushroom")
            {
                return ModelType.BlockSameTopAndBottom;
            }
            else if (blockName == "Huge Red Mushroom")
            {
                return ModelType.BlockSameTopAndBottom;
            }
            else if (blockName == "Iron Bars")
            {
                return ModelType.IronBars;
            }
            else if (blockName == "Glass Pane")
            {
                return ModelType.GlassPane;
            }
            else if (blockName == "Melon")
            {
                return ModelType.BlockSameTopAndBottom;
            }
            else if (blockName == "Pumpkin Stem Connected")
            {
                return ModelType.FrontFace;
            }
            else if (blockName == "Pumpkin Stem Disconnected")
            {
                return ModelType.FrontFace;
            }
            else if (blockName == "Melon Stem Connected")
            {
                return ModelType.FrontFace;
            }
            else if (blockName == "Melon Stem Disconnected")
            {
                return ModelType.FrontFace;
            }
            else if (blockName == "Vines")
            {
                return ModelType.FrontFace;
            }
            else if (blockName == "Fence Gate")
            {
                return ModelType.FenceGate;
            }
            else if (blockName == "Lily Pad")
            {
                return ModelType.TopFace;
            }
            else if (blockName == "Nether Brick Fence")
            {
                return ModelType.Fence;
            }
            else if (blockName == "Nether Brick Stairs")
            {
                return ModelType.Stairs;
            }
            else if (blockName == "Nether Wart Stage 0")
            {
                return ModelType.NetherWart;
            }
            else if (blockName == "Nether Wart Stage 1")
            {
                return ModelType.NetherWart;
            }
            else if (blockName == "Nether Wart Stage 2")
            {
                return ModelType.NetherWart;
            }
            else if (blockName == "Enchantment Table")
            {
                return ModelType.EnchantmentTable;
            }
            else if (blockName == "Brewing Stand Empty")
            {
                return ModelType.BrewingStandEmpty;
            }
            else if (blockName == "Brewing Stand Potion")
            {
                return ModelType.BrewingStandPotion;
            }
            else if (blockName == "Cauldron")
            {
                return ModelType.Cauldron;
            }
            else if (blockName == "End Portal Block")
            {
                return ModelType.EndPortalBlock;
            }
            else if (blockName == "Dragon Egg")
            {
                return ModelType.DragonEgg;
            }
            else if (blockName == "Cocoa Stage 0")
            {
                return ModelType.CocoaStage0;
            }
            else if (blockName == "Cocoa Stage 1")
            {
                return ModelType.CocoaStage1;
            }
            else if (blockName == "Cocoa Stage 2")
            {
                return ModelType.CocoaStage2;
            }
            else if (blockName == "Sandstone Stairs")
            {
                return ModelType.MultiTextureStairs;
            }
            else if (blockName == "Ender Chest")
            {
                return ModelType.Chest;
            }
            else if (blockName == "Tripwire Hook")
            {
                return ModelType.TripWireHook;
            }
            else if (blockName == "Tripwire")
            {
                return ModelType.TripWire;
            }
            else if (blockName == "Spruce Wood Stairs")
            {
                return ModelType.Stairs;
            }
            else if (blockName == "Birch Wood Stairs")
            {
                return ModelType.Stairs;
            }
            else if (blockName == "Jungle Wood Stairs")
            {
                return ModelType.Stairs;
            }
            else if (blockName == "Beacon")
            {
                return ModelType.Beacon;
            }
            else if (blockName == "Cobblestone Wall")
            {
                return ModelType.Wall;
            }
            else if (blockName == "Flower Pot")
            {
                return ModelType.FlowerPot;
            }
            else if (blockName == "Carrots Stage 0")
            {
                return ModelType.Wheat;
            }
            else if (blockName == "Carrots Stage 1")
            {
                return ModelType.Wheat;
            }
            else if (blockName == "Carrots Stage 2")
            {
                return ModelType.Wheat;
            }
            else if (blockName == "Carrots Stage 3")
            {
                return ModelType.Wheat;
            }
            else if (blockName == "Potatoes Stage 0")
            {
                return ModelType.Wheat;
            }
            else if (blockName == "Potatoes Stage 1")
            {
                return ModelType.Wheat;
            }
            else if (blockName == "Potatoes Stage 2")
            {
                return ModelType.Wheat;
            }
            else if (blockName == "Potatoes Stage 3")
            {
                return ModelType.Wheat;
            }
            else if (blockName == "Wooden Button")
            {
                return ModelType.Button;
            }
            else if (blockName == "Skeleton Skull")
            {
                return ModelType.MobHead;
            }
            else if (blockName == "Wither Skeleton Skull")
            {
                return ModelType.MobHead;
            }
            else if (blockName == "Zombie Head")
            {
                return ModelType.ZombieHead;
            }
            else if (blockName == "Head")
            {
                return ModelType.MobHead;
            }
            else if (blockName == "Creeper Head")
            {
                return ModelType.MobHead;
            }
            else if (blockName == "Anvil")
            {
                return ModelType.Anvil;
            }
            else if (blockName == "Trapped Chest")
            {
                return ModelType.Chest;
            }
            else if (blockName == "Double Trapped Chest")
            {
                return ModelType.DoubleChest;
            }
            else if (blockName == "Weighted Pressure Plate (Light)")
            {
                return ModelType.WeightedPressurePlateLight;
            }
            else if (blockName == "Weighted Pressure Plate (Heavy)")
            {
                return ModelType.WeightedPressurePlateHeavy;
            }
            else if (blockName == "Redstone Comparator Off")
            {
                return ModelType.RedstoneComparatorOff;
            }
            else if (blockName == "Redstone Comparator On")
            {
                return ModelType.RedstoneComparatorOn;
            }
            else if (blockName == "Daylight Sensor")
            {
                return ModelType.DaylightSensor;
            }
            else if (blockName == "Hopper")
            {
                return ModelType.Hopper;
            }
            else if (blockName == "Quartz Block")
            {
                return ModelType.BlockDiffTopAndBottom;
            }
            else if (blockName == "Activator Rail")
            {
                return ModelType.TopFace;
            }
            else if (blockName == "Dropper Horizontal")
            {
                return ModelType.BlockFrontTopAndBottom;
            }
            else if (blockName == "Dropper Vertical")
            {
                return ModelType.BlockTop;
            }
            else if (blockName == "White Stained Glass Pane")
            {
                return ModelType.GlassPane;
            }
            else if (blockName == "Orange Stained Glass Pane")
            {
                return ModelType.GlassPane;
            }
            else if (blockName == "Magenta Stained Glass Pane")
            {
                return ModelType.GlassPane;
            }
            else if (blockName == "Light Blue Stained Glass Pane")
            {
                return ModelType.GlassPane;
            }
            else if (blockName == "Yellow Stained Glass Pane")
            {
                return ModelType.GlassPane;
            }
            else if (blockName == "Lime Stained Glass Pane")
            {
                return ModelType.GlassPane;
            }
            else if (blockName == "Pink Stained Glass Pane")
            {
                return ModelType.GlassPane;
            }
            else if (blockName == "Gray Stained Glass Pane")
            {
                return ModelType.GlassPane;
            }
            else if (blockName == "Light Gray Stained Glass Pane")
            {
                return ModelType.GlassPane;
            }
            else if (blockName == "Cyan Stained Glass Pane")
            {
                return ModelType.GlassPane;
            }
            else if (blockName == "Purple Stained Glass Pane")
            {
                return ModelType.GlassPane;
            }
            else if (blockName == "Blue Stained Glass Pane")
            {
                return ModelType.GlassPane;
            }
            else if (blockName == "Brown Stained Glass Pane")
            {
                return ModelType.GlassPane;
            }
            else if (blockName == "Green Stained Glass Pane")
            {
                return ModelType.GlassPane;
            }
            else if (blockName == "Red Stained Glass Pane")
            {
                return ModelType.GlassPane;
            }
            else if (blockName == "Black Stained Glass Pane")
            {
                return ModelType.GlassPane;
            }
            else if (blockName == "Hay Block")
            {
                return ModelType.BlockSameTopAndBottom;
            }
            else if (blockName == "Carpet")
            {
                return ModelType.Carpet;
            }
            else if (blockName == "Orange Carpet")
            {
                return ModelType.Carpet;
            }
            else if (blockName == "Magenta Carpet")
            {
                return ModelType.Carpet;
            }
            else if (blockName == "Light Blue Carpet")
            {
                return ModelType.Carpet;
            }
            else if (blockName == "Yellow Carpet")
            {
                return ModelType.Carpet;
            }
            else if (blockName == "Lime Carpet")
            {
                return ModelType.Carpet;
            }
            else if (blockName == "Pink Carpet")
            {
                return ModelType.Carpet;
            }
            else if (blockName == "Gray Carpet")
            {
                return ModelType.Carpet;
            }
            else if (blockName == "Light Gray Carpet")
            {
                return ModelType.Carpet;
            }
            else if (blockName == "Cyan Carpet")
            {
                return ModelType.Carpet;
            }
            else if (blockName == "Purple Carpet")
            {
                return ModelType.Carpet;
            }
            else if (blockName == "Blue Carpet")
            {
                return ModelType.Carpet;
            }
            else if (blockName == "Brown Carpet")
            {
                return ModelType.Carpet;
            }
            else if (blockName == "Green Carpet")
            {
                return ModelType.Carpet;
            }
            else if (blockName == "Red Carpet")
            {
                return ModelType.Carpet;
            }
            else if (blockName == "Black Carpet")
            {
                return ModelType.Carpet;
            }
            else if (blockName == "Acacia Wood Stairs")
            {
                return ModelType.Stairs;
            }
            else if (blockName == "Dark Oak Wood Stairs")
            {
                return ModelType.Stairs;
            }
            else if (blockName == "Sunflower")
            {
                return ModelType.Sunflower;
            }
            else if (blockName == "Lilac")
            {
                return ModelType.TallPlant;
            }
            else if (blockName == "Rose Bush")
            {
                return ModelType.TallPlant;
            }
            else if (blockName == "Peony")
            {
                return ModelType.TallPlant;
            }
            else if (blockName == "Tall Grass")
            {
                return ModelType.TallPlant;
            }
            else if (blockName == "Large Fern")
            {
                return ModelType.TallPlant;
            }
            else if (blockName == "Destroy")
            {
                return ModelType.Destroy;
            }
            else if (blockName == "Inverted Daylight Sensor")
            {
                return ModelType.DaylightSensor;
            }
            else if (blockName == "Red Sandstone")
            {
                return ModelType.BlockDiffTopAndBottom;
            }
            else if (blockName == "Red Sandstone Stairs")
            {
                return ModelType.Stairs;
            }
            else if (blockName == "Red Sandstone Slab")
            {
                return ModelType.StoneSlab;
            }
            else if (blockName == "Spruce Fence Gate")
            {
                return ModelType.FenceGate;
            }
            else if (blockName == "Birch Fence Gate")
            {
                return ModelType.FenceGate;
            }
            else if (blockName == "Jungle Fence Gate")
            {
                return ModelType.FenceGate;
            }
            else if (blockName == "Dark Oak Fence Gate")
            {
                return ModelType.FenceGate;
            }
            else if (blockName == "Acacia Fence Gate")
            {
                return ModelType.FenceGate;
            }
            else if (blockName == "Spruce Fence")
            {
                return ModelType.Fence;
            }
            else if (blockName == "Birch Fence")
            {
                return ModelType.Fence;
            }
            else if (blockName == "Jungle Fence")
            {
                return ModelType.Fence;
            }
            else if (blockName == "Dark Oak Fence")
            {
                return ModelType.Fence;
            }
            else if (blockName == "Acacia Fence")
            {
                return ModelType.Fence;
            }
            else if (blockName == "Spruce Door")
            {
                return ModelType.Door;
            }
            else if (blockName == "Birch Door")
            {
                return ModelType.Door;
            }
            else if (blockName == "Jungle Door")
            {
                return ModelType.Door;
            }
            else if (blockName == "Acacia Door")
            {
                return ModelType.Door;
            }
            else if (blockName == "Dark Oak Door")
            {
                return ModelType.Door;
            }
            else
            {
                if (FrmMain.texturePackLoaded)
                {
                    return ModelType.Block;
                }
                else
                {
                    return ModelType.None;
                }
            }
        }

        public static bool loadOpenGLTextures()
        {
            try
            {
                blockChangeTime = DateTime.Now;

                textureCount = 1;

                if (firstLoad)
                {
                    firstLoad = false;
                }
                else
                {
                    Gl.glDeleteTextures(64, textures);
                }

                blockName = changeBlockName;
                Gl.glGenTextures(64, textures);

                List<string> textureFilenames = Blocks.getTextures(blockName);
                textureCount = textureFilenames.Count;

                for (int a = 0; a < textureFilenames.Count; a++)
                {
                    loadOpenGLTexture(textureFilenames[a], a);
                }

                /**/
                loadOpenGLTexture(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\stone.png", 63);

                modelType = getModelType(blockName);

                if (blockName == "Grass Block")
                {
                    loadGrassBlock();
                }
                else if (blockName == "Water Still")
                {
                    loadTextureStrip(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\water_still.png", 32);
                }
                else if (blockName == "Water Flowing")
                {
                    loadTextureStrip(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\water_flow.png", 64);
                }
                else if (blockName == "Lava Still")
                {
                    loadTextureStrip(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\lava_still.png", 20);
                }
                else if (blockName == "Lava Flowing")
                {
                    loadTextureStrip(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\lava_flow.png", 32);
                }
                else if (blockName == "Fire")
                {
                    loadFireTextures();
                    textureCount = 64;
                }
                else if (blockName == "Portal")
                {
                    loadTextureStrip(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\portal.png", 32);
                }
                else if (blockName == "Destroy")
                {
                    loadDestroyAnimation();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Exception occured loading opengl textures: " + exception.Message);
            }
            
            return true;
        }

        private static void loadGrassBlock()
        {
            Bitmap loadPicture = new Bitmap(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\grass_side_overlay.png");
            Bitmap grassSideOverlay = new Bitmap(loadPicture);
            loadPicture.Dispose();

            Color greenTint = Color.FromArgb(255, 84, 212, 0);

            //tint grassSideOverlay
            for (int y = 0; y < grassSideOverlay.Height; y++)
            {
                for (int x = 0; x < grassSideOverlay.Width; x++)
                {
                    Color colour = grassSideOverlay.GetPixel(x, y);

                    Color newColour = Color.FromArgb(colour.A, (int)(colour.R / 2 + greenTint.R / 2),
                        (int)(colour.G / 2 + greenTint.G / 2), (int)(colour.B / 2 + greenTint.B / 2));

                    grassSideOverlay.SetPixel(x, y, newColour);
                }
            }

            loadPicture = new Bitmap(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\grass_side.png");
            Bitmap grassSide = new Bitmap(loadPicture);
            loadPicture.Dispose();

            //add overlay to grass side
            for (int y = 0; y < grassSide.Height; y++)
            {
                for (int x = 0; x < grassSide.Width; x++)
                {
                    Color overlayColour = grassSideOverlay.GetPixel(x, y);
                    if (overlayColour.A == 255)
                    {
                        grassSide.SetPixel(x, y, overlayColour);
                    }
                }
            }

            loadOpenGLTexture(grassSide, 0);
            loadOpenGLTexture(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\grass_top.png", 1);
            loadOpenGLTexture(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\dirt.png", 2);
        }

        public static bool loadFireTextures()
        {
            textureCount = 64;
            Bitmap fireLayer1 = new Bitmap(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\fire_layer_0.png");
            int fireLayer1y = 0;

            for (int a = 0; a < 32; a++)
            {
                Bitmap fireFrame = new Bitmap(16, 16);

                for (int y = 0; y < 16; y++)
                {
                    for (int x = 0; x < 16; x++)
                    {
                        fireFrame.SetPixel(x, y, fireLayer1.GetPixel(x, y + fireLayer1y));
                    }
                }

                loadOpenGLTexture(fireFrame, a);
                fireLayer1y += 16;
            }

            fireLayer1.Dispose();

            Bitmap fireLayer2 = new Bitmap(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\fire_layer_1.png");
            int fireLayer2y = 0;

            for (int a = 32; a < 64; a++)
            {
                Bitmap fireFrame = new Bitmap(16, 16);

                for (int y = 0; y < 16; y++)
                {
                    for (int x = 0; x < 16; x++)
                    {
                        fireFrame.SetPixel(x, y, fireLayer2.GetPixel(x, y + fireLayer2y));
                    }
                }

                loadOpenGLTexture(fireFrame, a);
                fireLayer2y += 16;
            }

            fireLayer2.Dispose();

            return true;
        }

        public static bool loadTextureStrip(string path, int frames)
        {
            Bitmap layer1 = new Bitmap(path);
            int layer1y = 0;
            textureCount = frames;
            int width = layer1.Width;

            if (path.EndsWith("water_flow.png"))
            {
                width = width / 2;
            }

            for (int a = 0; a < frames; a++)
            {
                Bitmap frame = new Bitmap(width, width);

                for (int y = 0; y < width; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        frame.SetPixel(x, y, layer1.GetPixel(x, y + layer1y));
                    }
                }

                loadOpenGLTexture(frame, a);
                layer1y += width;
            }

            textureCount = frames;
            layer1.Dispose();
            return true;
        }

        public static void loadDestroyAnimation()
        {
            textureCount = 10;
            Bitmap stone = null;

            for (int a = 0; a < 10; a++)
            {
                stone = null;

                if (File.Exists(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\stone.png"))
                {
                    stone = new Bitmap(FrmMain.directory + "\\assets\\minecraft\\textures\\blocks\\stone.png");
                }
            
                Bitmap destroyFrame = new Bitmap(FrmMain.directory +
                    "\\assets\\minecraft\\textures\\blocks\\destroy_stage_" + a.ToString() + ".png");

                if (stone != null)
                {
                    for (int y = 0; y < 16; y++)
                    {
                        for (int x = 0; x < 16; x++)
                        {
                            Color colour = destroyFrame.GetPixel(x, y);

                            if (colour.A == 255)
                            {
                                stone.SetPixel(x, y, colour);
                            }
                        }
                    }
                }

                loadOpenGLTexture(stone, a);
                destroyFrame.Dispose();
            }

            if (stone != null)
            {
                stone.Dispose();
            }
        }

        public static bool loadOpenGLTexture(Bitmap textureImage, int index)
        {
            bool status = false;

            if (textureImage != null)
            {
                status = true;

                textureImage.RotateFlip(RotateFlipType.RotateNoneFlipY);
                Rectangle rectangle = new Rectangle(0, 0, textureImage.Width, textureImage.Height);
                BitmapData bitmapData = textureImage.LockBits(rectangle, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

                Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[index]);
                Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, Gl.GL_RGBA16, textureImage.Width, textureImage.Height, 0, Gl.GL_BGRA, Gl.GL_UNSIGNED_BYTE, bitmapData.Scan0);

                Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_NEAREST);
                Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_NEAREST);

                if (textureImage != null)
                {
                    textureImage.UnlockBits(bitmapData);
                    textureImage.Dispose();
                }
            }

            return status;
        }

        public static bool loadOpenGLTexture(Bitmap textureImage, string path, int index)
        {
            bool status = false;

            string filename = path.Substring(path.LastIndexOf("\\") + 1, path.Length - path.LastIndexOf("\\") - 1);

            //add green tint
            if (filename == "grass_top.png" || filename == "tallgrass.png" ||
                filename == "vine.png" || filename == "waterlily.png" ||
                filename == "leaves_acacia.png" || filename == "leaves_acacia_opaque.png" ||
                filename == "leaves_big_oak.png" || filename == "leaves_big_oak_opaque.png" ||
                filename == "leaves_birch.png" || filename == "leaves_birch_opaque.png" ||
                filename == "leaves_jungle.png" || filename == "leaves_jungle_opaque.png" ||
                filename == "leaves_oak.png" || filename == "leaves_oak_opaque.png" ||
                filename == "leaves_spruce.png" || filename == "leaves_spruce_opaque.png" ||
                filename == "double_plant_grass_bottom.png" || filename == "double_plant_grass_top.png" ||
                filename == "double_plant_fern_bottom.png" || filename == "double_plant_fern_top.png" ||
                filename == "pumpkin_stem_connected.png" || filename == "pumpkin_stem_disconnected.png" ||
                filename == "melon_stem_connected.png" || filename == "melon_stem_disconnected.png")
            {
                Color greenTint = Color.FromArgb(255, 84, 212, 0);

                for (int y = 0; y < textureImage.Height; y++)
                {
                    for (int x = 0; x < textureImage.Width; x++)
                    {
                        Color colour = textureImage.GetPixel(x, y);

                        Color newColour = Color.FromArgb(colour.A, (int)(colour.R / 2 + greenTint.R / 2),
                            (int)(colour.G / 2 + greenTint.G / 2), (int)(colour.B / 2 + greenTint.B / 2));

                        textureImage.SetPixel(x, y, newColour);
                    }
                }
            }

            //add red tint
            if (filename == "redstone_dust_cross.png" || filename == "redstone_dust_line.png")
            {
                Color redTint = Color.FromArgb(255, 0, 0, 0);

                for (int y = 0; y < textureImage.Height; y++)
                {
                    for (int x = 0; x < textureImage.Width; x++)
                    {
                        Color colour = textureImage.GetPixel(x, y);
                        Color newColour = Color.FromArgb(colour.A, (int)(colour.R * 1.0f / 4.0f + redTint.R * 3.0f / 4.0f), 0, 0);

                        textureImage.SetPixel(x, y, newColour);
                    }
                }
            }

            if (textureImage != null)
            {
                status = true;

                textureImage.RotateFlip(RotateFlipType.RotateNoneFlipY);
                Rectangle rectangle = new Rectangle(0, 0, textureImage.Width, textureImage.Height);
                BitmapData bitmapData = textureImage.LockBits(rectangle, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

                Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[index]);
                Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, Gl.GL_RGBA16, textureImage.Width, textureImage.Height, 0, Gl.GL_BGRA, Gl.GL_UNSIGNED_BYTE, bitmapData.Scan0);

                Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_NEAREST);
                Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_NEAREST);

                if (textureImage != null)
                {
                    textureImage.UnlockBits(bitmapData);
                    textureImage.Dispose();
                }
            }

            return status;
        }

        public static bool loadOpenGLTexture(string path, int index)
        {
            bool status = false;

            if (FrmMain.texturePackLoaded)
            {
                Bitmap textureImage = null;

                try
                {
                    textureImage = new Bitmap(path);
                }
                catch (Exception exception)
                {
                    textureImage = null;
                    Console.WriteLine("Exception occured trying to load " + path + ": " + exception.Message);
                }

                string filename = path.Substring(path.LastIndexOf("\\") + 1, path.Length - path.LastIndexOf("\\") - 1);

                //add green tint
                if (filename == "grass_top.png" || filename == "tallgrass.png" ||
                    filename == "vine.png" || filename == "waterlily.png" ||
                    filename == "leaves_acacia.png" || filename == "leaves_acacia_opaque.png" ||
                    filename == "leaves_big_oak.png" || filename == "leaves_big_oak_opaque.png" ||
                    filename == "leaves_birch.png" || filename == "leaves_birch_opaque.png" ||
                    filename == "leaves_jungle.png" || filename == "leaves_jungle_opaque.png" ||
                    filename == "leaves_oak.png" || filename == "leaves_oak_opaque.png" ||
                    filename == "leaves_spruce.png" || filename == "leaves_spruce_opaque.png" ||
                    filename == "double_plant_grass_bottom.png" || filename == "double_plant_grass_top.png" ||
                    filename == "double_plant_fern_bottom.png" || filename == "double_plant_fern_top.png" ||
                    filename == "pumpkin_stem_connected.png" || filename == "pumpkin_stem_disconnected.png" ||
                    filename == "melon_stem_connected.png" || filename == "melon_stem_disconnected.png")
                {
                    Color greenTint = Color.FromArgb(255, 84, 212, 0);

                    for (int y = 0; y < textureImage.Height; y++)
                    {
                        for (int x = 0; x < textureImage.Width; x++)
                        {
                            Color colour = textureImage.GetPixel(x, y);

                            Color newColour = Color.FromArgb(colour.A, (int)(colour.R / 2 + greenTint.R / 2),
                                (int)(colour.G / 2 + greenTint.G / 2), (int)(colour.B / 2 + greenTint.B / 2));

                            textureImage.SetPixel(x, y, newColour);
                        }
                    }
                }

                //add red tint
                if (filename == "redstone_dust_cross.png" || filename == "redstone_dust_line.png")
                {
                    Color redTint = Color.FromArgb(255, 0, 0, 0);

                    for (int y = 0; y < textureImage.Height; y++)
                    {
                        for (int x = 0; x < textureImage.Width; x++)
                        {
                            Color colour = textureImage.GetPixel(x, y);
                            Color newColour = Color.FromArgb(colour.A, (int)(colour.R * 1.0f / 4.0f + redTint.R * 3.0f / 4.0f), 0, 0);

                            textureImage.SetPixel(x, y, newColour);
                        }
                    }
                }

                if (textureImage != null)
                {
                    status = true;

                    textureImage.RotateFlip(RotateFlipType.RotateNoneFlipY);
                    Rectangle rectangle = new Rectangle(0, 0, textureImage.Width, textureImage.Height);
                    BitmapData bitmapData = textureImage.LockBits(rectangle, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

                    Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[index]);
                    Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, Gl.GL_RGBA16, textureImage.Width, textureImage.Height, 0, Gl.GL_BGRA, Gl.GL_UNSIGNED_BYTE, bitmapData.Scan0);

                    Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_NEAREST);
                    Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_NEAREST);

                    if (textureImage != null)
                    {
                        textureImage.UnlockBits(bitmapData);
                        textureImage.Dispose();
                    }
                }
            }

            return status;
        }

        public static void resizeOpenGLWindow(int width, int height)
        {
            if (height == 0)
            {
                height = 1;
            }

            windowWidth = width;
            windowHeight = height;

            Gl.glViewport(0, 0, width, height);
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Glu.gluPerspective(45, width / (double)height, 0.1, 100);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
        }

        public void Form_Activated(object sender, EventArgs e)
        {
            //active = true;
        }

        public void Form_Closing(object sender, CancelEventArgs e)
        {
            done = true;
        }

        public void Form_Deactivate(object sender, EventArgs e)
        {
            //active = false;
        }

        public void Form_KeyDown(object sender, KeyEventArgs e)
        {
            keys[e.KeyValue] = true;
        }

        public void Form_KeyUp(object sender, KeyEventArgs e)
        {
            keys[e.KeyValue] = false;
        }

        public void Form_Resize(object sender, EventArgs e)
        {
            resizeOpenGLWindow(form.Width, form.Height);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTexturePreview));
            this.SuspendLayout();
            // 
            // FrmTexturePreview
            // 
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(500, 100);
            this.Name = "FrmTexturePreview";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.FrmTexturePreview_Load);
            this.ResumeLayout(false);

        }

        private void FrmTexturePreview_Load(object sender, EventArgs e)
        {

        }
    }

    public enum ModelType
    {
        Block, BlockSTBF, BlockTop, BlockSameTopAndBottom, BlockDiffTopAndBottom, BlockFrontTopAndBottom, PlaneCross, FrontFace,
        TopFace, Cactus, EndPortalBlock, CocoaStage0, CocoaStage1, CocoaStage2, Chest, DoubleChest, Torch, RedstoneTorchOn,
        Bed, PistonExtended, StoneSlab, DoubleStoneSlab, Slab, Stairs, MultiTextureStairs, Wheat, StandingSign, WallSign, 
        Door, DaylightSensor, IronBars, DragonEgg, Lever, PressurePlate, Fire, AnimatedStrip, AnimatedStripFront, Button,
        Snow, Fence, GlassPane, Cake, Trapdoor, NetherWart, EnchantmentTable, RedstoneRepeaterOff, RedstoneRepeaterOn,
        Cauldron, BrewingStandEmpty, BrewingStandPotion, FenceGate, WeightedPressurePlateLight, WeightedPressurePlateHeavy, 
        Hopper, Carpet, Anvil, Sunflower, TallPlant, RedstoneComparatorOn, RedstoneComparatorOff, TripWireHook, TripWire,
        Beacon, Wall, FlowerPot, MobHead, ZombieHead, Destroy, GrassBlock, CraftingTable, None
    }
}

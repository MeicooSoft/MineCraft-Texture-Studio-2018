using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Tao.Platform.Windows;
using System.IO;

namespace MinecraftTextureStudio
{
    public class Program
    {
        public static Thread mainThread;
        public static Thread openGLThread;
        public static bool done;

        static void Main()
        {
            Application.ThreadException += new ThreadExceptionEventHandler(UIThreadException);

            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            AppDomain.CurrentDomain.UnhandledException += new
                UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            try
            {
                Application.EnableVisualStyles();

                mainThread = new Thread(runMainForm);
                mainThread.SetApartmentState(ApartmentState.STA);
                mainThread.Start();

                openGLThread = new Thread(runOpenGL);
                openGLThread.SetApartmentState(ApartmentState.STA);
                openGLThread.Start();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Exception occured in main: " + exception.Message + "\n" +
                    exception.StackTrace);
            }
        }

        public static void UIThreadException(object sender, ThreadExceptionEventArgs e)
        {
            DateTime date = DateTime.Now;
            string strDate = date.ToString("yyyyMMMMddmmHHss");
            Exception exception = (Exception)e.Exception;

            StreamWriter writer = new StreamWriter(new FileStream("error-log-" + strDate + ".log", FileMode.Create, FileAccess.Write));
            writer.WriteLine("Exception message: " + exception.Message);

            if (exception.InnerException != null)
            {
                writer.WriteLine("Inner exception: " + exception.InnerException.Message);
                writer.WriteLine("Inner exception stack trace");
                writer.WriteLine(exception.InnerException.StackTrace);
            }

            writer.WriteLine("Stack Trace");
            writer.WriteLine(exception.StackTrace);
            writer.Close();
        }

        public static void CurrentDomain_UnhandledException(Object sender, UnhandledExceptionEventArgs e)
        {
            DateTime date = DateTime.Now;
            string strDate = date.ToString("yyyyMMddmmHHss");
            Exception exception = (Exception)e.ExceptionObject;

            StreamWriter writer = new StreamWriter(new FileStream("error-log-" + strDate + ".log", FileMode.Create, FileAccess.Write));
            writer.WriteLine("Exception message: " + exception.Message);
            
            if (exception.InnerException != null)
            {
                writer.WriteLine("Inner exception: " + exception.InnerException.Message);
                writer.WriteLine("Inner exception stack trace");
                writer.WriteLine(exception.InnerException.StackTrace);
            }

            writer.WriteLine("Stack Trace");
            writer.WriteLine(exception.StackTrace);
            writer.Close();

            MessageBox.Show("An exception occurred in Minecraft Texture Studio. " +
                "Please email the file error-log-" + strDate + ".log in your Minecraft Texture Studio directory " + 
                "to tertrihfertray@gmail.com as it contains invaluable diagnostic information " +
                "that will help fix bugs in the program. Thank you, and sorry for the inconvenience", "Unhandled exception");
        }

        public static void runMainForm()
        {
            try
            {
                Application.Run(new FrmMain());
            }
            catch (Exception exception)
            {
                MessageBox.Show("Exception occured running main form: " + exception.Message);
                Program.done = true;
            }
        }

        public static void runOpenGL()
        {
            while (!FrmMain.done)
            {
                Program.done = false;

                try
                {
                    FrmTexturePreview form = new FrmTexturePreview();

                    if (!FrmTexturePreview.createWindow("Texture preview    Click and hold to rotate the block, right click to paint", 640, 480, 16))
                    {
                        return;
                    }

                    while (!Program.done)
                    {
                        Application.DoEvents();

                        if (FrmTexturePreview.active && (form != null) && !FrmTexturePreview.render())
                        {
                            Program.done = true;
                        }
                        else
                        {
                            Gdi.SwapBuffers(FrmTexturePreview.hDC);
                        }
                    }

                    FrmTexturePreview.closeOpenGLwindow();
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Exception occured running opengl program loop: " + exception.Message);
                }
            }
        }
    }
}

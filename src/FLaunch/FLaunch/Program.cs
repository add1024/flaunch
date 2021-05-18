using System;
using System.Threading;
using System.Windows.Forms;
using FLaunch.Forms;
using FLaunch.Logic;

namespace FLaunch
{
    static class Program
    {
        /// <summary>
        /// Main
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (var mutex = new Mutex(false, CommonConst.AppName))
            {
                if (!mutex.WaitOne(0, false)) { return; } //Prevent dual
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.ThreadException += Application_ThreadException;
                Thread.GetDomain().UnhandledException += Application_UnhandledException;
                Application.Run(new MainForm());
            }
        }

        /// <summary>
        /// Application_ThreadException
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">EventArgs</param>
        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            CallExceptionHandler(e.Exception);
        }

        /// <summary>
        /// Application_UnhandledException
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">EventArgs</param>
        private static void Application_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject != null) { CallExceptionHandler(e.ExceptionObject as Exception); }
        }

        /// <summary>
        /// CallExceptionHandler 
        /// </summary>
        /// <param name="ex">Unhandled Exception</param>
        private static void CallExceptionHandler(Exception ex)
        {
            CommonUtil.ShowMessage(ex);
        }
    }
}

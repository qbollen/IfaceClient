using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace InterfaceClient
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

           // bool newMutexCreated = false;
           // string mutexName = "Local//" +
           //     System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
           // Mutex mutex = null;
           // try
           // {
           //     mutex = new Mutex(false, mutexName, out newMutexCreated);
           // }
           // catch (Exception ex)
           // {
           //     MessageBox.Show(ex.Message + "/n/n" +
           //         ex.StackTrace +
           //         "/n/n" + "Applicatioin Exiting...","Exception throw");
           //     Application.Exit();
           // }
            //if (newMutexCreated)
           // {
                Application.Run(new FrmMain());
           // }
        }
    }
}

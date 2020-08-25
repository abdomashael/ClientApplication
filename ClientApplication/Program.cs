using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientApplication
{
    static class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ITIRepository repository= ITIRepository.getInstance();


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (repository.CheckConnection())
            {
                Application.Run(new Form1());

            }
            else
            {
                string title = "Error";
                string message = "Can't connect to service please check it!!!!!";
                MessageBox.Show(message,title);
            }
        }
    }
}

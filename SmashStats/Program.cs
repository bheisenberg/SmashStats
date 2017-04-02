using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmashStats
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
            HomeView homeView = new HomeView();
            TopPanel topPanel = new TopPanel();
            HomePresenter homePresenter = new HomePresenter(homeView);
            homePresenter.AttachToView();
            MainForm mainForm = new MainForm();
            mainForm.LoadView(homeView, DockStyle.Fill);
            //mainForm.LoadView(topPanel, DockStyle.Top);

            Application.Run(mainForm);
        }
    }
}

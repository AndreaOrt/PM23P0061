using System;
using System.IO;
using PM2Tarea3P201820110061.Controller;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PM2Tarea3P201820110061
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Views.EmpleadoViews());
        }

        static DataBaseSQLite dataBaseTarea;

        public static DataBaseSQLite BaseDatos
        {
            get
            {
                if (dataBaseTarea == null)
                    dataBaseTarea = new DataBaseSQLite(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PM2TareaAD.db3"));

                return dataBaseTarea;
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

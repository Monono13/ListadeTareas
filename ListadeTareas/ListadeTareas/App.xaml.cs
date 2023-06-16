using ListadeTareas.Datos;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ListadeTareas
{
    public partial class App : Application
    {
        public static DBContent Content { get; set; }
        public App()
        {
            InitializeComponent();
            InitializaDatabase();

            MainPage = new NavigationPage(new Main());
        }

        private void InitializaDatabase()
        {
            var folderApp = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var dbPath = System.IO.Path.Combine(folderApp, "Tarea.db3");
            Content = new DBContent(dbPath);
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

using calculadoraDias.Helpers;
using calculadoraDias.View;
using System;
using System.IO;
using Xamarin.Forms;

namespace calculadoraDias
{
    public partial class App : Application
    {
        static SqliteHelper db;
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new frmPrincipal());
        }
        public static SqliteHelper SQLiteDB
        {
            get
            {
                if (db == null)
                {
                    db = new SqliteHelper(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Dias.db3"));
                }
                return db;
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

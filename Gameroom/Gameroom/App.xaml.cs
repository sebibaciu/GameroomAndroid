using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System;
using Gameroom.Data;
using System.IO;

namespace Gameroom
{
    public partial class App : Application
    {
        static ReviewListDatabase database;
        public static ReviewListDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new ReviewListDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.
                    LocalApplicationData), "ReviewList.db3"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new ListEntryPage());
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

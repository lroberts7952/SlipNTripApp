using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SlipNTrip
{
    public partial class App : Application
    {
        static PatientDatabase patientDatabase;

        public static PatientDatabase PatientDatabase
        {
            get
            {
                if (patientDatabase == null)
                {
                    patientDatabase = new PatientDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "people.db3"));
                }
                return patientDatabase;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new HomePage());
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

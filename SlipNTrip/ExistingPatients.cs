using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace SlipNTrip
{
    public class ExistingPatients : ContentPage
    {
        private ListView listView;
        public ExistingPatients()
        {
            this.Title = "Patients";

            StackLayout stackLayout = new StackLayout();

            listView = new ListView();
            //listView.ItemsSource = App.PatientDatabase.GetPeopleAsync();
        }
    }
}
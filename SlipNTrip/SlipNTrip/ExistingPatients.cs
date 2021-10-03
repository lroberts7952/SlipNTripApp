using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using SQLite;

using Xamarin.Forms;

namespace SlipNTrip
{
    public class ExistingPatients : ContentPage
    {
        private ListView listView;
        string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "patients.db3");

        Patient patient = new Patient();

        public ExistingPatients()
        {
            this.Title = "Patients";
            var db = new SQLiteConnection(dbPath);

            StackLayout stackLayout = new StackLayout();

            SearchBar searchBar = new SearchBar { Placeholder = "Search items..." };
            searchBar.TextChanged += OnTextChanged;
            stackLayout.Children.Add(searchBar);

            listView = new ListView();
            listView.ItemsSource = db.Table<Patient>().OrderBy(x => x.Name).ToList();
            listView.ItemSelected += listView_ItemSelected;
            listView.BackgroundColor = Color.White;

            stackLayout.Children.Add(listView);
            Content = new ScrollView { Content = stackLayout };
        }

        private void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            patient = (Patient)e.SelectedItem;
            Navigation.PushAsync(new PatientProfile(patient));
        }

        private void OnTextChanged(object sender, EventArgs e)
        {

        }
    }
}
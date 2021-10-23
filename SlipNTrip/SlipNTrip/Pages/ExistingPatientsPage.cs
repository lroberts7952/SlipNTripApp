﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using SQLite;

using Xamarin.Forms;

namespace SlipNTrip
{
    public class ExistingPatientsPage : ContentPage
    {
        //private ListView listView;
        private ListView PatientListView;

        string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "patients.db3");

        Patient patient = new Patient();

        public ExistingPatientsPage()
        {
            this.Title = "Patients";
            var db = new SQLiteConnection(dbPath);

            StackLayout stackLayout = new StackLayout();

            SearchBar searchBar = new SearchBar { Placeholder = "Search items..." };
            searchBar.TextChanged += OnTextChanged;
            stackLayout.Children.Add(searchBar);

            var results = db.GetTableInfo("Patient");
            if(results.Count > 0)
            {
                PatientListView = new ListView();
                PatientListView.ItemsSource = db.Table<Patient>().OrderBy(x => x.Name).ToList();
                PatientListView.ItemSelected += listView_ItemSelected;
                PatientListView.BackgroundColor = Color.White;
                stackLayout.Children.Add(PatientListView);
            }
            
            Content = new ScrollView { Content = stackLayout };
        }

        private void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            patient = (Patient)e.SelectedItem;
            Navigation.PushAsync(new PatientInfoPage(patient));
        }

        private void OnTextChanged(object sender, EventArgs e)
        {
            //SearchBar searchBar = (SearchBar)sender;
            //listView.ItemsSource = PatientList.FindByName(searchBar.Text);
        }
    }
}
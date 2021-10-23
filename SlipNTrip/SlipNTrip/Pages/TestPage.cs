using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using SQLite;
using Xamarin.Forms;

namespace SlipNTrip
{
    public class TestPage : ContentPage
    {
        string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "testResults.db3");

        private Patient patient;
        private TestResults testResults = new TestResults();
        private Button newTest;
        private ListView testResultsListView;
        
        public TestPage(Patient patient)
        {
            var db = new SQLiteConnection(dbPath);

            this.patient = patient;
            this.Title = "Test";

            StackLayout stackLayout = new StackLayout();

            newTest = new Button();
            newTest.Text = "New Test";
            newTest.Clicked += newTestButtonClicked;
            stackLayout.Children.Add(newTest);

            var tableInfo = db.GetTableInfo("TestResults");
            if(tableInfo.Count > 0)
            {
                testResultsListView = new ListView();
                testResultsListView.ItemsSource = db.Table<TestResults>().Where(x => x.PatientID == patient.ID).ToList();
                testResultsListView.ItemSelected += listView_ItemSelected;
                stackLayout.Children.Add(testResultsListView);
            }
            Content = stackLayout;
        }

        async void newTestButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DeviceControlsPage(patient));
        }

        private void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            testResults = (TestResults)e.SelectedItem;
            Navigation.PushAsync(new Pages.TestResultPage(patient, testResults, true));
        }
    }
}
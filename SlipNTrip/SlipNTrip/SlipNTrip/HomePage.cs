using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace SlipNTrip
{
    public class HomePage : ContentPage
    {
        private Button addPatient;
        private Button existingPatients;
        private Button deviceControls;

        public HomePage()
        {
            StackLayout stackLayout = new StackLayout();
            this.Title = "Slip N Trip App";

            addPatient = new Button();
            addPatient.Text = "Add Patient";
            addPatient.Clicked += OnAddPatientButtonClicked;
            stackLayout.Children.Add(addPatient);

            existingPatients = new Button();
            existingPatients.Text = "Existing Patient";
            existingPatients.Clicked += OnExistingPatientsButtonClicked;
            stackLayout.Children.Add(existingPatients);

            deviceControls = new Button();
            deviceControls.Text = "Device Controls";
            //deviceControls.Clicked += OnDeviceControlsButtonClicked;
            stackLayout.Children.Add(deviceControls);

            Content = stackLayout;

        }

        async void OnAddPatientButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddPatient());
        }

        async void OnExistingPatientsButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ExistingPatient());
        }
    }
}
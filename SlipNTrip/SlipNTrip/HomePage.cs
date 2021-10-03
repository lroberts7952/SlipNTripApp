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

            /*Label welcomeMessage = new Label();
            welcomeMessage.Text = "Welcome to the Defying Gravity's App for the Slip N Trip Device.\n" +
                "Please Select an Option: \n" +
                "Add Patient: To add a new patient into the system\n" +
                "Existing Patients: To view and select an existing patient in the system\n" +
                "Device Controls: To access the device controls without needing to create a patient profile. " +
                "Used for testing purposes";
            welcomeMessage.FontSize = 24;
            stackLayout.Children.Add(welcomeMessage);*/
            
            addPatient = new Button();
            addPatient.Text = "Add Patient";
            addPatient.Clicked += OnAddPatientButtonClicked;
            stackLayout.Children.Add(addPatient);

            existingPatients = new Button();
            existingPatients.Text = "Existing Patients";
            existingPatients.Clicked += OnExistingPatientsButtonClicked;
            stackLayout.Children.Add(existingPatients);

            deviceControls = new Button();
            deviceControls.Text = "Device Controls";
            deviceControls.Clicked += OnDeviceControlsButtonClicked;
            stackLayout.Children.Add(deviceControls);

            Content = stackLayout;

        }

        async void OnAddPatientButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddPatient());
        }

        async void OnExistingPatientsButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ExistingPatients());
        }

        async void OnDeviceControlsButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DeviceControls());
        }
    }
}
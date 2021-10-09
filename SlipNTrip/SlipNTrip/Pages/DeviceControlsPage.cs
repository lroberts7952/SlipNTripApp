using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace SlipNTrip
{
    public class DeviceControlsPage : ContentPage
    {
        private Label directionLabel;
        private Entry directionEntry;
        private Picker directionPicker;
        private Label distanceLabel;
        private Entry distanceEntry;
        private Picker distancePicker;
        private Label velocityLabel;
        private Entry velocityEntry;
        private Picker velocityPicker;
        private Button runButton;
        private Button returnHome;

        public DeviceControlsPage()
        {
            this.Title = "Device Controls";

            string[] directionInputs = { "Forward", "Backward" };
            string[] distanceInputs = { "3.0", "6.0", "9.0", "12.0", "15.0"};
            string[] velocityInputs = { "15.0", "18.0", "21.0", "24.0", "27.0", "30.0", "33.0", "35.0"};
            
            StackLayout stackLayout = new StackLayout();

            directionLabel = new Label();
            directionLabel.Text = "Direction";
            directionLabel.FontSize = 24;
            stackLayout.Children.Add(directionLabel);
            directionEntry = new Entry();
            stackLayout.Children.Add(directionEntry);
            directionEntry.IsVisible = false;
            directionPicker = new Picker();
            directionPicker.Title = "Direction";
            foreach(string direction in directionInputs)
            {
                directionPicker.Items.Add(direction);
            }
            stackLayout.Children.Add(directionPicker);
            directionPicker.IsVisible = true;

            distanceLabel = new Label();
            distanceLabel.Text = "Distance";
            distanceLabel.FontSize = 24;
            stackLayout.Children.Add(distanceLabel);
            distanceEntry = new Entry();
            stackLayout.Children.Add(distanceEntry);
            distanceEntry.IsVisible = false;
            distancePicker = new Picker();
            distancePicker.Title = "Distance";
            foreach (string distance in distanceInputs)
            {
                distancePicker.Items.Add(distance);
            }
            stackLayout.Children.Add(distancePicker);
            distancePicker.IsVisible = true;

            velocityLabel = new Label();
            velocityLabel.Text = "Distance";
            velocityLabel.FontSize = 24;
            stackLayout.Children.Add(velocityLabel);
            velocityEntry = new Entry();
            stackLayout.Children.Add(velocityEntry);
            velocityEntry.IsVisible = false;
            velocityPicker = new Picker();
            velocityPicker.Title = "Velocity";
            foreach (string velocity in velocityInputs)
            {
                velocityPicker.Items.Add(velocity);
            }
            stackLayout.Children.Add(velocityPicker);
            velocityPicker.IsVisible = true;

            runButton = new Button();
            runButton.Text = "Run";
            runButton.Clicked += runButtonClicked;
            stackLayout.Children.Add(runButton);

            returnHome = new Button();
            returnHome.Text = "Return to Home Page";
            returnHome.Clicked += returnHomeButtonClicked;
            stackLayout.Children.Add(returnHome);

            Content = stackLayout;
        }

        async void runButtonClicked(object sender, EventArgs e)
        {
            if(distanceEntry.IsVisible)
            {
                if (!string.IsNullOrWhiteSpace(directionEntry.Text) && !!string.IsNullOrWhiteSpace(distanceEntry.Text)
                && !string.IsNullOrWhiteSpace(velocityEntry.Text))
                {
                    await Navigation.PushAsync(new Pages.TestResultPage());
                }
                else
                    await DisplayAlert("Device Controls Error", "One or more fields missing information", "Done");
            }
            else
            {
                if (directionPicker.SelectedIndex != -1 && distancePicker.SelectedIndex != -1 && velocityPicker.SelectedIndex != -1)
                {
                    await Navigation.PushAsync(new Pages.TestResultPage());
                }
                else
                    await DisplayAlert("Device Controls Error", "One or more fields missing information", "Done");
            }
        }

        async void returnHomeButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }

    }
}
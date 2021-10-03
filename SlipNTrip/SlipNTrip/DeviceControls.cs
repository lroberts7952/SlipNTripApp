using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace SlipNTrip
{
    public class DeviceControls : ContentPage
    {
        private Button returnHome;
        public DeviceControls()
        {
            this.Title = "Device Controls";

            StackLayout stackLayout = new StackLayout();

            returnHome = new Button();
            returnHome.Text = "Return to Home Page";
            returnHome.Clicked += returnHomeButtonClicked;
            stackLayout.Children.Add(returnHome);

            Content = stackLayout;
        }

        async void returnHomeButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }
    }
}
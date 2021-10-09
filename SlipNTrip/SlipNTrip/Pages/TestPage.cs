using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace SlipNTrip
{
    public class TestPage : ContentPage
    {
        private Button newTest;

        public TestPage()
        {
            this.Title = "Test";

            StackLayout stackLayout = new StackLayout();

            newTest = new Button();
            newTest.Text = "New Test";
            newTest.Clicked += newTestButtonClicked;
            stackLayout.Children.Add(newTest);

            Content = stackLayout;
        }

        async void newTestButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DeviceControlsPage());
        }
    }
}
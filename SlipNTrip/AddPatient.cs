using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace SlipNTrip
{
    public class AddPatient : ContentPage
    {
        private Label nameLabel;
        private Label ageLabel;
        private Label heightLabel;
        private Label weightLabel;
        private Label ShoeSizeLabel;

        private Entry nameEntry;
        private Entry ageEntry;
        private Entry heightEntry;
        private Entry weightEntry;
        private Entry shoeSizeEntry;

        private Button saveButton;
        public AddPatient()
        {
            this.Title = "Add Patient";

            StackLayout stackLayout = new StackLayout();

            nameLabel = new Label();
            nameLabel.Text = "Name";
            nameLabel.FontSize = 24;
            stackLayout.Children.Add(nameLabel);
            nameEntry = new Entry();
            nameEntry.Placeholder = "Jane Doe";
            stackLayout.Children.Add(nameEntry);

            ageLabel = new Label();
            ageLabel.Text = "Age";
            ageLabel.FontSize = 24;
            stackLayout.Children.Add(ageLabel);
            ageEntry = new Entry();
            ageEntry.Placeholder = "23";
            stackLayout.Children.Add(ageEntry);

            heightLabel = new Label();
            heightLabel.Text = "Height (ft.in)";
            heightLabel.FontSize = 24;
            stackLayout.Children.Add(heightLabel);
            heightEntry = new Entry();
            heightEntry.Placeholder = "5.5";
            stackLayout.Children.Add(heightEntry);

            weightLabel = new Label();
            weightLabel.Text = "Weight (lb)";
            weightLabel.FontSize = 24;
            stackLayout.Children.Add(weightLabel);
            weightEntry = new Entry();
            weightEntry.Placeholder = "126";
            stackLayout.Children.Add(weightEntry);

            ShoeSizeLabel = new Label();
            ShoeSizeLabel.Text = "Shoe Size";
            ShoeSizeLabel.FontSize = 24;
            stackLayout.Children.Add(ShoeSizeLabel);
            shoeSizeEntry = new Entry();
            shoeSizeEntry.Placeholder = "7";
            stackLayout.Children.Add(shoeSizeEntry);

            saveButton = new Button();
            saveButton.Text = "Save";
            saveButton.Clicked += OnButtonClicked;
            stackLayout.Children.Add(saveButton);

            Content = stackLayout;

        }

        async void OnButtonClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(nameEntry.Text) && !string.IsNullOrWhiteSpace(ageEntry.Text) && !string.IsNullOrWhiteSpace(heightEntry.Text))
            {
                await App.PatientDatabase.SavePersonAsync(new Patient
                {
                    Name = nameEntry.Text,
                    Age = int.Parse(ageEntry.Text),
                    Height = double.Parse(heightEntry.Text),
                    Weight = double.Parse(weightEntry.Text),
                    ShoeSize = double.Parse(shoeSizeEntry.Text)
                });

                nameEntry.Text = ageEntry.Text = heightEntry.Text = weightEntry.Text = shoeSizeEntry.Text = string.Empty;
                await Navigation.PopAsync();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SlipNTrip
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExistingPatient : ContentPage
    {
        public ExistingPatient()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            collectionView.ItemsSource = await App.PatientDatabase.GetPeopleAsync();
        }
    }
}
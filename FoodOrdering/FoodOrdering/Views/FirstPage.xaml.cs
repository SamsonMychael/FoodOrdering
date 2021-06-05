using FoodOrdering.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodOrdering.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FirstPage : ContentPage
    {
        public FirstPage()
        {
            InitializeComponent();
          //  LabelName.Text = "Welcome" + Preferences.Get("name","Guest") + ",";
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (!Auth.IsOldUser())
            {
                Task.Delay(300);
                Navigation.PushAsync(new LoginPage());
            }
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
        
        

        
    
    
}
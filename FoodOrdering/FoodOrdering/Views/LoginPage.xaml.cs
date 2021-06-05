using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodOrdering.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
           
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
           
        }

        private void Register_Tapped_1(object sender, EventArgs e)
        {
            LoginStackLayout.IsVisible = true;
            RegisterStackLayout.IsVisible = false;
        }

        private void Login_Tapped(object sender, EventArgs e)
        {
            LoginStackLayout.IsVisible = false;
            RegisterStackLayout.IsVisible = true;
        }
    }
}
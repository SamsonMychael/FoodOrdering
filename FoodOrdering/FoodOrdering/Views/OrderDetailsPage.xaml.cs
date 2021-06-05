using FoodOrdering.ViewModel;
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
    public partial class OrderDetailsPage : ContentPage
    {
        TotalCartVM vm;
        public OrderDetailsPage()
        {
            InitializeComponent();
            vm = Resources["vm"] as TotalCartVM;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            vm.ReadCollections1();
        }
    }
}
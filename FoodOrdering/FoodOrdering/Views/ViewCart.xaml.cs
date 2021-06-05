using FoodOrdering.Model;
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
    public partial class ViewCart : ContentPage
    {
        ViewCartVM vm;
        public ViewCart()
        {
            InitializeComponent();
            vm = Resources["vm"] as ViewCartVM;

        }
        public ViewCart(Category selectedItem2)
        {
            InitializeComponent();
            vm = Resources["vm"] as ViewCartVM;
           
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            vm.ReadCollection();
        }
    }
}
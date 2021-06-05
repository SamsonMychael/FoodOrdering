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
    public partial class CartDetailsPage : ContentPage
    {
       CartVM vm;
        public CartDetailsPage()
        {
            InitializeComponent();
          //  vm = Resources["vm"] as CartVM;
        }
        public CartDetailsPage(Category selectedcart1)
        {
            InitializeComponent();
            vm = Resources["vm"] as CartVM;
            vm.Category4 = selectedcart1;
        }
    }
}
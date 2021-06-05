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
    public partial class ProductDetails : ContentPage
    {
        ProductVM vm;
        public ProductDetails()
        {
            InitializeComponent();
            vm = Resources["vm"] as ProductVM;
        }
        public ProductDetails(Category selectedItem1)
        {
            InitializeComponent();
            vm = Resources["vm"] as ProductVM;
            vm.Category2 = selectedItem1;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
         
            Navigation.PushAsync(new FirstPage());
        }
    }
}
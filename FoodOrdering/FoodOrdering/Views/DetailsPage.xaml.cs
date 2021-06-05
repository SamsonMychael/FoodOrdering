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
    public partial class DetailsPage : ContentPage
    {
        DetailVM vm;
        public DetailsPage()
        {
            InitializeComponent();

            vm = Resources["vm"] as DetailVM;
        }
        public DetailsPage(Category selectedItem)
        {
            InitializeComponent();

            vm = Resources["vm"] as DetailVM;
            vm.Category1 = selectedItem;
            
        }
       
    }
}
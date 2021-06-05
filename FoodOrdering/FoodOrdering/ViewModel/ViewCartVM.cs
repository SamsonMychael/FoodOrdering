using FoodOrdering.Model;
using FoodOrdering.ViewModel.Helpers;
using FoodOrdering.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FoodOrdering.ViewModel
{
   public class ViewCartVM : INotifyPropertyChanged
    {
        private ObservableCollection<Category> categories;

        public ObservableCollection<Category> Categories
        {
            get { return categories; }
            set
            {
                categories = value;
                OnPropertyChanged("Categories");
            }
        }
        private int quantity;

        public int Quantity
        {
            get { return quantity; }
            set {
                quantity = value;
                OnPropertyChanged("Quantity");
            }
        }
        private int productId;

        public int ProductId
        {
            get { return productId; }
            set
            {
                productId = value;
             
                OnPropertyChanged("ProductId");
                
            }
        }
        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
              
                OnPropertyChanged("Name");
             
            }
        }
        private int price;

        public int Price
        {
            get { return price; }
            set {
                price = value;
                OnPropertyChanged("Price");
            }
        }
        private double  totalCost;

        public double  TotalCost
        {
            get { return totalCost; }
            set {
                totalCost = value;
              
                OnPropertyChanged("TotalCost");
            }
        }
       
        private int cost;

        public int Cost
        {
            get { return cost; }
            set
            {
                cost = value;

                OnPropertyChanged("Cost");
               
            }
        }

        private Category selectedcart1;

        public Category SelectedCart1
        {
            get { return selectedcart1; }
            set
            {
                selectedcart1 = value;
                OnPropertyChanged("SelectedCart");
                if (SelectedCart1 != null)
                {
                    App.Current.MainPage.Navigation.PushAsync(new CartDetailsPage(selectedcart1));

                }
               
            }
        }
     
        public ICommand OrderCommand { get; set; }
        public ViewCartVM()
        {
            Categories = new ObservableCollection<Category>();
            OrderCommand = new Command(PlaceOrder);
        }

        private async void PlaceOrder(object obj)
        {
            
                bool results = await App.Current.MainPage.DisplayAlert("", "Want to Place your Order?", "Yes", "No");
                if (results)
                {
                    await App.Current.MainPage.DisplayAlert("Success", "Ordered Successfully Please check your orders", "Ok");
                    await App.Current.MainPage.Navigation.PushAsync(new FirstPage());
                }
                else
                {
                    return;
                }
            
          
        }

        public async void ReadCollection()
        {
            var category = await DataBaseHelpers.ReadDate();
            categories.Clear();
           
            foreach(var s in category)
            {
                
                categories.Add(s);
                TotalCost += (s.Price * s.Quantity);
              
              }
        }



        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}

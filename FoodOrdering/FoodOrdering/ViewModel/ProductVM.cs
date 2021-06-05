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
    public class ProductVM : INotifyPropertyChanged
    {
        

        private Category category2;

        public Category Category2
        {
            get { return category2; }
            set
            {
                category2 = value;
                Name = Category2.Name;
                ProductId = Category2.ProductId;
                Price = Category2.Price;
                Description = Category2.Description;
                rating = Category2.Rating;
                Image1 = Category2.Image1;
                TotalCost = Category2.TotalCost;
                OnPropertyChanged("Category2");

            }
        }
        private int price;

        public int Price
        {
            get { return price; }
            set
            {
                price = value;
                category2.Price = price; 
                OnPropertyChanged("Price");
                OnPropertyChanged("Category2");
            }
        }
        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                category2.Name = name;
                OnPropertyChanged("Name");
                OnPropertyChanged("Category2");
            }
        }
        

        private string image1;

        public string Image1
        {
            get { return image1; }
            set
            {
                image1 = value;
                category2.Image1 = image1;
                OnPropertyChanged("Image1");
                OnPropertyChanged("Category2");
            }
        }

        private int productId;

        public int ProductId
        {
            get { return productId; }
            set
            {
                productId = value;
                category2.ProductId = productId;
                OnPropertyChanged("ProductId");
                OnPropertyChanged("Category2");
            }
        }
       
        private string description;

        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                category2.Description = description;
                OnPropertyChanged("Description");
                OnPropertyChanged("Category2");
            }
        }
        private string rating;

        public string Rating
        {
            get { return rating; }
            set
            {
                rating = value;
                category2.Rating = rating;
                OnPropertyChanged("Rating");
                OnPropertyChanged("Category2");
            }
        }
        private int quantity;

        public int Quantity
        {
            get 
            {
                return quantity;
              
            }
            set
            {
                quantity = value;
                if (quantity < 0)
                    quantity = 0;
                if (quantity > 10)
                    quantity -= 1;
                OnPropertyChanged("Quantity");
                OnPropertyChanged("Category2");
            }

        }

        private int cost;

        public int Cost
        {
            get { return cost; }
            set {
                cost = value;
              
                OnPropertyChanged("Cost");
                OnPropertyChanged("Category2");
            }
        }
        private double totalCost;

        public double TotalCost
        {
            get { return totalCost; }
            set
            {
                totalCost = value;

                OnPropertyChanged("TotalCost");
                OnPropertyChanged("Category2");
            }
        }

        private Category seletedItem2;

        public Category SelectedItem2
        {
            get { return seletedItem2; }
            set {
                seletedItem2 = value;
                OnPropertyChanged("SelectedItem2");
                OnPropertyChanged("Category2");
            }
        }

        public ICommand SubCommand { get; set; }
        public ICommand AddCommand { get; set; }

        public ICommand CartCommand { get; set; }

        public ICommand ViewCommand { get; set; }

        public ProductVM()
        {
            SubCommand = new Command(Decrement);
            AddCommand = new Command(Increment);
            CartCommand = new Command(CartItem,CartCanExecute);
            ViewCommand = new Command(ViewItem);
        }

      
        private void ViewItem(object obj)
        {
            if (quantity != 0)
            {
                App.Current.MainPage.Navigation.PushAsync(new ViewCart(seletedItem2));
            }
            else
                App.Current.MainPage.DisplayAlert("Alert", "Please selected the Quantity", "Ok");
        }

        private bool CartCanExecute(object arg)
        {
           if(quantity != 0)
            {
                return true;
            }
           else
            {
                return false;
            }
        }

        private  void CartItem(object obj)
        {

            bool results = DataBaseHelpers.InsertData(new Category
            {
                UserId = Auth.IsCurrentUser(),
                ProductId = ProductId,
                Name = Name,
                Price = Price,
                Description = Description,
                Rating = Rating,
                Image1 = Image1,
                Cost = Price * Quantity,
                Quantity = Quantity,
            
              



            }) ;
            if(results)
            {
                App.Current.MainPage.DisplayAlert("Success", "Items added to the cart", "Ok");
            }
            else
            {
                App.Current.MainPage.DisplayAlert("Error", "Please Select the quantity first", "Ok");
            }
               
            
          
        }

        private void Increment(object obj)
        {
            Quantity++;
           
        }

        private void Decrement(object obj)
        {
            Quantity--;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

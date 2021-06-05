using FoodOrdering.Model;
using FoodOrdering.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FoodOrdering.ViewModel
{
    public class CartVM : INotifyPropertyChanged
    {
        
        private Category category4;

        public Category Category4
        {
            get { return category4; }
            set {
                category4 = value;
                Quantity = Category4.Quantity;
                Name = Category4.Name;
                Description = Category4.Description;
                ProductId = Category4.ProductId;
                Price = Category4.Price;
               
                OnPropertyChanged("Category4");
            }
        }
        private int quantity;

        public int Quantity
        {
            get { return quantity; }
            set
            {
                quantity = value;
                category4.Quantity = quantity;
                OnPropertyChanged("Quantity");
                OnPropertyChanged("Category4");

            }
        }
        private int productId;

        public int ProductId
        {
            get { return productId; }
            set
            {
                productId = value;
                Category4.ProductId = productId;
                OnPropertyChanged("ProductId");
                OnPropertyChanged("Category4");

            }
        }
        private int price;

        public int Price
        {
            get { return price; }
            set
            {
                price = value;
                Category4.Price = price;
                OnPropertyChanged("Price");
                OnPropertyChanged("Category4");

            }
        }
        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                Category4.Name = name;
                OnPropertyChanged("Name");
                OnPropertyChanged("Category4");

            }
        }
        private string description;

        public string Description
        {
            get { return description; }
            set
            {
                description = value;
               Category4.Description = description;
                OnPropertyChanged("Description");
               OnPropertyChanged("Category4");

            }
        }
        

      


       // public ICommand SubCommand1 { get; set; }
       // public ICommand AddCommand1 { get; set; }

        public ICommand UpdateCommand { get; set; }

        public ICommand DeleteCommand { get; set; }

        public CartVM()
        {
            //SubCommand1 = new Command(Decrement);
          //  AddCommand1 = new Command(Increment);
            UpdateCommand = new Command(Update );
            DeleteCommand = new Command(Delete);
        }
        /* private bool Updatecanexecute(object arg)
         {
             if (quantity != 0)
             {
                 return true;
             }
             else
                 return false;
         }*/
       

        private async void Update(object obj)
        {
            bool result = DataBaseHelpers.UpdateData(Category4);

            if (result)
            {
                await App.Current.MainPage.DisplayAlert("Alert", "Do you want to update the Item", "Yes", "No");
                await App.Current.MainPage.Navigation.PopAsync();
            }
            else
                return;
            
        }

        private async void Delete(object obj)
        {
            bool results = await DataBaseHelpers.DeleteData(Category4);
            if (results)
            {
                await App.Current.MainPage.DisplayAlert("Alert", "Do you want to delete this item", "Yes", "No");
                await App.Current.MainPage.Navigation.PopAsync();
            }
            else
                return;
        }

      /*  private void Increment(object obj)
        {
            Quantity++;

        }

        private void Decrement(object obj)
        {
            Quantity--;
        }*/
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

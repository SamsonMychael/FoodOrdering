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
using Category = FoodOrdering.Model.Category;

namespace FoodOrdering.ViewModel
{
   public class FoodVM : INotifyPropertyChanged
    {
     

        private ObservableCollection<Category> categories;

        public ObservableCollection<Category> Categories
        {
            get { return categories; }
            set { 
                categories = value;
                OnPropertyChanged("Categories");
            }
        }

        private Category selectedItem;

        public Category SelectedItem
        {
            get { return selectedItem; }
            set {
                selectedItem = value;
                
                OnPropertyChanged("SelectedItem");
                

            }
        }



        public ICommand NextCommand { get; set; }
        public ICommand TotalCartCommand { get; set; }
        public ICommand SignOutCommand { get; set; }
        public FoodVM()
        {
            NextCommand = new Command(Next);
            categories = GetCategory();
            SignOutCommand = new Command(SignOut);
            TotalCartCommand = new Command(TotalCart);
        }

        private void TotalCart(object obj)
        {
            try
            {
                App.Current.MainPage.Navigation.PushAsync(new OrderDetailsPage());
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private async void SignOut(object obj)
        {
            bool results = await App.Current.MainPage.DisplayAlert("", "Do you want to logout ?", "Yes", "No");
            if(results)
            {
                Auth.LogOut();
               await App.Current.MainPage.Navigation.PushAsync(new LoginPage());
            }
        }

        private void Next(object obj)
        {
            if (selectedItem != null)
            {
                App.Current.MainPage.Navigation.PushAsync(new DetailsPage(selectedItem));
            }

        }

        public ObservableCollection<Category> GetCategory()
        {

            return new ObservableCollection<Category>()
            {
                new Category(){
                    CategoryId = 1,
                    CategoryName = "Burger",
                    CategoryPoster = "vegmain.jpg",
                    Image = "burger.jpg",
                    ProductId = 1,
                    
                    Image1 ="burgersand.jpg",
                    Name="Burger Hub",
                    Description= "Burger - Pizza - BreakFast",
                    Rating="4.8",
                    RatingDetails= "(113 ratings)",
                    Price = 69,
                },
                new Category(){
                    CategoryId = 2 ,
                    CategoryName = "Pizza",
                    CategoryPoster = "piz.jpg",
                    Image = "pizza.png",
                     ProductId = 2,
                     
                    Image1 ="pizzaaa.jpg",
                    Name="Pizza Hub",
                    Description= "Coke - Pizza - BreakFast",
                    Rating="4.3",
                    RatingDetails= "(143 ratings)",
                    Price = 199,
                },
                new Category(){
                    CategoryId = 3 ,
                    CategoryName = "Deserts",
                    CategoryPoster = "des.jpg",
                    Image = "deserts.png",
                     ProductId =3,
                    
                    Image1 ="vegmain.jpg",
                    Name="Deserts Hub",
                    Description= "Deserts - Pizza - BreakFast",
                    Rating="4.6",
                    RatingDetails= "(126 ratings)",
                    Price = 59,
                },
                new Category(){
                    CategoryId = 4 ,
                    CategoryName = "Veg Burger",
                    CategoryPoster = "veg.jpg",
                    Image = "vegburger.png",
                     ProductId = 4,
                   
                     Image1 = "burr.jpg",
                    Name=" VegBurger Hub",
                    Description= "Veg -Burger - Pizza - BreakFast",
                    Rating="4.7",
                    RatingDetails= "(117 ratings)",
                    Price = 79,
                },
                new Category(){
                    CategoryId = 5 ,
                    CategoryName = "Sandwich",
                    CategoryPoster = "san.jpg",
                    Image = "sandwich.png",
                     ProductId = 5,
                     
                    Image1 ="sann.jpg",
                    Name="Sand Wich Hub",
                    Description= "Veg- Pizza - BreakFast",
                    Rating="3.8",
                    RatingDetails= "(146 ratings)",
                    Price = 149,
                },
                new Category(){
                    CategoryId = 6 ,
                    CategoryName = " Veg Pizza",
                    CategoryPoster = "vegpiz",
                    Image = "pizza.png",
                    ProductId = 6,
                    
                    Image1 ="vegmain.jpg",
                    Name="Cokes",
                    Description= "Cokes -Cakes - BreakFast",
                    Rating="4.8",
                    RatingDetails= "(156 ratings)",
                    Price = 99,
                }
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

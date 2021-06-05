using FoodOrdering.Model;
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
   public class DetailVM : INotifyPropertyChanged
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
        private Category category1;

        public event PropertyChangedEventHandler PropertyChanged;

        public Category Category1
        {
            get { return category1; }
            set {
                category1 = value;
                CategoryPoster = Category1.CategoryPoster;
                Name = Category1.Name;
                CategoryName = Category1.CategoryName;
                Image1 = Category1.Image1;
                Description = Category1.Description;
                Rating = Category1.Rating;
                Price = Category1.Price;
                ProductId = category1.ProductId;
                RatingDetails = Category1.RatingDetails;
               
                OnPropertyChanged("Category1");
            }
        }
        private int productId;

        public int ProductId
        {
            get { return productId; }
            set
            {
                productId = value;
                Category1.ProductId = productId;
                OnPropertyChanged("ProductId");
                OnPropertyChanged("Category1");

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

        private string categoryPoster;

        public string CategoryPoster
        {
            get { return categoryPoster; }
            set { 
                categoryPoster = value;
                Category1.CategoryPoster = categoryPoster;
                OnPropertyChanged("CategoryPoster");
             
            }
        }

        private string image1;

        public string Image1
        {
            get { return image1; }
            set {
                image1 = value;
                Category1.Image1 = image1;
                OnPropertyChanged("Image1");
               
            }
        }


        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                Category1.Name = name;
                OnPropertyChanged("Name");
              

            }
        }


        private string description;

        public string Description
        {
            get { return description; }
            set { 
                description = value;
                Category1.Description = description;
                OnPropertyChanged("Description");
               
            }
        }

        private string rating;

        public string Rating
        {
            get { return rating; }
            set { 
                rating = value;
                Category1.Rating = rating;
                OnPropertyChanged("Rating");
              
            }
        }


        private string ratingDetails;

        public string RatingDetails
        {
            get { return ratingDetails; }
            set { 
                ratingDetails = value;
                Category1.RatingDetails = ratingDetails;
                OnPropertyChanged("RatingDetails");
              
            }
        }
        private string categoryName;

        public string CategoryName
        {
            get { return categoryName; }
            set { 
                categoryName = value;
                category1.CategoryName = categoryName;
                OnPropertyChanged("CategoryName");
               
            }
        }



        public ICommand DetailCommand { get; set; }
        public DetailVM()
        {
           Categories = GetCategories();
            DetailCommand = new Command(DetailNext);
        }

        private ObservableCollection<Category> GetCategories()
        {
            return new ObservableCollection<Category>()
            {
                 new Category(){
                 CategoryName="Burger",
                 ProductId =1,
                    CategoryPoster = "vegmain.jpg",
                    Image1 ="shark.png",
                    Name="Burger",
                    Description= "Burger - Pizza - BreakFast",
                    Rating="4.8",
                   Price = 69,
                    RatingDetails= "(113 ratings)",
                  
                },
                new Category(){
                   
                    CategoryName = "Pizza",
                    CategoryPoster = "piz.jpg",
                    Image1 ="pizzaveg.jpg",
                    Name="Pizza",
                     ProductId =2,
                      Price = 199,
                    Description= "Coke - Pizza - BreakFast",
                    Rating="4.3",
                    RatingDetails= "(143 ratings)"
                   
                },
                new Category(){
                   
                    CategoryName = "Deserts",
                    CategoryPoster = "des.jpg",
                    Image1 ="des.jpg",
                    Name="Deserts",
                  Price = 99,
                   ProductId =3,
                    Description= "Deserts - Pizza - BreakFast",
                    Rating="4.6",
                    RatingDetails= "(126 ratings)"
                   
                },
                new Category(){
                 
                    CategoryName = "Veg Burger",
                    CategoryPoster = "veg.jpg",
                     Image1 = "two.png",
                  Price = 149,
                   ProductId =4,
                    Name=" VegBurger",
                    Description= "Veg -Burger - Pizza - BreakFast",
                    Rating="4.7",
                    RatingDetails= "(117 ratings)"
                  
                },
                new Category(){
                  
                    CategoryName = "Sandwich",
                    CategoryPoster = "san.jpg",
                     Price = 169,
                      ProductId =5,
                    Image1 ="burgermain.jpg",
                    Name="Sand Wich ",
                    Description= "Veg- Pizza - BreakFast",
                   
                    Rating="3.8",
                    RatingDetails= "(146 ratings)"
                   
                },
                new Category(){
                  
                    CategoryName = " Veg Pizza",
                    CategoryPoster = "vegpiz",
                    Image1 ="vegmain.jpg",
                    Name="Cokes",
                     ProductId =6,
                    Price = 79,
                    Description= "Cokes -Cakes - BreakFast",
                    Rating="4.8",
                    RatingDetails= "(156 ratings)"
                   
                }
            };
        }
        private Category selectedItem1;

        public Category SelectedItem1
        {
            get { return selectedItem1; }
            set { 
                selectedItem1 = value;
                OnPropertyChanged("SelectedItem");
            }
        }


        private void DetailNext(object obj)
        {
           
                App.Current.MainPage.Navigation.PushAsync(new ProductDetails(selectedItem1));
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

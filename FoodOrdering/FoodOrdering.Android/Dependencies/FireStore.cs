using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using FoodOrdering.Model;
using Java.Util;
using FoodOrdering.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Android.Gms.Tasks;
using Firebase.Firestore;

[assembly : Dependency(typeof(FoodOrdering.Droid.Dependencies.FireStore))]
namespace FoodOrdering.Droid.Dependencies
{
    class FireStore : Java.Lang.Object, IFireStore , IOnCompleteListener
    {
        List<Category> categories;
        bool hasreadvalue = false;

        public FireStore()
        {
            categories = new List<Category>();
        }

        public async Task<bool> DeleteData(Category category)
        {
            try
            {
                var collection = Firebase.Firestore.FirebaseFirestore.Instance.Collection("Subscription");
                collection.Document(category.Id).Delete();
                return true;
            }

            catch (Exception ex)
            {
                return false;
            }
        }


        public  bool InsertData(Category category)
        {
            try
            {
                var collection = Firebase.Firestore.FirebaseFirestore.Instance.Collection("Subscription");
                var document = new JavaDictionary<string, Java.Lang.Object>
            {
                    {"author" , Firebase.Auth.FirebaseAuth.Instance.CurrentUser.Uid },
             //  {"categoryId" , category.CategoryId },
              //  {"categoryName" , category.CategoryName },
               // {"categoryPoster", category.CategoryPoster },
              //  {"Image" , category.Image },
                {"productId" ,category.ProductId },
                {"image1",category.Image1 },
                {"name", category.Name },
                    {"quantity",category.Quantity },
                {"description",category.Description },
                {"rating",category.Rating },
              //  {"ratingDetails",category.RatingDetails },
                {"price",category.Price },
                   {"totalCost",category.TotalCost },
                    {"cost",category.Cost }
            };
                collection.Add(document);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void OnComplete(Android.Gms.Tasks.Task task)
        {
            if (task.IsSuccessful)
            {
                var doucment = (QuerySnapshot)task.Result;
                categories.Clear();
                foreach(var doc in doucment.Documents)
                {
                    var cate = new Category
                    {
                        ProductId = (int)doc.Get("productId"),
                        Image1 = doc.Get("image1").ToString(),
                        UserId = doc.Get("author").ToString(),
                        Name = doc.Get("name").ToString(),
                        Quantity = (int)doc.Get("quantity"),
                        Description = doc.Get("description").ToString(),
                        Rating = doc.Get("rating").ToString(),
                        Price = (int)doc.Get("price"),
                       // CategoryName = doc.Get("categoryName").ToString(),
                        Cost = (int)doc.Get("cost"),
                       TotalCost = (double)doc.Get("totalCost"),
                        Id =doc.Id
                    };
                    categories.Add(cate);
                }
                hasreadvalue = true;
            }
            else
            {
                App.Current.MainPage.DisplayAlert("Error", "Something went wrong, please try again", "Okay");
            }
        }

        public async  Task<IList<Category>> ReadDate()
        {
            try
            {
                hasreadvalue = false;
                var collection = Firebase.Firestore.FirebaseFirestore.Instance.Collection("Subscription");
                var query = collection.WhereEqualTo("author", Firebase.Auth.FirebaseAuth.Instance.CurrentUser.Uid);
                query.Get().AddOnCompleteListener(this);
                for (int i = 0; i < 25; i++)
                {
                    await System.Threading.Tasks.Task.Delay(100);
                    if (hasreadvalue == true)
                        break;
                }
                return categories;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool UpdateData(Category category)
        {
            try { 
            var collection = Firebase.Firestore.FirebaseFirestore.Instance.Collection("Subscription");
            collection.Document(category.Id).Update("quantity", category.Quantity, "Price",category.Price,"totalCost",category.TotalCost);
            return true;
        }
              catch (Exception ex)
            {
                return false;
            }
        }
    }
}
using FoodOrdering.Model;
using FoodOrdering.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace FoodOrdering.ViewModel
{
    public class TotalCartVM : INotifyPropertyChanged
    {
        private ObservableCollection<Category> categories;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Category> Categories
        {
            get { return categories; }
            set
            {
                categories = value;
                OnPropertyChanged("Categories");
            }
        }

        private double totalCost;

        public double TotalCost
        {
            get { return totalCost; }
            set {
                totalCost = value;
                OnPropertyChanged("TotalCost");
            }
        }

        public TotalCartVM()
        {
            Categories = new ObservableCollection<Category>();
            
        }
        public async void ReadCollections1()
        {
            var category = await DataBaseHelpers.ReadDate();
               
            categories.Clear();

            foreach (var s in category)
            {

                categories.Add(s);
                TotalCost += (s.Price * s.Quantity);
                

            }
        }
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}

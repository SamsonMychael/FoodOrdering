using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace FoodOrdering.Model
{
    public class Category
    {
        public string UserId { get; set; }

        public string Id { get; set; }
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public int Quantity { get; set; }

        public string CategoryPoster { get; set; }

        public string Image { get; set; }


        public int ProductId { get; set; }

       

        public string Image1 { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        public string Rating { get; set; }
        public string RatingDetails { get; set; }

        public int Cost { get; set; }
        public double TotalCost { get; set; }
        public int Price { get; set; }
        

    }
}

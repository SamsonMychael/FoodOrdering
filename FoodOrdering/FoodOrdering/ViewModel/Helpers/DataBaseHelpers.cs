using FoodOrdering.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FoodOrdering.ViewModel.Helpers
{
    public interface IFireStore
    {
       bool InsertData(Category category);

        Task<bool> DeleteData(Category category);
        bool UpdateData(Category category);
        Task<IList<Category>> ReadDate();

    }
    public class DataBaseHelpers  
    {

        private static IFireStore firestore = DependencyService.Get<IFireStore>();

        public static bool InsertData(Category category)
        {
            try
            {
                return firestore.InsertData(category);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        
        public static Task<IList<Category>> ReadDate()
        {
            return firestore.ReadDate();
        }

        public static Task<bool> DeleteData(Category category)
        {
            return firestore.DeleteData(category);
        }

      
        public static bool UpdateData(Category category)
        {
            return firestore.UpdateData(category);
        }
    }
}

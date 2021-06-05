using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FoodOrdering.ViewModel.Helpers
{
    public interface IAuth
    {
        Task<bool> RegisterSection(string name, string email, string password);

        Task<bool> LoginSection(string email, string password);

        bool IsOldUser();

        string IsCurrentUser();

        bool LogOut();

        
    }
    public class Auth 
    {

        private static IAuth auth = DependencyService.Get<IAuth>();

        public Auth()
        {
        }

        public static string IsCurrentUser()
        {
            return auth.IsCurrentUser();
        }

        public static bool IsOldUser()
        {
            return auth.IsOldUser();
        }

        public static bool LogOut()
        {
            return auth.LogOut();
        }

        public static Task<bool> LoginSection(string email, string password)
        {
            return auth.LoginSection(email,password);
        }

        public static Task<bool> RegisterSection(string name ,string email, string password)
        {
            return auth.RegisterSection(name,email,password);
        }
    }
}

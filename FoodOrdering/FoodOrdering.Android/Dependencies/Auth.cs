using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using FoodOrdering.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly : Dependency(typeof(FoodOrdering.Droid.Dependencies.Auth))]
namespace FoodOrdering.Droid.Dependencies
{
    public class Auth : IAuth
    {
        public string IsCurrentUser()
        {
            return Firebase.Auth.FirebaseAuth.Instance.Uid;
        }

        public bool IsOldUser()
        {
            return Firebase.Auth.FirebaseAuth.Instance.CurrentUser != null;
        }

        public async Task<bool> LoginSection(string email, string password)
        {
            try
            {
                await Firebase.Auth.FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(email, password);

                return true;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
        }
        public  bool LogOut()
        {
            try
            {
                Firebase.Auth.FirebaseAuth.Instance.SignOut();
                return true;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> RegisterSection(string name, string email, string password)
        {
            try
            {
                await Firebase.Auth.FirebaseAuth.Instance.CreateUserWithEmailAndPasswordAsync(email, password);
                var profileupdates = new Firebase.Auth.UserProfileChangeRequest.Builder();
                profileupdates.SetDisplayName(name);
                var build = profileupdates.Build();
                var user = Firebase.Auth.FirebaseAuth.Instance.CurrentUser;
                await user.UpdateProfileAsync(build);

                return true;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
        }
    }
}
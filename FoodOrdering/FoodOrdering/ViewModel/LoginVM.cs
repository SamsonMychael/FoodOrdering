using FoodOrdering.ViewModel.Helpers;
using FoodOrdering.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FoodOrdering.ViewModel
{
   public class LoginVM : INotifyPropertyChanged
    {
        private string name;

        public string Name
        {
            get { return name; }
            set {
                name = value;
               
                OnPropertyChanged("Name");
                OnPropertyChanged("Login");
                OnPropertyChanged("Register");
            }
        }
        private string email;

        public string Email
        {
            get { return email; }
            set {
                email = value;
                OnPropertyChanged("Email");
                OnPropertyChanged("Login");
                OnPropertyChanged("Register");
            }
        }
        private string password;

        public string Password
        {
            get { return password; }
            set {
                password = value;
                OnPropertyChanged("Password");
                OnPropertyChanged("Login");
                OnPropertyChanged("Register");

            }
        }
        private string confirmpassword;

        public event PropertyChangedEventHandler PropertyChanged;

        public string ConfirmPassword
        {
            get { return confirmpassword; }
            set { 
                confirmpassword = value;
                OnPropertyChanged("ConfirmPassword");
                OnPropertyChanged("Login");
                OnPropertyChanged("Register");
            }
        }
      

        public bool Login
        {
            get
            {
                return !string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Password);

            }
             
        }
        public bool Register
        {
            
            get
            {
                 return !string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Password) && !string.IsNullOrEmpty(ConfirmPassword); 
                   
            }

        }
        public ICommand LoginCommand { get; set; }

        public ICommand RegisterCommand { get; set; }
        public LoginVM()
        {
            LoginCommand = new Command(CanLogin, LogincanExecute);
            RegisterCommand = new Command(CanRegister, RegistercanExecute);
        }

        private async void CanRegister(object obj)
        {
            if (Password != ConfirmPassword)
            {
                await App.Current.MainPage.DisplayAlert("Wrong", "Password does not match", "Ok");
             }
            else
            {
               bool results = await Auth.RegisterSection(Name, Email, Password);
                if(results)
                await App.Current.MainPage.DisplayAlert("Congrats", "Your Email and Password Registered Successfully", "Ok");

            }
            
        }

        private bool RegistercanExecute(object arg)
        {
            return Register;
        }

        private bool LogincanExecute(object arg)
        {
            return Login;
        }

        private async void CanLogin(object obj)
        {
            
              bool results =  await Auth.LoginSection(Email, Password);
            if (results)
                await App.Current.MainPage.Navigation.PushAsync(new FirstPage());
            else
               await App.Current.MainPage.DisplayAlert("Wrong", "SomethingWrong please try again later", "OK");
            
            
        }

        private void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


    }
}

using MvvmCross.Commands;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace OfficeTime.MvxStarter.Core.ViewModel
{
    public class LoginViewModel : MvxViewModel
    {
        
        private string _password;
        private string _email;

        public LoginViewModel()
        {

        }

        public string Email
        {
            get { return _email; }
            set
            {
                SetProperty(ref _email, value);
                RaisePropertyChanged(nameof(CanLogin));
                RaisePropertyChanged(nameof(ValidateEmail));
            }
        }

        public string Password
        {
            get { return _password; }
            set 
            { 
                SetProperty(ref _password, value);
                RaisePropertyChanged(nameof(CanLogin));
            }

        }

        public bool CanLogin => !string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Password);

        public void Login()
        {
            
        }

        public IMvxCommand LoginCommand
        {
            get 
            { 
                return new MvxCommand(Login); 
            }
        }

        public string ValidateEmail
        {
            get
            {
                return Convert.ToBoolean(!Email?.Contains("@")) ? "Please enter a valid email address" : null;
            }
        }
        //validation
        //private int myVar;


    }
}

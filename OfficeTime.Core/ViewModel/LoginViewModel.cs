using MvvmCross.Commands;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace OfficeTime.MvxStarter.Core.ViewModel
{
    public class LoginViewModel : MvxViewModel
    {
        public LoginViewModel()
        {

        }
        private string _username;

        public string Username
        {
            get { return _username; }
            set 
            { 
                SetProperty(ref _username, value);
                RaisePropertyChanged(nameof(CanLogin));
            }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set 
            { 
                SetProperty(ref _password, value);
                RaisePropertyChanged(nameof(CanLogin));
            }

        }

        public bool CanLogin => !string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password);

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


    }
}

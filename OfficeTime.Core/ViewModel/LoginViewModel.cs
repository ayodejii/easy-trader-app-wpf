using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using OfficeTime.MvxStarter.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace OfficeTime.MvxStarter.Core.ViewModel
{
    public class LoginViewModel : MvxViewModel
    {
        
        private string _password;
        private string _email;
        private readonly IMvxNavigationService navigationService;
        private readonly IDialogService dialogService;

        public LoginViewModel(IMvxNavigationService navigationService)
        {
            this.navigationService = navigationService;
            //this.dialogService = dialogService;
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
            if (Email == "admin@email.com" && Password == "admin")
                navigationService.Navigate(new MainViewModel());
            else
                dialogService.ShowMessageBox("bad login");
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

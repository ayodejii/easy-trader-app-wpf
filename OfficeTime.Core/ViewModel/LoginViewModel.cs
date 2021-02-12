using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace OfficeTime.MvxStarter.Core.ViewModel
{
    public class LoginViewModel : MvxViewModel
    {
        private string _username;

        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        void Login()
        {
            
        }

    }
}

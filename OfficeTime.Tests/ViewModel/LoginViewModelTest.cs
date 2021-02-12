using OfficeTime.MvxStarter.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace OfficeTime.Tests.ViewModel
{
    public class LoginViewModelTest
    {
        [Fact]
        public void CanLogin_WhenEmailAndPasswordEmpty_ShouldReturnFalse()
        {
            //arrange
            var loginViewModel = new LoginViewModel();

            //act
            bool result = loginViewModel.CanLogin;

            //assert
            Assert.False(result);
        }

        [Fact]
        public void CanLogin_WhenEmailOrPasswordEmpty_ShouldReturnFalse()
        {
            //arrange
            var loginViewModel = new LoginViewModel();
            loginViewModel.Username = "test";
            loginViewModel.Password = null;

            //act
            bool result = loginViewModel.CanLogin;

            //assert
            Assert.False(result);
        }

        [Fact]
        public void CanLogin_WhenEmailOrPasswordFilled_ShouldReturnTrue()
        {
            //arrange
            var loginViewModel = new LoginViewModel();
            loginViewModel.Username = "test";
            loginViewModel.Password = "password";

            //act
            bool result = loginViewModel.CanLogin;

            //assert
            Assert.True(result);
        }
    }
}

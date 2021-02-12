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
            loginViewModel.Email = "test";
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
            loginViewModel.Email = "test";
            loginViewModel.Password = "password";

            //act
            bool result = loginViewModel.CanLogin;

            //assert
            Assert.True(result);
        }

        [Fact]
        public void CanLogin_WhenEmailIsInvalid_ReturnErrorTest()
        {
            var loginViewModel = new LoginViewModel();
            loginViewModel.Username = "test";

            bool isValid = loginViewModel.Username.Contains("@");

            Assert.False(isValid);

            string expectedResult = "Please enter a valid email address";
            string actualResult = loginViewModel.ValidateEmail;

            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void CanLogin_WhenEmailIsFiveCharOrMore_ReturnnULL()
        {
            var loginViewModel = new LoginViewModel();
            loginViewModel.Username = "fivechar@gmail.com";

            bool isValid = loginViewModel.Username.Contains("@");

            Assert.True(isValid);

            string actualResult = loginViewModel.ValidateEmail;

            Assert.Null(actualResult);
        }
    }
}

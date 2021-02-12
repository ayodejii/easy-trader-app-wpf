using OfficeTime.MvxStarter.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using MvvmCross.Navigation;

namespace OfficeTime.Tests.ViewModel
{
    public class LoginViewModelTest
    {
        private Mock<IMvxNavigationService> notificationService;

        public LoginViewModelTest()
        {
            notificationService = new Mock<IMvxNavigationService>();
        }
        [Fact]
        public void CanLogin_WhenEmailAndPasswordEmpty_ShouldReturnFalse()
        {
            //arrange
            var loginViewModel = new LoginViewModel(notificationService.Object);

            //act
            bool result = loginViewModel.CanLogin;

            //assert
            Assert.False(result);
        }

        [Fact]
        public void CanLogin_WhenEmailOrPasswordEmpty_ShouldReturnFalse()
        {
            //arrange
            var loginViewModel = new LoginViewModel(notificationService.Object);
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
            var loginViewModel = new LoginViewModel(notificationService.Object);
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
            var loginViewModel = new LoginViewModel(notificationService.Object);
            loginViewModel.Email = "test";

            bool isValid = loginViewModel.Email.Contains("@");

            Assert.False(isValid);

            string expectedResult = "Please enter a valid email address";
            string actualResult = loginViewModel.ValidateEmail;

            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void CanLogin_WhenEmailIsFiveCharOrMore_ReturnnULL()
        {
            var loginViewModel = new LoginViewModel(notificationService.Object);
            loginViewModel.Email = "fivechar@gmail.com";

            bool isValid = loginViewModel.Email.Contains("@");

            Assert.True(isValid);

            string actualResult = loginViewModel.ValidateEmail;

            Assert.Null(actualResult);
        }
    }
}

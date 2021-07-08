using System;
using Xunit;
using ShopStore;
using ShopDbContext.Models;

namespace ShopStore.Test
{

    
    public class MocWelcomePage : WelcomePage
    {
        [Fact]
        public void LogIngTest()
        {
            //Arrange
            string a ="Qais";
            string b = "Qaisi";
            LogingIn LogIn = new LogingIn( a, b);

            //Act
            int result =LogIn.UserPK;

            //Assert
            Assert.Equal(1, result);

        }
    }
}

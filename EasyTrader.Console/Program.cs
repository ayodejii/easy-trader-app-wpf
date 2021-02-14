using EasyTrader.Domain.Models;
using EasyTrader.Domain.Services;
using EasyTrader.EntityFramework;
using EasyTrader.EntityFramework.Services;
using System;

namespace EasyTrader.Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            IDataService<User> userService = new GenericDataService<User>(new EasyTraderDbContextFactory());

            //var users = userService.Update(1, new User { Username = "username", Email = "email" }).Result;
            var user = userService.Delete(1).Result;
            //userService.Add(new User { Username = "test" }).Wait();
        }
    }
}

using PRSLibrary.Controllers;
using PRSLibrary.Models;
using System;

namespace TestPRSLibrary {
    class Program {

        public static void Main(string[] args) {


            var context = new PrsDbContext();

            var userCtrl = new UsersController(context);
            //this creates a new user
            var newUser = new User() {
                Id = 0, Username = "zz", Password = "xx",
                Firstname = "User", Lastname = "zz", Phone = "211", Email = "xx@user.com", 
                IsReviewer = false, IsAdmin = false
            };

                    
            var user3 = userCtrl.GetByPk(3);
            if(user3 is null) {
                Console.WriteLine("User not found!");
            } else {
                Console.WriteLine($"User3: {user3.Firstname} {user3.Lastname}");
            }
            user3.Lastname = "User3";
            userCtrl.Create(newUser);


            userCtrl.Change(user3);


             var user33 = userCtrl.GetByPk(33);
            if (user33 is null) {
                Console.WriteLine("User not found!");
            } else {
                Console.WriteLine($"User33: {user33.Firstname} {user33.Lastname}");
            }

            var users = userCtrl.GetAll(userCtrl);

            foreach(var user in users) {
                Console.WriteLine($"{user.Firstname} {user.Lastname}");

            }
        }
    }
}

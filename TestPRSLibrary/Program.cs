using PRSLibrary.Controllers;
using PRSLibrary.Models;
using System;

namespace TestPRSLibrary {
    class Program {

        static void Print(Product product) {  //created our own method to use over and over...reference to lines 21 and 27
            Console.WriteLine($"{product.Id,-5} {product.PartNbr,-12} {product.Name,-12} {product.Price,10:c} {product.Vendor.Name,-15}");
        }

        public static void Main(string[] args) {

            var context = new PrsDbContext();

            var prodCtrl = new ProductsController(context);

            var products = prodCtrl.GetAll();

            foreach(var p in products) {
                Print(p); 
            }

            var product = prodCtrl.GetByPk(2);

            if(product is not null) {
                Print(product);
            }







            //var userCtrl = new UsersController(context);
            ////this creates a new user
            //var newUser = new User() {
            //    Id = 0, Username = "LT", Password = "xx",
            //    Firstname = "User", Lastname = "thorn", Phone = "211", Email = "xx@user.com", 
            //    IsReviewer = false, IsAdmin = false
            //};

                    
            //var user3 = userCtrl.GetByPk(3);
            //if(user3 is null) {
            //    Console.WriteLine("User not found!");
            //} else {
            //    Console.WriteLine($"User3: {user3.Firstname} {user3.Lastname}");
            //}
            //user3.Lastname = "User3";
            //userCtrl.Create(newUser);


            //userCtrl.Change(user3);


            // var user33 = userCtrl.GetByPk(33);
            //if (user33 is null) {
            //    Console.WriteLine("User not found!");
            //} else {
            //    Console.WriteLine($"User33: {user33.Firstname} {user33.Lastname}");
            //}

            //userCtrl.Remove(5);

            //var users = userCtrl.GetAll(userCtrl);

            //foreach(var user in users) {
            //    Console.WriteLine($"{user.Id} {user.Firstname} {user.Lastname}");

            //}
        }
    }
}

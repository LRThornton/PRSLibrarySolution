using PRSLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRSLibrary.Controllers {
    public class UsersController {

        private readonly PrsDbContext _context;  //this is an internal variable for this class only

        public UsersController(PrsDbContext context) {
            this._context = context;
            
        }
        //this method returns all of the users
        public IEnumerable<User> GetAll(UsersController userCtrl) {
            return _context.Users.ToList();
        }
        //this method lets you pull by primary key
        public User GetByPk(int id) {
            return _context.Users.Find(id);
        }

        public User Create(User user) {
            if(user is null) {
                throw new ArgumentNullException("user");
            }
            if(user.Id !=0) {
                throw new ArgumentException("User.Id must be zero!");
            }
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }
    }
}

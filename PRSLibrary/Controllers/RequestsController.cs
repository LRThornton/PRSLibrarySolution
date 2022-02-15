using Microsoft.EntityFrameworkCore;
using PRSLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRSLibrary.Controllers {

    public class RequestsController {

        private readonly PrsDbContext _context;  //this is an internal variable for this class only

        public RequestsController(PrsDbContext context) {
            this._context = context;
        }
        //this method returns all of the products
        public IEnumerable<Request> GetAll() {
            return _context.Requests.Include(x => x.User).ToList();
        }
        //this method lets you pull by primary key
        public Request GetByPk(int id) {
            return _context.Requests.Include(x => x.User)
                                .SingleOrDefault(x => x.Id == id);
        }
        //this method creates new product
        public Request Create(Request request) {
            if (request is null) {
                throw new ArgumentException("Request");
            }           
            
            _context.Requests.Add(request);
            _context.SaveChanges();
            return request;
        }
        //this method will allow changes to be made to a product
        public void Change(Request user) {
            _context.SaveChanges();
        }
        //this one deletes  // void means it will not return anything
        public void Remove(int id) {
            var Request = _context.Requests.Find(id);
            if (Request is null) {                   
                throw new Exception("Request not found!");
            }
            _context.Requests.Remove(Request);
            _context.SaveChanges();
        }
    }
}

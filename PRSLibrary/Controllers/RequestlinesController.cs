using Microsoft.EntityFrameworkCore;
using PRSLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRSLibrary.Controllers {

    public class RequestlinesController {

        private readonly PrsDbContext _context;  //this is an internal variable for this class only

        public RequestlinesController(PrsDbContext context) {
            this._context = context;
        }
        //this method returns all of the requests
        public IEnumerable<Requestline> GetAll () {
            return _context.Requestlines
                            .Include(x => x.Product)
                            .Include(x => x.Request)
                            .ToList();
        }
        //this method lets you pull by primary key
        public Requestline GetByPk(int id) {
            return _context.Requestlines
                            .Include(x => x.Product)
                            .Include(x => x.Request)
                            .SingleOrDefault(x => x.Id == id);
        }
        //this method creates new product
        public Requestline Create(Requestline requestline) {
            if (requestline is null) {
                throw new ArgumentException("Requestline");
            }

            _context.Requestlines.Add(requestline);
            _context.SaveChanges();
            return requestline;
        }
        //this method will allow changes to be made to a product
        public void Change(Request user) {
            _context.SaveChanges();
        }
        //this one deletes  // void means it will not return anything
        public void Remove(int id) {
            var Requestline = _context.Requestlines.Find(id);
            if (Requestline is null) {
                throw new Exception("Request not found!");
            }
            _context.Requestlines.Remove(Requestline);
            _context.SaveChanges();
        }

    }
}

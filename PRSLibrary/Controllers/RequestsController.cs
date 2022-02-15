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
        //this method will pull all requests with review status
        public IEnumerable<Request> GetRequestsInReview(int userId) {
            var requests = _context.Requests
                                    .Where(x => x.Status == "REVIEW" //this will narrow the request to only ones in review and not the current users requests
                                            && x.UserId != userId) //this will make it so the reviewers items Do not show up because they may not approve their own requests
                                    .ToList();
            return requests;           
        }
        
        public void SetRejected(Request request) {
            request.Status = "REJECTED";
            Change(request);
        }

        public void SetApproved(Request request) {
            request.Status = "APPROVED";
            Change(request);
        }

        //method for update record
        public void SetReview(Request request) {
            if (request.Total <= 50) {
                request.Status = "APPROVED";
            } else {
                request.Status = "REVIEW";
            }
            Change(request);
        }

        
        //this method returns all of the requests
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

using PRSLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PRSLibrary.Controllers {

    public class VendorsController { //make class public

        private readonly PrsDbContext _context;  //this is an internal variable for this class only

        public VendorsController(PrsDbContext context) {
            this._context = context;
        }
        //this method returns all of the users
        public IEnumerable<Vendor> GetAll(VendorsController vendorCtrl) {
            return _context.Vendors.ToList();
        }
        //this method lets you pull by primary key
        public Vendor GetByPk(int id) {
            return _context.Vendors.Find(id);
        }
        //this method makes the create 
        public Vendor Create(Vendor vendor) {
            _context.Vendors.Add(vendor);
            _context.SaveChanges();

            return vendor;
        }
        //this method will allow changes (update) to be made to a vendor
        public void Change(Vendor vendor) {
            _context.SaveChanges();
        }
        //this one deletes a vendor - void means it will not return anything
        public void Remove(int id) {
            var vendor = _context.Vendors.Find(id);
            if (vendor is not null) {
                _context.Vendors.Remove(vendor);
                _context.SaveChanges();
            }
        }
    }
}

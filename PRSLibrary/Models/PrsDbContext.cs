using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRSLibrary.Models {
    public class PrsDbContext : DbContext {

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Vendor> Vendors { get; set; }

        public PrsDbContext() { }

        public PrsDbContext(DbContextOptions<PrsDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder builder) {
            if(!builder.IsConfigured) {// if not already configured do the following
                builder.UseSqlServer(
                    "server=localhost\\sqlexpress;database =TestPrsDb;trusted_connection=true"
                    );

            }
        }

        protected override void OnModelCreating(ModelBuilder builder) {
            //makes Username in User unique  Username is the name of the column, User is the name of the class
            builder.Entity<User>(e => {
                e.HasIndex(p => p.Username).IsUnique(true);
            });

            builder.Entity<Vendor>(e => {
                e.HasIndex(p => p.Code).IsUnique(true);
            });
        }
    }
}

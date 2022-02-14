using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRSLibrary.Models {
    public class PrsDbContext : DbContext {

        public PrsDbContext() { }

        public PrsDbContext(DbContextOptions<PrsDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder builder) {
            if(!builder.IsConfigured) {// if not already configured do the following
                builder.UseSqlServer(
                    "server=localhost\\sqlexpress;database =TestPrsDb;trusted_connection=true"
                    );

            }
        }
    }
}

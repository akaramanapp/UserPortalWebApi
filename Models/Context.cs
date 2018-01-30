using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace UserPortalWebApi.Models
{
    public class Context: DbContext
    {
        public Context(): base("UserPortal")
        {

        }

        public DbSet<User> Users { get; set; }
    }
}
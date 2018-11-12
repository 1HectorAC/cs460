using HW7.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HW7.DAL
{
    public class UserContext : DbContext
    {
        /// <summary>
        /// Contructor for UserContext. Has database Connection.
        /// </summary>
        public UserContext() : base("name=HW7UserLog")
        {

        }

        public virtual DbSet<User> Users { get; set; }
    }
}
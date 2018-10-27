using HW5.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HW5.DAL
{
    public class TennantRequestContext : DbContext
    {
        /// <summary>
        /// Constructor for Tennant Request. Has connection to db.
        /// </summary>
        public TennantRequestContext() : base("name=TennantInfo")
        {

        }

        public virtual DbSet<TennantRequest> TennantRequests { get; set; }
        

    }
}
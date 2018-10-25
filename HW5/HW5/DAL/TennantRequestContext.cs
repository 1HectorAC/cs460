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
        //rename database
        public TennantRequestContext() : base("name=SecondTry")
        {

        }

        public virtual DbSet<TennantRequest> TennantRequests { get; set; }
        

    }
}
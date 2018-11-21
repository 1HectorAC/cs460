using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HW8.Models.ViewModels
{
    public class BuyerItem
    {

        public virtual DbSet<Buyer> Buyers { get; set; }
        public virtual DbSet<Item> Items { get; set; }
    }
}
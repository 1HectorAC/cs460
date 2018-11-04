using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HW6.Models.ViewModels
{
    public class PersonDashboardVM
    {
        //Information from the person.
        public string FullName { get; set; }

        public string PreferredName { get; set; }

        public string PhoneNumber { get; set; }

        public string FaxNumber { get; set; }

        public string EmailAddress { get; set; }

        public DateTime ValidFrom { get; set; }

        //need photo
        public byte[] Photo { get; set; }

        //Information from the company.
        public string CompanyName { get; set; }

        public string CompanyPhoneNumber { get; set; }

        public string CompanyFaxNumber { get; set; }

        public string Website { get; set; }

        public DateTime YearStarted { get; set; }

        //purchases
        public int TotalOrders { get; set; }

        public decimal GrossSales { get; set; }

        public decimal GrossProfit { get; set; }

        public List<ItemPurchased> MostProfitableItems { get; set; }


    }
}
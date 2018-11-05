using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HW6.Models.ViewModels
{
    public class PersonDashboardVM
    {
        //Information from the person.
        [Display(Name="Full Name")]
        public string FullName { get; set; }

        [Display(Name = "Preferred Name")]
        public string PreferredName { get; set; }

        [Display(Name = "Phone")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Fax")]
        public string FaxNumber { get; set; }

        [Display(Name = "Email")]
        public string EmailAddress { get; set; }

        [Display(Name = "Member Since")]
        public DateTime ValidFrom { get; set; }

        public byte[] Photo { get; set; }

        //Information from the company.
        [Display(Name = "Company")]
        public string CompanyName { get; set; }

        [Display(Name = "Phone")]
        public string CompanyPhoneNumber { get; set; }

        [Display(Name = "Fax")]
        public string CompanyFaxNumber { get; set; }

        [Display(Name = "Website")]
        public string Website { get; set; }

        [Display(Name = "Member Since")]
        public int YearStarted { get; set; }

        //Information from purchases.
        [Display(Name = "Orders")]
        public int TotalOrders { get; set; }

        [Display(Name = "Gross Sales")]
        public decimal GrossSales { get; set; }

        [Display(Name = "Gross Profits")]
        public decimal GrossProfit { get; set; }

        public List<ItemPurchased> MostProfitableItems { get; set; }


    }
}
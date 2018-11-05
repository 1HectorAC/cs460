using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HW6.Models.ViewModels
{
    public class ItemPurchased
    {
        public int StockItemID { get; set; }

        public string Description { get; set; }

        [Display(Name = "Line Profit")]
        public decimal ProfitLine { get; set; }

        [Display(Name = "Sales Person")]
        public string SalesPerson { get; set; }

        /// <summary>
        /// Contructor for an ItemPurchased object with all its parameters initialized.
        /// </summary>
        /// <param name="StockItemID"></param>
        /// <param name="Description"></param>
        /// <param name="ProfitLine"></param>
        /// <param name="SalesPerson"></param>
        public ItemPurchased(int StockItemID, string Description, decimal ProfitLine, string SalesPerson)
        {
            this.StockItemID = StockItemID;
            this.Description = Description;
            this.ProfitLine = ProfitLine;
            this.SalesPerson = SalesPerson;
        }
    }

}
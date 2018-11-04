using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HW6.Models.ViewModels
{
    public class ItemPurchased
    {
        public int StockItemID { get; set; }
        public string Description { get; set; }
        public decimal ProfitLine { get; set; }
        public string SalesPerson { get; set; }
        public ItemPurchased(int StockItemID, string Description, decimal ProfitLine, string SalesPerson)
        {
            this.StockItemID = StockItemID;
            this.Description = Description;
            this.ProfitLine = ProfitLine;
            this.SalesPerson = SalesPerson;
        }
    }

}
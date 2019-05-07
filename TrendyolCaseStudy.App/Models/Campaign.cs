using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrendyolCaseStudy.App.Interfaces;

namespace TrendyolCaseStudy.App.Models
{
    public class Campaign : ICampaign
    {

        public int _categoryId { get; set; }
        public decimal _discount { get; set; }
        public int _quantity { get; set; }

        public Campaign(int categoryId, decimal dicount, int quantity)
        {
            _categoryId = categoryId;
            _discount = dicount;
            _quantity = quantity;
        }

    }
}
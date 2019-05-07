using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrendyolCaseStudy.App.Models
{
    public class CouponModel
    {
        public int _CouponId { get; set; }
        public int _CartMinValue { get; set; }
        public decimal _Discount { get; set; }

        public CouponModel(int couponId,int cartMinValue,decimal discount)
        {
            _CouponId = couponId;
            _CartMinValue = cartMinValue;
            _Discount = discount;
        }

    }
}
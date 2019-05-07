using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrendyolCaseStudy.BLL.Abstract;
using TrendyolCaseStudy.Entity.Concrete;

namespace TrendyolCaseStudy.App.Models
{
    public class DeliveryCostCalculator
    {
        private int _costPerDelivery;
        private int _costPerProduct;
        private const int FixedCost = 10;
        private int _numberOfDelivery;
        private int _numberOfProduct;
        public DeliveryCostCalculator(int costPerDelivery, int costPerProduct, int numberOfDelivery, int numberOfProduct)
        {
            _costPerDelivery = costPerDelivery;
            _costPerProduct = costPerProduct;
            _numberOfDelivery = numberOfDelivery;
            _numberOfProduct = numberOfProduct;
        }

        public Decimal calculateFor(OrderDetails orderDetails)
        {
            return _costPerDelivery * _numberOfDelivery + _costPerProduct * _numberOfProduct + FixedCost;
        }
    }
}
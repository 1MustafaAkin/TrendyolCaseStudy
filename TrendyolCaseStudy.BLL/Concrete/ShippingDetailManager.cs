using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendyolCaseStudy.BLL.Abstract;
using TrendyolCaseStudy.Dal.Abstract;
using TrendyolCaseStudy.Entity.Concrete;

namespace TrendyolCaseStudy.BLL.Concrete
{
    public class ShippingDetailManager : IShippingDetailService
    {
        private IShippingDetailDal _shippingDetailDal;

        public ShippingDetailManager(IShippingDetailDal shippingDetailDal)
        {
            _shippingDetailDal = shippingDetailDal;
        }

        public void Add(ShippingDetail shippingDetail)
        {
            _shippingDetailDal.Add(shippingDetail);
        }

        public void Delete(ShippingDetail shippingDetail)
        {
            try
            {
                _shippingDetailDal.Delete(shippingDetail);
            }
            catch
            {
                throw new Exception("Silme Gerçekleşemedi");
            }
        }

        public IEnumerable<ShippingDetail> GetAll()
        {
            return _shippingDetailDal.GetAll();
        }

        public ShippingDetail GetShippingDetailById(int? id)
        {
            return _shippingDetailDal.Get(x => x.ShippingDetailID == id);
        }

        public void Update(ShippingDetail shippingDetail)
        {
            _shippingDetailDal.Update(shippingDetail);
        }
    }
}

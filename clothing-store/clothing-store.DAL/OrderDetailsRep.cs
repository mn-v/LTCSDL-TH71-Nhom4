using System;
using clothing_store.Common.DAL;


namespace clothing_store.DAL
{
    using clothing_store.Common.Rsp;
    using clothing_store.DAL.Models;
    using System.Linq;

    public class OrderDetailsRep : GenericRep<OnlineStoreContext, OrderDetails>
    {
        #region -- Override --
        public override OrderDetails Read(int id)
        {
            var res = All.FirstOrDefault(p => p.OrderId == id);
            return res;
        }


        public int Remove(int id)
        {
            var m = base.All.FirstOrDefault(p => p.OrderId == id);
            m = base.Delete(m);
            return m.ProductId;
        }
        
        #endregion

        #region -- Methods --
        



        #endregion
    }
}

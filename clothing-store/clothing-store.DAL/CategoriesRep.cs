using System;
using System.Collections.Generic;
using System.Text;
using clothing_store.Common.DAL;

namespace clothing_store.DAL
{
    using clothing_store.DAL.Models;
    using System.Linq;

    // day la lop dai dien cho doi tuong Categories
    public class CategoriesRep : GenericRep<OnlineStoreContext, Categories>
    {
        #region -- Overrides --
        public override Categories Read(int id)
        {
            var res = All.FirstOrDefault(p => p.CategoryId == id);
            return res; // thay vi ghi base.All thi ghi All no cung hieu
        }
        
        public int Remove(int id)
        {
            var m = base.All.First(i => i.CategoryId == id);
            m = base.Delete(m);
            return m.CategoryId;
        }
        #endregion
    }
}

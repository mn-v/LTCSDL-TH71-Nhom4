using System;
using System.Collections.Generic;
using System.Text;

using clothing_store.Common.Rsp;
using clothing_store.Common.BLL;

namespace clothing_store.BLL
{
    using clothing_store.DAL.Models;
    using DAL;
    using System.Reflection.Metadata.Ecma335;

    public class CategoriesSvc:GenericSvc<CategoriesRep, Categories>
    {
        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();

            var m = _rep.Read(id);
            res.Data = m;

            return res;
        }

        public override SingleRsp Update(Categories m)
        {
            var res = new SingleRsp();

            var m1 = m.CategoryId > 0 ? _rep.Read(m.CategoryId) : _rep.Read(m.CategoryName);
            if(m1==null)
            {
                res.SetError("EZ103", "No data.");
            }
            else
            {
                res = base.Update(m);
                res.Data = m;
            }

            return res;
        }
        
    }
}

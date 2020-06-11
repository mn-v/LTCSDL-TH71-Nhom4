using System;
using System.Collections.Generic;
using System.Text;

using clothing_store.Common.Rsp;
using clothing_store.Common.BLL;

namespace clothing_store.BLL
{
    using clothing_store.Common.Req;
    using clothing_store.DAL.Models;
    using DAL;
    using System.Linq;
    using System.Reflection.Metadata.Ecma335;

    public class CategoriesSvc:GenericSvc<CategoriesRep, Categories>
    {
        #region -- Overrides --
        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();

            var m = _rep.Read(id);
            res.Data = m;

            return res;
        }

        public override int Remove(int id)
        {
            var res = new SingleRsp();

            var m = _rep.Remove(id);
            res.Data = m;

            return 0;
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
        #endregion

        public SingleRsp CreateCategory(CategoriesReq category)
        {
            var res = new SingleRsp();
            Categories categories = new Categories();
            categories.CategoryId = category.CategoryId;
            categories.CategoryName = category.CategoryName;
            categories.Title = category.Title;
            categories.Description = category.Description;
            categories.Gender = category.Gender;
            
            res = _rep.CreateCategory(categories);
            return res;
        }

        public SingleRsp UpdateCategory(CategoriesReq category)
        {
            var res = new SingleRsp();
            Categories categories = new Categories();
            categories.CategoryId = category.CategoryId;
            categories.CategoryName = category.CategoryName;
            categories.Title = category.Title;
            categories.Description = category.Description;
            categories.Gender = category.Gender;

            res = _rep.UpdateCategory(categories);
            return res;
        }

        public int DeleteCategory(int id)
        {
            return _rep.DeleteCategory(id);
        }

        public object SearchCategory(String keyword, int page, int size)
        {
            var pro = All.Where(x => x.CategoryName.Contains(keyword));

            var offset = (page - 1) * size;
            var total = pro.Count();
            int totalPages = (total % size) == 0 ? (int)(total / size) : (int)((total / size) + 1);
            var data = pro.OrderBy(x => x.CategoryName).Skip(offset).Take(size).ToList();

            var res = new
            {
                Data = data,
                TotalRecord = total,
                TotalPages = totalPages,
                Page = page,
                Size = size
            };
            return res;
        }
    }
}

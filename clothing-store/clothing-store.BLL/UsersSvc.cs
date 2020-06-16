using clothing_store.Common.BLL;
using clothing_store.Common.Rsp;
using clothing_store.DAL;
using clothing_store.DAL.Models;
using System;
using System.Linq;

namespace clothing_store.BLL
{
    public class UsersSvc : GenericSvc<UsersRep, Users>
    {
        #region -- Override --
        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();

            var m = _rep.Read(id);
            res.Data = m;

            return res;
        }
        #endregion

        #region -- Methods --
        public object SearchUser(String keyword, int page, int size)
        {
            var pro = All.Where(x => x.UserName.Contains(keyword));

            var offset = (page - 1) * size;
            var total = pro.Count();
            int totalPages = (total % size) == 0 ? (int)(total / size) : (int)((total / size) + 1);
            var data = pro.OrderBy(x => x.UserName).Skip(offset).Take(size).ToList();

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
        public object CheckAcc(String user, String pass)
        {
            return _rep.CheckAcc(user, pass);
        }
        #endregion
    }
}

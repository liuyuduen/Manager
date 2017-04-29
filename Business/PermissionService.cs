using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Base.Entity;
using IBusiness;
using Base.Utility;
using Base.Cache;
using Base.Kernel;
using System.Web.Caching;

namespace Business
{
    public class PermissionService : IPermissionService
    {
        private string SystemID { get { return ConfigHelper.SystemID; } }
        DataContext db = new DataContext();
        IUserRoleService urs = Base.Utility.CastleContainer.Instance.Resolve<IUserRoleService>();

        public List<string> GetPermssionsByUser(string userID)
        {
            List<string> pers = null;

            object obj = DataCache.Get(CacheKey.UserList);
            if (obj == null)
            {

                List<T_UserRole> urlist = urs.GetUserRolesByUserID(userID);
                var ps = db.T_Permission.Where(m => m != null && m.RoleID == userID).ToList();
                 
                foreach (T_Permission p in ps)
                {
                    pers.Add(p.PermissionID);
                }
                foreach (T_UserRole ur in urlist)
                {
                    T_Permission per = db.T_Permission.Select(m => m != null && m.RoleID == ur.RoleID) as T_Permission;
                    if (!pers.Contains(per.PermissionID))
                        pers.Add(per.PermissionID);
                }

                AggregateCacheDependency cd = TableCacheDependency.GetUserDependency();
                DataCache.Insert(CacheKey.UserPermissions + userID, cd, pers, false);
            }
            else
            {
                pers = (List<string>)obj;
            }
            return pers;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBusiness;
using Base.Utility;
using Base.Entity;
using Base.Cache;
using Base.Kernel;
using System.Web.Caching;

namespace Business
{
    public class RoleService : IRoleService
    {
        private string SystemID { get { return ConfigHelper.SystemID; } }

        DataContext db = new DataContext();

        public int AddRole(T_Role role)
        {
            int result = -1;
            db.T_Role.Add(role);
            result = db.SaveChanges();
            return result;
        }
        public int UpdateRole(T_Role role)
        {
            int result = -1;
            T_Role obj = db.T_Role.Find(role.RoleID);
            obj = role;
            result = db.SaveChanges();
            return result;
        }
        public int DeleteRole(string RoleID)
        {
            int result = -1;
            T_Role obj = db.T_Role.Find(RoleID);
            db.T_Role.Remove(obj);
            result = db.SaveChanges();
            return result;
        }



        public T_Role GetRoleByID(string RoleID)
        {
            var role = db.T_Role.Select(t => t != null && t.RoleID == RoleID && t.SystemID == SystemID);
            return role as T_Role;
        }

        public List<T_Role> GetRoleList()
        {
            List<T_Role> roles = null;

            roles = db.T_Role.ToList();

            return roles;
        }
    }
}

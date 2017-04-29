using Base.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBusiness
{
    public interface IRoleService
    {
        int AddRole(T_Role role);
        int UpdateRole(T_Role role);
        int DeleteRole(string roleID);
         
        T_Role GetRoleByID(string roleID);
        List<T_Role> GetRoleList();
    }
}

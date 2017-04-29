using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Base.Entity;

namespace IBusiness
{
    public interface IUserRoleService
    {
        /// <summary>
        /// 获取用户所有角色
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="systemID"></param>
        /// <returns></returns>
        List<T_UserRole> GetUserRolesByUserID(string userID);

    }
}

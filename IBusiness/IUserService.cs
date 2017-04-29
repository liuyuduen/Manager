using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Base.Entity;
using Base.Utility;

namespace IBusiness
{
    public interface IUserService
    {
        int AddUser(T_User user);
        int UpdateUser(T_User user);
        int DeleteUser(string userID);
         
        T_User Login(string loginName);
        T_User GetUserByID(string userID);
        List<T_User> GetUserList();
    }
}

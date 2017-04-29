using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Base.Entity;
using IBusiness;
using Base.Kernel;
using System.Web.Caching;
using Base.Cache;
using Base.DataAccess.Repository;
using Base.Utility;

namespace Business
{

    public class UserService : IUserService
    {
        private string SystemID { get { return ConfigHelper.SystemID; } }

        DataContext db = new DataContext();

        public int AddUser(T_User user)
        {
            int result = -1;
            db.T_User.Add(user);
            result = db.SaveChanges();
            return result;
        }
        public int UpdateUser(T_User user)
        {
            int result = -1;
            T_User obj = db.T_User.Find(user.UserID);
            obj = user;
            result = db.SaveChanges();
            return result;
        }
        public int DeleteUser(string userID)
        {
            int result = -1;
            T_User obj = db.T_User.Find(userID);
            db.T_User.Remove(obj);
            result = db.SaveChanges();
            return result;
        }


        public T_User Login(string loginName)
        {
            T_User user = null;
            user = db.T_User.Where(t => t != null && t.LoginName == loginName) as T_User;

            return user;
        }
        public T_User GetUserByID(string userID)
        {
            var user = db.T_User.Select(t => t != null && t.UserID == userID && t.SystemID == SystemID);
            return user as T_User;
        }

        public List<T_User> GetUserList()
        {
            List<T_User> users = null;

            object obj = DataCache.Get(CacheKey.UserList);
            if (obj == null)
            {
                users = db.T_User.ToList();

                AggregateCacheDependency cd = TableCacheDependency.GetUserDependency();
                DataCache.Insert(CacheKey.UserList, cd, users, false);
            }
            else
            {
                users = (List<T_User>)obj;
            }

            return users;
        }

    }
}

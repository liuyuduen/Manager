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
using System.Data.Common;
using Base.DataAccess;

namespace Business
{

    public class UserService : IUserService
    {
        private string SystemID { get { return ConfigHelper.SystemID; } }

        DataContext db = new DataContext();
        RepositoryFactory<T_User> data = new RepositoryFactory<T_User>();

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

        public List<T_User> GetUserList(string loginName, ref JqGridParam jqgrid)
        {
            List<T_User> users = null;

            StringBuilder strSql = new StringBuilder();
            List<DbParameter> parameter = new List<DbParameter>();
            strSql.Append("select * from T_User where 1=1");
            if (!loginName.IsNullOrEmpty())
            {
                strSql.Append(" and loginName like '%@loginName%'");
                parameter.Add(DbFactory.CreateDbParameter("@loginName", loginName.Trim()));
            }

            users = data.Repository().FindListPageBySql(strSql.ToString(), ref jqgrid);

            return users;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBusiness;
using Base.Utility;
using Base.Entity;
using Base.DataAccess.Repository;
using System.Data.Common;
using Base.DataAccess;

namespace Business
{
    public class UserRoleService : RepositoryFactory<T_UserRole>, IUserRoleService
    {
        private string SystemID { get { return ConfigHelper.SystemID; } }

        DataContext db = new DataContext();

        public List<T_UserRole> GetUserRolesByUserID(string userID)
        {

            List<T_UserRole> uroles = null;

            uroles = db.T_UserRole.Where(t => t != null && t.UserID == userID && t.SystemID == SystemID).ToList();

            return uroles;

        }
    }
}

using Base.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBusiness;
using Base.Utility;

namespace Base.Kernel
{
    public class Permission
    {
        IPermissionService business = CastleContainer.Instance.Resolve<IPermissionService>();
        IManageProvider provider = CastleContainer.Instance.Resolve<IManageProvider>();

        public List<string> DirPermission
        {
            get
            {
                return business.GetPermssionsByUser(provider.Current().UserId);
            }
        }

        public bool CheckUserPermission(string permissionID)
        {
            return DirPermission.Contains(permissionID);
        }
    }
    /// <summary>
    /// 权限认证模式
    /// </summary>
    public enum PermissionMode
    {
        /// <summary>执行</summary>
        Enforce,
        /// <summary>忽略</summary>
        Ignore
    }
}

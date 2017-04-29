using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Base.Entity
{
    /// <summary>
    /// 角色权限表的模型
    /// </summary>
    [Serializable]
    public class T_Permission
    {
        private string _permssionID;
        private string _systemID = String.Empty;
        private string _roleID = String.Empty;
        private string _moduleID = String.Empty;

        public T_Permission() { }
        /// <summary>
        /// 角色权限ID
        /// </summary>
        public string PermissionID
        {
            get { return _permssionID; }
            set { _permssionID = value; }
        }
        /// <summary>
        /// 系统ID
        /// </summary>
        public string SystemID
        {
            get { return _systemID; }
            set { _systemID = value; }
        }
        /// <summary>
        /// 角色 ID
        /// </summary>
        [Key]
        public string RoleID
        {
            get { return _roleID; }
            set { _roleID = value; }
        }
        /// <summary>
        ///  权限ID
        /// </summary>
        public string ModuleID
        {
            get { return _moduleID; }
            set { _moduleID = value; }
        }

    }
}



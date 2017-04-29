using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Base.Entity
{
    /// <summary>
    /// 角色表的模型
    /// </summary>
    [Serializable]
    public class T_Role
    {
        private string _roleID;
        private string _systemID = String.Empty;
        private string _roleName = String.Empty;
        private string _createUser = String.Empty;
        private DateTime _createDate;

        private string _updateUser = String.Empty;
        private DateTime _updateDate;
        private bool _status;
        private short _index;

        public T_Role() { }
        /// <summary>
        /// 编号
        /// </summary>
        [Key]
        public string RoleID
        {
            get { return _roleID; }
            set { _roleID = value; }
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
        /// 角色名称
        /// </summary>
        public string RoleName
        {
            get { return _roleName; }
            set { _roleName = value; }
        }
        /// <summary>
        /// 创建人ID
        /// </summary>
        public string CreateUser
        {
            get { return _createUser; }
            set { _createUser = value; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate
        {
            get { return _createDate; }
            set { _createDate = value; }
        }
        /// <summary>
        /// 更新人ID
        /// </summary>
        public string UpdateUser
        {
            get { return _updateUser; }
            set { _updateUser = value; }
        }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdateDate
        {
            get { return _updateDate; }
            set { _updateDate = value; }
        }

        /// <summary>
        ///  状态：0启用 1 禁用
        /// </summary>
        public bool Status
        {
            get { return _status; }
            set { _status = value; }
        }
        /// <summary>
        /// 排序
        /// </summary>
        public short Index
        {
            get { return _index; }
            set { _index = value; }
        }

    }
}



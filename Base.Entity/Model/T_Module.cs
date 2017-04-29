using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Base.Entity
{
    /// <summary>
    /// 权限表的模型
    /// </summary>
    [Serializable]
    public class T_Module
    {
        private string _moduleID;

        private string _systemID = String.Empty;
        private string _moduleName = String.Empty;
        private string _moduleParentID = String.Empty;
        private bool _type;
        private string _uRL = String.Empty;
        private string _moduleCode = String.Empty;
        private short _index;
        private bool _status;
        private string _createUser = String.Empty;
        private string _createDate = String.Empty;
        private string _updateUser = String.Empty;
        private string _updateDate = String.Empty;

        public T_Module() { }
        [Key]
        public string ModuleID
        {
            get { return _moduleID; }
            set { _moduleID = value; }
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
        /// 权限名称
        /// </summary>
        public string ModuleName
        {
            get { return _moduleName; }
            set { _moduleName = value; }
        }
        /// <summary>
        /// 模块父级ID
        /// </summary>
        public string ModuleParentID
        {
            get { return _moduleParentID; }
            set { _moduleParentID = value; }
        }
        /// <summary>
        /// 模块类型 0页面导航 1功能按钮
        /// </summary>
        public bool Type
        {
            get { return _type; }
            set { _type = value; }
        }
        /// <summary>
        /// 菜单路径
        /// </summary>
        public string URL
        {
            get { return _uRL; }
            set { _uRL = value; }
        }
        /// <summary>
        /// 权限模块
        /// </summary>
        public string ModuleCode
        {
            get { return _moduleCode; }
            set { _moduleCode = value; }
        }
        /// <summary>
        /// 排序
        /// </summary>
        public short Index
        {
            get { return _index; }
            set { _index = value; }
        }
        /// <summary>
        /// 状态 0 启用1禁用
        /// </summary>
        public bool Status
        {
            get { return _status; }
            set { _status = value; }
        }

        public string CreateUser
        {
            get { return _createUser; }
            set { _createUser = value; }
        }

        public string CreateDate
        {
            get { return _createDate; }
            set { _createDate = value; }
        }

        public string UpdateUser
        {
            get { return _updateUser; }
            set { _updateUser = value; }
        }

        public string UpdateDate
        {
            get { return _updateDate; }
            set { _updateDate = value; }
        }

    }
}



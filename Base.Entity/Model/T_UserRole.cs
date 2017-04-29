using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Base.Entity
{
	/// <summary>
	/// 用户角色表的模型
	/// </summary>
	[Serializable]
	public class T_UserRole
	{
		private string _userRoleID;
        private string _systemID = String.Empty;
        private string _userID = String.Empty;
		private string _roleID = String.Empty;
		
		public T_UserRole() {}
        /// <summary>
        /// 用户角色ID
        /// </summary> 
        [Key]
        public string UserRoleID
		{
			get{ return _userRoleID; }
			set{ _userRoleID = value; }
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
        /// 用户ID
        /// </summary>
        public string UserID
		{
			get{ return _userID; }
			set{ _userID = value; }
		}
        /// <summary>
        /// 角色ID
        /// </summary>
        public string RoleID
		{
			get{ return _roleID; }
			set{ _roleID = value; }
		}
		
	}
}



using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Base.Entity
{
    /// <summary>
    /// 用户表的模型
    /// </summary>
    [Serializable]
    public class T_User
    {
        private string _userID;
        private string _systemID = String.Empty;
        private string _loginName = String.Empty;
        private string _pwssWord = String.Empty;
        private string _niceName = String.Empty; 
        private int _level;
        private int _integral;
        private DateTime _registerDate;
        private DateTime _upudateDate;
        private DateTime _lastLoginDate;
        private DateTime _lastOpreateDate;
        private bool _isOnLin;
        private int _userType;
        private short _userStatus;

        public T_User() { }
        /// <summary>
        /// 编号
        /// </summary> 
        [Key]
        public string UserID
        {
            get { return _userID; }
            set { _userID = value; }
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
        /// 登录名
        /// </summary>
        public string LoginName
        {
            get { return _loginName; }
            set { _loginName = value; }
        }
        /// <summary>
        /// 密码
        /// </summary>
        public string PwssWord
        {
            get { return _pwssWord; }
            set { _pwssWord = value; }
        }
        /// <summary>
        /// 昵称
        /// </summary>
        public string NiceName
        {
            get { return _niceName; }
            set { _niceName = value; }
        }
     
       
        /// <summary>
        /// 等级
        /// </summary>
        public int Level
        {
            get { return _level; }
            set { _level = value; }
        }
        /// <summary>
        /// 积分
        /// </summary>
        public int Integral
        {
            get { return _integral; }
            set { _integral = value; }
        }
        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime RegisterDate
        {
            get { return _registerDate; }
            set { _registerDate = value; }
        }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpudateDate
        {
            get { return _upudateDate; }
            set { _upudateDate = value; }
        }
        /// <summary>
        /// 最后登录时间
        /// </summary>
        public DateTime LastLoginDate
        {
            get { return _lastLoginDate; }
            set { _lastLoginDate = value; }
        }
        /// <summary>
        /// 最后操作时间
        /// </summary>
        public DateTime LastOpreateDate
        {
            get { return _lastOpreateDate; }
            set { _lastOpreateDate = value; }
        }
        /// <summary>
        /// 是否在线
        /// </summary>
        public bool IsOnLin
        {
            get { return _isOnLin; }
            set { _isOnLin = value; }
        }
        /// <summary>
        /// 用户类型  0系统账号 1 普通用户 2 广告商用户 3 推广员
        /// </summary>
        public int UserType
        {
            get { return _userType; }
            set { _userType = value; }
        }
        /// <summary>
        /// 状态 0正常 1锁定 2删除
        /// </summary>
        public short UserStatus
        {
            get { return _userStatus; }
            set { _userStatus = value; }
        }
    

    }
}



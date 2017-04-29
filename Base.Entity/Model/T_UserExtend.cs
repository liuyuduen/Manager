using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Base.Entity
{
    /// <summary>
    /// 用户扩展表的模型
    /// </summary>
    [Serializable]
    public class T_UserExtend
    {
        private string _userExtendID; 
        private string _userID = String.Empty;
        private string _userName = String.Empty;
        private string _userIDCard = String.Empty;
        private string _phone = String.Empty;
        private string _email = String.Empty;
        private string _fax = String.Empty;
        private string _address = String.Empty;
        private bool _gender;
        private DateTime _birthday;
        private string _photo = String.Empty;
        private string _userIP = String.Empty;

        public T_UserExtend() { }

        [Key]
        public string UserExtendID
        {
            get { return _userExtendID; }
            set { _userExtendID = value; }
        }
        /// <summary>
        /// 用户ID
        /// </summary>
        public string UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }
        
        /// <summary>
        /// 实名
        /// </summary>
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }
        /// <summary>
        /// 身份证
        /// </summary>
        public string UserIDCard
        {
            get { return _userIDCard; }
            set { _userIDCard = value; }
        }
        /// <summary>
        /// 手机
        /// </summary>
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        /// <summary>
        /// 传真
        /// </summary>
        public string Fax
        {
            get { return _fax; }
            set { _fax = value; }
        }
        /// <summary>
        /// 住址
        /// </summary>
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }
        /// <summary>
        /// 性别
        /// </summary>
        public bool Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }
        /// <summary>
        /// 生日
        /// </summary>
        public DateTime Birthday
        {
            get { return _birthday; }
            set { _birthday = value; }
        }
        /// <summary>
        /// 用户头像
        /// </summary>
        public string Photo
        {
            get { return _photo; }
            set { _photo = value; }
        }
        /// <summary>
        ///登录IP
        ///</summary>
        public string UserIP
        {
            get { return _userIP; }
            set { _userIP = value; }
        }
    }
}



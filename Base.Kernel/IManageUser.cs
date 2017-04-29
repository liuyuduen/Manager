using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Base.Kernel
{
    /// <summary>
    /// 管理用户接口
    /// </summary>
    public class IManageUser
    {
        #region 基础信息
        /// <summary>
        /// 用户主键
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// 登陆账户
        /// </summary>
        public string LoginName { get; set; }
        /// <summary>
        /// 登陆密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 用户昵称
        /// </summary>
        public string NiceName { get; set; } 
        /// <summary>
        /// 用户等级
        /// </summary>
        public int Level { get; set; }
        /// <summary>
        /// 积分
        /// </summary>
        public int Integral { get; set; }
        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime RegisterDate { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpudateDate { get; set; }
        /// <summary>
        /// 最后登录时间
        /// </summary>
        public DateTime LastLoginDate { get; set; }
        /// <summary>
        /// 最后活动时间
        /// </summary>
        public DateTime LastOpreateDate { get; set; }
        /// <summary>
        /// 是否在线
        /// </summary>
        public bool IsOnLin { get; set; }
        /// <summary>
        /// 用户类型
        /// </summary>
        public int UserType { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int UserStatus { get; set; }
        /// <summary>
        /// 登录IP
        /// </summary>
        public string UserIP { get; set; }
        #endregion

        #region 扩展信息
        /// <summary>
        /// 真实姓名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 真实姓名
        /// </summary>
        public string UserIDCard { get; set; }
        /// <summary>
        /// 真实姓名
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 真实姓名
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 真实姓名
        /// </summary>
        public string Fax { get; set; }
        /// <summary>
        /// 真实姓名
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string Gender { get; set; }
        /// <summary>
        /// 生日
        /// </summary>
        public string Birthday { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        public string Photo { get; set; }
        #endregion
         
    }
}

using Base.Utility;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Base.Entity
{
    /// <summary>
    /// 创建一个EF实体框架 上下文
    /// </summary>
    public partial class DataContext : DbContext
    {
        public DataContext()
            : base(ConfigHelper.DB_CONNECTION_STRING)
        {
        }
        public DbSet<T_User> T_User { get; set; }
        public DbSet<T_UserExtend> T_UserExtend { get; set; }
        public DbSet<T_UserRole> T_UserRole { get; set; }
        public DbSet<T_Role> T_Role { get; set; }
        public DbSet<T_Permission> T_Permission { get; set; }
        public DbSet<T_Module> T_Module { get; set; }

    }
}

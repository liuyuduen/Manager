using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Base.Utility
{
    /// <summary>
    /// 针对SQLServer查询返回模型的辅助类
    /// </summary>
    public class SqlModelHelper<T> where T : class, new()
    {
        /// <summary>
        /// 根据Sql获得单个对象
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="pas">参数数组</param>
        /// <returns>单个对象</returns>
        public static T GetSingleObjectBySql(string sql, params SqlParameter[] pas)
        {
            DataTable dt = SqlHelper.ExecuteDataTable(sql, pas);
            IList<T> ts = ModelConvertHelper<T>.ConvertToModel(dt);
            return (ts.Count == 0 ? null : ts[0]);
        }

        /// <summary>
        /// 根据Sql获得某对象的集合
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="pas">参数数组</param>
        /// <returns>对象集合</returns>
        public static List<T> GetObjectsBySql(string sql, params SqlParameter[] pas)
        {
            DataTable dt = SqlHelper.ExecuteDataTable(sql, pas);
            return ModelConvertHelper<T>.ConvertToModel(dt);
        }

        /// <summary>
        /// 根据存储过程获得单个对象
        /// </summary>
        /// <param name="proc">存储过程名称</param>
        /// <param name="pas">参数数组</param>
        /// <returns>单个对象</returns>
        public static T GetSingleObjectByProc(string proc, params SqlParameter[] pas)
        {
            DataTable dt = SqlHelper.ExecuteDataTableProc(proc, pas);
            IList<T> ts = ModelConvertHelper<T>.ConvertToModel(dt);
            return (ts.Count == 0 ? null : ts[0]);
        }

        /// <summary>
        /// 根据存储过程获得某对象的集合
        /// </summary>
        /// <param name="proc">存储过程名称</param>
        /// <param name="pas">参数数组</param>
        /// <returns>对象集合</returns>
        public static List<T> GetObjectsByProc(string proc, params SqlParameter[] pas)
        {
            DataTable dt = SqlHelper.ExecuteDataTableProc(proc, pas);
            return ModelConvertHelper<T>.ConvertToModel(dt);
        }
    }
}

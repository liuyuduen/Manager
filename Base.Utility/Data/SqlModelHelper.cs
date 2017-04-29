using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Base.Utility
{
    /// <summary>
    /// ���SQLServer��ѯ����ģ�͵ĸ�����
    /// </summary>
    public class SqlModelHelper<T> where T : class, new()
    {
        /// <summary>
        /// ����Sql��õ�������
        /// </summary>
        /// <param name="sql">SQL���</param>
        /// <param name="pas">��������</param>
        /// <returns>��������</returns>
        public static T GetSingleObjectBySql(string sql, params SqlParameter[] pas)
        {
            DataTable dt = SqlHelper.ExecuteDataTable(sql, pas);
            IList<T> ts = ModelConvertHelper<T>.ConvertToModel(dt);
            return (ts.Count == 0 ? null : ts[0]);
        }

        /// <summary>
        /// ����Sql���ĳ����ļ���
        /// </summary>
        /// <param name="sql">SQL���</param>
        /// <param name="pas">��������</param>
        /// <returns>���󼯺�</returns>
        public static List<T> GetObjectsBySql(string sql, params SqlParameter[] pas)
        {
            DataTable dt = SqlHelper.ExecuteDataTable(sql, pas);
            return ModelConvertHelper<T>.ConvertToModel(dt);
        }

        /// <summary>
        /// ���ݴ洢���̻�õ�������
        /// </summary>
        /// <param name="proc">�洢��������</param>
        /// <param name="pas">��������</param>
        /// <returns>��������</returns>
        public static T GetSingleObjectByProc(string proc, params SqlParameter[] pas)
        {
            DataTable dt = SqlHelper.ExecuteDataTableProc(proc, pas);
            IList<T> ts = ModelConvertHelper<T>.ConvertToModel(dt);
            return (ts.Count == 0 ? null : ts[0]);
        }

        /// <summary>
        /// ���ݴ洢���̻��ĳ����ļ���
        /// </summary>
        /// <param name="proc">�洢��������</param>
        /// <param name="pas">��������</param>
        /// <returns>���󼯺�</returns>
        public static List<T> GetObjectsByProc(string proc, params SqlParameter[] pas)
        {
            DataTable dt = SqlHelper.ExecuteDataTableProc(proc, pas);
            return ModelConvertHelper<T>.ConvertToModel(dt);
        }
    }
}

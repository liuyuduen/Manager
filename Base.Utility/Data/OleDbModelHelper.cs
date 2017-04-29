
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb; 

namespace Base.Utility
{
    /// <summary>
    /// ��ѯ����ģ�͵ĸ�����
    /// </summary>
    public class OleDbModelHelper<T> where T : class ,new()
    {
        /// <summary>
        /// ����Sql��õ�������
        /// </summary>
        /// <param name="sql">SQL���</param>
        /// <param name="pas">��������</param>
        /// <returns>��������</returns>
        public static T GetSingleObjectBySql(string sql,params OleDbParameter[] pas)
        {
            DataTable dt = AccessHelper.ExecuteDataTable(sql, pas);
            IList<T> ts = ModelConvertHelper<T>.ConvertToModel(dt);
            return (ts.Count == 0 ? null : ts[0]);
        }

        /// <summary>
        /// ����Sql���ĳ����ļ���
        /// </summary>
        /// <param name="sql">SQL���</param>
        /// <param name="pas">��������</param>
        /// <returns>���󼯺�</returns>
        public static IList<T> GetObjectsBySql(string sql, params OleDbParameter[] pas)
        {
            DataTable dt = AccessHelper.ExecuteDataTable(sql, pas);
            return ModelConvertHelper<T>.ConvertToModel(dt);
        }

        /// <summary>
        /// ���ݴ洢���̻�õ�������
        /// </summary>
        /// <param name="proc">�洢��������</param>
        /// <param name="pas">��������</param>
        /// <returns>��������</returns>
        public static T GetSingleObjectByProc(string proc, params OleDbParameter[] pas)
        {
            DataTable dt = AccessHelper.ExecuteDataTableProc(proc, pas);
            IList<T> ts = ModelConvertHelper<T>.ConvertToModel(dt);
            return (ts.Count == 0 ? null : ts[0]);
        }

        /// <summary>
        /// ���ݴ洢���̻��ĳ����ļ���
        /// </summary>
        /// <param name="proc">�洢��������</param>
        /// <param name="pas">��������</param>
        /// <returns>���󼯺�</returns>
        public static IList<T> GetObjectsByProc(string proc, params OleDbParameter[] pas)
        {
            DataTable dt = AccessHelper.ExecuteDataTableProc(proc, pas);
            return ModelConvertHelper<T>.ConvertToModel(dt);
        }
    }
}

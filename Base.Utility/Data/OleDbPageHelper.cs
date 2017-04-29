using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Base.Utility
{
    /// <summary>
    /// OleDb��ҳ������
    /// </summary>
    public class OleDbPageHelper
    {
        /// <summary>
        /// ����SQL�������Ӧ�ļ�¼��
        /// </summary>
        /// <param name="sql">SQL���</param>
        /// <returns>��¼��</returns>
        public static int GetRecordCount(string sql)
        {
            // �õ�from���ڵ�λ��
            int fromIndex = sql.LastIndexOf(" from ", StringComparison.OrdinalIgnoreCase);

            // �õ�from��������
            string from = sql.Substring(fromIndex + 1);

            string newSql = "select count(*) " + from;

            return Convert.ToInt32(AccessHelper.ExecuteScalar(newSql));
        }


        /// <summary>
        /// ���ĳһҳ������
        /// </summary>
        /// <param name="sql">Ҫִ�е�SQL���</param>
        /// <param name="orderBy">���������(���磺order by Age Desc)</param>
        /// <param name="primaryKey">����(���磺p.Id)</param>
        /// <param name="startRowIndex">��ʼ������</param>
        /// <param name="pageSize">ҳ��С</param>
        /// <returns>��ҳ�������</returns>
        public static DataTable GetPagedInfo(string sql, string orderBy, string primaryKey, int startRowIndex, int pageSize)
        {
            // �õ�from���ڵ�λ��
            int fromIndex = sql.LastIndexOf(" from ", StringComparison.OrdinalIgnoreCase);

            // �õ�where���ڵ�λ��
            int whereIndex = sql.LastIndexOf(" where ", StringComparison.OrdinalIgnoreCase);

            // �õ���ѯ���ֶ�
            string fields = sql.Substring(7, fromIndex - 7);

            // �õ�from��������
            string from = sql.Substring(fromIndex, whereIndex - fromIndex);

            // �õ�where��������
            string where = (whereIndex == -1 ? "where 1=1" : sql.Substring(whereIndex));

            // ƴ��Ҫִ�е�SQL���
            string sqlAll = "";
            if (startRowIndex == 0)
            {
                sqlAll = string.Format("select top {0} {1} {2} {3} {4}", pageSize, fields, from, where, orderBy);
            }
            else
            {
                sqlAll = string.Format("select top {0} {1} {2} {3} and {4} not in(select top {5} {6} {7} {8} {9}) {10}",
                pageSize, fields, from, where, primaryKey, startRowIndex, primaryKey, from, where, orderBy, orderBy);
            }


            return AccessHelper.ExecuteDataTable(sqlAll);

        }


    }
}

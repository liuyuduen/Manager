using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Base.Utility;

namespace Base.Utility
{
    /// <summary>
    /// SQL��ҳ������
    /// </summary>
    public class SqlPageHelper
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

            return Convert.ToInt32(SqlHelper.ExecuteScalar(newSql));
        }

        /// <summary>
        /// ���ĳһҳ������(�����ؼ�¼��)
        /// </summary>
        /// <param name="sql">Ҫִ�е�SQL���</param>
        /// <param name="orderBy">���������(���磺order by Age Desc)</param>
        /// <param name="primaryKey">����(���磺p.Id��ֻ��SQLServer2000ʱ�Ų�������)</param>
        /// <param name="fromLocation">��from��λ����(��1��ʼ)</param>
        /// <param name="startRowIndex">��ʼ������</param>
        /// <param name="pageSize">ҳ��С</param>
        /// <returns>��ҳ�������</returns>
        public static DataTable GetPagedInfo(string sql, string orderBy, string primaryKey,int fromLocation, int startRowIndex, int pageSize)
        {
            int rc = 0;
            DataTable dt = null;

            switch (ConfigHelper.SQLDbType)
            {
                case SQLDbType.SQL2000:
                    dt = GetPagedInfoBySQL2000(sql, orderBy, primaryKey,fromLocation, startRowIndex, pageSize, out rc, false);
                    break;
                case SQLDbType.SQL2005:
                    dt = GetPagedInfoBySQL2005(sql, orderBy,fromLocation, startRowIndex, pageSize ,out rc, false);
                    break;
            }
            return dt;
        }


        /// <summary>
        /// ���ĳһҳ������(�����ؼ�¼��)
        /// </summary>
        /// <param name="sql">Ҫִ�е�SQL���</param>
        /// <param name="orderBy">���������(���磺order by Age Desc)</param>
        ///  <param name="primaryKey">����(���磺p.Id��ֻ��SQLServer2000ʱ�Ų�������)</param>
        /// <param name="startRowIndex">��ʼ������</param>
        /// <param name="pageSize">ҳ��С</param>
        /// <returns>��ҳ�������</returns>
        public static DataTable GetPagedInfo(string sql, string orderBy, string primaryKey, int startRowIndex, int pageSize)
        {
            int rc = 0;
            DataTable dt = null;

            switch (ConfigHelper.SQLDbType)
            {
                case SQLDbType.SQL2000:
                    dt= GetPagedInfoBySQL2000(sql, orderBy,primaryKey, 0,startRowIndex, pageSize, out rc, false);
                    break;
                case SQLDbType.SQL2005:
                    dt= GetPagedInfoBySQL2005(sql, orderBy,0,startRowIndex, pageSize, out rc, false);
                    break;
            }
            return dt;
        }

        /// <summary>
        /// ���ĳһҳ������(���ؼ�¼��)
        /// </summary>
        /// <param name="sql">Ҫִ�е�SQL���</param>
        /// <param name="orderBy">���������(���磺order by Age Desc)</param>
        /// <param name="primaryKey">����(���磺p.Id��ֻ��SQLServer2000ʱ�Ų�������)</param>
        /// <param name="startRowIndex">��ʼ������</param>
        /// <param name="pageSize">ҳ��С</param>
        /// <param name="recordCount">��¼��(����ֵ)</param>
        /// <returns>��ҳ�������</returns>
        public static DataTable GetPagedInfo(string sql, string orderBy,string primaryKey, int startRowIndex, int pageSize, out int recordCount)
        {
            DataTable dt = null;
            switch (ConfigHelper.SQLDbType)
            {
                case SQLDbType.SQL2000:
                    dt= GetPagedInfoBySQL2000(sql, orderBy, primaryKey,0, startRowIndex, pageSize, out recordCount, true);
                    break;
                case SQLDbType.SQL2005:
                    dt= GetPagedInfoBySQL2005(sql, orderBy,0, startRowIndex, pageSize, out recordCount, true);
                    break;
                default:
                    recordCount = 0;
                    break;
            }
            return dt;
        }

        #region ���ĳһҳ������(SQL2000)

        /// <summary>
        /// ���ĳһҳ������(SQL2000)
        /// </summary>
        /// <param name="sql">Ҫִ�е�SQL���</param>
        /// <param name="orderBy">���������(���磺order by Age Desc)</param>
        /// <param name="primaryKey">����(���磺p.Id)</param>
        /// <param name="fromLocation">��from��λ����(��1��ʼ)</param>
        /// <param name="startRowIndex">��ʼ������</param>
        /// <param name="pageSize">ҳ��С</param>
        /// <param name="recordCount">��¼����(��������ؼ�¼������Ϊ0��������ؼ�¼������Ϊʵ�ʵļ�¼��)</param>
        /// <param name="isReutrnRecordCount">�Ƿ񷵻ؼ�¼��</param>
        /// <returns>��ҳ�������</returns>
        private static DataTable GetPagedInfoBySQL2000(string sql, string orderBy, string primaryKey, int fromLocation , int startRowIndex, int pageSize, out int recordCount, bool isReutrnRecordCount)
        {
            // �õ�from���ڵ�λ��
            int fromIndex = 0;
            if (fromLocation == 0)
                fromIndex = sql.LastIndexOf(" from ", StringComparison.OrdinalIgnoreCase);
            else
            {
                int lastStart = -1;
                int fromCount = 0;

                while ( (lastStart = sql.IndexOf(" from ", lastStart+1, StringComparison.OrdinalIgnoreCase)) > -1)
                {
                    fromCount++;
                    if (fromCount == fromLocation)
                    {
                        fromIndex = lastStart;
                        break;
                    }
                }

                if (lastStart == -1)
                {
                    throw new ApplicationException("��ָ��λ��û���ҵ�from�ؼ���");
                }
            }

            // �õ�where���ڵ�λ��
            int whereIndex = sql.LastIndexOf(" where ", StringComparison.OrdinalIgnoreCase);

            // �õ���ѯ���ֶ�
            string fields = sql.Substring(7, fromIndex - 7);

            // �õ�from��������
            string from = sql.Substring(fromIndex, whereIndex - fromIndex);

            // �õ�where��������
            string where = (whereIndex == -1 ? "where 1=1" : sql.Substring(whereIndex));

            // ƴ��Ҫִ�е�SQL���
            string sqlAll = string.Format("select top {0} {1} {2} {3} and {4} not in(select top {5} {6} {7} {8} {9}) {10}",
                pageSize, fields, from, where, primaryKey, startRowIndex, primaryKey, from, where, orderBy, orderBy);

            if (isReutrnRecordCount)
            {
                sqlAll += ";select count(*) " + from + " " + where;
            }

            DataSet ds = SqlHelper.ExecuteDataSet(sqlAll);

            if (isReutrnRecordCount)
            {
                // ���������¼��
                recordCount = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
            }
            else
            {
                recordCount = 0;
            }

            return ds.Tables[0];
        }

        #endregion

        #region ���ĳһҳ������(SQL2005)

        /// <summary>
        /// ���ĳһҳ������(SQL2005)
        /// </summary>
        /// <param name="sql">Ҫִ�е�SQL���</param>
        /// <param name="orderBy">���������(���磺order by Age Desc)</param>
        /// <param name="fromLocation">��from��λ����(��1��ʼ)</param>
        /// <param name="startRowIndex">��ʼ������</param>
        /// <param name="pageSize">ҳ��С</param>
        /// <param name="recordCount">��¼����(��������ؼ�¼������Ϊ0��������ؼ�¼������Ϊʵ�ʵļ�¼��)</param>
        /// <param name="isReutrnRecordCount">�Ƿ񷵻ؼ�¼��</param>
        /// <returns>��ҳ�������</returns>
        private static DataTable GetPagedInfoBySQL2005(string sql, string orderBy,int fromLocation, int startRowIndex, int pageSize,  out int recordCount, bool isReutrnRecordCount)
        {
            // �õ�from���ڵ�λ��
            int fromIndex = 0;
            if (fromLocation == 0)
                fromIndex = sql.LastIndexOf(" from ", StringComparison.OrdinalIgnoreCase);
            else
            {
                int lastStart = -1;
                int fromCount = 0;

                while ((lastStart = sql.IndexOf(" from ", lastStart + 1, StringComparison.OrdinalIgnoreCase)) > -1)
                {
                    fromCount++;
                    if (fromCount == fromLocation)
                    {
                        fromIndex = lastStart;
                        break;
                    }
                }

                if (lastStart == -1)
                {
                    throw new ApplicationException("��ָ��λ��û���ҵ�from�ؼ���");
                }
            }

            // �õ���ѯ���ֶ�
            string fields = sql.Substring(7, fromIndex - 7);

            // �õ�from��������
            string from = sql.Substring(fromIndex);

            // ƴ��Ҫִ�е�SQL���(������2005)
            string sqlAll = string.Format("select * from (select {0},row_number() over({1}) as Row {2}) as Temp where Row between {3} and {4}",
                fields, orderBy, from, (startRowIndex + 1), (startRowIndex + pageSize));

            if (isReutrnRecordCount)
            {
                sqlAll += ";select count(*) " + from;
            }

            DataSet ds = SqlHelper.ExecuteDataSet(sqlAll);

            if (isReutrnRecordCount)
            {
                // ���������¼��
                recordCount = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
            }
            else
            {
                recordCount = 0;
            }

            return ds.Tables[0];
        }

        #endregion
    }
}

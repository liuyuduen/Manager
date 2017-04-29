using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using System.Data.Common;
using Base.Utility;

namespace Base.Utility
{
    /// <summary>
    /// SQLServer���ݲ���ͨ����
    /// </summary>
    public abstract class SqlHelper
    {
        /// <summary>
        /// ���ݿ����Ӵ�
        /// </summary>
        public static readonly string DB_CONNECTION_STRING = ConfigHelper.DbConnectionString;

        #region ִ�в�����������Ӱ�������

        /// <summary>
        /// ִ�в�����������Ӱ�������
        /// </summary>
        /// <param name="cmdText">SQL���</param>
        /// <param name="commandParameters">ִ��������Ҫ�Ĳ���</param>
        /// <returns>������Ӱ�������</returns>
        public static int ExecuteNonQuery(string cmdText, params SqlParameter[] commandParameters)
        {
            return ExecuteNonQuery(CommandType.Text, cmdText, commandParameters);
        }

        /// <summary>
        /// ִ�в�����������Ӱ�������
        /// </summary>
        /// <param name="tran">�Ѵ��ڵ�����</param>
        /// <param name="cmdText">SQL���</param>
        /// <param name="commandParameters">ִ��������Ҫ�Ĳ���</param>
        /// <returns>������Ӱ�������</returns>
        public static int ExecuteNonQuery(SqlTransaction trans, string cmdText, params SqlParameter[] commandParameters)
        {
            return ExecuteNonQuery(trans, CommandType.Text, cmdText, commandParameters);

        }

        /// <summary>
        /// ִ�в�����������Ӱ�������(�洢����)
        /// </summary>
        /// <param name="cmdText">�洢��������</param>
        /// <param name="commandParameters">ִ��������Ҫ�Ĳ���</param>
        /// <returns>������Ӱ�������</returns>
        public static int ExecuteNonQueryProc(string cmdText, params SqlParameter[] commandParameters)
        {
            return ExecuteNonQuery(CommandType.StoredProcedure, cmdText, commandParameters);
        }

        /// <summary>
        /// ִ�в�����������Ӱ�������(�洢����)
        /// </summary>
        /// <param name="tran">�Ѵ��ڵ�����</param>
        /// <param name="cmdText">�洢��������</param>
        /// <param name="commandParameters">ִ��������Ҫ�Ĳ���</param>
        /// <returns>������Ӱ�������</returns>
        public static int ExecuteNonQueryProc(SqlTransaction trans, string cmdText, params SqlParameter[] commandParameters)
        {
            return ExecuteNonQuery(trans, CommandType.StoredProcedure, cmdText, commandParameters);
        }

        private static int ExecuteNonQuery(CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();

            using (SqlConnection conn = new SqlConnection(DB_CONNECTION_STRING))
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);

                int val = cmd.ExecuteNonQuery();

                cmd.Parameters.Clear();

                return val;
            }
        }

        private static int ExecuteNonQuery(SqlTransaction trans, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();

            PrepareCommand(cmd, trans.Connection, trans, cmdType, cmdText, commandParameters);

            int val = cmd.ExecuteNonQuery();

            cmd.Parameters.Clear();

            return val;

        }

        #endregion

        #region ִ�в�ѯ������SqlDataReader

        /// <summary>
        /// ִ�в�ѯ������SqlDataReader
        /// </summary>
        /// <param name="commandText">SQL���</param>
        /// <param name="commandParameters">ִ������Ĳ�����</param>
        /// <returns>һ�����������SqlDataReader</returns>
        public static SqlDataReader ExecuteReader(string cmdText, params SqlParameter[] commandParameters)
        {
            return ExecuteReader(CommandType.Text, cmdText, commandParameters);
        }

        /// <summary>
        /// ִ�в�ѯ������SqlDataReader(�洢����)
        /// </summary>
        /// <param name="commandText">�洢��������</param>
        /// <param name="commandParameters">ִ������Ĳ�����</param>
        /// <returns>һ�����������SqlDataReader</returns>
        public static SqlDataReader ExecuteReaderProc(string cmdText, params SqlParameter[] commandParameters)
        {
            return ExecuteReader(CommandType.StoredProcedure, cmdText, commandParameters);
        }

        public static SqlDataReader ExecuteReader(CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();

            SqlConnection conn = new SqlConnection(DB_CONNECTION_STRING);

            try
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);

                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                cmd.Parameters.Clear();

                return rdr;
            }
            catch
            {
                conn.Close();
                throw;
            }
        }

        #endregion

        #region ִ�в��������ر��е�һ�У���һ�е�ֵ

        /// <summary>
        /// ִ�в��������ر��е�һ�У���һ�е�ֵ
        /// </summary>
        /// <param name="commandText">SQL���</param>
        /// <param name="commandParameters">ִ������Ĳ�����</param>        
        /// <returns>���صĶ���</returns>
        public static object ExecuteScalar(string cmdText, params SqlParameter[] commandParameters)
        {
            return ExecuteScalar(CommandType.Text, cmdText, commandParameters);
        }

        /// <summary>
        /// ִ�в��������ر��е�һ�У���һ�е�ֵ
        /// </summary>
        /// <param name="tran">�Ѵ��ڵ�����</param>
        /// <param name="commandText">SQL���</param>
        /// <param name="commandParameters">ִ������Ĳ�����</param>        
        /// <returns>���صĶ���</returns>
        public static object ExecuteScalar(SqlTransaction trans, string cmdText, params SqlParameter[] commandParameters)
        {
            return ExecuteScalar(trans,CommandType.Text, cmdText, commandParameters);
        }

        /// <summary>
        /// ִ�в��������ر��е�һ�У���һ�е�ֵ(�洢����)
        /// </summary>
        /// <param name="commandText">�洢��������</param>
        /// <param name="commandParameters">ִ������Ĳ�����</param>        
        /// <returns>���صĶ���</returns>
        public static object ExecuteScalarProc(string cmdText, params SqlParameter[] commandParameters)
        {
            return ExecuteScalar(CommandType.StoredProcedure, cmdText, commandParameters);
        }

        private static object ExecuteScalar(SqlTransaction trans, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();

            PrepareCommand(cmd, trans.Connection, trans, cmdType, cmdText, commandParameters);

            object val = cmd.ExecuteScalar();

            cmd.Parameters.Clear();

            return val;
        }

        private static object ExecuteScalar(CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();

            using (SqlConnection connection = new SqlConnection(DB_CONNECTION_STRING))
            {
                PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);

                object val = cmd.ExecuteScalar();

                cmd.Parameters.Clear();

                return val;
            }
        }

        #endregion

        #region ִ��һ������������ݼ������ݱ�

        /// <summary>
        /// ִ��һ������������ݱ�
        /// </summary>
        /// <param name="commandText">SQL���</param>
        /// <param name="commandParameters">ִ������Ĳ�����</param>
        /// <returns>�������ݱ�</returns>
        public static DataTable ExecuteDataTable(string commandText, params SqlParameter[] commandParameters)
        {
            return ExecuteDataSet(commandText, commandParameters).Tables[0];
        }

        /// <summary>
        /// ִ��һ������������ݱ�(�洢����)
        /// </summary>
        /// <param name="commandText">�洢��������</param>
        /// <param name="commandParameters">ִ������Ĳ�����</param>
        /// <returns>�������ݱ�</returns>
        public static DataTable ExecuteDataTableProc(string commandText, params SqlParameter[] commandParameters)
        {
            return ExecuteDataSetProc(commandText, commandParameters).Tables[0];
        }

        /// <summary>
        /// ִ��һ������������ݼ�
        /// </summary>
        /// <param name="commandText">SQL���</param>
        /// <param name="commandParameters">ִ������Ĳ�����</param>
        /// <returns>�������ݼ�</returns>
        public static DataSet ExecuteDataSet(string commandText, params SqlParameter[] commandParameters)
        {
            return ExecuteDataSet(CommandType.Text, commandText, commandParameters);
        }

        /// <summary>
        /// ִ��һ������������ݼ�(�洢����)
        /// </summary>
        /// <param name="commandText">�洢��������</param>
        /// <param name="commandParameters">ִ������Ĳ�����</param>
        /// <returns>�������ݼ�</returns>
        public static DataSet ExecuteDataSetProc(string commandText, params SqlParameter[] commandParameters)
        {
            return ExecuteDataSet(CommandType.StoredProcedure, commandText, commandParameters);
        }

        public static DataSet ExecuteDataSet(CommandType cmdType, string commandText, params SqlParameter[] commandParameters)
        {

            SqlCommand cmd = new SqlCommand();

            using (SqlConnection conn = new SqlConnection(DB_CONNECTION_STRING))
            {
                PrepareCommand(cmd, conn, null, cmdType, commandText, commandParameters);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                cmd.Parameters.Clear();
                return ds;
            }
        }

        #endregion

        /// <summary>
        /// ����SqlCommand����
        /// </summary>
        /// <param name="cmd">SqlCommand����</param>
        /// <param name="conn">SqlConnection ����</param>
        /// <param name="trans">SqlTransaction ����</param>
        /// <param name="cmdType">CommandType(ִ�д洢���̻�SQL���)</param>
        /// <param name="cmdText">�洢�������ƻ�SQL���</param>
        /// <param name="cmdParms">�������õ��Ĳ�����</param>
        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, CommandType cmdType, string cmdText, SqlParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();

            cmd.Connection = conn;
            cmd.CommandText = cmdText;

            if (trans != null)
                cmd.Transaction = trans;

            cmd.CommandType = cmdType;

            if (cmdParms != null)
            {
                foreach (SqlParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
            }
        }
    }
}

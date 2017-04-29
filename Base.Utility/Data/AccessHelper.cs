using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.Configuration;
using System.Data;
using Base.Utility; 
using Base.Utility;

namespace Base.Utility
{
    /// <summary>
    /// Access���ݲ���ͨ����
    /// </summary>
    public abstract class AccessHelper
    { 
        /// <summary>
        /// ���ݿ����Ӵ�
        /// </summary>
        public static readonly string DB_CONNECTION_STRING = ConfigHelper.DbConnectionString.Replace("|RootPath|", HttpHelper.CurrentServer.MapPath("/"));

        #region ִ�в�����������Ӱ�������

        /// <summary>
        /// ִ�в�����������Ӱ�������
        /// </summary>
        /// <param name="cmdText">SQL���</param>
        /// <param name="commandParameters">ִ��������Ҫ�Ĳ���</param>
        /// <returns>������Ӱ�������</returns>
        public static int ExecuteNonQuery(string cmdText, params OleDbParameter[] commandParameters)
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
        public static int ExecuteNonQuery(OleDbTransaction trans, string cmdText, params OleDbParameter[] commandParameters)
        {
            return ExecuteNonQuery(trans, CommandType.Text, cmdText, commandParameters);

        }

        /// <summary>
        /// ִ�в�����������Ӱ�������(�洢����)
        /// </summary>
        /// <param name="cmdText">�洢��������</param>
        /// <param name="commandParameters">ִ��������Ҫ�Ĳ���</param>
        /// <returns>������Ӱ�������</returns>
        public static int ExecuteNonQueryProc(string cmdText, params OleDbParameter[] commandParameters)
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
        public static int ExecuteNonQueryProc(OleDbTransaction trans, string cmdText, params OleDbParameter[] commandParameters)
        {
            return ExecuteNonQuery(trans, CommandType.StoredProcedure, cmdText, commandParameters);
        }

        private static int ExecuteNonQuery(CommandType cmdType, string cmdText, params OleDbParameter[] commandParameters)
        {
            OleDbCommand cmd = new OleDbCommand();

            using (OleDbConnection conn = new OleDbConnection(DB_CONNECTION_STRING))
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);

                int val = cmd.ExecuteNonQuery();

                cmd.Parameters.Clear();

                return val;
            }
        }

        private static int ExecuteNonQuery(OleDbTransaction trans, CommandType cmdType, string cmdText, params OleDbParameter[] commandParameters)
        {
            OleDbCommand cmd = new OleDbCommand();

            PrepareCommand(cmd, trans.Connection, trans, cmdType, cmdText, commandParameters);

            int val = cmd.ExecuteNonQuery();

            cmd.Parameters.Clear();

            return val;

        }

        #endregion

        #region ִ�в�ѯ������OleDbDataReader

        /// <summary>
        /// ִ�в�ѯ������OleDbDataReader
        /// </summary>
        /// <param name="commandText">SQL���</param>
        /// <param name="commandParameters">ִ������Ĳ�����</param>
        /// <returns>һ�����������OleDbDataReader</returns>
        public static OleDbDataReader ExecuteReader(string cmdText, params OleDbParameter[] commandParameters)
        {
            return ExecuteReader(CommandType.Text, cmdText, commandParameters);
        }

        /// <summary>
        /// ִ�в�ѯ������OleDbDataReader(�洢����)
        /// </summary>
        /// <param name="commandText">�洢��������</param>
        /// <param name="commandParameters">ִ������Ĳ�����</param>
        /// <returns>һ�����������OleDbDataReader</returns>
        public static OleDbDataReader ExecuteReaderProc(string cmdText, params OleDbParameter[] commandParameters)
        {
            return ExecuteReader(CommandType.StoredProcedure, cmdText, commandParameters);
        }

        public static OleDbDataReader ExecuteReader(CommandType cmdType, string cmdText, params OleDbParameter[] commandParameters)
        {
            OleDbCommand cmd = new OleDbCommand();

            OleDbConnection conn = new OleDbConnection(DB_CONNECTION_STRING);

            try
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);

                OleDbDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

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
        public static object ExecuteScalar(string cmdText, params OleDbParameter[] commandParameters)
        {
            return ExecuteScalar(CommandType.Text, cmdText, commandParameters);
        }

        /// <summary>
        /// ִ�в��������ر��е�һ�У���һ�е�ֵ(�洢����)
        /// </summary>
        /// <param name="commandText">�洢��������</param>
        /// <param name="commandParameters">ִ������Ĳ�����</param>        
        /// <returns>���صĶ���</returns>
        public static object ExecuteScalarProc(string cmdText, params OleDbParameter[] commandParameters)
        {
            return ExecuteScalar(CommandType.StoredProcedure, cmdText, commandParameters);
        }

        public static object ExecuteScalar(CommandType cmdType, string cmdText, params OleDbParameter[] commandParameters)
        {
            OleDbCommand cmd = new OleDbCommand();

            using (OleDbConnection connection = new OleDbConnection(DB_CONNECTION_STRING))
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
        public static DataTable ExecuteDataTable(string commandText, params OleDbParameter[] commandParameters)
        {
            return ExecuteDataSet(commandText, commandParameters).Tables[0];
        }

        /// <summary>
        /// ִ��һ������������ݱ�(�洢����)
        /// </summary>
        /// <param name="commandText">�洢��������</param>
        /// <param name="commandParameters">ִ������Ĳ�����</param>
        /// <returns>�������ݱ�</returns>
        public static DataTable ExecuteDataTableProc(string commandText, params OleDbParameter[] commandParameters)
        {
            return ExecuteDataSetProc(commandText, commandParameters).Tables[0];
        }

        /// <summary>
        /// ִ��һ������������ݼ�
        /// </summary>
        /// <param name="commandText">SQL���</param>
        /// <param name="commandParameters">ִ������Ĳ�����</param>
        /// <returns>�������ݼ�</returns>
        public static DataSet ExecuteDataSet(string commandText, params OleDbParameter[] commandParameters)
        {
            return ExecuteDataSet(CommandType.Text, commandText, commandParameters);
        }

        /// <summary>
        /// ִ��һ������������ݼ�(�洢����)
        /// </summary>
        /// <param name="commandText">�洢��������</param>
        /// <param name="commandParameters">ִ������Ĳ�����</param>
        /// <returns>�������ݼ�</returns>
        public static DataSet ExecuteDataSetProc(string commandText, params OleDbParameter[] commandParameters)
        {
            return ExecuteDataSet(CommandType.StoredProcedure, commandText, commandParameters);
        }

        public static DataSet ExecuteDataSet(CommandType cmdType, string commandText, params OleDbParameter[] commandParameters)
        {

            OleDbCommand cmd = new OleDbCommand();

            using (OleDbConnection conn = new OleDbConnection(DB_CONNECTION_STRING))
            {
                PrepareCommand(cmd, conn, null, cmdType, commandText, commandParameters);

                OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                cmd.Parameters.Clear();
                return ds;
            }
        }

        #endregion

        /// <summary>
        /// ����OleDbCommand����
        /// </summary>
        /// <param name="cmd">OleDbCommand����</param>
        /// <param name="conn">OleDbConnection ����</param>
        /// <param name="trans">OleDbTransaction ����</param>
        /// <param name="cmdType">CommandType(ִ�д洢���̻�SQL���)</param>
        /// <param name="cmdText">�洢�������ƻ�SQL���</param>
        /// <param name="cmdParms">�������õ��Ĳ�����</param>
        private static void PrepareCommand(OleDbCommand cmd, OleDbConnection conn, OleDbTransaction trans, CommandType cmdType, string cmdText, OleDbParameter[] cmdParms)
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
                foreach (OleDbParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
            }
        }
    }
}

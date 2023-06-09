using DataAccessLayer_PaulBikeStore.Repository.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer_PaulBikeStore.Repository.Implementations
{
    public class SqlHelper : ISqlHelper
    {
        private readonly string connectionString;
        public SqlHelper(IConfiguration configuration)
        {
            this.connectionString = configuration["ConnectionStrings:PaulBikeStoreDB"]!;
        }

        #region Reader
        /// Returns a datareader for the sql command

        public SqlDataReader ExecuteReader(string cmdText, CommandType type, SqlParameter[]? prms =null)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);

                using (SqlCommand cmd = new SqlCommand(cmdText, conn))
                {
                    cmd.CommandType = type;
                    cmd.CommandTimeout = 1000;

                    if (prms != null)
                    {
                        foreach (SqlParameter p in prms)
                        {
                            cmd.Parameters.Add(p);
                        }
                    }
                    conn.Open();
                    return cmd.ExecuteReader(CommandBehavior.CloseConnection);
                }
            }
            catch (Exception e)
            {
                //VIIV_IQ2020.Models.ErrorLog objErrorLogInput = new VIIV_IQ2020.Models.ErrorLog { ErrorDescription = e.StackTrace.ToString(), ErrorLogID = -1, PageName = "" };
                //VIIV_IQ2020.Models.ErrorLogOutput objErrorLogOutput = new VIIV_IQ2020.Models.ErrorLogDAL().SaveErrorLog(objErrorLogInput, new VIIV_IQ2020.Pages.IndexModel().GetUserID("ErrorLog"));
                throw e;
            }
        }

        /// Returns a datareader for the sql command
        public SqlDataReader ExecuteReader(string cmdText, CommandType type)
        {
            try
            {
                return ExecuteReader(cmdText, type, null);
            }
            catch (Exception e)
            {
                //VIIV_IQ2020.Models.ErrorLog objErrorLogInput = new VIIV_IQ2020.Models.ErrorLog { ErrorDescription = e.StackTrace.ToString(), PageName = "" };
                //ErrorLogOutput objErrorLogOutput = new ErrorLogDAL().SaveErrorLog(objErrorLogInput, new VIIV_IQ2020.Pages.IndexModel().GetUserID("ErrorLog"));
                throw e;
            }
        }
        #endregion

        #region DataSet
        /// Returns a dataset for the sql command

        public SqlDataReader ExecuteReaderWithParam(string cmdText, CommandType type, SqlParameter[] prms)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);

                using (SqlCommand cmd = new SqlCommand(cmdText, conn))
                {
                    cmd.CommandType = type;
                    cmd.CommandTimeout = 1000;

                    if (prms != null)
                    {
                        foreach (SqlParameter p in prms)
                        {
                            cmd.Parameters.Add(p);
                        }
                    }
                    conn.Open();
                    return cmd.ExecuteReader(CommandBehavior.CloseConnection);
                }
            }
            catch (Exception e)
            {
                // VIIV_IQ2020.Models.ErrorLog objErrorLogInput = new VIIV_IQ2020.Models.ErrorLog { ErrorDescription = e.StackTrace.ToString(), PageName = "" };
                //ErrorLogOutput objErrorLogOutput = new ErrorLogDAL().SaveErrorLog(objErrorLogInput, new VIIV_IQ2020.Pages.IndexModel().GetUserID("ErrorLog"));
                throw e;
            }
        }

        public DataSet ExecuteDataSet(string cmdText, CommandType type, SqlParameter[] prms, out SqlCommand cmd)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    DataSet ds = new DataSet();

                    using (cmd = new SqlCommand(cmdText, conn))
                    {
                        cmd.CommandType = type;
                        cmd.CommandTimeout = 1000;

                        if (prms != null)
                        {
                            foreach (SqlParameter p in prms)
                            {
                                cmd.Parameters.Add(p);
                            }
                        }
                        SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                        adpt.Fill(ds);
                        return ds;
                    }
                }
            }
            catch (Exception e)
            {
                //VIIV_IQ2020.Models.ErrorLog objErrorLogInput = new VIIV_IQ2020.Models.ErrorLog { ErrorDescription = e.StackTrace.ToString(), PageName = "" };

                //  ErrorLogOutput objErrorLogOutput = new ErrorLogDAL().SaveErrorLog(objErrorLogInput, new VIIV_IQ2020.Pages.IndexModel().GetUserID("ErrorLog"));
                //VIIV_IQ2020.Models.ErrorLog objErrorLogInput = new VIIV_IQ2020.Models.ErrorLog { ErrorDescription = e.Message.ToString(), PageName = "" };
                //ErrorLogOutput objErrorLogOutput = new ErrorLogDAL().SaveErrorLog(objErrorLogInput, "bds28996");
                throw e;
            }
        }

        /// Returns a dataset for the sql command
        public DataSet ExecuteDataSet(string cmdText, CommandType type)
        {
            try
            {
                SqlCommand cmd;
                return ExecuteDataSet(cmdText, type, null, out cmd);
            }
            catch (Exception e)
            {
                //    VIIV_IQ2020.Models.ErrorLog objErrorLogInput = new VIIV_IQ2020.Models.ErrorLog { ErrorDescription = e.StackTrace.ToString(), PageName = "" };
                //  ErrorLogOutput objErrorLogOutput = new ErrorLogDAL().SaveErrorLog(objErrorLogInput, new VIIV_IQ2020.Pages.IndexModel().GetUserID("ErrorLog"));
                throw e;
            }
        }
        #endregion

        #region NonQuery
        /// Executes a non query
        public int ExecuteNonQuery(string cmdText, CommandType type, SqlParameter[] prms)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(cmdText, conn))
                    {
                        cmd.CommandType = type;
                        cmd.CommandTimeout = 1000;

                        if (prms != null)
                        {
                            foreach (SqlParameter p in prms)
                            {
                                cmd.Parameters.Add(p);
                            }
                        }
                        conn.Open();
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                //VIIV_IQ2020.Models.ErrorLog objErrorLogInput = new VIIV_IQ2020.Models.ErrorLog { ErrorDescription = e.Message.ToString() + "-" + e.StackTrace.ToString(), PageName = "" };
                // ErrorLogOutput objErrorLogOutput = new ErrorLogDAL().SaveErrorLog(objErrorLogInput, new VIIV_IQ2020.Pages.IndexModel().GetUserID("ErrorLog"));
                throw e;
            }
        }

        public int ExecuteNonQuery(string cmdText, CommandType type, SqlParameter[] prms, out SqlCommand cmd)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (cmd = new SqlCommand(cmdText, conn))
                    {
                        cmd.CommandType = type;
                        cmd.CommandTimeout = 1000;

                        if (prms != null)
                        {
                            foreach (SqlParameter p in prms)
                            {
                                cmd.Parameters.Add(p);
                            }
                        }
                        conn.Open();
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                //VIIV_IQ2020.Models.ErrorLog objErrorLogInput = new VIIV_IQ2020.Models.ErrorLog { ErrorDescription = e.Message.ToString() + "-" + e.StackTrace.ToString(), PageName = "" };
                // ErrorLogOutput objErrorLogOutput = new ErrorLogDAL().SaveErrorLog(objErrorLogInput, new VIIV_IQ2020.Pages.IndexModel().GetUserID("ErrorLog"));
                throw e;
            }
        }

        public string ExecuteQueryWithTrans(string Cmdtext, CommandType type, SqlParameter[] prms)
        {
            string vReturnResult;
            SqlConnection conn = new SqlConnection(connectionString);
            SqlTransaction MyTrans = null;

            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                MyTrans = conn.BeginTransaction();

                using (SqlCommand cmd = new SqlCommand(Cmdtext, conn, MyTrans))
                {
                    cmd.CommandType = type;
                    cmd.CommandTimeout = 1000;

                    if (prms != null)
                    {
                        foreach (SqlParameter p in prms)
                        {
                            cmd.Parameters.Add(p);
                        }
                    }
                    vReturnResult = cmd.ExecuteNonQuery().ToString();
                    MyTrans.Commit();
                    return vReturnResult;
                }
            }
            catch (Exception e)
            {
                if (conn.State == ConnectionState.Open)
                {
                    MyTrans.Rollback();
                    conn.Close();
                }
                conn.Dispose();
                //VIIV_IQ2020.Models.ErrorLog objErrorLogInput = new VIIV_IQ2020.Models.ErrorLog { ErrorDescription = e.Message.ToString() + "-" + e.StackTrace.ToString(), PageName = "" };
                //ErrorLogOutput objErrorLogOutput = new ErrorLogDAL().SaveErrorLog(objErrorLogInput, new VIIV_IQ2020.Pages.IndexModel().GetUserID("ErrorLog"));
                throw e;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                conn.Dispose();
            }
        }

        /// Executes a non query
        public int ExecuteNonQuery(string cmdText, CommandType type)
        {
            try
            {
                return ExecuteNonQuery(cmdText, type, null);
            }
            catch (Exception e)
            {
                //VIIV_IQ2020.Models.ErrorLog objErrorLogInput = new VIIV_IQ2020.Models.ErrorLog { ErrorDescription = e.StackTrace.ToString(), PageName = "" };
                //ErrorLogOutput objErrorLogOutput = new ErrorLogDAL().SaveErrorLog(objErrorLogInput, new VIIV_IQ2020.Pages.IndexModel().GetUserID("ErrorLog"));
                throw e;
            }
        }
        #endregion

        #region Scalar
        /// Returns the scalar object of the query
        public object ExecuteScalar(string cmdText, CommandType type, SqlParameter[] prms)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(cmdText, conn))
                    {
                        cmd.CommandType = type;
                        cmd.CommandTimeout = 1000;

                        if (prms != null)
                        {
                            foreach (SqlParameter p in prms)
                            {
                                cmd.Parameters.Add(p);
                            }
                        }
                        conn.Open();
                        return cmd.ExecuteScalar();
                    }
                }
            }
            catch (Exception e)
            {
                //VIIV_IQ2020.Models.ErrorLog objErrorLogInput = new VIIV_IQ2020.Models.ErrorLog { ErrorDescription = e.StackTrace.ToString(), PageName = "" };
                //ErrorLogOutput objErrorLogOutput = new ErrorLogDAL().SaveErrorLog(objErrorLogInput, new VIIV_IQ2020.Pages.IndexModel().GetUserID("ErrorLog"));
                throw e;
            }
        }

        /// Returns the scalar object of the query
        public object ExecuteScalar(string cmdText, CommandType type)
        {
            try
            {
                return ExecuteScalar(cmdText, type, null);
            }
            catch (Exception e)
            {
                //VIIV_IQ2020.Models.ErrorLog objErrorLogInput = new VIIV_IQ2020.Models.ErrorLog { ErrorDescription = e.StackTrace.ToString(), PageName = "" };
                //ErrorLogOutput objErrorLogOutput = new ErrorLogDAL().SaveErrorLog(objErrorLogInput, new VIIV_IQ2020.Pages.IndexModel().GetUserID("ErrorLog"));
                throw e;
            }
        }
        #endregion

        #region ValuePicker
        /// <summary>
        /// Return value as per given seprator or idex
        /// </summary>
        /// <param name="strString">Passed String</param>
        /// <param name="count">Index for string</param>
        /// <param name="Seprator">Seprator for string</param>
        /// <returns> string </returns>
        public string StrPicker(string strString, int count = 1, char Seprator = ':')
        {
            string[] vSplitStr = strString.Split(Seprator);

            if (vSplitStr.Length > 1)
            {
                return vSplitStr[count - 1].ToString();
            }
            else
            {
                return vSplitStr[0].ToString();
            }
        }
        #endregion

        #region Bulk Copy
        public void WriteToServer(string DestinationTableName, DataTable dtData)
        {
            try
            {
                using (var bulkCopy = new SqlBulkCopy(connectionString, SqlBulkCopyOptions.Default))
                {
                    bulkCopy.BatchSize = 100;
                    bulkCopy.DestinationTableName = DestinationTableName;
                    bulkCopy.WriteToServer(dtData);
                }
            }
            catch (Exception e)
            {
                //VIIV_IQ2020.Models.ErrorLog objErrorLogInput = new VIIV_IQ2020.Models.ErrorLog { ErrorDescription = e.StackTrace.ToString(), PageName = "" };
                //ErrorLogOutput objErrorLogOutput = new ErrorLogDAL().SaveErrorLog(objErrorLogInput, new VIIV_IQ2020.Pages.IndexModel().GetUserID("ErrorLog"));
                throw e;
            }
        }
        #endregion
    }
}
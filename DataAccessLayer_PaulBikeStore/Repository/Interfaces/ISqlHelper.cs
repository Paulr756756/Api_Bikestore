using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer_PaulBikeStore.Repository.Interfaces
{
    public interface ISqlHelper
    {
        DataSet ExecuteDataSet(string cmdText, CommandType type);
        DataSet ExecuteDataSet(string cmdText, CommandType type, SqlParameter[] prms, out SqlCommand cmd);
        int ExecuteNonQuery(string cmdText, CommandType type);
        int ExecuteNonQuery(string cmdText, CommandType type, SqlParameter[] prms);
        int ExecuteNonQuery(string cmdText, CommandType type, SqlParameter[] prms, out SqlCommand cmd);
        string ExecuteQueryWithTrans(string Cmdtext, CommandType type, SqlParameter[] prms);
        SqlDataReader ExecuteReader(string cmdText, CommandType type);
        SqlDataReader ExecuteReader(string cmdText, CommandType type, SqlParameter[]? prms=null);
        SqlDataReader ExecuteReaderWithParam(string cmdText, CommandType type, SqlParameter[] prms);
        object ExecuteScalar(string cmdText, CommandType type);
        object ExecuteScalar(string cmdText, CommandType type, SqlParameter[] prms);
        string StrPicker(string strString, int count = 1, char Seprator = ':');
        void WriteToServer(string DestinationTableName, DataTable dtData);
    }
}
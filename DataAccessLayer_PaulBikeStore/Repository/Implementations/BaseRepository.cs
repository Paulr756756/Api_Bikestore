using DataAccessLayer_PaulBikeStore.Repository.Interfaces;
using System;
using System.Data.SqlClient;
using System.Reflection;

namespace DataAccessLayer_PaulBikeStore.Repository.Implementations

{
    public class BaseRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly ISqlHelper sqlHelper;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlHelper"></param>
        public BaseRepository(ISqlHelper sqlHelper)
        {
            this.sqlHelper = sqlHelper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="databaseModel"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<T> Add<T>(DatabaseModel databaseModel)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="databaseModel"></param>
        /// <returns></returns>
        public async Task<List<TResult>> Get<TResult>(DatabaseModel databaseModel)
        {
            SqlDataReader dr = databaseModel.SqlParameters == null ? await Task.FromResult(sqlHelper.ExecuteReader(databaseModel.ProcedureName!, databaseModel.CommandType)) : await Task.FromResult(sqlHelper.ExecuteReader(databaseModel.ProcedureName!, databaseModel.CommandType, databaseModel.SqlParameters.ToArray()));
            return InitializeDataReader<TResult>(dr);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="databaseModel"></param>
        /// <returns></returns>
        public async Task<List<T>> GetById<T>(DatabaseModel databaseModel)
        {
            SqlDataReader dr = await Task.FromResult(sqlHelper.ExecuteReader(databaseModel.ProcedureName!, databaseModel.CommandType, databaseModel.SqlParameters!.ToArray()));
            return InitializeDataReader<T>(dr);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="databaseModel"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<T> Remove<T>(DatabaseModel databaseModel)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="databaseModel"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<T> Update<T>(DatabaseModel databaseModel)
        {
            throw new NotImplementedException();
        }


        private List<TResult> InitializeDataReader<TResult>(SqlDataReader dr)
        {
            List<TResult> list = new List<TResult>();
            Type type = typeof(TResult);
            var properties = type.GetProperties();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    var element = (TResult)Activator.CreateInstance(typeof(TResult))!;
                    foreach (var prp in properties)
                    {
                        PropertyInfo prop = type.GetProperty(prp.Name)!;
                        try
                        {
                            if (dr[$"{prp.Name}"] == DBNull.Value)
                            {
                                prop.SetValue(element, null);
                            }
                            else
                            {
                                prop.SetValue(element, dr[$"{prp.Name}"]);
                            }
                        }
                        catch (Exception ex)
                        {

                        }

                    }
                    list.Add(element);
                }
            }
            dr.Close();
            return list;
        }
    }
}


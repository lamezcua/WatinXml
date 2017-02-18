using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace QaCommon
{
    class SqlHelper
    {
        readonly string connectionString;
        public string ConnectionString
        {
            get { return connectionString; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="theConnectionString"></param>
        public SqlHelper(string theConnectionString)
        {
            connectionString = theConnectionString;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public DataTable GetResultTable(string query)
        {
            DataTable table = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = new SqlCommand(
                    query, connection);
                adapter.Fill(table);
            }
            return table;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public DataSet GetDataSet(string query)
        {
            DataSet dataset = new DataSet();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = new SqlCommand(
                    query, connection);
                adapter.Fill(dataset);
            }
            return dataset;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public string GetResult(string query)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                object retObj = cmd.ExecuteScalar();
                return retObj.ToString();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        public void ExecuteQuery(string query)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    
    }
}

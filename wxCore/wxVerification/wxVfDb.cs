using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Data.SqlClient;

namespace wxCore
{
    /// <summary>
    /// Verify a result on database
    /// </summary>
    [XmlType]
    [Serializable]
    public class wxVfDb : wxVerifier
    {
        public wxVfDb() : this("", "","") { }

        public wxVfDb(string name, string inQuery, string expected_result)
            : base(name, expected_result)
        {
            query = inQuery;
            exResult = expected_result;
        }

        public string query;
        [XmlElement]
        public string Query
        {
            get { return query; }
            set { query = value; }
        }

        private string exResult;
        [XmlElement]
        public string ExpectedResult
        {
            get { return exResult; }
            set { exResult = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override bool Verify()
        {
            if (query == String.Empty)
                throw new ApplicationException("DB Verifier Error: Query cannnot be empty");

            using (SqlConnection conn = new SqlConnection(Wxs.Instance.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                try
                {
                    string result = cmd.ExecuteScalar().ToString();
                    if (String.Compare(result, exResult, true) == 0)
                    {
                        Wxs.Instance.Log.InfoFormat("Test DB {0} passed, result {1} matches", Name, result);
                        return true;
                    }
                    else
                    {
                        Wxs.Instance.Log.WarnFormat("Test DB {0} failed : Expected Result {1}!= Actual Result {2}",
                            Name, result, exResult);
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    Wxs.Instance.Log.ErrorFormat("Error: Exception {0} thrown executing DB Test {1}!", ex.Message, Name);
                    return false;
                }
            }
        }
    }
}

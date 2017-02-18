using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using WatiN.Core;


namespace wxCore
{
    public sealed class Wxs
    {
        static readonly Wxs instance = new Wxs();

        static Wxs() { }

        private Wxs() { }

        public static Wxs Instance
        {
            get { return instance; }
        }

        string connectionString;
        public string ConnectionString
        {
            get { return connectionString; }
            set { connectionString = value; }
        }

        IE ie;
        public IE Ie
        {
            get { return ie; }
            set
            {
                ie = value;
                BaseUrl = String.Format("{0}://{1}/", ie.Uri.Scheme, ie.Uri.Host);
            }
        }
        
        ILog log;
        public ILog Log
        {
            get { return log; }
            set { log = value; }
        }


        string baseUrl;
        public string BaseUrl
        {
            get { return baseUrl; }
            set { baseUrl = value; }
        }
    }
}
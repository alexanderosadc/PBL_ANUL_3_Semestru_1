﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace Test_API.Common
{
    public static class Tools
    {
        public static string ConnectionString { get; set; }


        //public static string GetConnectionString(string name = "SecurityDB")
        //{
        //    return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        //}


        //public static string ConnectionString (string name)
        //{
        //    return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        //}

    }
}

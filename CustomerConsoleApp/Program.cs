﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            DbHandler.QueryDb("select * from Customers");
        }
    }
}

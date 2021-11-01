﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Football.Database
{
    public class DbSettings
    {
        public string Hostname { get; set; }
        public int Port { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }

        public string DbName { get; set; }
    }
}

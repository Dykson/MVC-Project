﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCProject.Entity
{
    class User
    {
        public int Id { get; set; }
        public string Login {get; set;}
        public string Password {get; set;}
        public string Firstname { get; set;}
        public string Lastname { get; set; }
        public string Position { get; set; }
    }
}

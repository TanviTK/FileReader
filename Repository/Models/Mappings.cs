﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models
{
    public class Mappings
    {
        public int MappingId { get; set; }
        public string MapType { get; set; }
        public string MapName { get; set; }
        public string ExecutionType { get; set; }
        public int SettingId { get; set; }
    }
}

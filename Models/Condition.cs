﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CHIMS.WebApi.Models
{
    public class Condition: Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
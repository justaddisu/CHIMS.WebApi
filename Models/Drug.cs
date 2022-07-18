using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CHIMS.WebApi.Models
{
    public class Drug: Entity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Repitation { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
    }
}


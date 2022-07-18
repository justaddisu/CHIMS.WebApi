using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CHIMS.WebApi.Models
{
    public class Kebele: Entity
    {
        public string Name { get; set; }

        //Navigation Properties
        public int WeredaId { get; set; }
        public Wereda Wereda { get; set; }
       
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CHIMS.WebApi.Models
{
    public class Service: Entity
    {
        public string Name { get; set; }
        public decimal Price  { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }


        //Navigation Properties
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}

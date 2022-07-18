using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CHIMS.WebApi.Models
{
    public class Ward:Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }


        //davigation property
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}

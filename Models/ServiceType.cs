using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CHIMS.WebApi.Models
{
    public class ServiceType: Entity
    {
        public string Name { get; set; }

        //Navigation Properties
        public List<Patient> Patients { get; set; }
    }
}

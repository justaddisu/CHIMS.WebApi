using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CHIMS.WebApi.Models
{
    public class Patient: Entity
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Photo { get; set; }
        public string IdNumber { get; set; }
        public string MRM { get; set; }


        //Navigation properties
        public int WeredaId { get; set; }
        public Wereda Wereda { get; set; }
        public int? OrganizationId { get; set; }
        public Organization Organization { get; set; }
        public int KebeleId { get; set; }
        public Kebele Kebele { get; set; }
        public int ServiceTypeId { get; set; }
        public ServiceType ServiceType { get; set; }
        public bool IsOrganization { get; set; }


    }
}


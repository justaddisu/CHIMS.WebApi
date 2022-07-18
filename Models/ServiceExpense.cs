using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CHIMS.WebApi.Models
{
    public class ServiceExpense : Entity
    {
        public int PatientId { get; set; }
        public Patient Patient { get; set; }        
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int ServiceId { get; set; }
        public Service Service { get; set; }
        public decimal Price { get; set; }
        public bool IsExempted { get; set; }

    }
}


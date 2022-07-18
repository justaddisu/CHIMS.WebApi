using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CHIMS.WebApi.Models
{
    public class BedExpense: Entity
    {
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public int ConditionId { get; set; }
        public Condition Condition { get; set; }
        public int BedId { get; set; }
        public Bed Bed { get; set; }
        public DateTime DateOfAdmission { get; set; }
        public DateTime DateOfDischarge { get; set; }
        public decimal Price { get; set; }
        public decimal ServiceCharge { get; set; }
        public bool IsExempted { get; set; }

    }
}



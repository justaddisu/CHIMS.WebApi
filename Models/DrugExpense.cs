using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CHIMS.WebApi.Models
{
    public class DrugExpense :Entity
    {
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public int DrugId { get; set; }
        public Drug Drug { get; set; }
        public decimal Price { get; set; }
        public string PrescriberFullName { get; set; }
        public string PrescriberRegistration { get; set; }
        public DateTime PrescriptionDate { get; set; }
        public string EvaluaterFullName { get; set; }
        public string EvaluaterRegistration { get; set; }
        public DateTime EvaluationDate { get; set; }
        public bool IsExempted { get; set; }
    }
}


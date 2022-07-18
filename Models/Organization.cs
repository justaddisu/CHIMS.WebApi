using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CHIMS.WebApi.Models
{
    public class Organization: Entity
    {
        public string Name { get; set; }
        public string AgreementLetter { get; set; }
        public DateTime AgreementStarted { get; set; }
        public DateTime AgreementEnd { get; set; }


        //Navigation Properties
        public int WeredaId { get; set; }
        public Wereda Wereda { get; set; }
        public int KebeleId { get; set; }
        public Kebele Kebele { get; set; }
       
    }
}


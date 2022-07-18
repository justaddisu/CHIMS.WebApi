using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CHIMS.WebApi.Models
{
    public class Entity
    {
        public int Id { get; set; }        
        public string CreateBy { get; set; }        
        public DateTime CreateAt { get; set; }        
        public string UpdateBy { get; set; }        
        public DateTime UpdateAt { get; set; }
    }
}

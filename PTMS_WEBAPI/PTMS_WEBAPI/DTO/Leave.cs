using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PTMS_WEBAPI.DTO
{

    
    [Table("LeaveInformation")]
    public class Leave
    {
        public int Id{get;set;}
        public string LeaveReason{get;set;}       
        public DateTime StartDate{get;set;}
        public DateTime EndDate{get;set;}
        public int LeaveType{get;set;}
        public int UserId{get;set;}
    }
}

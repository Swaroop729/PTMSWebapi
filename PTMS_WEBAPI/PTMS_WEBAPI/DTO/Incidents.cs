using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTMS_WEBAPI.DTO
{
    public class Incidents
    {
        public int Id{get;set;}
        public string IncidentId{get;set;}
        public int Percentage{get;set;}
        public string Comment{get;set;}
        public string ApplicationName{get;set;}
        public DateTime CreatedDate{get;set;}
        public DateTime ModifiedDate{get;set;}
        public DateTime ResolutionDate{get;set;}
        public int UserId{get;set;}
    }
}

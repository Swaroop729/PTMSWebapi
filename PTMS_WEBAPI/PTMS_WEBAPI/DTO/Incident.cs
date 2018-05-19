using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTMS_WEBAPI.DTO
{
    public class Incident
    {
        public Incident(int id, string incidentId, int percentage, string comment, string applicationName, DateTime createdDate, DateTime modifiedDate, DateTime resolutionDate, int userId)
        {
            Id = id;
            IncidentId = incidentId;
            Percentage = percentage;
            Comment = comment;
            ApplicationName = applicationName;
            CreatedDate = createdDate;
            ModifiedDate = modifiedDate;
            ResolutionDate = resolutionDate;
            UserId = userId;
        }

        private int Id ;
        private string IncidentId ;
        private int Percentage ;
        private string Comment ;
        private string ApplicationName ;
        private DateTime CreatedDate ;
        private DateTime ModifiedDate ;
        private DateTime ResolutionDate ;
        private int UserId ;

        public int Id1 { get => Id; set => Id = value; }
        public string IncidentId1 { get => IncidentId; set => IncidentId = value; }
        public int Percentage1 { get => Percentage; set => Percentage = value; }
        public string Comment1 { get => Comment; set => Comment = value; }
        public string ApplicationName1 { get => ApplicationName; set => ApplicationName = value; }
        public DateTime CreatedDate1 { get => CreatedDate; set => CreatedDate = value; }
        public DateTime ModifiedDate1 { get => ModifiedDate; set => ModifiedDate = value; }
        public DateTime ResolutionDate1 { get => ResolutionDate; set => ResolutionDate = value; }
        public int UserId1 { get => UserId; set => UserId = value; }
    }
}

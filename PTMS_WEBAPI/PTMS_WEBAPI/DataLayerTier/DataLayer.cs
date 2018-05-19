using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PTMS_WEBAPI.DTO;
using System.Data.SqlClient;

namespace PTMS_WEBAPI.DataLayerTier
{
    public class DataLayer
    {
        IConfiguration configuration;
        SqlConnection connection;


        public DataLayer(IConfiguration _configuration)
        {
            this.configuration = _configuration;
            string connectionstr = configuration.GetConnectionString("localDb");
            connection = new SqlConnection(connectionstr);
        }

        public IEnumerable<Incident> getAllIncidents(int id)
        {
            List<Incident> incidents = new List<Incident>();
            SqlCommand command;
            if (id == 0) {
                command = new SqlCommand("select * from Incidents" , connection);
            }
            else
            {
                command = new SqlCommand("select * from Incidents where id =" + id, connection);
            }

            connection.Open();
           using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Incident incident = new Incident(
                        Convert.ToInt32(reader["Id"]), 
                        Convert.ToString(reader["IncidentId"]),
                        Convert.ToInt32(reader["Percentage"]),
                        Convert.ToString(reader["Comment"]),
                        Convert.ToString(reader["ApplicationName"]),
                        Convert.ToDateTime(reader["CreatedDate"]),
                        Convert.ToDateTime(reader["ModifiedDate"]),
                        Convert.ToDateTime(reader["ResolutionDate"]),
                        Convert.ToInt32(reader["UserId"])
                        );
                    incidents.Add(incident);
                }
            }

                return incidents;

                   }

        public Boolean AddIncident(Incident obj)
        {
            try
            {

                return true;
            }
            catch (Exception )
            {

                return false;
            }
        }
        
    }
}

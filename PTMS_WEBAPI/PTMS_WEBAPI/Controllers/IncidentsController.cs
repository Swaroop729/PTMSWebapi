using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PTMS_WEBAPI.DTO;
using PTMS_WEBAPI.DataLayerTier;


namespace PTMS_WEBAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Incidents")]
    public class IncidentsController : Controller
    {

        IConfiguration configuration;

        public IncidentsController(IConfiguration _configuration)
        {
            configuration = _configuration;
            string constr = configuration.GetConnectionString("localDb");
        }

        // GET: api/Incidents
        [HttpGet]
        public IEnumerable<Incident> Get()
        {
            DataLayer dataLayer = new DataLayer(configuration);
            var allIncidents = dataLayer.getAllIncidents(0);
            return allIncidents;
        }

        // GET: api/Incidents/5
        [HttpGet("{id}", Name = "GetIncident")]
        public Incident Get(int id)
        {
            DataLayer dataLayer = new DataLayer(configuration);
            // we can use the Elementat property to return one object in a list of objects
            return dataLayer.getAllIncidents(id).ElementAt(0);
        }
        
        // POST: api/Incidents
        [HttpPost]
        public void Post([FromBody]Incident obj)
        {
            DataLayer dataLayer = new DataLayer(configuration);


        }
        
        // PUT: api/Incidents/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

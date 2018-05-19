using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PTMS_WEBAPI.DTO;

namespace PTMS_WEBAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Incident/")]
    public class IncidentController : Controller
    {
        private PTMSDBContext mycontext;
        public IncidentController(PTMSDBContext _context)
        {
            mycontext = _context;
        }

        // GET: api/Incident
        [HttpGet]
        public IActionResult Get()
        {
            List<Incidents> IncidentsList = mycontext.Incidents.ToList();
            return Ok(IncidentsList);
        }

        // GET: api/Incident/5
        [HttpGet("{id:int}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var existingObj =  mycontext.Incidents.Find(id);
            if (existingObj == null)
             return NotFound();
            return Ok(existingObj);
        }
        
        // POST: api/Incident
        [HttpPost]
        public IActionResult Post([FromBody]Incidents obj)
        {
            mycontext.Incidents.Add(obj);
            mycontext.SaveChanges();
            var url = Url.Link("Get", new { id = obj.Id });
             return Created(url, obj);
        }
        
        // PUT: api/Incident/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Incidents inputobj)
        {
            var obj = mycontext.Incidents.Find(id);
            obj.IncidentId = inputobj.IncidentId;
            obj.Percentage = inputobj.Percentage;
            obj.Comment = inputobj.Comment;
            obj.ApplicationName = inputobj.ApplicationName;
            obj.ResolutionDate = inputobj.ResolutionDate;

            mycontext.SaveChanges();
            return Ok(obj);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingObj = mycontext.Incidents.Find(id);
            if (existingObj == null)
             return NotFound();
        
            mycontext.Incidents.Remove(existingObj);
            
            mycontext.SaveChanges();
        
            return NoContent();
        }
        [Route("GetInCompletedTasksForUser/{UserId:int}/{month}")]
        public IActionResult GetInCompletedTasksForUser( int UserId ,string month ){
            //   string[] months= new string[12] {
            //         "January",
            //         "February",
            //         "March",
            //         "April",
            //         "May",
            //         "June",
            //         "July",
            //         "August",
            //         "September",
            //         "October",
            //         "November",
            //         "December"
            //   };
            // var mon = Array.IndexOf(months,month) +1;
            var ListofIncompleteIncidents = mycontext.Incidents.Where(obj=>obj.UserId==UserId && obj.Percentage<100 &&
                                            Convert.ToDateTime(obj.CreatedDate).ToString("MMMM")==month);
            return Ok(ListofIncompleteIncidents);
        }
    }
}

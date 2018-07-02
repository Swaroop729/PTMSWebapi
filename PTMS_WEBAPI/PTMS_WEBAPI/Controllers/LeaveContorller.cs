using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PTMS_WEBAPI.DTO;


namespace PTMS_WEBAPI.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    public class LeaveController : Controller
    {

         private PTMSDBContext mycontext;

        public LeaveController(PTMSDBContext _context)
        {
           mycontext = _context;
        }

        // GET api/Leaves
        [HttpGet]
        [AllowAnonymous]
        public string Get()
        {
            return  "this action will be return in future";
                //             try{
                //     var UserLeaves =  mycontext.Leaves.Where(c=>c.UserId==id);
                //     return Ok(UserLeaves);
                // }
                // catch (Exception e){
                //         return Content(e.Message);
                // }
        }

        // GET api/Leaves/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try{
                var UserLeave =  mycontext.Leaves.Find(id);
                return Ok(UserLeave);
            }
            catch (Exception e){
                    return Content(e.Message);
            }

        }

        // POST api/Leaves
        [HttpPost]
        public IActionResult AddLeave([FromBody]Leave InputObj)
        {
            if(InputObj!= null){
            mycontext.Leaves.Add(InputObj);
            mycontext.SaveChanges();       
            return CreatedAtAction("Leave Added", InputObj);         
            }
            else{
                return NoContent();
            }
        }

        // PUT api/Leaves/5
        [HttpPut("{id}")]
        public IActionResult EditLeave(int id, [FromBody]Leave InputObj)
        {
            var obj = mycontext.Leaves.Find(id);
            if(obj!= null){
            obj.UserId = InputObj.UserId;
            obj.StartDate = InputObj.StartDate;
            obj.EndDate = InputObj.EndDate;
            obj.LeaveReason = InputObj.LeaveReason;
            obj.LeaveType = InputObj.LeaveType;
            mycontext.SaveChanges();       
            return Ok("Leave Edited !!");  
            }
            else{
                return NoContent();
            }
        }

        // DELETE api/Leaves/5
        [HttpDelete("{id}")]
        public IActionResult DeleteLeave(int id)
        {
            var obj = mycontext.Leaves.Find(id);
            if(obj!= null){
            mycontext.Leaves.Remove(obj);
            mycontext.SaveChanges();       
            return Ok("Leave Deleted !!");  
            }
            else{
                return NoContent();
            }
        }
    }
}

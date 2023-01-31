using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TestAPI.Models;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private APIContext db { get; set; }

        public ProjectsController(APIContext context) { db = context; }

        // GET: api/<UsersController>
        [HttpGet]
        public ActionResult<IEnumerable<Project>> Get()
        {
             return Ok(db.Projects.ToList());

        }

        // POST api/<UsersController>

        [HttpPost]
        public string Post([FromBody] Project projects)
        {
            _ = db.Add(projects);
            db.SaveChanges();
            return "Added";
        }


        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            Project projects = db.Projects.Find(id);

            if (projects == null)
            {
                return ("Project was not Found");
            }

            db.Projects.Remove(projects);
            db.SaveChanges();

            return ("Delete was successful");
        }
    }
}

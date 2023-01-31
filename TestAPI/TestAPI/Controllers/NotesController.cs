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
    public class NotesController : ControllerBase
    {
        private APIContext db { get; set; }

        public NotesController(APIContext context) { db = context; }

        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<Note> Get()
        {
            return db.Notes.ToList();

        }

        // POST api/<UsersController>

        [HttpPost]
        public string Post([FromBody] Note Notes)
        {
            _ = db.Add(Notes);
            db.SaveChanges();
            return "Added";
        }


        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            Note notes = db.Notes.Find(id);

            if (notes == null)
            {
                return ("Notes were not Found");
            }

            db.Notes.Remove(notes);
            db.SaveChanges();

            return ("Delete was successful");
        }
    }
}

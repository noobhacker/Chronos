using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ChronosWebAPI.Models;

namespace ChronosWebAPI.Controllers
{
    public class Student_SubjectController : ApiController
    {
        private ChronosWebAPIContext db = new ChronosWebAPIContext();

        // GET: api/Student_Subject
        public IQueryable<Student_Subject> GetStudent_Subject()
        {
            return db.Student_Subject;
        }

        // GET: api/Student_Subject/5
        [ResponseType(typeof(Student_Subject))]
        public async Task<IHttpActionResult> GetStudent_Subject(int id)
        {
            Student_Subject student_Subject = await db.Student_Subject.FindAsync(id);
            if (student_Subject == null)
            {
                return NotFound();
            }

            return Ok(student_Subject);
        }

        // PUT: api/Student_Subject/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutStudent_Subject(int id, Student_Subject student_Subject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != student_Subject.Id)
            {
                return BadRequest();
            }

            db.Entry(student_Subject).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Student_SubjectExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Student_Subject
        [ResponseType(typeof(Student_Subject))]
        public async Task<IHttpActionResult> PostStudent_Subject(Student_Subject student_Subject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Student_Subject.Add(student_Subject);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = student_Subject.Id }, student_Subject);
        }

        // DELETE: api/Student_Subject/5
        [ResponseType(typeof(Student_Subject))]
        public async Task<IHttpActionResult> DeleteStudent_Subject(int id)
        {
            Student_Subject student_Subject = await db.Student_Subject.FindAsync(id);
            if (student_Subject == null)
            {
                return NotFound();
            }

            db.Student_Subject.Remove(student_Subject);
            await db.SaveChangesAsync();

            return Ok(student_Subject);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Student_SubjectExists(int id)
        {
            return db.Student_Subject.Count(e => e.Id == id) > 0;
        }
    }
}
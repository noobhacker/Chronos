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
    public class SubjectSessionsController : ApiController
    {
        private ChronosWebAPIContext db = new ChronosWebAPIContext();

        // GET: api/SubjectSessions
        public IQueryable<SubjectSession> GetSubjectSessions()
        {
            return db.SubjectSessions;
        }

        // GET: api/SubjectSessions/5
        [ResponseType(typeof(SubjectSession))]
        public async Task<IHttpActionResult> GetSubjectSession(int id)
        {
            SubjectSession subjectSession = await db.SubjectSessions.FindAsync(id);
            if (subjectSession == null)
            {
                return NotFound();
            }

            return Ok(subjectSession);
        }

        // PUT: api/SubjectSessions/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSubjectSession(int id, SubjectSession subjectSession)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != subjectSession.Id)
            {
                return BadRequest();
            }

            db.Entry(subjectSession).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubjectSessionExists(id))
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

        // POST: api/SubjectSessions
        [ResponseType(typeof(SubjectSession))]
        public async Task<IHttpActionResult> PostSubjectSession(SubjectSession subjectSession)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SubjectSessions.Add(subjectSession);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = subjectSession.Id }, subjectSession);
        }

        // DELETE: api/SubjectSessions/5
        [ResponseType(typeof(SubjectSession))]
        public async Task<IHttpActionResult> DeleteSubjectSession(int id)
        {
            SubjectSession subjectSession = await db.SubjectSessions.FindAsync(id);
            if (subjectSession == null)
            {
                return NotFound();
            }

            db.SubjectSessions.Remove(subjectSession);
            await db.SaveChangesAsync();

            return Ok(subjectSession);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SubjectSessionExists(int id)
        {
            return db.SubjectSessions.Count(e => e.Id == id) > 0;
        }
    }
}
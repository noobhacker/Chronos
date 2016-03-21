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
    public class Subject_SubjectSessionController : ApiController
    {
        private ChronosWebAPIContext db = new ChronosWebAPIContext();

        // GET: api/Subject_SubjectSession
        public IQueryable<Subject_SubjectSession> GetSubject_SubjectSession()
        {
            return db.Subject_SubjectSession;
        }

        // GET: api/Subject_SubjectSession/5
        [ResponseType(typeof(Subject_SubjectSession))]
        public async Task<IHttpActionResult> GetSubject_SubjectSession(int id)
        {
            Subject_SubjectSession subject_SubjectSession = await db.Subject_SubjectSession.FindAsync(id);
            if (subject_SubjectSession == null)
            {
                return NotFound();
            }

            return Ok(subject_SubjectSession);
        }

        // PUT: api/Subject_SubjectSession/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSubject_SubjectSession(int id, Subject_SubjectSession subject_SubjectSession)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != subject_SubjectSession.Id)
            {
                return BadRequest();
            }

            db.Entry(subject_SubjectSession).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Subject_SubjectSessionExists(id))
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

        // POST: api/Subject_SubjectSession
        [ResponseType(typeof(Subject_SubjectSession))]
        public async Task<IHttpActionResult> PostSubject_SubjectSession(Subject_SubjectSession subject_SubjectSession)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Subject_SubjectSession.Add(subject_SubjectSession);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = subject_SubjectSession.Id }, subject_SubjectSession);
        }

        // DELETE: api/Subject_SubjectSession/5
        [ResponseType(typeof(Subject_SubjectSession))]
        public async Task<IHttpActionResult> DeleteSubject_SubjectSession(int id)
        {
            Subject_SubjectSession subject_SubjectSession = await db.Subject_SubjectSession.FindAsync(id);
            if (subject_SubjectSession == null)
            {
                return NotFound();
            }

            db.Subject_SubjectSession.Remove(subject_SubjectSession);
            await db.SaveChangesAsync();

            return Ok(subject_SubjectSession);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Subject_SubjectSessionExists(int id)
        {
            return db.Subject_SubjectSession.Count(e => e.Id == id) > 0;
        }
    }
}
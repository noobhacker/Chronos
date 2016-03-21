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
    public class ConfessionsController : ApiController
    {
        private ChronosWebAPIContext db = new ChronosWebAPIContext();

        // GET: api/Confessions
        public IQueryable<Confession> GetConfessions()
        {
            return db.Confessions;
        }

        // GET: api/Confessions/5
        [ResponseType(typeof(Confession))]
        public async Task<IHttpActionResult> GetConfession(int id)
        {
            Confession confession = await db.Confessions.FindAsync(id);
            if (confession == null)
            {
                return NotFound();
            }

            return Ok(confession);
        }

        // PUT: api/Confessions/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutConfession(int id, Confession confession)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != confession.Id)
            {
                return BadRequest();
            }

            db.Entry(confession).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConfessionExists(id))
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

        // POST: api/Confessions
        [ResponseType(typeof(Confession))]
        public async Task<IHttpActionResult> PostConfession(Confession confession)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Confessions.Add(confession);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = confession.Id }, confession);
        }

        // DELETE: api/Confessions/5
        [ResponseType(typeof(Confession))]
        public async Task<IHttpActionResult> DeleteConfession(int id)
        {
            Confession confession = await db.Confessions.FindAsync(id);
            if (confession == null)
            {
                return NotFound();
            }

            db.Confessions.Remove(confession);
            await db.SaveChangesAsync();

            return Ok(confession);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ConfessionExists(int id)
        {
            return db.Confessions.Count(e => e.Id == id) > 0;
        }
    }
}
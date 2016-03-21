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
    public class ConfessionLikesController : ApiController
    {
        private ChronosWebAPIContext db = new ChronosWebAPIContext();

        // GET: api/ConfessionLikes
        public IQueryable<ConfessionLikes> GetConfessionLikes()
        {
            return db.ConfessionLikes;
        }

        // GET: api/ConfessionLikes/5
        [ResponseType(typeof(ConfessionLikes))]
        public async Task<IHttpActionResult> GetConfessionLikes(int id)
        {
            ConfessionLikes confessionLikes = await db.ConfessionLikes.FindAsync(id);
            if (confessionLikes == null)
            {
                return NotFound();
            }

            return Ok(confessionLikes);
        }

        // PUT: api/ConfessionLikes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutConfessionLikes(int id, ConfessionLikes confessionLikes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != confessionLikes.Id)
            {
                return BadRequest();
            }

            db.Entry(confessionLikes).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConfessionLikesExists(id))
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

        // POST: api/ConfessionLikes
        [ResponseType(typeof(ConfessionLikes))]
        public async Task<IHttpActionResult> PostConfessionLikes(ConfessionLikes confessionLikes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ConfessionLikes.Add(confessionLikes);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = confessionLikes.Id }, confessionLikes);
        }

        // DELETE: api/ConfessionLikes/5
        [ResponseType(typeof(ConfessionLikes))]
        public async Task<IHttpActionResult> DeleteConfessionLikes(int id)
        {
            ConfessionLikes confessionLikes = await db.ConfessionLikes.FindAsync(id);
            if (confessionLikes == null)
            {
                return NotFound();
            }

            db.ConfessionLikes.Remove(confessionLikes);
            await db.SaveChangesAsync();

            return Ok(confessionLikes);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ConfessionLikesExists(int id)
        {
            return db.ConfessionLikes.Count(e => e.Id == id) > 0;
        }
    }
}
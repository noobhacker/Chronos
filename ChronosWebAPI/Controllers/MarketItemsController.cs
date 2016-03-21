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
    public class MarketItemsController : ApiController
    {
        private ChronosWebAPIContext db = new ChronosWebAPIContext();

        // GET: api/MarketItems
        public IQueryable<MarketItem> GetMarketItems()
        {
            return db.MarketItems;
        }

        // GET: api/MarketItems/5
        [ResponseType(typeof(MarketItem))]
        public async Task<IHttpActionResult> GetMarketItem(int id)
        {
            MarketItem marketItem = await db.MarketItems.FindAsync(id);
            if (marketItem == null)
            {
                return NotFound();
            }

            return Ok(marketItem);
        }

        // PUT: api/MarketItems/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMarketItem(int id, MarketItem marketItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != marketItem.Id)
            {
                return BadRequest();
            }

            db.Entry(marketItem).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MarketItemExists(id))
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

        // POST: api/MarketItems
        [ResponseType(typeof(MarketItem))]
        public async Task<IHttpActionResult> PostMarketItem(MarketItem marketItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MarketItems.Add(marketItem);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = marketItem.Id }, marketItem);
        }

        // DELETE: api/MarketItems/5
        [ResponseType(typeof(MarketItem))]
        public async Task<IHttpActionResult> DeleteMarketItem(int id)
        {
            MarketItem marketItem = await db.MarketItems.FindAsync(id);
            if (marketItem == null)
            {
                return NotFound();
            }

            db.MarketItems.Remove(marketItem);
            await db.SaveChangesAsync();

            return Ok(marketItem);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MarketItemExists(int id)
        {
            return db.MarketItems.Count(e => e.Id == id) > 0;
        }
    }
}
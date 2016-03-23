using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ChronosWebAPI.Models;
using Chronos;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using System;

namespace ChronosWebAPI.Controllers
{
    public class MarketItemController : ApiController
    {
        private ChronosWebAPIContext db = new ChronosWebAPIContext();

        [ResponseType(typeof(AddMarketItemViewModel))]
        public async Task<IHttpActionResult> Post([FromBody]AddMarketItemViewModel vm)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //// var vm = JsonConvert.DeserializeObject<ConfessionViewModel>(_vm);

            if (await UserValidator.ValidateUser(vm.student) == false)
                return BadRequest(ModelState);

            db.MarketItems.Add(new MarketItem()
            {
                 ItemName=vm.
            });

            //db.Confessions.Add(new Confession()
            //{
            //    PostDateTime = DateTime.Now,
            //    PostedById = vm.student.Id,
            //    Message = vm.PostMessage
            //});

            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = vm.student.Id }, vm);
        }
    }
}

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
                ItemName = vm.marketItem.ItemName,
                Price = vm.marketItem.Price,
                Description = vm.marketItem.Description,
                ImageUrl = vm.marketItem.ImageUrl,
                PostDateTime = DateTime.Now,
                SellerId = vm.student.Id
            });
            
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = vm.student.Id }, vm);
        }

        [ResponseType(typeof(MarketViewModel))]
        public async Task<IHttpActionResult> Get()
        {
            var result = from a in db.MarketItems
                         select a;


            var returnValue = new MarketViewModel();
            returnValue.itemList = new ObservableCollection<MarketItem>(result);

            return Ok(returnValue);
        }

    }
}

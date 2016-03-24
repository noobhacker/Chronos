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
    public class PlacesController : ApiController
    {
        private ChronosWebAPIContext db = new ChronosWebAPIContext();

        [ResponseType(typeof(PlacesViewModel))]
        public async Task<IHttpActionResult> Get()
        {
            var query = from a in db.Happenings
                         select a;

            var result = new ObservableCollection<HapListItem>();

            foreach(var a in query)
            {
                result.Add(new HapListItem()
                {
                    Id = a.Id, // to bring this go details page
                    ImageUrl = a.ImageUrl,
                    EventName = a.Name,
                    LocationText = a.Location + ", " + a.StartDateTime.ToString("D"),
                    Price = a.Price == 0 ? "Free" : "RM" + a.Price.ToString(),
                    TimeText = a.StartDateTime.ToString("hh.mmtt") + " - " +
                    a.EndDateTime.ToString("hh.mmtt")
                });
            }
            
            var returnValue = new PlacesViewModel();
            returnValue.hapList = new ObservableCollection<HapListItem>(result);

            return Ok(returnValue);
        }
    }
}

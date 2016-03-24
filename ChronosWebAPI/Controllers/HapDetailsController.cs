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
    public class HapDetailsController : ApiController
    {
        private ChronosWebAPIContext db = new ChronosWebAPIContext();

        [ResponseType(typeof(HapDetailsViewModel))]
        public async Task<IHttpActionResult> Get(int id) // id for which detail to get
        {
            var result = from a in db.Happenings
                         where a.Id == id
                         select a;


            var returnValue = new HapDetailsViewModel();
            returnValue.HapDetails = result.ToList()[0];

            return Ok(returnValue);
        }
    }
}

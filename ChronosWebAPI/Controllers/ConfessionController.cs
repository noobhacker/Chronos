using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ChronosWebAPI.Models;
using Chronos;
using System.Collections.ObjectModel;
using System;

namespace ChronosWebAPI.Controllers
{
    public class ConfessionController : ApiController
    {
        private ChronosWebAPIContext db = new ChronosWebAPIContext();

        [ResponseType(typeof(ConfessionViewModel))]
        public async Task<IHttpActionResult> Post([FromBody]ConfessionViewModel vm)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // var vm = JsonConvert.DeserializeObject<ConfessionViewModel>(_vm);

            if (await UserValidator.ValidateUser(vm.student) == false)
                return BadRequest(ModelState);

            db.Confessions.Add(new Confession()
            {
                PostDateTime = DateTime.Now,
                PostedById = vm.student.Id,
                Message = vm.PostMessage
            });
                       
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = vm.student.Id }, vm);
        }

        // get confession based on id later
        [ResponseType(typeof(ConfessionViewModel))]
        public async Task<IHttpActionResult> Get()
        {
            var result = from a in db.Confessions
                         select new ConfessionList()
                         {
                             Id=a.Id,
                             Message=a.Message,
                             PostDateTime=a.PostDateTime
                         };

            //foreach(var r in result)
            //{
            //    var q = from a in db.Confessions
            //             join b in db.ConfessionLikes on a.Id equals b.ConfessionId
            //             where a.Id == r.Id
            //             select a;
            //    //r.Likes = q.ToList().Count();
            //}

            var returnValue = new ConfessionViewModel();
            returnValue.confessionList = new ObservableCollection<ConfessionList>(result);

            return Ok(returnValue);

        }
    }
    
}

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
    public class ConfessionController : ApiController
    {
        private ChronosWebAPIContext db = new ChronosWebAPIContext();

        [ResponseType(typeof(string))]
        public async Task<IHttpActionResult> PostConfession([FromBody]string _vm)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var vm = JsonConvert.DeserializeObject<ConfessionViewModel>(_vm);

            Student stud = await db.Students.FindAsync(vm.student.Id);

            // check if found
            if (stud != null)
            {
                // check if correct id and password
                if (!(stud.Id == vm.student.Id) || !(stud.Password == vm.student.Password))
                    return BadRequest(ModelState);
            }
            else
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
        public async Task<IHttpActionResult> GetConfession()
        {
            var result = from a in db.Confessions
                         select new ConfessionList()
                         {
                             Id=a.Id,
                             Message=a.Message,
                             PostDateTime=a.PostDateTime
                         };

            foreach(var r in result)
            {
                r.Likes = (from a in db.Confessions
                           join b in db.ConfessionLikes on a.Id equals b.ConfessionId
                           where a.Id == r.Id
                           select a).Count().ToString();
            }

            var returnValue = new ConfessionViewModel();
            returnValue.confessionList = new ObservableCollection<ConfessionList>(result);

            return Ok(returnValue);

        }
    }
    
}

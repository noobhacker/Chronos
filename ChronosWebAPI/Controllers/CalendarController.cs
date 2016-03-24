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
    public class CalendarController : ApiController
    {
        private ChronosWebAPIContext db = new ChronosWebAPIContext();

        [ResponseType(typeof(CalendarViewModel))]
        public async Task<IHttpActionResult> Post([FromBody]CalendarViewModel vm)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            if (await UserValidator.ValidateUser(vm.student) == false)
                return BadRequest(ModelState);

            db.Events.Add(new Event()
            {
                StudentId = vm.student.Id,
                Desc = vm.input.Desc,
                DueDate = vm.input.DueDate
            });

            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = vm.student.Id }, vm);
        }

        [ResponseType(typeof(CalendarViewModel))]
        public async Task<IHttpActionResult> Get(int Id)
        {
            var now = DateTime.Now;
            var result = from a in db.Events
                         where a.StudentId == Id
                         //&& a.DueDate > now
                         select a;

            var returnValue = new CalendarViewModel();
            returnValue.eventList = new ObservableCollection<Event>(result);

            return Ok(returnValue);
        }
    }
}

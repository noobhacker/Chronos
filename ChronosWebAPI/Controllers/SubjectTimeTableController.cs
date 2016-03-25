using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ChronosWebAPI.Models;
using Chronos;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Net;
using Chronos.ViewModels;

namespace ChronosWebAPI.Controllers
{
    public class SubjectTimeTableController : ApiController
    {
        private ChronosWebAPIContext db = new ChronosWebAPIContext();
        
        [ResponseType(typeof(string))]
        public async Task<IHttpActionResult> PostSubjectTimeTable([FromBody]string _vm)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var vm = JsonConvert.DeserializeObject<AddSubjectViewModel>(_vm);

            if (await UserValidator.ValidateUser(vm.student) == false)
                return BadRequest(ModelState);

            var subjectResult = db.Subjects.Add(vm.subject);
            
            foreach (var s in vm.sessions)
            {
                s.SubjectId = subjectResult.Id;
                db.SubjectSessions.Add(s);
            }
            
            db.Student_Subject.Add(new Student_Subject()
            {
                StudentId = vm.student.Id,
                SubjectId = subjectResult.Id
            });

            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = vm.student.Id }, vm);
        }

        // GET: api/Student_Subject
        [ResponseType(typeof(HomeViewModel))]
        public async Task<IHttpActionResult> GetSubjectTimeTable(int Id)
        {
            var now = DateTime.Now;
            var result = from a in db.Students
                         join b in db.Student_Subject on a.Id equals b.StudentId
                         join c in db.Subjects on b.SubjectId equals c.Id
                         join d in db.SubjectSessions on c.Id equals d.SubjectId
                         where a.Id == Id &&
                         d.Day == now.DayOfWeek &&
                         d.EndTime > now.TimeOfDay
                         select new SubjectTimeTable()
                         {
                             SubjectText = c.Code + " " + c.Name,
                             ClassType = d.SessionType,
                             Lecturer = c.Lecturer,
                             StartTime = d.StartTime,
                             EndTime = d.EndTime
                         };

            var returnValue = new HomeViewModel();
            returnValue.laterGVItems = new ObservableCollection<SubjectTimeTable>(result);
            
            return Ok(returnValue);

        }

        #region under construction
        // PUT: api/MarketItems/5
        [ResponseType(typeof(AddSubjectViewModel))]
        public async Task<IHttpActionResult> Put(AddSubjectViewModel vm)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (await UserValidator.ValidateUser(vm.student) == false)
                return BadRequest(ModelState);

            db.Subjects.Attach(vm.subject);

            var query = from a in db.SubjectSessions
                        where a.SubjectId == vm.subject.Id
                        select a;

            foreach (var d in query)
            { 
                foreach (var s in vm.sessions)
                {
                    if (CountSubjectSession(s.Id) > 0)
                        db.SubjectSessions.Attach(s);
                    else
                        db.SubjectSessions.Add(s);
                }
                if (d.SubjectId == vm.subject.Id &&
                    vm.sessions.Count(e => e.Id == d.SubjectId) == 0)
                    db.SubjectSessions.Remove(d);
            }

            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        private int CountSubjectSession(int id) => 
            db.SubjectSessions.Count(e => e.Id == id);


        // DELETE: api/MarketItems/5
        [ResponseType(typeof(MarketItem))]
        public async Task<IHttpActionResult> Delete(int Id, string password)
        {
            MarketItem marketItem = await db.MarketItems.FindAsync(Id);
            if (marketItem == null)
            {
                return NotFound();
            }

            if (await UserValidator.ValidateUser(new Student()
            {
                Id = Id,
                Password = password
            }) == false)
                return BadRequest(ModelState);

            db.MarketItems.Remove(marketItem);
            await db.SaveChangesAsync();

            return Ok(marketItem);
        }
        #endregion 
    }

}

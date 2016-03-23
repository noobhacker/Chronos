using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ChronosWebAPI.Models;
using Chronos;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace ChronosWebAPI.Controllers
{
    public class SubjectTimeTableController : ApiController
    {
        private ChronosWebAPIContext db = new ChronosWebAPIContext();

        // POST: api/SubjectSessions
        [ResponseType(typeof(string))]
        public async Task<IHttpActionResult> PostSubjectTimeTable([FromBody]string _vm)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var vm = JsonConvert.DeserializeObject<AddSubjectPageViewModel>(_vm);

            var subjectResult = db.Subjects.Add(vm.subject);

            // await db.SaveChangesAsync();

            foreach (var s in vm.sessions)
            {
                s.SubjectId = subjectResult.Id;
                db.SubjectSessions.Add(s);
            }

            // await db.SaveChangesAsync();

            db.Student_Subject.Add(new Student_Subject()
            {
                StudentId = vm.student.Id,
                SubjectId = subjectResult.Id,
                // Student= vm.student // what is this for @@?
            });

            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = vm.student.Id }, vm);
        }

        // GET: api/Student_Subject
        [ResponseType(typeof(HomePageViewModel))]
        public async Task<IHttpActionResult> GetSubjectTimeTable(int Id)
        {
            var result = from a in db.Students
                         join b in db.Student_Subject on a.Id equals b.StudentId
                         join c in db.Subjects on b.SubjectId equals c.Id
                         join d in db.SubjectSessions on c.Id equals d.SubjectId
                         //where a.Id == Id
                         select new SubjectTimeTable()
                         {
                             SubjectText = c.Code + " " + c.Name,
                             ClassType = d.SessionType,
                             Lecturer = c.Lecturer,
                             StartTime = d.StartTime,
                             EndTime = d.EndTime
                         };

            var returnValue = new HomePageViewModel();
            returnValue.laterGVItems = new ObservableCollection<SubjectTimeTable>(result);
            
            return Ok(returnValue);

        }
    }
    
}

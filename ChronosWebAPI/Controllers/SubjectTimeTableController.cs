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
    public class SubjectTimeTableController : ApiController
    {
        private ChronosWebAPIContext db = new ChronosWebAPIContext();

        // GET: api/Student_Subject
        public IQueryable<SubjectTimeTable> GetTimeTable(int Id)
        {
            //return db.Student_Subject;

            var result = from a in db.Students
                         join b in db.Student_Subject on a.Id equals b.Student.Id
                         join c in db.Subjects on b.Subject.Id equals c.Id
                         join d in db.SubjectSessions on c.Id equals d.Subject.Id
                         select new SubjectTimeTable()
                         {
                             SubjectText = c.Code + " " + c.Name,
                             ClassType = d.SessionType,
                             Lecturer = c.Lecturer,
                             StartTime = d.StartTime,
                             EndTime = d.EndTime
                         };

            //var result = from a in db.Students select a;

            return result;
        }
    }
    
}

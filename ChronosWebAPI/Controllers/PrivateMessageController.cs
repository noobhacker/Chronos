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
    public class PrivateMessageController : ApiController
    {
        private ChronosWebAPIContext db = new ChronosWebAPIContext();

        [ResponseType(typeof(PostMessageViewModel))]
        public async Task<IHttpActionResult> Post([FromBody]PostMessageViewModel vm)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            if (await UserValidator.ValidateUser(vm.student) == false)
                return BadRequest(ModelState);

            db.PrivateMessages.Add(new PrivateMessage()
            {
                Message = vm.Message,
                ReceiverId = vm.ReceiverId,
                SenderId = vm.student.Id,
                SentDatetime = DateTime.Now
            });

            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = vm.student.Id }, vm);
        }

        [ResponseType(typeof(PrivateMessageViewModel))]
        public async Task<IHttpActionResult> Get(int Id, string password)
        {

            if (await UserValidator.ValidateUser(new Student()
            {
                 Id=Id,
                 Password=password
            }) == false)
                return BadRequest(ModelState);

            var result = from a in db.PrivateMessages
                         join b in db.Students on a.SenderId equals b.Id
                         where a.ReceiverId == Id
                         select new InboxItem()
                         {
                             SenderId = a.SenderId,
                             SenderName = b.FullName,
                             Message = a.Message
                         };

            var returnValue = new PrivateMessageViewModel();
            returnValue.inboxList = new ObservableCollection<InboxItem>(result);

            return Ok(returnValue);
        }
    }
}

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
    public class PrivateMessageController : ApiController
    {
        private ChronosWebAPIContext db = new ChronosWebAPIContext();

        //Post

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

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChronosWebAPI.Models
{
    public class Subject_SubjectSession
    {
        public int Id { get; set; }

        [Column(Order = 1), Key, ForeignKey("Subject")]
        public int Subject_Id { get; set; }

        [Column(Order = 2), Key, ForeignKey("SubjectSession")]
        public int SubjectSession_Id { get; set; }
    }
}

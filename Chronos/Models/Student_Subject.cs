using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChronosWebAPI.Models
{
    public class Student_Subject
    {
        public int Id { get; set; }
        
        public int StudentId { get; set; }
        public int SubjectId { get; set; }

        public Student Student { get; set; }
        
        public Subject Subject { get; set; }
    }
}

using ChronosWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChronosWebAPI.Controllers
{
    public static class UserValidator
    {

        public static async Task<bool> ValidateUser(Student student)
        {
            ChronosWebAPIContext db = new ChronosWebAPIContext();

            Student stud = await db.Students.FindAsync(student.Id);

            // check if found
            if (stud != null)
            {
                // check if correct id and password
                if (!(stud.Id == student.Id) || !(stud.Password == student.Password))
                    return false;
            }
            else
                return false;

            return true;
        }
    }
}

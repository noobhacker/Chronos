using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ChronosWebAPI.Models;

namespace Chronos
{
    public static class GlobalVariables
    {
        public static Student CurrentUser { get; set; }

        static GlobalVariables()
        {
            CurrentUser = new Student()
            {
                Id = 1,
                Email = "chronos@outlook.com",
                FullName = "Chronos",
                StudentId = "888888888",
                Password = "Microsoft123",
                DailyConfessionChance = 100
            };
        }

    }
}

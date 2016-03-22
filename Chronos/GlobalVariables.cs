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
        #region INotifyPropertyChanged
        //public event PropertyChangedEventHandler PropertyChanged;
        //protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}
        #endregion

        public const string WebAPIAddress = "http://localhost:17461/api/"; // "http://chronosmy.azurewebsites.net/api/";

        public static Student CurrentUser { get; set; }

        static GlobalVariables()
        {
            CurrentUser = new Student()
            {
                Id = 0,
                Email = "chronosmy@outlook.com",
                FullName = "Developer",
                StudentId = "888888888",
                Password = "Microsoft123"
            };
        }

    }
}

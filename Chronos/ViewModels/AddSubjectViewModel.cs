using ChronosWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronos.ViewModels
{
    public class AddSubjectViewModel
    {
        public Subject subject { get; set; }
    
        public ObservableCollection<SubjectSession> sessions = new ObservableCollection<SubjectSession>();

        public Student student { get; set; } 

        public AddSubjectViewModel()
        {
            subject = new Subject();
            student = GlobalVariables.CurrentUser;
        }

    }
}

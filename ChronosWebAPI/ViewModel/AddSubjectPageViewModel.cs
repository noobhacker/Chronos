using ChronosWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronos
{
    public class AddSubjectPageViewModel
    {
        public Subject subject { get; set; }
    
        public ObservableCollection<SubjectSession> sessions = new ObservableCollection<SubjectSession>();

        public AddSubjectPageViewModel()
        {
            subject = new Subject();
        }

    }
}

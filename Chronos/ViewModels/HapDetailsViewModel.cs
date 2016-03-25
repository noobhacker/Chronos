using ChronosWebAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Chronos.ViewModels
{
    public class HapDetailsViewModel
    { 
        public Happening HapDetails { get; set; }
        public HapDetailsViewModel()
        {
            HapDetails = new Happening();
        }
    }
}

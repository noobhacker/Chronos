using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChronosWebAPI.Models
{
    public class Happening
    {
        public int Id { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public double Price { get; set; }
        public string Location { get; set; }
        public int LocationX { get; set; }
        public int LocationY { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public string Contact { get; set; }
    }
}

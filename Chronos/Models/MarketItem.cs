using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChronosWebAPI.Models
{
    public class MarketItem
    {
        public int Id { get; set; }
        public int SellerId { get; set; }
        public Student Student { get; set; }
        public DateTime PostDateTime { get; set; }
        public string ItemName { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
    }
}

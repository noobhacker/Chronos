﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChronosWebAPI.Models
{
    public class ConfessionLikes
    {
        public int Id { get; set; }

        public int ConfessionId { get; set; }

        public int LikedById { get; set; }
        public Confession Confession { get; set; }
        public Student Student { get; set; }
    }
}

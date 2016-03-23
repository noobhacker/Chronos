﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChronosWebAPI.Models;

namespace Chronos
{
    public class AddMarketItemViewModel
    {
        public MarketItem marketItem { get; set; }
        public Student student { get; set; }

        public AddMarketItemViewModel()
        {
            student = GlobalVariables.CurrentUser;
        }
    }
}

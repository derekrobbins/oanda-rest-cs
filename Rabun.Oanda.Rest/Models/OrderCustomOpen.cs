﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rabun.Oanda.Rest.Models
{
    public class OrderCustumOpen : OrderOpen
    {
        public OrderOpened OrderOpened { get; set; }
    }
}

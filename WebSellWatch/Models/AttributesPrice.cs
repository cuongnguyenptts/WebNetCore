﻿using System;
using System.Collections.Generic;

namespace WebSellWatch.Models
{
    public partial class AttributesPrice
    {
        public int AttributesPriceId { get; set; }
        public int? AttributeId { get; set; }
        public int? ProductId { get; set; }
        public int? Price { get; set; }
        public bool Active { get; set; }

        public virtual Attribute? Product { get; set; }
        public virtual Product? ProductNavigation { get; set; }
    }
}

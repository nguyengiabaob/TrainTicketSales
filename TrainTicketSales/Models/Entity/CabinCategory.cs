﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace TrainTicketSales.Models.Entity
{
    public partial class CabinCategory
    {
        public CabinCategory()
        {
            Cabin = new HashSet<Cabin>();
        }

        public string Code { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Cabin> Cabin { get; set; }
    }
}
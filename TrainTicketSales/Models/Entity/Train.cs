// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace TrainTicketSales.Models.Entity
{
    public partial class Train
    {
        public Train()
        {
            Cabin = new HashSet<Cabin>();
            Schedule = new HashSet<Schedule>();
        }

        public string Code { get; set; }
        public string Name { get; set; }
        public string Des { get; set; }

        public virtual ICollection<Cabin> Cabin { get; set; }
        public virtual ICollection<Schedule> Schedule { get; set; }
    }
}
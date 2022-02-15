using System;
using System.Collections.Generic;
using TrainTicketSales.Models.Entity;

namespace TrainTicketSales.ModelsViews
{
    public class ScheduleAdminViewModel
    {

        public long? BeginStationId { get; set; }
        public long? EndStationId { get; set; }
        public string TrainCode { get; set; }
        public DateTime? DateBegin { get; set; }
        public DateTime? DateEnd { get; set; }

        public virtual ICollection<Station> BeginStation { get; set; }
        public virtual ICollection<Station> EndStation { get; set; }
        public virtual ICollection<Train> TrainCodeNavigation { get; set; }

    }
}

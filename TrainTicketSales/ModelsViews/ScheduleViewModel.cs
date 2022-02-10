using System;
using System.Collections.Generic;

namespace TrainTicketSales.ModelsViews
{
    public class ScheduleViewModel
    {
        public long Id { get; set; }
        public long? BeginStationId { get; set; }
        public long? EndStationId { get; set; }
        public string TrainCode { get; set; }
        public DateTime? DateBegin { get; set; }
        public DateTime? DateEnd { get; set; }
        public virtual IEnumerable<TrainViewModel> TrainsList { get; set; }
    }
}

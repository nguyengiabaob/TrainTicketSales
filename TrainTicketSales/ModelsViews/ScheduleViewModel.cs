using System.Collections.Generic;

namespace TrainTicketSales.ModelsViews
{
    public class ScheduleViewModel
    {
        public virtual IEnumerable<TrainViewModel> TrainsList { get; set; }
    }
}

using System.Collections.Generic;
using TrainTicketSales.Models.Entity;

namespace TrainTicketSales.ModelsViews
{
    public class CabinViewModel
    {
        public long Id { get; set; }
        public string CabinCategoryCode { get; set; }
        public string CabinCategoryName { get; set; }
        public string CabinName { get; set; }
        public string Index { get; set; }
        public string TrainCode { get; set; }     

        public virtual IEnumerable<SeatViewModel> Seat { get; set; }
    }
}

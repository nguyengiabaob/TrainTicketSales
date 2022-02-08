using System.Collections.Generic;

namespace TrainTicketSales.ModelsViews {
    public class CabinViewModel {
        public long Id { get; set; }
        public string CabinCategoryCode { get; set; }
        public string Index { get; set; }
        public string TrainCode { get; set; }      
        public virtual IEnumerable<SeatViewModel> Seat { get; set; }
    }
}

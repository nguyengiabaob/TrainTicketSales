using System.Collections.Generic;
using TrainTicketSales.Models.Entity;

namespace TrainTicketSales.ModelsViews
{
    public class TrainViewModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Des { get; set; }
        public virtual IEnumerable<CabinViewModel> Cabin { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainTicketSales.ModelsViews
{
    public class CartItemViewModel
    {
        public long Id { get; set; }
        public string Direction { get; set; }
        public int Index { get; set; }
        public string NameTrain { get; set; }
        public string Time  {get; set; }
        public string Cabin {get; set; }
        public int Price { get; set; }
        public string CabinName { get; set; }
    }
}

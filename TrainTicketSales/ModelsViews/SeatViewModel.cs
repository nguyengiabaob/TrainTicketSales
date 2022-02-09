namespace TrainTicketSales.ModelsViews
{
    public class SeatViewModel
    {
        public long Id { get; set; }
        public long? CabinId { get; set; }
        public string SeatCategoryCode { get; set; }
        public string FloorCode { get; set; }
        public int? Index { get; set; }
        public long? Price { get; set; }
        public bool? Status { get; set; }
    }
}

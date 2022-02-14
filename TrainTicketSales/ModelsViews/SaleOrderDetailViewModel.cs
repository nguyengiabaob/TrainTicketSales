namespace TrainTicketSales.ModelsViews
{
    public class SaleOrderDetailViewModel
    {
        public long Id { get; set; }
        public long? SaleOrderId { get; set; }
        public string Name { get; set; }
        public string SeatName { get; set; }
        public decimal? Price { get; set; }
        public string SeatId { get; set; }
        public string Status { get; set; }
        public string IdentityCard { get; set; }
        public long? ScheduleID { get; set; }
    }
}

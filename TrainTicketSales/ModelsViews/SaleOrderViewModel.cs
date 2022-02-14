using System;
using System.Collections.Generic;
using TrainTicketSales.Models.Entity;

namespace TrainTicketSales.ModelsViews
{
    public class SaleOrderViewModel
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public DateTime? OrderDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string IdentityCard { get; set; }
        public float Total { get; set; }
        public string ActionLink { get; set; }

        /// <summary>
        /// 1: đặt mua; 2: chấp nhận bán; 3: trả tiền; 4: xác nhận nhận tiền, 5:  giao vé, 6: hoãn, 7: đổi chuyển
        /// </summary>
        public string Status { get; set; }

        public IEnumerable<SaleOrderDetailViewModel> SaleOrderDetail { get; set; }
    }
}

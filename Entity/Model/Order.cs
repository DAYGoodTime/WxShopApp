using Entity.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WxsAppShop.Entity.Model
{
    [Table("orders")]
    public class Order
    {
        [Key]
        public Guid order_id { get; set; } = Guid.NewGuid();

        public Guid item_id { get; set; } = Guid.Empty;

        public Guid user_id { get; set; } = Guid.Empty;

        public decimal total_price { get; set; } = decimal.Zero;

        public decimal actual_price { get; set; } = decimal.Zero;

        public decimal single_price { get; set; } = decimal.Zero;

        public int count { get; set; }

        public Guid option_id { get; set; } = Guid.Empty;

        public DateTime create_time { get; set; } = DateTime.Now;

        public OrderState order_state { get; set; } = OrderState.Pending_Payment;
    }
}

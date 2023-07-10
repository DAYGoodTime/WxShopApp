using Entity.Vo;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WxsAppShop.Entity.Model
{
    [Table("shop_items")]
    public class Item
    {
        [Key]
        public Guid item_id { get; set; } = Guid.NewGuid();

        public string item_name { get; set; } = string.Empty;

        public string item_description { get; set; } = string.Empty;

        public string item_icon_url { get; set; } = string.Empty;

        public string item_category { get; set; } = string.Empty;
        /// <summary>
        /// 仅作为展示价格，不是商品的真实价格
        /// </summary>
        public decimal item_display_price { get; set; } = decimal.Zero;

        /// <summary>
        /// 在购物车当中会使用到的商品数量
        /// </summary>
        [NotMapped]
        public int item_count { get; set; } = 0;
    }
}

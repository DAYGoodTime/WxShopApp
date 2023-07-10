using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
    /// <summary>
    /// 商品选项类
    /// 每个选项才是真正的独立“商品”
    /// 它们决定库存，价格，以及用户真正选择的“商品”
    /// </summary>
    [Table("options")]
    public class ItemSubOption
    {
        /// <summary>
        /// 商品选项主键id
        /// </summary>
        [Key]
        public Guid option_id { get; set; } = Guid.NewGuid();
        /// <summary>
        /// 选项名字
        /// </summary>
        public string option_name { get; set; } = string.Empty;
        /// <summary>
        /// 选项价格，这才是决定商品的真正价格
        /// </summary>
        public decimal option_price { get; set; } = decimal.Zero;
        /// <summary>
        /// 所对应的商品id，方便溯源。
        /// </summary>
        public Guid item_id { get; set; } = Guid.Empty;
        /// <summary>
        /// 所对应的Tag id，方便溯源。
        /// </summary>
        public Guid Tag_id { get; set; } = Guid.Empty;
        /// <summary>
        /// 选项库存，这才是决定商品的真正库存
        /// 用来判断能否创建订单的库存。
        /// </summary>
        public int storage { get; set; } = 0;
    }
}

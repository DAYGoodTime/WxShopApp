using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Schemas
{
    public class UserOrderSates
    {
        /// <summary>
        /// 待支付
        /// </summary>
        public int Pending { get; set; } = 0;
        /// <summary>
        /// 已支付(待发货)
        /// </summary>
        public int Already_Paid { get; set; } = 0;
        /// <summary>
        /// 发货中
        /// </summary>
        public int Shipping { get; set; } = 0;
        /// <summary>
        /// 完成
        /// </summary>
        public int Finished { get; set; } = 0;
    }
}

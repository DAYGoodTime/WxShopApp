using Entity.Model;
using Entity.Vo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WxsAppShop.Entity.Model;

namespace Entity.Schemas
{
    /// <summary>
    /// 创建订单所需要的实体
    /// </summary>
    public class CreateOrder
    {
        /// <summary>
        /// 发起订单请求的用户id
        /// </summary>
        public Guid user_id { get; set; } = Guid.Empty;
        /// <summary>
        /// 所下单的物品
        /// </summary>
        public List<ItemSubOptionVo> items { get; set; }
    }
}

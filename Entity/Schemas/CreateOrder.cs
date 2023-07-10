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
    public class CreateOrder
    {
        public Guid user_id { get; set; } = Guid.Empty;

        public List<ItemSubOptionVo> items { get; set; }
    }
}

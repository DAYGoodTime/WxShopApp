using Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WxsAppShop.Entity.Model;

namespace Entity.Vo
{
    public class ItemVo : Item
    {
        /// <summary>
        /// 物品的所拥有的选项
        /// </summary>
        public List<ItemTagOptions> options { get; set; }
        /// <summary>
        /// 物品的“销量”
        /// </summary>
        public int Sales { get; set; } = 0;
    }
}

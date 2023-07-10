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
        public List<ItemTagOptions> options { get; set; }

        public int Sales { get; set; } = 0;
    }
}

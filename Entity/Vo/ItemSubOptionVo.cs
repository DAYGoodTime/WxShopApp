using Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Vo
{
    public class ItemSubOptionVo : ItemSubOption
    {
        /// <summary>
        /// 数量，用来指代该选项的商品的数量
        /// </summary>
        public int count { get; set; } = 0;
    }
}

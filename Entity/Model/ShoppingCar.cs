using Entity.Vo;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WxsAppShop.Entity.Model;

namespace Entity.Model
{
    [Table("user_shopping_table")]
    public class ShoppingCar
    {
        [Key]
        public Guid shopping_item_id { get; set; } = Guid.NewGuid();

        public Guid option_id { get; set; } = Guid.Empty;

        public Guid item_id { get; set; } = Guid.Empty;

        public int count { get; set; } = 0;

        public Guid user_id { get; set; } = Guid.Empty;

        [NotMapped]
        public Item item { get; set; }
    }
}

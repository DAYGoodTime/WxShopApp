using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WxsAppShop.Entity.Base;

namespace WxsAppShop.Entity.Model
{
    [Table("news")]
    public class News : BaseObject
    {
        [Key]
        public Guid news_id { get; set; } = Guid.NewGuid();
    }
}

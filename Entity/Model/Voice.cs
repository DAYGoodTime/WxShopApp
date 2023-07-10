using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WxsAppShop.Entity.Base;

namespace WxsAppShop.Entity.Model
{
    [Table("voices")]
    public class Voice : BaseObject
    {
        [Key]
        public Guid voice_id { get; set; } = Guid.NewGuid();
        public int likes { get; set; } = 0;
    }
}

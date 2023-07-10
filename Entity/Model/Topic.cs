using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WxsAppShop.Entity.Base;

namespace WxsAppShop.Entity.Model
{
    [Table("topics")]
    public class Topic : BaseObject
    {
        [Key]
        public Guid topic_id { get; set; } = Guid.NewGuid();

    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WxsAppShop.Entity.Base;

namespace WxsAppShop.Entity.Model
{
    [Table("votes")]
    public class Vote : BaseObject
    {
        [Key]
        public Guid vote_id { get; set; } = Guid.NewGuid();
        public DateTime deadline_time { get; set; }
    }
}

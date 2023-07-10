using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
    /// <summary>
    /// 用户收藏类
    /// </summary>
    [Table("user_collection_table")]
    public class Collection
    {
        /// <summary>
        /// 收藏id
        /// </summary>
        [Key]
        public Guid collection_id { get; set; } = Guid.NewGuid();
        /// <summary>
        /// 用户id
        /// </summary>
        public Guid user_id { get; set; } = Guid.Empty;
        /// <summary>
        /// 被收藏商品id
        /// </summary>
        public Guid item_id { get; set; } = Guid.Empty;
        /// <summary>
        /// 收藏时间
        /// </summary>
        public DateTime create_time { get; set; } = DateTime.Now;
    }
}

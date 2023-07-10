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
    /// 用户对商品评论类
    /// </summary>
    [Table("comments")]
    public class Comment
    {
        /// <summary>
        /// 评论id
        /// </summary>
        [Key]
        public Guid comment_id { get; set; } = Guid.NewGuid();
        /// <summary>
        /// 商品id
        /// </summary>
        public Guid item_id { get; set; } = Guid.Empty;
        /// <summary>
        /// 评论者id
        /// </summary>
        public Guid user_id { get; set; } = Guid.Empty;
        /// <summary>
        /// 评论标题
        /// </summary>
        public string comment_title { get; set; } = string.Empty;
        /// <summary>
        /// 评论内容
        /// </summary>
        public string comment_context { get; set; } = string.Empty;
        /// <summary>
        /// 评论配图连接(集合)
        /// </summary>
        [NotMapped]
        public List<string> img_urls { get; set; } = new List<string>(0);
    }
}

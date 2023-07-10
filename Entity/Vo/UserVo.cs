using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Vo
{
    public class UserVo
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public Guid user_id { get; set; } = Guid.NewGuid();
        /// <summary>
        /// 用户姓名
        /// </summary>
        public string user_name { get; set; } = string.Empty;
        /// <summary>
        /// 用户头像
        /// </summary>
        public string user_avatar { get; set; } = string.Empty;
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime create_time { get; set; } = DateTime.Now;
    }
}

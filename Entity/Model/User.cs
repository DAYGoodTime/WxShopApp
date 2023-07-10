

using Entity.Vo;
using Omu.ValueInjecter;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WxsAppShop.Entity.Model
{
    /// <summary>
    /// 用户类
    /// </summary>
    [Table("users")]
    public class User
    {
        [Key]
        /// <summary>
        /// 用户主键id
        /// </summary>
        public Guid user_id { get; set; } = Guid.NewGuid();
        /// <summary>
        /// 用户名
        /// </summary>
        public string user_name { get; set; } = string.Empty;
        /// <summary>
        /// 用户密码
        /// </summary>
        public string user_password { get; set; } = string.Empty;
        /// <summary>
        /// 用户头像地址
        /// </summary>
        public string user_avatar { get; set; } = string.Empty;
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime create_time { get; set; } = DateTime.Now;

        public UserVo toVo()
        {
            return new UserVo().InjectFrom(this) as UserVo;
        }
    }
}

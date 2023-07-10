using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Vo
{
    public class UserVo
    {
        public Guid user_id { get; set; } = Guid.NewGuid();

        public string user_name { get; set; } = string.Empty;

        public string user_avatar { get; set; } = string.Empty;

        public DateTime create_time { get; set; } = DateTime.Now;
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
    [Table("address")]
    public class Address
    {
        [Key]
        public Guid address_id {  get; set; } = Guid.NewGuid();

        public Guid user_id { get; set; } = Guid.Empty;

        public string address_title { get; set; } = string.Empty;

        public string address_context { get; set; } = string.Empty;

        public DateTime create_time { get; set; } = DateTime.Now;
    }
}

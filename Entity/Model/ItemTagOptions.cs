using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
    [Table("item_options_table")]
    public class ItemTagOptions
    {
        [Key]
        public Guid option_tag_id { get; set; } = Guid.NewGuid();

        public string option_title { get; set; } = string.Empty;

        public Guid item_id { get; set; } = Guid.Empty;

        [NotMapped]
        public List<ItemSubOption> subOptions { get; set; }
    }
}

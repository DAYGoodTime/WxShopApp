using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
    [Table("categories")]
    public class Category
    {
        [Key]
        public Guid category_id { get; set; } = Guid.NewGuid();

        public string category_name { get; set; } = string.Empty;

        /// <summary>
        /// Not Used
        /// </summary>
        [NotMapped]
        public string category_description { get; set;} = string.Empty;
    }
}

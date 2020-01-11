using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace LessonWpf.Entity
{
    [Table("goods")]
    class Phone
    {
        [Column("id")]
        public uint Id { get; set; }
        [Column("category_id")]
        public uint CategoryId { get; set; }
        [Column("name")]
        [StringLength(128, MinimumLength = 6)]
        public string Name { get; set; }
        [Required]
        [Column("num")]
        public uint Count { get; set; }
        [Range(1, 20)]
        [Column("cost")]
        public uint Cost { get; set; }
        [Column("description")]
        public string Description { get; set; }
    }
}

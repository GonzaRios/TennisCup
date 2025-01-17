using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicationCore.Entities
{
    [Table("players")]
    public  class Players
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        [MaxLength(150)]
        public string Name { get; set; }

        [Column("gender")]
        [MaxLength(50)]
        public string Gender { get; set; }

        [Column("ability")]
        public int Ability { get; set; }
        
    }
}

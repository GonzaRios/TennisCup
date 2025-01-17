using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicationCore.Entities
{
    [Table("female_players")]
    public  class FemalePlayers : Players
    {
        [Key]
        [NotMapped]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id_female")]
        public int Id_Female { get; set; }

        [Column("reaction_time")]
        public double ReactionTime { get; set; }
    }
}

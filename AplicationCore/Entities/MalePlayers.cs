using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicationCore.Entities
{
    [Table("male_players")]
    public class MalePlayers : Players
    {
        [Key]
        [NotMapped]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id_male")]
        public int Id_Male {  get; set; }

        [Column("strengh")]
        public double Strength { get; set; }

        [Column("speed")]
        public double  Speed { get; set; }
        
    }
}

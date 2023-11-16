using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YBTE8G_HFT_2023241.Models
{
    [Table("Players")]
    public class Player : Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("PlayerID", TypeName = "int")]
        public override int  Id { get; set; }
        [Required]
        public string IngameName { get; set; }
        [Required]
        public int YearsActive { get; set; }
        public bool LeagueChampion { get; set; }
        public int Salary { get; set; }
        public int TeamId { get;  set; }
        public int GameId { get; set; }
        [NotMapped]
        public virtual Game game { get; set;}
        [NotMapped]
        public virtual Team Team { get; set; }
    }
}

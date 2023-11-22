using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace YBTE8G_HFT_2023241.Models
{
    [Table("Teams")]
    public class Team : Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("TeamID", TypeName = "int")]
        public override int Id { get; set; }
        public string TeamName { get;  set; }
        public string CountryOfOrigin { get;  set; }
        public bool MultipleGamesPlayed { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Player> Players { get; set; }

            
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace YBTE8G_HFT_2023241.Models
{
    [Table("Games")]
    public class Game : Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("GameID", TypeName = "int")]
        public override int Id { get; set; }
        public string GameName { get; set; }
        public string LeagueName { get; set; }
        [MaxLength(30)]
        [Required]
        public string Developer { get; set; }
        public int ReleaseDate { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Player> Players { get; set; }
    }
}

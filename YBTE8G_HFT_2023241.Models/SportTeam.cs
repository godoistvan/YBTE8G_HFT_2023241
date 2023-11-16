using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace YBTE8G_HFT_2023241.Models
{
    [Table("classes")]
    public class SportTeam : Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("SportTeamID", TypeName = "int")]
        public override int Id { get; set; }
        public string SportName { get;  set; }
        public string Mascot { get;  set; }
        public bool AreChampions { get; set; }
        public int StudentId { get; set; }
        [NotMapped]
        public virtual ICollection<Student> Students { get; set; }

            
    }
}

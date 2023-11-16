using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YBTE8G_HFT_2023241.Models
{
    [Table("students")]
    public class Student : Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("StudentID", TypeName = "int")]
        public override int  Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public int SportTeamId { get;  set; }
        public int CourseId { get; set; }
        [Required]
        public int SemestersIn { get; set; }
        [NotMapped]
        public virtual List<Course> Courses { get; set;}
        [NotMapped]
        public virtual SportTeam Team { get; set; }
    }
}

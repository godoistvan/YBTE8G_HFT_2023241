using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YBTE8G_HFT_2023241.Models
{
    [Table("courses")]
    public class Course : Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("CourseID", TypeName = "int")]
        public override int Id { get; set; }
        public int RecommendedSemester { get; set; }
        [MaxLength(30)]
        [Required]
        public string CourseName { get; set; }
        [NotMapped]
        public int TeacherName { get; set; }
        [ForeignKey(nameof(Class))]
        public int ClassID { get; set; }
        [NotMapped]
        public virtual Student Student { get; set; }
        [NotMapped]
        public virtual Class Class { get; set; }
        public int Difficulty { get; set; }
        public int Credit { get; set; }
    }
}

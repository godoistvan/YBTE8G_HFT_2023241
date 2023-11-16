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
        [Required]
        public int SemestersIn { get; set; }
        [NotMapped]
        public virtual Course Course { get; set;}
        [NotMapped]
        public virtual Class Class { get; set; }
    }
}

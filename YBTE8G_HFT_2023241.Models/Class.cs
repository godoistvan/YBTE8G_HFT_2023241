﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YBTE8G_HFT_2023241.Models
{
    [Table("classes")]
    public class Class : Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ClassID", TypeName = "int")]
        public override int Id { get; set; }
        public int FinalGrade { get; set; }
        public string SemesterTakenIn { get;  set; }
        public bool AllowedForExam { get;  set; }
        [NotMapped]
        public virtual Student student { get; set; }
        [NotMapped]
        public virtual Course Course { get; set; }
        [ForeignKey(nameof(Course))]
        public int CourseID { get; set; }
        [ForeignKey(nameof(student))]
        public int StudentID { get; set; }

    }
}

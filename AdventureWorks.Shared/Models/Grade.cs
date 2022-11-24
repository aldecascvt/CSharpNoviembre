using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Adventureworks.Data
{
    [Index(nameof(StudentUserId), Name = "IX_FK_StudentGrade")]
    [Index(nameof(SubjectId), Name = "IX_FK_SubjectGrade")]
    public partial class Grade
    {
        [Key]
        public int Id { get; set; }
        public string Assessment { get; set; } = null!;
        public string? Comments { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime AssessmentDate { get; set; }
        public int SubjectId { get; set; }
        public Guid StudentUserId { get; set; }

        [ForeignKey(nameof(StudentUserId))]
        [InverseProperty(nameof(Student.Grades))]
        public virtual Student StudentUser { get; set; } = null!;
        [ForeignKey(nameof(SubjectId))]
        [InverseProperty("Grades")]
        public virtual Subject Subject { get; set; } = null!;
    }
}

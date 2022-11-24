using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Adventureworks.Data
{
    [Index(nameof(TeacherUserId), Name = "IX_FK_TeacherStudent")]
    public partial class Student
    {
        public Student()
        {
            Grades = new HashSet<Grade>();
            ParentsUsers = new HashSet<Parent>();
        }

        [Key]
        public Guid UserId { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; } = null!;
        [StringLength(50)]
        public string LastName { get; set; } = null!;
        public string ImageName { get; set; } = null!;
        public Guid? TeacherUserId { get; set; }

        [ForeignKey(nameof(TeacherUserId))]
        [InverseProperty(nameof(Teacher.Students))]
        public virtual Teacher? TeacherUser { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty("Student")]
        public virtual User User { get; set; } = null!;
        [InverseProperty(nameof(Grade.StudentUser))]
        public virtual ICollection<Grade> Grades { get; set; }

        [ForeignKey("StudentsUserId")]
        [InverseProperty(nameof(Parent.StudentsUsers))]
        public virtual ICollection<Parent> ParentsUsers { get; set; }
    }
}

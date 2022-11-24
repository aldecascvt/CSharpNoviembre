using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Adventureworks.Data
{
    public partial class Parent
    {
        public Parent()
        {
            StudentsUsers = new HashSet<Student>();
        }

        [Key]
        public Guid UserId { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; } = null!;
        [StringLength(50)]
        public string LastName { get; set; } = null!;

        [ForeignKey(nameof(UserId))]
        [InverseProperty("Parent")]
        public virtual User User { get; set; } = null!;

        [ForeignKey("ParentsUserId")]
        [InverseProperty(nameof(Student.ParentsUsers))]
        public virtual ICollection<Student> StudentsUsers { get; set; }
    }
}

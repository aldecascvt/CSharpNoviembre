using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Adventureworks.Data
{
    public partial class Subject
    {
        public Subject()
        {
            Grades = new HashSet<Grade>();
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        [InverseProperty(nameof(Grade.Subject))]
        public virtual ICollection<Grade> Grades { get; set; }
    }
}

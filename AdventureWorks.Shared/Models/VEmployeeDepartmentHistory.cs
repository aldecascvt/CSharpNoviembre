using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Adventureworks.Data
{
    /// <summary>
    /// Returns employee name and current and previous departments.
    /// </summary>
    [Keyless]
    public partial class VEmployeeDepartmentHistory
    {
        [Column("BusinessEntityID")]
        public int BusinessEntityId { get; set; }
        [StringLength(8)]
        public string? Title { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; } = null!;
        [StringLength(50)]
        public string? MiddleName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; } = null!;
        [StringLength(10)]
        public string? Suffix { get; set; }
        [StringLength(50)]
        public string Shift { get; set; } = null!;
        [StringLength(50)]
        public string Department { get; set; } = null!;
        [StringLength(50)]
        public string GroupName { get; set; } = null!;
        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime? EndDate { get; set; }
    }
}

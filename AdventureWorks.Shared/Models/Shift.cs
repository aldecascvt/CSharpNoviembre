using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Adventureworks.Data
{
    /// <summary>
    /// Work shift lookup table.
    /// </summary>
    [Table("Shift", Schema = "HumanResources")]
    [Index(nameof(Name), Name = "AK_Shift_Name", IsUnique = true)]
    [Index(nameof(StartTime), nameof(EndTime), Name = "AK_Shift_StartTime_EndTime", IsUnique = true)]
    public partial class Shift
    {
        public Shift()
        {
            EmployeeDepartmentHistories = new HashSet<EmployeeDepartmentHistory>();
        }

        /// <summary>
        /// Primary key for Shift records.
        /// </summary>
        [Key]
        [Column("ShiftID")]
        public byte ShiftId { get; set; }
        /// <summary>
        /// Shift description.
        /// </summary>
        [StringLength(50)]
        public string Name { get; set; } = null!;
        /// <summary>
        /// Shift start time.
        /// </summary>
        public TimeSpan StartTime { get; set; }
        /// <summary>
        /// Shift end time.
        /// </summary>
        public TimeSpan EndTime { get; set; }
        /// <summary>
        /// Date and time the record was last updated.
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [InverseProperty(nameof(EmployeeDepartmentHistory.Shift))]
        public virtual ICollection<EmployeeDepartmentHistory> EmployeeDepartmentHistories { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Adventureworks.Data
{
    /// <summary>
    /// Lookup table containing the departments within the Adventure Works Cycles company.
    /// </summary>
    [Table("Department", Schema = "HumanResources")]
    [Index(nameof(Name), Name = "AK_Department_Name", IsUnique = true)]
    public partial class Department
    {
        public Department()
        {
            EmployeeDepartmentHistories = new HashSet<EmployeeDepartmentHistory>();
        }

        /// <summary>
        /// Primary key for Department records.
        /// </summary>
        [Key]
        [Column("DepartmentID")]
        public short DepartmentId { get; set; }
        /// <summary>
        /// Name of the department.
        /// </summary>
        [StringLength(50)]
        public string Name { get; set; } = null!;
        /// <summary>
        /// Name of the group to which the department belongs.
        /// </summary>
        [StringLength(50)]
        public string GroupName { get; set; } = null!;
        /// <summary>
        /// Date and time the record was last updated.
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [InverseProperty(nameof(EmployeeDepartmentHistory.Department))]
        public virtual ICollection<EmployeeDepartmentHistory> EmployeeDepartmentHistories { get; set; }
    }
}

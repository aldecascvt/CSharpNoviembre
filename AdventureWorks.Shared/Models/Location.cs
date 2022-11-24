using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Adventureworks.Data
{
    /// <summary>
    /// Product inventory and manufacturing locations.
    /// </summary>
    [Table("Location", Schema = "Production")]
    [Index(nameof(Name), Name = "AK_Location_Name", IsUnique = true)]
    public partial class Location
    {
        public Location()
        {
            ProductInventories = new HashSet<ProductInventory>();
            WorkOrderRoutings = new HashSet<WorkOrderRouting>();
        }

        /// <summary>
        /// Primary key for Location records.
        /// </summary>
        [Key]
        [Column("LocationID")]
        public short LocationId { get; set; }
        /// <summary>
        /// Location description.
        /// </summary>
        [StringLength(50)]
        public string Name { get; set; } = null!;
        /// <summary>
        /// Standard hourly cost of the manufacturing location.
        /// </summary>
        [Column(TypeName = "smallmoney")]
        public decimal CostRate { get; set; }
        /// <summary>
        /// Work capacity (in hours) of the manufacturing location.
        /// </summary>
        [Column(TypeName = "decimal(8, 2)")]
        public decimal Availability { get; set; }
        /// <summary>
        /// Date and time the record was last updated.
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [InverseProperty(nameof(ProductInventory.Location))]
        public virtual ICollection<ProductInventory> ProductInventories { get; set; }
        [InverseProperty(nameof(WorkOrderRouting.Location))]
        public virtual ICollection<WorkOrderRouting> WorkOrderRoutings { get; set; }
    }
}

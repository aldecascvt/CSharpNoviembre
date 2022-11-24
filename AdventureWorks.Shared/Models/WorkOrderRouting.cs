using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Adventureworks.Data
{
    /// <summary>
    /// Work order details.
    /// </summary>
    [Table("WorkOrderRouting", Schema = "Production")]
    [Index(nameof(ProductId), Name = "IX_WorkOrderRouting_ProductID")]
    public partial class WorkOrderRouting
    {
        /// <summary>
        /// Primary key. Foreign key to WorkOrder.WorkOrderID.
        /// </summary>
        [Key]
        [Column("WorkOrderID")]
        public int WorkOrderId { get; set; }
        /// <summary>
        /// Primary key. Foreign key to Product.ProductID.
        /// </summary>
        [Key]
        [Column("ProductID")]
        public int ProductId { get; set; }
        /// <summary>
        /// Primary key. Indicates the manufacturing process sequence.
        /// </summary>
        [Key]
        public short OperationSequence { get; set; }
        /// <summary>
        /// Manufacturing location where the part is processed. Foreign key to Location.LocationID.
        /// </summary>
        [Column("LocationID")]
        public short LocationId { get; set; }
        /// <summary>
        /// Planned manufacturing start date.
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime ScheduledStartDate { get; set; }
        /// <summary>
        /// Planned manufacturing end date.
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime ScheduledEndDate { get; set; }
        /// <summary>
        /// Actual start date.
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? ActualStartDate { get; set; }
        /// <summary>
        /// Actual end date.
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? ActualEndDate { get; set; }
        /// <summary>
        /// Number of manufacturing hours used.
        /// </summary>
        [Column(TypeName = "decimal(9, 4)")]
        public decimal? ActualResourceHrs { get; set; }
        /// <summary>
        /// Estimated manufacturing cost.
        /// </summary>
        [Column(TypeName = "money")]
        public decimal PlannedCost { get; set; }
        /// <summary>
        /// Actual manufacturing cost.
        /// </summary>
        [Column(TypeName = "money")]
        public decimal? ActualCost { get; set; }
        /// <summary>
        /// Date and time the record was last updated.
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey(nameof(LocationId))]
        [InverseProperty("WorkOrderRoutings")]
        public virtual Location Location { get; set; } = null!;
        [ForeignKey(nameof(WorkOrderId))]
        [InverseProperty("WorkOrderRoutings")]
        public virtual WorkOrder WorkOrder { get; set; } = null!;
    }
}

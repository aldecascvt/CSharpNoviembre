using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Adventureworks.Data
{
    /// <summary>
    /// Cross-reference table mapping sales orders to sales reason codes.
    /// </summary>
    [Table("SalesOrderHeaderSalesReason", Schema = "Sales")]
    public partial class SalesOrderHeaderSalesReason
    {
        /// <summary>
        /// Primary key. Foreign key to SalesOrderHeader.SalesOrderID.
        /// </summary>
        [Key]
        [Column("SalesOrderID")]
        public int SalesOrderId { get; set; }
        /// <summary>
        /// Primary key. Foreign key to SalesReason.SalesReasonID.
        /// </summary>
        [Key]
        [Column("SalesReasonID")]
        public int SalesReasonId { get; set; }
        /// <summary>
        /// Date and time the record was last updated.
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey(nameof(SalesOrderId))]
        [InverseProperty(nameof(SalesOrderHeader.SalesOrderHeaderSalesReasons))]
        public virtual SalesOrderHeader SalesOrder { get; set; } = null!;
        [ForeignKey(nameof(SalesReasonId))]
        [InverseProperty("SalesOrderHeaderSalesReasons")]
        public virtual SalesReason SalesReason { get; set; } = null!;
    }
}

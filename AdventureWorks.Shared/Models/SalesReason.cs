using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Adventureworks.Data
{
    /// <summary>
    /// Lookup table of customer purchase reasons.
    /// </summary>
    [Table("SalesReason", Schema = "Sales")]
    public partial class SalesReason
    {
        public SalesReason()
        {
            SalesOrderHeaderSalesReasons = new HashSet<SalesOrderHeaderSalesReason>();
        }

        /// <summary>
        /// Primary key for SalesReason records.
        /// </summary>
        [Key]
        [Column("SalesReasonID")]
        public int SalesReasonId { get; set; }
        /// <summary>
        /// Sales reason description.
        /// </summary>
        [StringLength(50)]
        public string Name { get; set; } = null!;
        /// <summary>
        /// Category the sales reason belongs to.
        /// </summary>
        [StringLength(50)]
        public string ReasonType { get; set; } = null!;
        /// <summary>
        /// Date and time the record was last updated.
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [InverseProperty(nameof(SalesOrderHeaderSalesReason.SalesReason))]
        public virtual ICollection<SalesOrderHeaderSalesReason> SalesOrderHeaderSalesReasons { get; set; }
    }
}

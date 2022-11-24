using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Adventureworks.Data
{
    /// <summary>
    /// Manufacturing failure reasons lookup table.
    /// </summary>
    [Table("ScrapReason", Schema = "Production")]
    [Index(nameof(Name), Name = "AK_ScrapReason_Name", IsUnique = true)]
    public partial class ScrapReason
    {
        public ScrapReason()
        {
            WorkOrders = new HashSet<WorkOrder>();
        }

        /// <summary>
        /// Primary key for ScrapReason records.
        /// </summary>
        [Key]
        [Column("ScrapReasonID")]
        public short ScrapReasonId { get; set; }
        /// <summary>
        /// Failure description.
        /// </summary>
        [StringLength(50)]
        public string Name { get; set; } = null!;
        /// <summary>
        /// Date and time the record was last updated.
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [InverseProperty(nameof(WorkOrder.ScrapReason))]
        public virtual ICollection<WorkOrder> WorkOrders { get; set; }
    }
}

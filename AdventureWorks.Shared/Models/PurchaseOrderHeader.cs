using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Adventureworks.Data
{
    /// <summary>
    /// General purchase order information. See PurchaseOrderDetail.
    /// </summary>
    [Table("PurchaseOrderHeader", Schema = "Purchasing")]
    [Index(nameof(EmployeeId), Name = "IX_PurchaseOrderHeader_EmployeeID")]
    [Index(nameof(VendorId), Name = "IX_PurchaseOrderHeader_VendorID")]
    public partial class PurchaseOrderHeader
    {
        public PurchaseOrderHeader()
        {
            PurchaseOrderDetails = new HashSet<PurchaseOrderDetail>();
        }

        /// <summary>
        /// Primary key.
        /// </summary>
        [Key]
        [Column("PurchaseOrderID")]
        public int PurchaseOrderId { get; set; }
        /// <summary>
        /// Incremental number to track changes to the purchase order over time.
        /// </summary>
        public byte RevisionNumber { get; set; }
        /// <summary>
        /// Order current status. 1 = Pending; 2 = Approved; 3 = Rejected; 4 = Complete
        /// </summary>
        public byte Status { get; set; }
        /// <summary>
        /// Employee who created the purchase order. Foreign key to Employee.BusinessEntityID.
        /// </summary>
        [Column("EmployeeID")]
        public int EmployeeId { get; set; }
        /// <summary>
        /// Vendor with whom the purchase order is placed. Foreign key to Vendor.BusinessEntityID.
        /// </summary>
        [Column("VendorID")]
        public int VendorId { get; set; }
        /// <summary>
        /// Shipping method. Foreign key to ShipMethod.ShipMethodID.
        /// </summary>
        [Column("ShipMethodID")]
        public int ShipMethodId { get; set; }
        /// <summary>
        /// Purchase order creation date.
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime OrderDate { get; set; }
        /// <summary>
        /// Estimated shipment date from the vendor.
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? ShipDate { get; set; }
        /// <summary>
        /// Purchase order subtotal. Computed as SUM(PurchaseOrderDetail.LineTotal)for the appropriate PurchaseOrderID.
        /// </summary>
        [Column(TypeName = "money")]
        public decimal SubTotal { get; set; }
        /// <summary>
        /// Tax amount.
        /// </summary>
        [Column(TypeName = "money")]
        public decimal TaxAmt { get; set; }
        /// <summary>
        /// Shipping cost.
        /// </summary>
        [Column(TypeName = "money")]
        public decimal Freight { get; set; }
        /// <summary>
        /// Total due to vendor. Computed as Subtotal + TaxAmt + Freight.
        /// </summary>
        [Column(TypeName = "money")]
        public decimal TotalDue { get; set; }
        /// <summary>
        /// Date and time the record was last updated.
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        [InverseProperty("PurchaseOrderHeaders")]
        public virtual Employee Employee { get; set; } = null!;
        [ForeignKey(nameof(ShipMethodId))]
        [InverseProperty("PurchaseOrderHeaders")]
        public virtual ShipMethod ShipMethod { get; set; } = null!;
        [ForeignKey(nameof(VendorId))]
        [InverseProperty("PurchaseOrderHeaders")]
        public virtual Vendor Vendor { get; set; } = null!;
        [InverseProperty(nameof(PurchaseOrderDetail.PurchaseOrder))]
        public virtual ICollection<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
    }
}

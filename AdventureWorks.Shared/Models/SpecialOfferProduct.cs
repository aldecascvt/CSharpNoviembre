using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Adventureworks.Data
{
    /// <summary>
    /// Cross-reference table mapping products to special offer discounts.
    /// </summary>
    [Table("SpecialOfferProduct", Schema = "Sales")]
    [Index(nameof(Rowguid), Name = "AK_SpecialOfferProduct_rowguid", IsUnique = true)]
    [Index(nameof(ProductId), Name = "IX_SpecialOfferProduct_ProductID")]
    public partial class SpecialOfferProduct
    {
        public SpecialOfferProduct()
        {
            SalesOrderDetails = new HashSet<SalesOrderDetail>();
        }

        /// <summary>
        /// Primary key for SpecialOfferProduct records.
        /// </summary>
        [Key]
        [Column("SpecialOfferID")]
        public int SpecialOfferId { get; set; }
        /// <summary>
        /// Product identification number. Foreign key to Product.ProductID.
        /// </summary>
        [Key]
        [Column("ProductID")]
        public int ProductId { get; set; }
        /// <summary>
        /// ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.
        /// </summary>
        [Column("rowguid")]
        public Guid Rowguid { get; set; }
        /// <summary>
        /// Date and time the record was last updated.
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey(nameof(ProductId))]
        [InverseProperty("SpecialOfferProducts")]
        public virtual Product Product { get; set; } = null!;
        [ForeignKey(nameof(SpecialOfferId))]
        [InverseProperty("SpecialOfferProducts")]
        public virtual SpecialOffer SpecialOffer { get; set; } = null!;
        [InverseProperty(nameof(SalesOrderDetail.SpecialOfferProduct))]
        public virtual ICollection<SalesOrderDetail> SalesOrderDetails { get; set; }
    }
}

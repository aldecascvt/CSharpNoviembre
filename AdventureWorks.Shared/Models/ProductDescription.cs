using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Adventureworks.Data
{
    /// <summary>
    /// Product descriptions in several languages.
    /// </summary>
    [Table("ProductDescription", Schema = "Production")]
    [Index(nameof(Rowguid), Name = "AK_ProductDescription_rowguid", IsUnique = true)]
    public partial class ProductDescription
    {
        public ProductDescription()
        {
            ProductModelProductDescriptionCultures = new HashSet<ProductModelProductDescriptionCulture>();
        }

        /// <summary>
        /// Primary key for ProductDescription records.
        /// </summary>
        [Key]
        [Column("ProductDescriptionID")]
        public int ProductDescriptionId { get; set; }
        /// <summary>
        /// Description of the product.
        /// </summary>
        [StringLength(400)]
        public string Description { get; set; } = null!;
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

        [InverseProperty(nameof(ProductModelProductDescriptionCulture.ProductDescription))]
        public virtual ICollection<ProductModelProductDescriptionCulture> ProductModelProductDescriptionCultures { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Adventureworks.Data
{
    /// <summary>
    /// High-level product categorization.
    /// </summary>
    [Table("ProductCategory", Schema = "Production")]
    [Index(nameof(Name), Name = "AK_ProductCategory_Name", IsUnique = true)]
    [Index(nameof(Rowguid), Name = "AK_ProductCategory_rowguid", IsUnique = true)]
    public partial class ProductCategory
    {
        public ProductCategory()
        {
            ProductSubcategories = new HashSet<ProductSubcategory>();
        }

        /// <summary>
        /// Primary key for ProductCategory records.
        /// </summary>
        [Key]
        [Column("ProductCategoryID")]
        public int ProductCategoryId { get; set; }
        /// <summary>
        /// Category description.
        /// </summary>
        [StringLength(50)]
        public string Name { get; set; } = null!;
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

        [InverseProperty(nameof(ProductSubcategory.ProductCategory))]
        public virtual ICollection<ProductSubcategory> ProductSubcategories { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Adventureworks.Data
{
    /// <summary>
    /// Product model classification.
    /// </summary>
    [Table("ProductModel", Schema = "Production")]
    [Index(nameof(Name), Name = "AK_ProductModel_Name", IsUnique = true)]
    [Index(nameof(Rowguid), Name = "AK_ProductModel_rowguid", IsUnique = true)]
    [Index(nameof(CatalogDescription), Name = "PXML_ProductModel_CatalogDescription")]
    [Index(nameof(Instructions), Name = "PXML_ProductModel_Instructions")]
    public partial class ProductModel
    {
        public ProductModel()
        {
            ProductModelIllustrations = new HashSet<ProductModelIllustration>();
            ProductModelProductDescriptionCultures = new HashSet<ProductModelProductDescriptionCulture>();
            Products = new HashSet<Product>();
        }

        /// <summary>
        /// Primary key for ProductModel records.
        /// </summary>
        [Key]
        [Column("ProductModelID")]
        public int ProductModelId { get; set; }
        /// <summary>
        /// Product model description.
        /// </summary>
        [StringLength(50)]
        public string Name { get; set; } = null!;
        /// <summary>
        /// Detailed product catalog information in xml format.
        /// </summary>
        [Column(TypeName = "xml")]
        public string? CatalogDescription { get; set; }
        /// <summary>
        /// Manufacturing instructions in xml format.
        /// </summary>
        [Column(TypeName = "xml")]
        public string? Instructions { get; set; }
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

        [InverseProperty(nameof(ProductModelIllustration.ProductModel))]
        public virtual ICollection<ProductModelIllustration> ProductModelIllustrations { get; set; }
        [InverseProperty(nameof(ProductModelProductDescriptionCulture.ProductModel))]
        public virtual ICollection<ProductModelProductDescriptionCulture> ProductModelProductDescriptionCultures { get; set; }
        [InverseProperty(nameof(Product.ProductModel))]
        public virtual ICollection<Product> Products { get; set; }
    }
}

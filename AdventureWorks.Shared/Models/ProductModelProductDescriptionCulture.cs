using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Adventureworks.Data
{
    /// <summary>
    /// Cross-reference table mapping product descriptions and the language the description is written in.
    /// </summary>
    [Table("ProductModelProductDescriptionCulture", Schema = "Production")]
    public partial class ProductModelProductDescriptionCulture
    {
        /// <summary>
        /// Primary key. Foreign key to ProductModel.ProductModelID.
        /// </summary>
        [Key]
        [Column("ProductModelID")]
        public int ProductModelId { get; set; }
        /// <summary>
        /// Primary key. Foreign key to ProductDescription.ProductDescriptionID.
        /// </summary>
        [Key]
        [Column("ProductDescriptionID")]
        public int ProductDescriptionId { get; set; }
        /// <summary>
        /// Culture identification number. Foreign key to Culture.CultureID.
        /// </summary>
        [Key]
        [Column("CultureID")]
        [StringLength(6)]
        public string CultureId { get; set; } = null!;
        /// <summary>
        /// Date and time the record was last updated.
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey(nameof(CultureId))]
        [InverseProperty("ProductModelProductDescriptionCultures")]
        public virtual Culture Culture { get; set; } = null!;
        [ForeignKey(nameof(ProductDescriptionId))]
        [InverseProperty("ProductModelProductDescriptionCultures")]
        public virtual ProductDescription ProductDescription { get; set; } = null!;
        [ForeignKey(nameof(ProductModelId))]
        [InverseProperty("ProductModelProductDescriptionCultures")]
        public virtual ProductModel ProductModel { get; set; } = null!;
    }
}

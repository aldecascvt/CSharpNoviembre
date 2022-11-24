using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Adventureworks.Data
{
    /// <summary>
    /// Unit of measure lookup table.
    /// </summary>
    [Table("UnitMeasure", Schema = "Production")]
    [Index(nameof(Name), Name = "AK_UnitMeasure_Name", IsUnique = true)]
    public partial class UnitMeasure
    {
        public UnitMeasure()
        {
            BillOfMaterials = new HashSet<BillOfMaterial>();
            ProductSizeUnitMeasureCodeNavigations = new HashSet<Product>();
            ProductVendors = new HashSet<ProductVendor>();
            ProductWeightUnitMeasureCodeNavigations = new HashSet<Product>();
        }

        /// <summary>
        /// Primary key.
        /// </summary>
        [Key]
        [StringLength(3)]
        public string UnitMeasureCode { get; set; } = null!;
        /// <summary>
        /// Unit of measure description.
        /// </summary>
        [StringLength(50)]
        public string Name { get; set; } = null!;
        /// <summary>
        /// Date and time the record was last updated.
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [InverseProperty(nameof(BillOfMaterial.UnitMeasureCodeNavigation))]
        public virtual ICollection<BillOfMaterial> BillOfMaterials { get; set; }
        [InverseProperty(nameof(Product.SizeUnitMeasureCodeNavigation))]
        public virtual ICollection<Product> ProductSizeUnitMeasureCodeNavigations { get; set; }
        [InverseProperty(nameof(ProductVendor.UnitMeasureCodeNavigation))]
        public virtual ICollection<ProductVendor> ProductVendors { get; set; }
        [InverseProperty(nameof(Product.WeightUnitMeasureCodeNavigation))]
        public virtual ICollection<Product> ProductWeightUnitMeasureCodeNavigations { get; set; }
    }
}

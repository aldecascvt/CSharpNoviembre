using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Adventureworks.Data
{
    /// <summary>
    /// Lookup table containing the languages in which some AdventureWorks data is stored.
    /// </summary>
    [Table("Culture", Schema = "Production")]
    [Index(nameof(Name), Name = "AK_Culture_Name", IsUnique = true)]
    public partial class Culture
    {
        public Culture()
        {
            ProductModelProductDescriptionCultures = new HashSet<ProductModelProductDescriptionCulture>();
        }

        /// <summary>
        /// Primary key for Culture records.
        /// </summary>
        [Key]
        [Column("CultureID")]
        [StringLength(6)]
        public string CultureId { get; set; } = null!;
        /// <summary>
        /// Culture description.
        /// </summary>
        [StringLength(50)]
        public string Name { get; set; } = null!;
        /// <summary>
        /// Date and time the record was last updated.
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [InverseProperty(nameof(ProductModelProductDescriptionCulture.Culture))]
        public virtual ICollection<ProductModelProductDescriptionCulture> ProductModelProductDescriptionCultures { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Adventureworks.Data
{
    /// <summary>
    /// Lookup table containing the ISO standard codes for countries and regions.
    /// </summary>
    [Table("CountryRegion", Schema = "Person")]
    [Index(nameof(Name), Name = "AK_CountryRegion_Name", IsUnique = true)]
    public partial class CountryRegion
    {
        public CountryRegion()
        {
            CountryRegionCurrencies = new HashSet<CountryRegionCurrency>();
            SalesTerritories = new HashSet<SalesTerritory>();
            StateProvinces = new HashSet<StateProvince>();
        }

        /// <summary>
        /// ISO standard code for countries and regions.
        /// </summary>
        [Key]
        [StringLength(3)]
        public string CountryRegionCode { get; set; } = null!;
        /// <summary>
        /// Country or region name.
        /// </summary>
        [StringLength(50)]
        public string Name { get; set; } = null!;
        /// <summary>
        /// Date and time the record was last updated.
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [InverseProperty(nameof(CountryRegionCurrency.CountryRegionCodeNavigation))]
        public virtual ICollection<CountryRegionCurrency> CountryRegionCurrencies { get; set; }
        [InverseProperty(nameof(SalesTerritory.CountryRegionCodeNavigation))]
        public virtual ICollection<SalesTerritory> SalesTerritories { get; set; }
        [InverseProperty(nameof(StateProvince.CountryRegionCodeNavigation))]
        public virtual ICollection<StateProvince> StateProvinces { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Adventureworks.Data
{
    /// <summary>
    /// Lookup table containing standard ISO currencies.
    /// </summary>
    [Table("Currency", Schema = "Sales")]
    [Index(nameof(Name), Name = "AK_Currency_Name", IsUnique = true)]
    public partial class Currency
    {
        public Currency()
        {
            CountryRegionCurrencies = new HashSet<CountryRegionCurrency>();
            CurrencyRateFromCurrencyCodeNavigations = new HashSet<CurrencyRate>();
            CurrencyRateToCurrencyCodeNavigations = new HashSet<CurrencyRate>();
        }

        /// <summary>
        /// The ISO code for the Currency.
        /// </summary>
        [Key]
        [StringLength(3)]
        public string CurrencyCode { get; set; } = null!;
        /// <summary>
        /// Currency name.
        /// </summary>
        [StringLength(50)]
        public string Name { get; set; } = null!;
        /// <summary>
        /// Date and time the record was last updated.
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [InverseProperty(nameof(CountryRegionCurrency.CurrencyCodeNavigation))]
        public virtual ICollection<CountryRegionCurrency> CountryRegionCurrencies { get; set; }
        [InverseProperty(nameof(CurrencyRate.FromCurrencyCodeNavigation))]
        public virtual ICollection<CurrencyRate> CurrencyRateFromCurrencyCodeNavigations { get; set; }
        [InverseProperty(nameof(CurrencyRate.ToCurrencyCodeNavigation))]
        public virtual ICollection<CurrencyRate> CurrencyRateToCurrencyCodeNavigations { get; set; }
    }
}

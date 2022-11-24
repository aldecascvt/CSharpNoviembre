using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Adventureworks.Data
{
    /// <summary>
    /// Currency exchange rates.
    /// </summary>
    [Table("CurrencyRate", Schema = "Sales")]
    [Index(nameof(CurrencyRateDate), nameof(FromCurrencyCode), nameof(ToCurrencyCode), Name = "AK_CurrencyRate_CurrencyRateDate_FromCurrencyCode_ToCurrencyCode", IsUnique = true)]
    public partial class CurrencyRate
    {
        public CurrencyRate()
        {
            SalesOrderHeaders = new HashSet<SalesOrderHeader>();
        }

        /// <summary>
        /// Primary key for CurrencyRate records.
        /// </summary>
        [Key]
        [Column("CurrencyRateID")]
        public int CurrencyRateId { get; set; }
        /// <summary>
        /// Date and time the exchange rate was obtained.
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime CurrencyRateDate { get; set; }
        /// <summary>
        /// Exchange rate was converted from this currency code.
        /// </summary>
        [StringLength(3)]
        public string FromCurrencyCode { get; set; } = null!;
        /// <summary>
        /// Exchange rate was converted to this currency code.
        /// </summary>
        [StringLength(3)]
        public string ToCurrencyCode { get; set; } = null!;
        /// <summary>
        /// Average exchange rate for the day.
        /// </summary>
        [Column(TypeName = "money")]
        public decimal AverageRate { get; set; }
        /// <summary>
        /// Final exchange rate for the day.
        /// </summary>
        [Column(TypeName = "money")]
        public decimal EndOfDayRate { get; set; }
        /// <summary>
        /// Date and time the record was last updated.
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey(nameof(FromCurrencyCode))]
        [InverseProperty(nameof(Currency.CurrencyRateFromCurrencyCodeNavigations))]
        public virtual Currency FromCurrencyCodeNavigation { get; set; } = null!;
        [ForeignKey(nameof(ToCurrencyCode))]
        [InverseProperty(nameof(Currency.CurrencyRateToCurrencyCodeNavigations))]
        public virtual Currency ToCurrencyCodeNavigation { get; set; } = null!;
        [InverseProperty(nameof(SalesOrderHeader.CurrencyRate))]
        public virtual ICollection<SalesOrderHeader> SalesOrderHeaders { get; set; }
    }
}

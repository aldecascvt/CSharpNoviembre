using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Adventureworks.Data
{
    /// <summary>
    /// Stores (including demographics) that sell Adventure Works Cycles products to consumers.
    /// </summary>
    [Keyless]
    public partial class VStoreWithDemographic
    {
        [Column("BusinessEntityID")]
        public int BusinessEntityId { get; set; }
        [StringLength(50)]
        public string Name { get; set; } = null!;
        [Column(TypeName = "money")]
        public decimal? AnnualSales { get; set; }
        [Column(TypeName = "money")]
        public decimal? AnnualRevenue { get; set; }
        [StringLength(50)]
        public string? BankName { get; set; }
        [StringLength(5)]
        public string? BusinessType { get; set; }
        public int? YearOpened { get; set; }
        [StringLength(50)]
        public string? Specialty { get; set; }
        public int? SquareFeet { get; set; }
        [StringLength(30)]
        public string? Brands { get; set; }
        [StringLength(30)]
        public string? Internet { get; set; }
        public int? NumberEmployees { get; set; }
    }
}

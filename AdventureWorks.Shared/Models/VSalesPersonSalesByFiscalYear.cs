using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Adventureworks.Data
{
    /// <summary>
    /// Uses PIVOT to return aggregated sales information for each sales representative.
    /// </summary>
    [Keyless]
    public partial class VSalesPersonSalesByFiscalYear
    {
        [Column("SalesPersonID")]
        public int? SalesPersonId { get; set; }
        [StringLength(152)]
        public string? FullName { get; set; }
        [StringLength(50)]
        public string JobTitle { get; set; } = null!;
        [StringLength(50)]
        public string SalesTerritory { get; set; } = null!;
        [Column("2002", TypeName = "money")]
        public decimal? _2002 { get; set; }
        [Column("2003", TypeName = "money")]
        public decimal? _2003 { get; set; }
        [Column("2004", TypeName = "money")]
        public decimal? _2004 { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Adventureworks.Data
{
    /// <summary>
    /// Joins StateProvince table with CountryRegion table.
    /// </summary>
    [Keyless]
    public partial class VStateProvinceCountryRegion
    {
        [Column("StateProvinceID")]
        public int StateProvinceId { get; set; }
        [StringLength(3)]
        public string StateProvinceCode { get; set; } = null!;
        public bool IsOnlyStateProvinceFlag { get; set; }
        [StringLength(50)]
        public string StateProvinceName { get; set; } = null!;
        [Column("TerritoryID")]
        public int TerritoryId { get; set; }
        [StringLength(3)]
        public string CountryRegionCode { get; set; } = null!;
        [StringLength(50)]
        public string CountryRegionName { get; set; } = null!;
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Adventureworks.Data
{
    /// <summary>
    /// Sales representiatives (names and addresses) and their sales-related information.
    /// </summary>
    [Keyless]
    public partial class VSalesPerson
    {
        [Column("BusinessEntityID")]
        public int BusinessEntityId { get; set; }
        [StringLength(8)]
        public string? Title { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; } = null!;
        [StringLength(50)]
        public string? MiddleName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; } = null!;
        [StringLength(10)]
        public string? Suffix { get; set; }
        [StringLength(50)]
        public string JobTitle { get; set; } = null!;
        [StringLength(25)]
        public string? PhoneNumber { get; set; }
        [StringLength(50)]
        public string? PhoneNumberType { get; set; }
        [StringLength(50)]
        public string? EmailAddress { get; set; }
        public int EmailPromotion { get; set; }
        [StringLength(60)]
        public string AddressLine1 { get; set; } = null!;
        [StringLength(60)]
        public string? AddressLine2 { get; set; }
        [StringLength(30)]
        public string City { get; set; } = null!;
        [StringLength(50)]
        public string StateProvinceName { get; set; } = null!;
        [StringLength(15)]
        public string PostalCode { get; set; } = null!;
        [StringLength(50)]
        public string CountryRegionName { get; set; } = null!;
        [StringLength(50)]
        public string? TerritoryName { get; set; }
        [StringLength(50)]
        public string? TerritoryGroup { get; set; }
        [Column(TypeName = "money")]
        public decimal? SalesQuota { get; set; }
        [Column("SalesYTD", TypeName = "money")]
        public decimal SalesYtd { get; set; }
        [Column(TypeName = "money")]
        public decimal SalesLastYear { get; set; }
    }
}

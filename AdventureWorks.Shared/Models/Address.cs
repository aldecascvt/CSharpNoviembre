using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Adventureworks.Data
{
    /// <summary>
    /// Street address information for customers, employees, and vendors.
    /// </summary>
    [Table("Address", Schema = "Person")]
    [Index(nameof(Rowguid), Name = "AK_Address_rowguid", IsUnique = true)]
    [Index(nameof(AddressLine1), nameof(AddressLine2), nameof(City), nameof(StateProvinceId), nameof(PostalCode), Name = "IX_Address_AddressLine1_AddressLine2_City_StateProvinceID_PostalCode", IsUnique = true)]
    [Index(nameof(StateProvinceId), Name = "IX_Address_StateProvinceID")]
    public partial class Address
    {
        public Address()
        {
            BusinessEntityAddresses = new HashSet<BusinessEntityAddress>();
            SalesOrderHeaderBillToAddresses = new HashSet<SalesOrderHeader>();
            SalesOrderHeaderShipToAddresses = new HashSet<SalesOrderHeader>();
        }

        /// <summary>
        /// Primary key for Address records.
        /// </summary>
        [Key]
        [Column("AddressID")]
        public int AddressId { get; set; }
        /// <summary>
        /// First street address line.
        /// </summary>
        [StringLength(60)]
        public string AddressLine1 { get; set; } = null!;
        /// <summary>
        /// Second street address line.
        /// </summary>
        [StringLength(60)]
        public string? AddressLine2 { get; set; }
        /// <summary>
        /// Name of the city.
        /// </summary>
        [StringLength(30)]
        public string City { get; set; } = null!;
        /// <summary>
        /// Unique identification number for the state or province. Foreign key to StateProvince table.
        /// </summary>
        [Column("StateProvinceID")]
        public int StateProvinceId { get; set; }
        /// <summary>
        /// Postal code for the street address.
        /// </summary>
        [StringLength(15)]
        public string PostalCode { get; set; } = null!;
        /// <summary>
        /// ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.
        /// </summary>
        [Column("rowguid")]
        public Guid Rowguid { get; set; }
        /// <summary>
        /// Date and time the record was last updated.
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey(nameof(StateProvinceId))]
        [InverseProperty("Addresses")]
        public virtual StateProvince StateProvince { get; set; } = null!;
        [InverseProperty(nameof(BusinessEntityAddress.Address))]
        public virtual ICollection<BusinessEntityAddress> BusinessEntityAddresses { get; set; }
        [InverseProperty(nameof(SalesOrderHeader.BillToAddress))]
        public virtual ICollection<SalesOrderHeader> SalesOrderHeaderBillToAddresses { get; set; }
        [InverseProperty(nameof(SalesOrderHeader.ShipToAddress))]
        public virtual ICollection<SalesOrderHeader> SalesOrderHeaderShipToAddresses { get; set; }
    }
}

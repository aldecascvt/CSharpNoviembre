using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Adventureworks.Data
{
    /// <summary>
    /// Cross-reference table mapping customers, vendors, and employees to their addresses.
    /// </summary>
    [Table("BusinessEntityAddress", Schema = "Person")]
    [Index(nameof(Rowguid), Name = "AK_BusinessEntityAddress_rowguid", IsUnique = true)]
    [Index(nameof(AddressId), Name = "IX_BusinessEntityAddress_AddressID")]
    [Index(nameof(AddressTypeId), Name = "IX_BusinessEntityAddress_AddressTypeID")]
    public partial class BusinessEntityAddress
    {
        /// <summary>
        /// Primary key. Foreign key to BusinessEntity.BusinessEntityID.
        /// </summary>
        [Key]
        [Column("BusinessEntityID")]
        public int BusinessEntityId { get; set; }
        /// <summary>
        /// Primary key. Foreign key to Address.AddressID.
        /// </summary>
        [Key]
        [Column("AddressID")]
        public int AddressId { get; set; }
        /// <summary>
        /// Primary key. Foreign key to AddressType.AddressTypeID.
        /// </summary>
        [Key]
        [Column("AddressTypeID")]
        public int AddressTypeId { get; set; }
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

        [ForeignKey(nameof(AddressId))]
        [InverseProperty("BusinessEntityAddresses")]
        public virtual Address Address { get; set; } = null!;
        [ForeignKey(nameof(AddressTypeId))]
        [InverseProperty("BusinessEntityAddresses")]
        public virtual AddressType AddressType { get; set; } = null!;
        [ForeignKey(nameof(BusinessEntityId))]
        [InverseProperty("BusinessEntityAddresses")]
        public virtual BusinessEntity BusinessEntity { get; set; } = null!;
    }
}

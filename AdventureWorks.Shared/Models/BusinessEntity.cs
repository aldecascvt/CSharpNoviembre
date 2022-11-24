using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Adventureworks.Data
{
    /// <summary>
    /// Source of the ID that connects vendors, customers, and employees with address and contact information.
    /// </summary>
    [Table("BusinessEntity", Schema = "Person")]
    [Index(nameof(Rowguid), Name = "AK_BusinessEntity_rowguid", IsUnique = true)]
    public partial class BusinessEntity
    {
        public BusinessEntity()
        {
            BusinessEntityAddresses = new HashSet<BusinessEntityAddress>();
            BusinessEntityContacts = new HashSet<BusinessEntityContact>();
        }

        /// <summary>
        /// Primary key for all customers, vendors, and employees.
        /// </summary>
        [Key]
        [Column("BusinessEntityID")]
        public int BusinessEntityId { get; set; }
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

        [InverseProperty("BusinessEntity")]
        public virtual Person Person { get; set; } = null!;
        [InverseProperty("BusinessEntity")]
        public virtual Store Store { get; set; } = null!;
        [InverseProperty("BusinessEntity")]
        public virtual Vendor Vendor { get; set; } = null!;
        [InverseProperty(nameof(BusinessEntityAddress.BusinessEntity))]
        public virtual ICollection<BusinessEntityAddress> BusinessEntityAddresses { get; set; }
        [InverseProperty(nameof(BusinessEntityContact.BusinessEntity))]
        public virtual ICollection<BusinessEntityContact> BusinessEntityContacts { get; set; }
    }
}

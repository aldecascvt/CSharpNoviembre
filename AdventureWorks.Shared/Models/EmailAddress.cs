using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Adventureworks.Data
{
    /// <summary>
    /// Where to send a person email.
    /// </summary>
    [Table("EmailAddress", Schema = "Person")]
    [Index(nameof(EmailAddress1), Name = "IX_EmailAddress_EmailAddress")]
    public partial class EmailAddress
    {
        /// <summary>
        /// Primary key. Person associated with this email address.  Foreign key to Person.BusinessEntityID
        /// </summary>
        [Key]
        [Column("BusinessEntityID")]
        public int BusinessEntityId { get; set; }
        /// <summary>
        /// Primary key. ID of this email address.
        /// </summary>
        [Key]
        [Column("EmailAddressID")]
        public int EmailAddressId { get; set; }
        /// <summary>
        /// E-mail address for the person.
        /// </summary>
        [Column("EmailAddress")]
        [StringLength(50)]
        public string? EmailAddress1 { get; set; }
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

        [ForeignKey(nameof(BusinessEntityId))]
        [InverseProperty(nameof(Person.EmailAddresses))]
        public virtual Person BusinessEntity { get; set; } = null!;
    }
}

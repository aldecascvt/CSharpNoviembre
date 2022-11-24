using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Adventureworks.Data
{
    /// <summary>
    /// Telephone number and type of a person.
    /// </summary>
    [Table("PersonPhone", Schema = "Person")]
    [Index(nameof(PhoneNumber), Name = "IX_PersonPhone_PhoneNumber")]
    public partial class PersonPhone
    {
        /// <summary>
        /// Business entity identification number. Foreign key to Person.BusinessEntityID.
        /// </summary>
        [Key]
        [Column("BusinessEntityID")]
        public int BusinessEntityId { get; set; }
        /// <summary>
        /// Telephone number identification number.
        /// </summary>
        [Key]
        [StringLength(25)]
        public string PhoneNumber { get; set; } = null!;
        /// <summary>
        /// Kind of phone number. Foreign key to PhoneNumberType.PhoneNumberTypeID.
        /// </summary>
        [Key]
        [Column("PhoneNumberTypeID")]
        public int PhoneNumberTypeId { get; set; }
        /// <summary>
        /// Date and time the record was last updated.
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey(nameof(BusinessEntityId))]
        [InverseProperty(nameof(Person.PersonPhones))]
        public virtual Person BusinessEntity { get; set; } = null!;
        [ForeignKey(nameof(PhoneNumberTypeId))]
        [InverseProperty("PersonPhones")]
        public virtual PhoneNumberType PhoneNumberType { get; set; } = null!;
    }
}

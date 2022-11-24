using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Adventureworks.Data
{
    /// <summary>
    /// Type of phone number of a person.
    /// </summary>
    [Table("PhoneNumberType", Schema = "Person")]
    public partial class PhoneNumberType
    {
        public PhoneNumberType()
        {
            PersonPhones = new HashSet<PersonPhone>();
        }

        /// <summary>
        /// Primary key for telephone number type records.
        /// </summary>
        [Key]
        [Column("PhoneNumberTypeID")]
        public int PhoneNumberTypeId { get; set; }
        /// <summary>
        /// Name of the telephone number type
        /// </summary>
        [StringLength(50)]
        public string Name { get; set; } = null!;
        /// <summary>
        /// Date and time the record was last updated.
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [InverseProperty(nameof(PersonPhone.PhoneNumberType))]
        public virtual ICollection<PersonPhone> PersonPhones { get; set; }
    }
}

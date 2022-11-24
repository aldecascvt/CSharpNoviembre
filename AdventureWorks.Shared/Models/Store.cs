using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Adventureworks.Data
{
    /// <summary>
    /// Customers (resellers) of Adventure Works products.
    /// </summary>
    [Table("Store", Schema = "Sales")]
    [Index(nameof(Rowguid), Name = "AK_Store_rowguid", IsUnique = true)]
    [Index(nameof(SalesPersonId), Name = "IX_Store_SalesPersonID")]
    [Index(nameof(Demographics), Name = "PXML_Store_Demographics")]
    public partial class Store
    {
        public Store()
        {
            Customers = new HashSet<Customer>();
        }

        /// <summary>
        /// Primary key. Foreign key to Customer.BusinessEntityID.
        /// </summary>
        [Key]
        [Column("BusinessEntityID")]
        public int BusinessEntityId { get; set; }
        /// <summary>
        /// Name of the store.
        /// </summary>
        [StringLength(50)]
        public string Name { get; set; } = null!;
        /// <summary>
        /// ID of the sales person assigned to the customer. Foreign key to SalesPerson.BusinessEntityID.
        /// </summary>
        [Column("SalesPersonID")]
        public int? SalesPersonId { get; set; }
        /// <summary>
        /// Demographic informationg about the store such as the number of employees, annual sales and store type.
        /// </summary>
        [Column(TypeName = "xml")]
        public string? Demographics { get; set; }
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
        [InverseProperty("Store")]
        public virtual BusinessEntity BusinessEntity { get; set; } = null!;
        [ForeignKey(nameof(SalesPersonId))]
        [InverseProperty("Stores")]
        public virtual SalesPerson? SalesPerson { get; set; }
        [InverseProperty(nameof(Customer.Store))]
        public virtual ICollection<Customer> Customers { get; set; }
    }
}

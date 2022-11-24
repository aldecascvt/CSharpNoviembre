using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Adventureworks.Data
{
    /// <summary>
    /// Résumés submitted to Human Resources by job applicants.
    /// </summary>
    [Table("JobCandidate", Schema = "HumanResources")]
    [Index(nameof(BusinessEntityId), Name = "IX_JobCandidate_BusinessEntityID")]
    public partial class JobCandidate
    {
        /// <summary>
        /// Primary key for JobCandidate records.
        /// </summary>
        [Key]
        [Column("JobCandidateID")]
        public int JobCandidateId { get; set; }
        /// <summary>
        /// Employee identification number if applicant was hired. Foreign key to Employee.BusinessEntityID.
        /// </summary>
        [Column("BusinessEntityID")]
        public int? BusinessEntityId { get; set; }
        /// <summary>
        /// Résumé in XML format.
        /// </summary>
        [Column(TypeName = "xml")]
        public string? Resume { get; set; }
        /// <summary>
        /// Date and time the record was last updated.
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey(nameof(BusinessEntityId))]
        [InverseProperty(nameof(Employee.JobCandidates))]
        public virtual Employee? BusinessEntity { get; set; }
    }
}

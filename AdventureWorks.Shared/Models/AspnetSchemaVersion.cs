using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Adventureworks.Data
{
    [Table("aspnet_SchemaVersions")]
    public partial class AspnetSchemaVersion
    {
        [Key]
        [StringLength(128)]
        public string Feature { get; set; } = null!;
        [Key]
        [StringLength(128)]
        public string CompatibleSchemaVersion { get; set; } = null!;
        public bool IsCurrentVersion { get; set; }
    }
}

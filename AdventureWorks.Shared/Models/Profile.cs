using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Adventureworks.Data
{
    public partial class Profile
    {
        [Key]
        public Guid UserId { get; set; }
        [StringLength(4000)]
        public string PropertyNames { get; set; } = null!;
        [StringLength(4000)]
        public string PropertyValueStrings { get; set; } = null!;
        [Column(TypeName = "image")]
        public byte[] PropertyValueBinary { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime LastUpdatedDate { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty("Profile")]
        public virtual User User { get; set; } = null!;
    }
}

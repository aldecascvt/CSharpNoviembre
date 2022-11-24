using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Adventureworks.Data
{
    [Table("aspnet_PersonalizationPerUser")]
    [Index(nameof(UserId), nameof(PathId), Name = "aspnet_PersonalizationPerUser_ncindex2", IsUnique = true)]
    public partial class AspnetPersonalizationPerUser
    {
        [Key]
        public Guid Id { get; set; }
        public Guid? PathId { get; set; }
        public Guid? UserId { get; set; }
        [Column(TypeName = "image")]
        public byte[] PageSettings { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime LastUpdatedDate { get; set; }

        [ForeignKey(nameof(PathId))]
        [InverseProperty(nameof(AspnetPath.AspnetPersonalizationPerUsers))]
        public virtual AspnetPath? Path { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(AspnetUser.AspnetPersonalizationPerUsers))]
        public virtual AspnetUser? User { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Adventureworks.Data
{
    [Table("aspnet_Paths")]
    public partial class AspnetPath
    {
        public AspnetPath()
        {
            AspnetPersonalizationPerUsers = new HashSet<AspnetPersonalizationPerUser>();
        }

        public Guid ApplicationId { get; set; }
        [Key]
        public Guid PathId { get; set; }
        [StringLength(256)]
        public string Path { get; set; } = null!;
        [StringLength(256)]
        public string LoweredPath { get; set; } = null!;

        [ForeignKey(nameof(ApplicationId))]
        [InverseProperty(nameof(AspnetApplication.AspnetPaths))]
        public virtual AspnetApplication Application { get; set; } = null!;
        [InverseProperty("Path")]
        public virtual AspnetPersonalizationAllUser AspnetPersonalizationAllUser { get; set; } = null!;
        [InverseProperty(nameof(AspnetPersonalizationPerUser.Path))]
        public virtual ICollection<AspnetPersonalizationPerUser> AspnetPersonalizationPerUsers { get; set; }
    }
}

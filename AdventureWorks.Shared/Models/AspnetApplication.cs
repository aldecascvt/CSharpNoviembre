using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Adventureworks.Data
{
    [Table("aspnet_Applications")]
    [Index(nameof(LoweredApplicationName), Name = "UQ__aspnet_A__17477DE407663FFE", IsUnique = true)]
    [Index(nameof(ApplicationName), Name = "UQ__aspnet_A__3091033166715AFF", IsUnique = true)]
    public partial class AspnetApplication
    {
        public AspnetApplication()
        {
            AspnetMemberships = new HashSet<AspnetMembership>();
            AspnetPaths = new HashSet<AspnetPath>();
            AspnetRoles = new HashSet<AspnetRole>();
            AspnetUsers = new HashSet<AspnetUser>();
        }

        [StringLength(256)]
        public string ApplicationName { get; set; } = null!;
        [StringLength(256)]
        public string LoweredApplicationName { get; set; } = null!;
        [Key]
        public Guid ApplicationId { get; set; }
        [StringLength(256)]
        public string? Description { get; set; }

        [InverseProperty(nameof(AspnetMembership.Application))]
        public virtual ICollection<AspnetMembership> AspnetMemberships { get; set; }
        [InverseProperty(nameof(AspnetPath.Application))]
        public virtual ICollection<AspnetPath> AspnetPaths { get; set; }
        [InverseProperty(nameof(AspnetRole.Application))]
        public virtual ICollection<AspnetRole> AspnetRoles { get; set; }
        [InverseProperty(nameof(AspnetUser.Application))]
        public virtual ICollection<AspnetUser> AspnetUsers { get; set; }
    }
}

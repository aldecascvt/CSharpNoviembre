using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Adventureworks.Data
{
    [Table("aspnet_Roles")]
    public partial class AspnetRole
    {
        public AspnetRole()
        {
            Users = new HashSet<AspnetUser>();
        }

        public Guid ApplicationId { get; set; }
        [Key]
        public Guid RoleId { get; set; }
        [StringLength(256)]
        public string RoleName { get; set; } = null!;
        [StringLength(256)]
        public string LoweredRoleName { get; set; } = null!;
        [StringLength(256)]
        public string? Description { get; set; }

        [ForeignKey(nameof(ApplicationId))]
        [InverseProperty(nameof(AspnetApplication.AspnetRoles))]
        public virtual AspnetApplication Application { get; set; } = null!;

        [ForeignKey("RoleId")]
        [InverseProperty(nameof(AspnetUser.Roles))]
        public virtual ICollection<AspnetUser> Users { get; set; }
    }
}

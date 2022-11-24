using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Adventureworks.Data
{
    public partial class User
    {
        public User()
        {
            Roles = new HashSet<Role>();
        }

        public Guid ApplicationId { get; set; }
        [Key]
        public Guid UserId { get; set; }
        [StringLength(50)]
        public string UserName { get; set; } = null!;
        public bool IsAnonymous { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastActivityDate { get; set; }
        [StringLength(20)]
        public string UserPassword { get; set; } = null!;

        [ForeignKey(nameof(ApplicationId))]
        [InverseProperty("Users")]
        public virtual Application Application { get; set; } = null!;
        [InverseProperty("User")]
        public virtual Membership Membership { get; set; } = null!;
        [InverseProperty("User")]
        public virtual Parent Parent { get; set; } = null!;
        [InverseProperty("User")]
        public virtual Profile Profile { get; set; } = null!;
        [InverseProperty("User")]
        public virtual Student Student { get; set; } = null!;
        [InverseProperty("User")]
        public virtual Teacher Teacher { get; set; } = null!;

        [ForeignKey("UserId")]
        [InverseProperty(nameof(Role.Users))]
        public virtual ICollection<Role> Roles { get; set; }
    }
}

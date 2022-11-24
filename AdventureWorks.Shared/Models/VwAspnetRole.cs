using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Adventureworks.Data
{
    [Keyless]
    public partial class VwAspnetRole
    {
        public Guid ApplicationId { get; set; }
        public Guid RoleId { get; set; }
        [StringLength(256)]
        public string RoleName { get; set; } = null!;
        [StringLength(256)]
        public string LoweredRoleName { get; set; } = null!;
        [StringLength(256)]
        public string? Description { get; set; }
    }
}

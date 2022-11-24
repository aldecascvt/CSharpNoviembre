using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Adventureworks.Data
{
    [Keyless]
    public partial class VwAspnetUser
    {
        public Guid ApplicationId { get; set; }
        public Guid UserId { get; set; }
        [StringLength(256)]
        public string UserName { get; set; } = null!;
        [StringLength(256)]
        public string LoweredUserName { get; set; } = null!;
        [StringLength(16)]
        public string? MobileAlias { get; set; }
        public bool IsAnonymous { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastActivityDate { get; set; }
    }
}

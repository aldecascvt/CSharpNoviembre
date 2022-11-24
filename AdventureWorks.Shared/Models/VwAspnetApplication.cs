using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Adventureworks.Data
{
    [Keyless]
    public partial class VwAspnetApplication
    {
        [StringLength(256)]
        public string ApplicationName { get; set; } = null!;
        [StringLength(256)]
        public string LoweredApplicationName { get; set; } = null!;
        public Guid ApplicationId { get; set; }
        [StringLength(256)]
        public string? Description { get; set; }
    }
}

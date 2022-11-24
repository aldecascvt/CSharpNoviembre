using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Adventureworks.Data
{
    [Keyless]
    public partial class VwAspnetWebPartStatePath
    {
        public Guid ApplicationId { get; set; }
        public Guid PathId { get; set; }
        [StringLength(256)]
        public string Path { get; set; } = null!;
        [StringLength(256)]
        public string LoweredPath { get; set; } = null!;
    }
}

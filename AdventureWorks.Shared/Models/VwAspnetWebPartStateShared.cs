using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Adventureworks.Data
{
    [Keyless]
    public partial class VwAspnetWebPartStateShared
    {
        public Guid PathId { get; set; }
        public int? DataSize { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdatedDate { get; set; }
    }
}

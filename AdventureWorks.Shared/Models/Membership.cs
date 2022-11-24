using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Adventureworks.Data
{
    public partial class Membership
    {
        public Guid ApplicationId { get; set; }
        [Key]
        public Guid UserId { get; set; }
        [StringLength(128)]
        public string Password { get; set; } = null!;
        public int PasswordFormat { get; set; }
        [StringLength(128)]
        public string PasswordSalt { get; set; } = null!;
        [StringLength(256)]
        public string? Email { get; set; }
        [StringLength(256)]
        public string? PasswordQuestion { get; set; }
        [StringLength(128)]
        public string? PasswordAnswer { get; set; }
        public bool IsApproved { get; set; }
        public bool IsLockedOut { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreateDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastLoginDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastPasswordChangedDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastLockoutDate { get; set; }
        public int FailedPasswordAttemptCount { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime FailedPasswordAttemptWindowStart { get; set; }
        public int FailedPasswordAnswerAttemptCount { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime FailedPasswordAnswerAttemptWindowsStart { get; set; }
        [StringLength(256)]
        public string? Comment { get; set; }

        [ForeignKey(nameof(ApplicationId))]
        [InverseProperty("Memberships")]
        public virtual Application Application { get; set; } = null!;
        [ForeignKey(nameof(UserId))]
        [InverseProperty("Membership")]
        public virtual User User { get; set; } = null!;
    }
}

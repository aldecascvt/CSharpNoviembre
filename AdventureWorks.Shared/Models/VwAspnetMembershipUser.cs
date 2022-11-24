using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Adventureworks.Data
{
    [Keyless]
    public partial class VwAspnetMembershipUser
    {
        public Guid UserId { get; set; }
        public int PasswordFormat { get; set; }
        [Column("MobilePIN")]
        [StringLength(16)]
        public string? MobilePin { get; set; }
        [StringLength(256)]
        public string? Email { get; set; }
        [StringLength(256)]
        public string? LoweredEmail { get; set; }
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
        public DateTime FailedPasswordAnswerAttemptWindowStart { get; set; }
        [Column(TypeName = "ntext")]
        public string? Comment { get; set; }
        public Guid ApplicationId { get; set; }
        [StringLength(256)]
        public string UserName { get; set; } = null!;
        [StringLength(16)]
        public string? MobileAlias { get; set; }
        public bool IsAnonymous { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastActivityDate { get; set; }
    }
}

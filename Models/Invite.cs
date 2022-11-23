using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BugTracker.Models
{
    public class Invite
    {
        // primary key
        public int Id { get; set; }

        // foreign keys
        public int CompanyId { get; set; }
        public int ProjectId { get; set; }
        [Required]
        public string? InvitorId { get; set; }
        public string? InviteeId { get; set; }

        [Required]
        [DisplayName("Email")]
        public string? InviteeEmail { get; set; }
        [Required]
        [DisplayName("First Name")]
        public string? InviteeFirstName { get; set; }
        [Required]
        [DisplayName("Last Name")]
        public string? InviteeLastName { get; set; }

        public string? Message { get; set; }
        public bool IsValid { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Date Sent")]
        public DateTime InviteDate { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayName("Date Joined")]
        public DateTime JoinDate { get; set; }

        public Guid CompanyToken { get; set; }

        // nav props
        public virtual Company? Company { get; set; }
        public virtual Project? Project { get; set; }
        public virtual BTUser? Invitor { get; set; }
        public virtual BTUser? Invitee { get; set; }
    }
}

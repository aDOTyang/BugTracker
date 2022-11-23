using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BugTracker.Models
{
    public class Ticket
    {
        // primary key
        public int Id { get; set; }
        
        // foreign keys
        public int ProjectId { get; set; }
        public int TicketTypeId { get; set; }
        public int TicketStatusId { get; set; }
        public int TicketPriorityId { get; set; }
        public string? DeveloperUserId { get; set; }
        [Required]
        public string? SubmitterUserId { get; set; }


        [Required]
        [DisplayName("Ticket Title")]
        public string? Title { get; set; }
        
        [Required]
        [DisplayName("Ticket Description")]
        [StringLength(5000)]
        public string? Description { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Date Created")]
        public DateTime Created { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Date Updated")]
        public DateTime? Updated { get; set; }

        public bool Archived { get; set; }

        [DisplayName("Archived By Project")]
        public bool ArchivedByProject { get; set; }

        // nav props
        public virtual Project? Project { get; set; }
        [DisplayName("Priority")]
        public virtual TicketPriority? TicketPriority { get; set; }
        [DisplayName("Status")]
        public virtual TicketStatus? TicketStatus { get; set; }
        [DisplayName("Type")]
        public virtual TicketType? TicketType { get; set; }
        [DisplayName("Ticket Developer")]
        public virtual BTUser? DeveloperUser { get; set;}
        [DisplayName("Submitted By")]
        public virtual BTUser? SubmitterUser { get; set; }
        public virtual ICollection<TicketComment> Comments { get; set; } = new HashSet<TicketComment>();
        public virtual ICollection<TicketHistory> History { get; set; } = new HashSet<TicketHistory>();
        public virtual ICollection<TicketAttachment> Attachments { get; set; } = new HashSet<TicketAttachment>();
        public virtual ICollection<Notification> Notifications { get; set; } = new HashSet<Notification>();
    }
}

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BugTracker.Models
{
    public class Notification
    {
        // primary key
        public int Id { get; set; }

        // foreign keys
        public int? ProjectId { get; set; }
        public int? TicketId { get; set; }
        public string? SenderId { get; set; }
        public string? RecipientId { get; set; }
        public int NotificationTypeId {get; set;}


        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and max of {1} characters long.", MinimumLength = 2)]
        public string? Title { get; set; }

        [Required]
        [StringLength(1000, ErrorMessage = "The {0} must be at least {2} and max of {1} characters long.", MinimumLength = 2)]
        public string? Message { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Date Created")]
        public DateTime Created { get; set; }

        [DisplayName("Has Been Read")]
        public bool HasBeenViewed { get; set; }

        // nav props
        public virtual NotificationType? NotificationType { get; set; }
        public virtual Ticket? Tickets { get; set; }
        public virtual Project? Projects { get; set; }
        public virtual BTUser? Sender { get; set; }
        public virtual BTUser? Recipient { get; set; }
    }
}

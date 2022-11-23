using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BugTracker.Models
{
    public class TicketHistory
    {
        // primary key
        public int Id { get; set; }

        // foreign key
        public int TicketId { get; set; }


        [DisplayName("Updated Ticket Property")]
        public string? PropertyName { get; set; }
        [DisplayName("Description of Change")]
        [StringLength(2000)]
        public string? Description { get; set; }

        [DisplayName("Previous Value")]
        public string? OldValue { get; set; }
        [DisplayName("Current Value")]
        public string? NewValue { get; set; }

        [Required]
        public string? UserId { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Date Created")]
        public DateTime Created { get; set; }

        // nav props
        public virtual Ticket? Ticket { get; set; }
        [DisplayName("Team Member")]
        public virtual BTUser? User { get; set; }
    }
}

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BugTracker.Models
{
    public class TicketComment
    {
        // primary key
        public int Id { get; set; }

        // foreign keys
        public int TicketId { get; set; }
        [Required]
        public string? UserId { get; set; }


        [Required]
        [DisplayName("Member Comment")]
        [StringLength(2000)]
        public string? Comment { get; set; }

        [DisplayName("Created Date")]
        [DataType(DataType.Date)]
        public DateTime Created { get; set; }

        // nav prop
        public virtual Ticket? Ticket { get; set; }
        
        [DisplayName("Team Member")]
        public virtual BTUser? User { get; set; }
    }
}

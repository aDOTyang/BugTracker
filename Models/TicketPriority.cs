using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BugTracker.Models
{
    public class TicketPriority
    {
        // primary key
        public int Id { get; set; }

        [Required]
        [DisplayName("Ticket Priority")]
        public string? Name { get; set; }
    }
}

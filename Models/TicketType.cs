using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BugTracker.Models
{
    public class TicketType
    {
        // primary key
        public int Id { get; set; }

        [Required]
        [DisplayName("Ticket Type")]
        public string? Name { get; set; }
    }
}

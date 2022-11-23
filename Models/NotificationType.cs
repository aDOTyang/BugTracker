using System.ComponentModel;

namespace BugTracker.Models
{
    public class NotificationType
    {
        // primary key
        public int Id { get; set; }

        [DisplayName("Type Name")]
        public string? Name { get; set; }
    }
}

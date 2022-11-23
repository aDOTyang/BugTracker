using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BugTracker.Models
{
    public class ProjectPriority
    {
        // primary key
        public int Id { get; set; }

        [Required]
        [DisplayName("Project Priority Name")]
        public string? Name { get; set; }
    }
}

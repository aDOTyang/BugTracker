using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BugTracker.Models
{
    public class Project
    {
        // primary key
        public int Id { get; set; }
        // foreign key
        public int CompanyId { get; set; }
        public int? ProjectPriorityId { get; set; }
        

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and max of {1} characters long.", MinimumLength = 2)]
        public string? Name { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "The {0} must be at least {2} and max of {1} characters long.", MinimumLength = 2)]
        public string? Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime Created { get; set; }

        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }

        [DisplayName("Project Image")]
        public byte[]? ImageFileData { get; set; }
        [DisplayName("File Extension")]
        public string? ImageFileType { get; set; }

        [NotMapped]
        public IFormFile? ImageFormFile { get; set; }

        public bool Archived { get; set; }

        // nav props
        public virtual Company? Company { get; set; }
        public virtual ProjectPriority? ProjectPriority { get; set; }
        public virtual ICollection<BTUser> Members { get; set; } = new HashSet<BTUser>();
        public virtual ICollection<Ticket> Tickets { get; set; } = new HashSet<Ticket>();
    }
}

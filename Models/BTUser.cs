using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System.ComponentModel;

namespace BugTracker.Models
{
    public class BTUser : IdentityUser
    {
        [Required]
        [Display(Name = "First Name")]
        [StringLength(25, ErrorMessage = "The {0} must be at least {2} and max of {1} characters long.", MinimumLength = 2)]
        public string? FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(25, ErrorMessage = "The {0} must be at least {2} and max of {1} characters long.", MinimumLength = 2)]
        public string? LastName { get; set; }

        [NotMapped]
        public string? FullName { get { return $"{FirstName} {LastName}"; } }

        [DisplayName("User Image")]
        public byte[]? ImageFileData { get; set; }
        [DisplayName("File Extension")]
        public string? ImageFileType { get; set; }

        [NotMapped]
        public IFormFile? ImageFormFile { get; set; }

        // foreign key
        public int CompanyId { get; set; }

        // nav props
        public virtual Company? Company { get; set; }
        public virtual ICollection<Project> Projects { get; set; } = new HashSet<Project>();
    }
}

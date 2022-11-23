using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BugTracker.Models
{
    public class Company
    {
        // primary key
        public int Id { get; set; }

        [Required]
        [DisplayName("Company Name")]
        public string? Name { get; set; }

        [DisplayName("Company Description")]
        public string? Description { get; set; }

        [DisplayName("Company Image")]
        public byte[]? ImageFileData { get; set; }
        [DisplayName("File Extension")]
        public string? ImageFileType { get; set; }

        [NotMapped]
        public IFormFile? ImageFormFile { get; set; }

        // nav prop
        public virtual ICollection<Project> Projects { get; set; } = new HashSet<Project>();
        public virtual ICollection<BTUser> Members { get; set; } = new HashSet<BTUser>();
        public virtual ICollection<Invite> Invites { get; set; } = new HashSet<Invite>();
    }
}

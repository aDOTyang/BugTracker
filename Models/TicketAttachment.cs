using BugTracker.Extensions;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BugTracker.Models
{
    public class TicketAttachment
    {
        // primary key
        public int Id { get; set; }

        // foreign keys
        public int TicketId { get; set; }
        [Required]
        public string? UserId { get; set; }


        [DisplayName("File Description")]
        [StringLength(1000)]
        public string? Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime Created { get; set; }

        [DisplayName("File Name")]
        public string? FileName { get; set; }

        [DisplayName("File Attachment")]
        public byte[]? FileData { get; set; }
        [DisplayName("File Extension")]
        public string? FileContentType { get; set; }

        [NotMapped]
        [DisplayName("Select a file")]
        [DataType(DataType.Upload)]
        [MaxFileSize(1024 * 1024)]
        [AllowedExtensions(new string[] { ".jpg", ".png", ".doc", ".docx", ".xls", ".xlsx", ".pdf" })]
        public IFormFile? FormFile { get; set; }

        // nav prop
        public virtual Ticket? Ticket { get; set; }
        
        [DisplayName("Team Member")]
        public virtual BTUser? User { get; set; }
    }
}

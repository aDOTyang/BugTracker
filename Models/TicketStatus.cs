﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BugTracker.Models
{
    public class TicketStatus
    {
        // primary key
        public int Id { get; set; }

        [Required]
        [DisplayName("Ticket Status")]
        public string? Name { get; set; }
    }
}

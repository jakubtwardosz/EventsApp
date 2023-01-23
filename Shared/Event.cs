using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsApp.Shared
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        // Photo

        // Start date
        // End date

        // Address
        // Location
        // Price

        // Owner
        // Category

        // Phone
        // Email
    }
}

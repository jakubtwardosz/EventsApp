using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public DateTime Date { get; set; } = DateTime.Now;
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public List<Image> Images { get; set; } = new List<Image>();
        public string ImageUrl { get; set; } = string.Empty;
        public Address? Address { get; set; }
        public int AddressId { get; set; }
        public Category? Category { get; set; }
        public int CategoryId { get; set; }
        public bool Deleted { get; set; } = false;
        [NotMapped]
        public bool Editing { get; set; } = false;
        [NotMapped]
        public bool IsNew { get; set; } = false;
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication1.Attributes;

namespace WebApplication1.Model
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        [FutureDate]
        public DateTime Date { get; set; }
        public int OrganizationId { get; set; }
        public Organization? Organization { get; set; }
    }
}

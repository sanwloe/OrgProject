using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Model
{
    public class Organization
    {
        [Key]
        public int OrganizationId { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}

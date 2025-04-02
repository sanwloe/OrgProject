using Microsoft.EntityFrameworkCore;
using WebApplication1.Model;

namespace WebApplication1.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> opt) : base(opt)
        {
            
        }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var organizations = new Organization[] 
            { 
                new Organization() { OrganizationId = 1, Name = "Organization A" },
                new Organization() { OrganizationId = 2, Name = "Organization B" },
                new Organization() { OrganizationId = 3, Name = "Organization C" },
                new Organization() { OrganizationId = 4, Name = "Organization D" },
            };
            var events = new Event[]
            {
                new Event() { EventId = 1, Description = "Event 1",Title = "Event",Date = new DateTime(2025,4,2).AddDays(1),OrganizationId = organizations[0].OrganizationId },
                new Event() { EventId = 2, Description = "Event 2",Title = "Event",Date = new DateTime(2025,4,2).AddDays(1),OrganizationId = organizations[0].OrganizationId },
                new Event() { EventId = 3, Description = "Event 3",Title = "Event",Date = new DateTime(2025,4,2).AddDays(2),OrganizationId = organizations[0].OrganizationId },
                new Event() { EventId = 4, Description = "Event 4",Title = "Event",Date = new DateTime(2025,4,3).AddDays(2),OrganizationId = organizations[0].OrganizationId },
                new Event() { EventId = 5, Description = "Event 5",Title = "Event",Date = new DateTime(2025,4,3).AddDays(3),OrganizationId = organizations[0].OrganizationId },
            };

            modelBuilder.Entity<Organization>().HasData(organizations);
            modelBuilder.Entity<Event>().HasData(events);

            base.OnModelCreating(modelBuilder);
        }
    }
}

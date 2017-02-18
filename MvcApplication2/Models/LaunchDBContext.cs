using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using MvcApplication2.Models.Mapping;

namespace MvcApplication2.Models
{
    public partial class LaunchDBContext : DbContext
    {
        static LaunchDBContext()
        {
            Database.SetInitializer<LaunchDBContext>(null);
        }

        public LaunchDBContext()
            : base("Name=LaunchDBContext")
        {
        }

        public DbSet<customer> customers { get; set; }
        public DbSet<CustomerTicket> CustomerTickets { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new customerMap());
            modelBuilder.Configurations.Add(new CustomerTicketMap());
            modelBuilder.Configurations.Add(new TicketMap());
        }
    }
}

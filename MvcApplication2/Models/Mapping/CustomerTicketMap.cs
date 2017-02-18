using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MvcApplication2.Models.Mapping
{
    public class CustomerTicketMap : EntityTypeConfiguration<CustomerTicket>
    {
        public CustomerTicketMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            // Table & Column Mappings
            this.ToTable("CustomerTicket");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.CustomerID).HasColumnName("CustomerID");
            this.Property(t => t.TicketID).HasColumnName("TicketID");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");

            // Relationships
            this.HasRequired(t => t.customer)
                .WithMany(t => t.CustomerTickets)
                .HasForeignKey(d => d.CustomerID);
            this.HasRequired(t => t.Ticket)
                .WithMany(t => t.CustomerTickets)
                .HasForeignKey(d => d.TicketID);

        }
    }
}

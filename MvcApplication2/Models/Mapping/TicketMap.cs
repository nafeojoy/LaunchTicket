using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MvcApplication2.Models.Mapping
{
    public class TicketMap : EntityTypeConfiguration<Ticket>
    {
        public TicketMap()
        {
            // Primary Key
            this.HasKey(t => t.L_ID);

            // Properties
            this.Property(t => t.Start)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Destination)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.L_Name)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Ticket");
            this.Property(t => t.L_ID).HasColumnName("L_ID");
            this.Property(t => t.Start).HasColumnName("Start");
            this.Property(t => t.Destination).HasColumnName("Destination");
            this.Property(t => t.L_Name).HasColumnName("L_Name");
            this.Property(t => t.Dept_Time).HasColumnName("Dept_Time");
            this.Property(t => t.Fare_Deck).HasColumnName("Fare_Deck");
            this.Property(t => t.Fare_1st_Class).HasColumnName("Fare_1st_Class");
            this.Property(t => t.Fare_Cabin).HasColumnName("Fare_Cabin");
            this.Property(t => t.Max).HasColumnName("Max");
        }
    }
}

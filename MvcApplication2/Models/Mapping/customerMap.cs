using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MvcApplication2.Models.Mapping
{
    public class customerMap : EntityTypeConfiguration<customer>
    {
        public customerMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.user_name)
                .HasMaxLength(50);

            this.Property(t => t.first_name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.last_name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.address)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.contact_no)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.gender)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.occupation)
                .HasMaxLength(50);

            this.Property(t => t.password)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.confirmpassword)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.email)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("customer");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.user_name).HasColumnName("user_name");
            this.Property(t => t.first_name).HasColumnName("first_name");
            this.Property(t => t.last_name).HasColumnName("last_name");
            this.Property(t => t.address).HasColumnName("address");
            this.Property(t => t.contact_no).HasColumnName("contact_no");
            this.Property(t => t.gender).HasColumnName("gender");
            this.Property(t => t.occupation).HasColumnName("occupation");
            this.Property(t => t.password).HasColumnName("password");
            this.Property(t => t.confirmpassword).HasColumnName("confirmpassword");
            this.Property(t => t.email).HasColumnName("email");
        }
    }
}

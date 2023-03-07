using Assignment.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment.Entities;

public partial class AssignmentContext : DbContext
{
    public AssignmentContext()
    {
    }

    public AssignmentContext(DbContextOptions<AssignmentContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Person> People { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Person__3214EC07D9CE2240");

            entity.ToTable("Person");

            entity.Property(e => e.City)
                .IsUnicode(false)
                .HasColumnName("city");
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("firstName");
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("lastName");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("email");
            entity.Property(e => e.HomeAddress)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("homeAddress");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("phoneNumber");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

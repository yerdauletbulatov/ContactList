using ContactList.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ContactList.Infrastructure;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Contact> Contacts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Contact>(entity =>
        {
            entity.HasKey(c => c.Id);
            entity.Property(c => c.FirstName).IsRequired().HasMaxLength(50);
            entity.Property(c => c.LastName).IsRequired().HasMaxLength(50);
            entity.Property(c => c.PhoneNumber).IsRequired().HasMaxLength(20);
            entity.Property(c => c.Email).HasMaxLength(100);
        });

        // Seed Data
        modelBuilder.Entity<Contact>().HasData(
            new Contact
            {
                Id = Guid.NewGuid(),
                FirstName = "John",
                LastName = "Doe",
                PhoneNumber = "123-456-7890",
                Email = "john.doe@example.com"
            },
            new Contact
            {
                Id = Guid.NewGuid(),
                FirstName = "Jane",
                LastName = "Smith",
                PhoneNumber = "987-654-3210",
                Email = "jane.smith@example.com"
            },
            new Contact
            {
                Id = Guid.NewGuid(),
                FirstName = "Bob",
                LastName = "Brown",
                PhoneNumber = "456-789-0123",
                Email = "bob.brown@example.com"
            },
            new Contact
            {
                Id = Guid.NewGuid(),
                FirstName = "Alice",
                LastName = "Johnson",
                PhoneNumber = "321-654-0987",
                Email = "alice.johnson@example.com"
            },
            new Contact
            {
                Id = Guid.NewGuid(),
                FirstName = "Charlie",
                LastName = "Williams",
                PhoneNumber = "123-123-1234",
                Email = "charlie.williams@example.com"
            },
            new Contact
            {
                Id = Guid.NewGuid(),
                FirstName = "Emily",
                LastName = "Davis",
                PhoneNumber = "987-987-9876",
                Email = "emily.davis@example.com"
            },
            new Contact
            {
                Id = Guid.NewGuid(),
                FirstName = "Michael",
                LastName = "Wilson",
                PhoneNumber = "456-456-4567",
                Email = "michael.wilson@example.com"
            },
            new Contact
            {
                Id = Guid.NewGuid(),
                FirstName = "Olivia",
                LastName = "Taylor",
                PhoneNumber = "789-789-7890",
                Email = "olivia.taylor@example.com"
            },
            new Contact
            {
                Id = Guid.NewGuid(),
                FirstName = "James",
                LastName = "Anderson",
                PhoneNumber = "234-567-8901",
                Email = "james.anderson@example.com"
            },
            new Contact
            {
                Id = Guid.NewGuid(),
                FirstName = "Sophia",
                LastName = "Thomas",
                PhoneNumber = "890-123-4567",
                Email = "sophia.thomas@example.com"
            },
            new Contact
            {
                Id = Guid.NewGuid(),
                FirstName = "William",
                LastName = "Moore",
                PhoneNumber = "567-890-1234",
                Email = "william.moore@example.com"
            },
            new Contact
            {
                Id = Guid.NewGuid(),
                FirstName = "Isabella",
                LastName = "Martin",
                PhoneNumber = "345-678-9012",
                Email = "isabella.martin@example.com"
            },
            new Contact
            {
                Id = Guid.NewGuid(),
                FirstName = "Alexander",
                LastName = "Harris",
                PhoneNumber = "901-234-5678",
                Email = "alexander.harris@example.com"
            },
            new Contact
            {
                Id = Guid.NewGuid(),
                FirstName = "Mia",
                LastName = "Clark",
                PhoneNumber = "678-901-2345",
                Email = "mia.clark@example.com"
            },
            new Contact
            {
                Id = Guid.NewGuid(),
                FirstName = "Daniel",
                LastName = "Martinez",
                PhoneNumber = "123-456-7891",
                Email = "daniel.martinez@example.com"
            }
        );
    }
}
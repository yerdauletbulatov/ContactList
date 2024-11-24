using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ContactList.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { new Guid("0b7ee150-4970-4354-b8ad-2d68b5aff2c2"), "daniel.martinez@example.com", "Daniel", "Martinez", "123-456-7891" },
                    { new Guid("132a8a45-6e10-4cd3-be5d-d673bf515324"), "william.moore@example.com", "William", "Moore", "567-890-1234" },
                    { new Guid("213cdceb-06fe-4049-8fa0-c8c4f589b076"), "james.anderson@example.com", "James", "Anderson", "234-567-8901" },
                    { new Guid("334dff84-0e0a-447a-ba05-6c9935d2a9d3"), "alexander.harris@example.com", "Alexander", "Harris", "901-234-5678" },
                    { new Guid("37f46b4b-bb6b-4aa6-9544-d141f97cbbc2"), "bob.brown@example.com", "Bob", "Brown", "456-789-0123" },
                    { new Guid("4d2c760c-794d-4544-bf90-ce00743d3b1c"), "jane.smith@example.com", "Jane", "Smith", "987-654-3210" },
                    { new Guid("5205f1fc-ee07-4521-b624-a76ca8f40c30"), "emily.davis@example.com", "Emily", "Davis", "987-987-9876" },
                    { new Guid("6920f9e1-4f26-488e-b2d1-d58823c35af3"), "alice.johnson@example.com", "Alice", "Johnson", "321-654-0987" },
                    { new Guid("817f4af0-d1aa-4821-bd34-f641f4720b40"), "michael.wilson@example.com", "Michael", "Wilson", "456-456-4567" },
                    { new Guid("aad1fea2-d857-4d17-b684-9f44baad605e"), "charlie.williams@example.com", "Charlie", "Williams", "123-123-1234" },
                    { new Guid("b2ecb682-f25b-4ee1-9e7d-f537bcd1da05"), "olivia.taylor@example.com", "Olivia", "Taylor", "789-789-7890" },
                    { new Guid("b6ef5175-46ab-44da-ae5b-e1cd66bf7b79"), "isabella.martin@example.com", "Isabella", "Martin", "345-678-9012" },
                    { new Guid("c1a92de7-6346-4235-a92d-ba5d5c09efa6"), "sophia.thomas@example.com", "Sophia", "Thomas", "890-123-4567" },
                    { new Guid("d72022b3-62e1-4de3-abca-b96adc9ec313"), "john.doe@example.com", "John", "Doe", "123-456-7890" },
                    { new Guid("e8ed0b6a-041c-4392-8dc9-cdced5996884"), "mia.clark@example.com", "Mia", "Clark", "678-901-2345" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");
        }
    }
}

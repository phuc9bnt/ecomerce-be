using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FirstInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    RolesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.RolesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RolesId",
                        column: x => x.RolesId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("a1b2c3d4-e5f6-7890-abcd-123456789012"), "Administrator" },
                    { new Guid("b2c3d4e5-f6a7-8901-bcde-234567890123"), "User" },
                    { new Guid("c3d4e5f6-a7b8-9012-cdef-345678901234"), "Moderator" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Password", "UserName" },
                values: new object[,]
                {
                    { new Guid("d4e5f6a7-b8c9-0123-def4-456789012345"), "john.doe@example.com", "John", "Doe", "hashed_password_123", "johndoe" },
                    { new Guid("e5f6a7b8-c9d0-1234-ef45-567890123456"), "jane.smith@example.com", "Jane", "Smith", "hashed_password_456", "janesmith" },
                    { new Guid("f6a7b8c9-d0e1-2345-f456-678901234567"), "bob.johnson@example.com", "Bob", "Johnson", "hashed_password_789", "bobjohnson" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RolesId", "UsersId" },
                values: new object[,]
                {
                    { new Guid("a1b2c3d4-e5f6-7890-abcd-123456789012"), new Guid("d4e5f6a7-b8c9-0123-def4-456789012345") },
                    { new Guid("b2c3d4e5-f6a7-8901-bcde-234567890123"), new Guid("d4e5f6a7-b8c9-0123-def4-456789012345") },
                    { new Guid("b2c3d4e5-f6a7-8901-bcde-234567890123"), new Guid("e5f6a7b8-c9d0-1234-ef45-567890123456") },
                    { new Guid("b2c3d4e5-f6a7-8901-bcde-234567890123"), new Guid("f6a7b8c9-d0e1-2345-f456-678901234567") },
                    { new Guid("c3d4e5f6-a7b8-9012-cdef-345678901234"), new Guid("f6a7b8c9-d0e1-2345-f456-678901234567") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UsersId",
                table: "UserRoles",
                column: "UsersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

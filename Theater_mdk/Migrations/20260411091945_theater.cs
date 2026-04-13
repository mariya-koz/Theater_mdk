using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Theater_mdk.Migrations
{
    /// <inheritdoc />
    public partial class theater : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Books",
                table: "Books");

            migrationBuilder.RenameTable(
                name: "Students",
                newName: "Audiences");

            migrationBuilder.RenameTable(
                name: "Books",
                newName: "Ticket");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Audiences",
                table: "Audiences",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ticket",
                table: "Ticket",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Ticket",
                table: "Ticket");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Audiences",
                table: "Audiences");

            migrationBuilder.RenameTable(
                name: "Ticket",
                newName: "Books");

            migrationBuilder.RenameTable(
                name: "Audiences",
                newName: "Students");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Books",
                table: "Books",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                table: "Students",
                column: "Id");
        }
    }
}

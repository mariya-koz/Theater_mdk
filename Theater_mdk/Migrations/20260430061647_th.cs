using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Theater_mdk.Migrations
{
    /// <inheritdoc />
    public partial class th : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AuthUser",
                table: "AuthUser");

            migrationBuilder.RenameTable(
                name: "AuthUser",
                newName: "AuthUsers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AuthUsers",
                table: "AuthUsers",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AuthUsers",
                table: "AuthUsers");

            migrationBuilder.RenameTable(
                name: "AuthUsers",
                newName: "AuthUser");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AuthUser",
                table: "AuthUser",
                column: "Id");
        }
    }
}

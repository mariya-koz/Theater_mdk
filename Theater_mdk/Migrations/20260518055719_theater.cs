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
            migrationBuilder.DropForeignKey(
                name: "FK_AuthUsers_Images_ImageId",
                table: "AuthUsers");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropIndex(
                name: "IX_AuthUsers_ImageId",
                table: "AuthUsers");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "AuthUsers");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AuthUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "AuthUsers",
                type: "varbinary(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "AuthUsers");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AuthUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "AuthUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageData = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthUsers_ImageId",
                table: "AuthUsers",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthUsers_Images_ImageId",
                table: "AuthUsers",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id");
        }
    }
}

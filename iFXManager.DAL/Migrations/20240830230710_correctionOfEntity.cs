using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace iFXManager.DAL.Migrations
{
    /// <inheritdoc />
    public partial class correctionOfEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdNumber",
                table: "Entities",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdNumber",
                table: "Entities");
        }
    }
}

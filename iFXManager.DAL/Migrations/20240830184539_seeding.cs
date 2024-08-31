using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace iFXManager.DAL.Migrations
{
    /// <inheritdoc />
    public partial class seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("IdentificationTypes", new string[] { "Description", "Status" }, new object[] { "Social Security Number", true });            
            migrationBuilder.InsertData("IdentificationTypes", new string[] { "Description", "Status" }, new object[] { "Taxpayer Identification Number", true });

            migrationBuilder.InsertData("EntityTypes", new string[] { "Description", "Status" }, new object[] { "Mixed", true });
            migrationBuilder.InsertData("EntityTypes", new string[] { "Description", "Status" }, new object[] { "Private", true });
            migrationBuilder.InsertData("EntityTypes", new string[] { "Description", "Status" }, new object[] { "Public", true });

            migrationBuilder.InsertData("Positions", new string[] { "Description", "Status" }, new object[] { "Chief Technology Officer", true });
            migrationBuilder.InsertData("Positions", new string[] { "Description", "Status" }, new object[] { "Chief Marketing Officer", true });
            migrationBuilder.InsertData("Positions", new string[] { "Description", "Status" }, new object[] { "Chief Human Resources Officer", true });
            migrationBuilder.InsertData("Positions", new string[] { "Description", "Status" }, new object[] { "Chief Data Officer", true });
            migrationBuilder.InsertData("Positions", new string[] { "Description", "Status" }, new object[] { "Chief Innovation Officer", true });
                                                                                                              
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

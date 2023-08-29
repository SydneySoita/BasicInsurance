using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BasicInsurance.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class basicinsurance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Undewritingcases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicantName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Policytype = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RiskDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    HealthCondition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Accidents = table.Column<int>(type: "int", nullable: false),
                    RiskResult = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoverageAmount = table.Column<double>(type: "float", nullable: true),
                    PaymentFrequency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PremiumAmount = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Undewritingcases", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Undewritingcases");
        }
    }
}

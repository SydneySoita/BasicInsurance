using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BasicInsurance.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AnnuityMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Annuity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrincipalAmount = table.Column<int>(type: "int", nullable: false),
                    IntrestRate = table.Column<double>(type: "float", nullable: false),
                    NumberofPayments = table.Column<int>(type: "int", nullable: false),
                    PaymentFrequency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentAmount = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Annuity", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Annuity");
        }
    }
}

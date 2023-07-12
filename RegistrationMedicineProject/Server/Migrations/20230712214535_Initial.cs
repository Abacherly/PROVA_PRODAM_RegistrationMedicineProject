using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistrationMedicineProject.Server.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Retentions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Retentions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RegistrationMedicines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Administration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Class = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Classification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RetentionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrationMedicines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegistrationMedicines_Retentions_RetentionId",
                        column: x => x.RetentionId,
                        principalTable: "Retentions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Retentions",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Não" });

            migrationBuilder.InsertData(
                table: "Retentions",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Sim" });

            migrationBuilder.InsertData(
                table: "RegistrationMedicines",
                columns: new[] { "Id", "Administration", "Class", "Classification", "Name", "RetentionId" },
                values: new object[] { 1, "Via Oral", "Analgésico", "Tarja Vermelha", "Nimesulida", 1 });

            migrationBuilder.InsertData(
                table: "RegistrationMedicines",
                columns: new[] { "Id", "Administration", "Class", "Classification", "Name", "RetentionId" },
                values: new object[] { 2, "Via Oral", "Antibiótico", "Tarja Vermelha", "Azitromicina", 2 });

            migrationBuilder.CreateIndex(
                name: "IX_RegistrationMedicines_RetentionId",
                table: "RegistrationMedicines",
                column: "RetentionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegistrationMedicines");

            migrationBuilder.DropTable(
                name: "Retentions");
        }
    }
}

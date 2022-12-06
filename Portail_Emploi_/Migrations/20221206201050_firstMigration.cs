using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortailEmploi.Migrations
{
    /// <inheritdoc />
    public partial class firstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Candidats",
                columns: table => new
                {
                    IDCandidat = table.Column<int>(name: "ID_Candidat", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NEtude = table.Column<string>(name: "N_Etude", type: "nvarchar(max)", nullable: false),
                    NExperience = table.Column<int>(name: "N_Experience", type: "int", nullable: false),
                    DEmployeur = table.Column<string>(name: "D_Employeur", type: "nvarchar(max)", nullable: false),
                    CV = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidats", x => x.IDCandidat);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Candidats");
        }
    }
}

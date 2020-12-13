using Microsoft.EntityFrameworkCore.Migrations;

namespace BaoCaoThucTap.Migrations
{
    public partial class add_anhsanpham : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "anhSanPhams",
                columns: table => new
                {
                    maanh = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    urlAnh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    masp = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_anhSanPhams", x => x.maanh);
                    table.ForeignKey(
                        name: "FK_anhSanPhams_sanPhams_masp",
                        column: x => x.masp,
                        principalTable: "sanPhams",
                        principalColumn: "masp",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_anhSanPhams_masp",
                table: "anhSanPhams",
                column: "masp");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "anhSanPhams");
        }
    }
}

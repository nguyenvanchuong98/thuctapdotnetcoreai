using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BaoCaoThucTap.Migrations
{
    public partial class SanPham : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "sanPhams",
                columns: table => new
                {
                    masp = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tensp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ngaynhap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    urlImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    giasp = table.Column<double>(type: "float", nullable: false),
                    motasp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sanPhams", x => x.masp);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sanPhams");
        }
    }
}

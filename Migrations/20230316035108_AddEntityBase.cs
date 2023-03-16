using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace prod.Migrations
{
    /// <inheritdoc />
    public partial class AddEntityBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, comment: "Primary Key")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false, comment: "Flag Soft Delete"),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Audit column, created date"),
                    created_by = table.Column<long>(type: "bigint", nullable: true, comment: "Audit column, created by"),
                    updated_date = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Audit column, updated date"),
                    updated_by = table.Column<long>(type: "bigint", nullable: true, comment: "Audit column, updated by")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, comment: "Primary Key")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Categoryid = table.Column<long>(type: "bigint", nullable: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false, comment: "Flag Soft Delete"),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Audit column, created date"),
                    created_by = table.Column<long>(type: "bigint", nullable: true, comment: "Audit column, created by"),
                    updated_date = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Audit column, updated date"),
                    updated_by = table.Column<long>(type: "bigint", nullable: true, comment: "Audit column, updated by")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_Categoryid",
                        column: x => x.Categoryid,
                        principalTable: "Categories",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_Categoryid",
                table: "Products",
                column: "Categoryid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}

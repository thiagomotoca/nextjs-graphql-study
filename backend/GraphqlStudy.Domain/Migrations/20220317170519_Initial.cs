using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraphqlStudy.Domain.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "employee",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employee", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "relative",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    employeeid = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_relative", x => x.id);
                    table.ForeignKey(
                        name: "FK_relative_employee_employeeid",
                        column: x => x.employeeid,
                        principalTable: "employee",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "employee",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { new Guid("5b29f85e-ae90-4397-92ae-0c96ae5d9c94"), "Kaci Jacobi" },
                    { new Guid("6a363a29-b588-44b4-bcff-67f5f73a87a3"), "Leila Ankunding" }
                });

            migrationBuilder.InsertData(
                table: "relative",
                columns: new[] { "id", "employeeid", "name" },
                values: new object[,]
                {
                    { new Guid("244d93ab-8dcf-400b-8dc2-22fa92d0b57e"), new Guid("6a363a29-b588-44b4-bcff-67f5f73a87a3"), "Hester Schuppe" },
                    { new Guid("7439b8e4-6577-46c8-b652-978b01866617"), new Guid("5b29f85e-ae90-4397-92ae-0c96ae5d9c94"), "Mia Little" },
                    { new Guid("93ad2237-d809-4c57-ac8a-ce50a72f60c0"), new Guid("6a363a29-b588-44b4-bcff-67f5f73a87a3"), "Cleve Parisian" },
                    { new Guid("c7f8c808-aac1-4459-839f-086780162f90"), new Guid("5b29f85e-ae90-4397-92ae-0c96ae5d9c94"), "Mariam Gaylord" },
                    { new Guid("dd5c4a96-e315-4e61-8608-851751e60b8a"), new Guid("5b29f85e-ae90-4397-92ae-0c96ae5d9c94"), "Lawrence Simonis" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_employee_id",
                table: "employee",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_relative_employeeid",
                table: "relative",
                column: "employeeid");

            migrationBuilder.CreateIndex(
                name: "IX_relative_id",
                table: "relative",
                column: "id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "relative");

            migrationBuilder.DropTable(
                name: "employee");
        }
    }
}

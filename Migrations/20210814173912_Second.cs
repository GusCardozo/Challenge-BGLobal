using Microsoft.EntityFrameworkCore.Migrations;

namespace Challenge.BGLobal.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Brand",
                schema: "BGlobal",
                table: "Vehicles");

            migrationBuilder.AddColumn<int>(
                name: "BrandId",
                schema: "BGlobal",
                table: "Vehicles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Brands",
                schema: "BGlobal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "BGlobal",
                table: "Brands",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Ford" },
                    { 2, "Fiat" },
                    { 3, "Peugeot" },
                    { 4, "Mercedes Benz" },
                    { 5, "Audi" },
                    { 6, "BMW" },
                    { 7, "Renault" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_BrandId",
                schema: "BGlobal",
                table: "Vehicles",
                column: "BrandId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Brands_BrandId",
                schema: "BGlobal",
                table: "Vehicles",
                column: "BrandId",
                principalSchema: "BGlobal",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Brands_BrandId",
                schema: "BGlobal",
                table: "Vehicles");

            migrationBuilder.DropTable(
                name: "Brands",
                schema: "BGlobal");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_BrandId",
                schema: "BGlobal",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "BrandId",
                schema: "BGlobal",
                table: "Vehicles");

            migrationBuilder.AddColumn<string>(
                name: "Brand",
                schema: "BGlobal",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}

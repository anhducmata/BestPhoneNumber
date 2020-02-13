using Microsoft.EntityFrameworkCore.Migrations;

namespace BestPhoneNumber.Migrations
{
    public partial class UpdatePrimaryKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NumberProvide",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TelecomHostId = table.Column<int>(nullable: false),
                    PrefixNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NumberProvide", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "NumberProvide",
                columns: new[] { "Id", "PrefixNumber", "TelecomHostId" },
                values: new object[,]
                {
                    { 1, "086", 1 },
                    { 2, "096", 1 },
                    { 3, "097", 1 },
                    { 4, "089", 2 },
                    { 5, "090", 2 },
                    { 6, "093", 2 },
                    { 7, "088", 3 },
                    { 8, "091", 3 },
                    { 9, "094", 3 }
                });

            migrationBuilder.InsertData(
                table: "TelecomHost",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Viettel" },
                    { 2, "Mobi" },
                    { 3, "VinaPhone" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NumberProvide");

            migrationBuilder.DeleteData(
                table: "TelecomHost",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TelecomHost",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TelecomHost",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}

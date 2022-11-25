using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UsuarioChallenge.Migrations
{
    public partial class atualizandorole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "Name" },
                values: new object[] { "431564bf-f8f0-4043-be67-53b6723f575b", "authorizeduser" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "Name" },
                values: new object[] { "ddc80bc2-069f-4781-bc7c-d5799b41cd0e", "AuthorizedUser" });
        }
    }
}

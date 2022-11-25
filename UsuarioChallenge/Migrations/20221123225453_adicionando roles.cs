using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UsuarioChallenge.Migrations
{
    public partial class adicionandoroles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 1, "ddc80bc2-069f-4781-bc7c-d5799b41cd0e", "AuthorizedUser", "AUTHORIZEDUSER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}

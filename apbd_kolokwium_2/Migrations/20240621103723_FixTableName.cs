using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apbd_kolokwium_2.Migrations
{
    /// <inheritdoc />
    public partial class FixTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Object_Owner_Owners_Owner_ID",
                table: "Object_Owner");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Owners",
                table: "Owners");

            migrationBuilder.RenameTable(
                name: "Owners",
                newName: "Owner");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Owner",
                table: "Owner",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Object_Owner_Owner_Owner_ID",
                table: "Object_Owner",
                column: "Owner_ID",
                principalTable: "Owner",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Object_Owner_Owner_Owner_ID",
                table: "Object_Owner");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Owner",
                table: "Owner");

            migrationBuilder.RenameTable(
                name: "Owner",
                newName: "Owners");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Owners",
                table: "Owners",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Object_Owner_Owners_Owner_ID",
                table: "Object_Owner",
                column: "Owner_ID",
                principalTable: "Owners",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

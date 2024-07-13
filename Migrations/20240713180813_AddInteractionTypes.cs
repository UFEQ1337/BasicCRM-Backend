using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BasicCRM.Migrations
{
    /// <inheritdoc />
    public partial class AddInteractionTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "InteractionTypeGuid",
                table: "Interactions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "InteractionTypes",
                columns: table => new
                {
                    InteractionTypeGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InteractionTypes", x => x.InteractionTypeGuid);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Interactions_InteractionTypeGuid",
                table: "Interactions",
                column: "InteractionTypeGuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Interactions_InteractionTypes_InteractionTypeGuid",
                table: "Interactions",
                column: "InteractionTypeGuid",
                principalTable: "InteractionTypes",
                principalColumn: "InteractionTypeGuid",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interactions_InteractionTypes_InteractionTypeGuid",
                table: "Interactions");

            migrationBuilder.DropTable(
                name: "InteractionTypes");

            migrationBuilder.DropIndex(
                name: "IX_Interactions_InteractionTypeGuid",
                table: "Interactions");

            migrationBuilder.DropColumn(
                name: "InteractionTypeGuid",
                table: "Interactions");
        }
    }
}

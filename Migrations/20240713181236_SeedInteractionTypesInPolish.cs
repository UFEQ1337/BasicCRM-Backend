using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BasicCRM.Migrations
{
    /// <inheritdoc />
    public partial class SeedInteractionTypesInPolish : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "InteractionTypes",
                columns: new[] { "InteractionTypeGuid", "Name" },
                values: new object[,]
                {
                    { new Guid("1f5f32a6-c920-40eb-92fa-8cc4c3105df0"), "E-mail" },
                    { new Guid("7c3cedf4-8239-45cd-ab7b-c98e3536737d"), "Spotkanie" },
                    { new Guid("a02ec858-ae19-4ae9-9bd8-1fe168316832"), "Rozmowa telefoniczna" },
                    { new Guid("f146df04-1766-4a0a-9b9a-6c8fadcf8120"), "Media społecznościowe" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "InteractionTypes",
                keyColumn: "InteractionTypeGuid",
                keyValue: new Guid("1f5f32a6-c920-40eb-92fa-8cc4c3105df0"));

            migrationBuilder.DeleteData(
                table: "InteractionTypes",
                keyColumn: "InteractionTypeGuid",
                keyValue: new Guid("7c3cedf4-8239-45cd-ab7b-c98e3536737d"));

            migrationBuilder.DeleteData(
                table: "InteractionTypes",
                keyColumn: "InteractionTypeGuid",
                keyValue: new Guid("a02ec858-ae19-4ae9-9bd8-1fe168316832"));

            migrationBuilder.DeleteData(
                table: "InteractionTypes",
                keyColumn: "InteractionTypeGuid",
                keyValue: new Guid("f146df04-1766-4a0a-9b9a-6c8fadcf8120"));
        }
    }
}

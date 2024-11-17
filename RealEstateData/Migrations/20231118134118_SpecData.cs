using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RealEstateData.Migrations
{
    /// <inheritdoc />
    public partial class SpecData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Specifications",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("2bbb9c72-f34b-488b-99fb-eb84db730ca3"), "Teras" },
                    { new Guid("30999148-ea38-4c31-b789-8ed39cfb5ec1"), "Deniz Manzaralı" },
                    { new Guid("3eca8670-2fb4-419d-b97e-8b6228ea553f"), "Ebeveyn Banyo" },
                    { new Guid("46a1fc19-0732-4f76-b087-effeb11aaa62"), "Fiber İnternet" },
                    { new Guid("4dc44b8b-b92a-4f3a-99af-874352121b6e"), "Kombili" },
                    { new Guid("5a8ce8a7-d59a-428c-be14-a7cd74dcb97b"), "Kapalı Otopark" },
                    { new Guid("6f5f1dcb-e5e0-45a3-9464-d15232e89fca"), "Yerden Isıtma" },
                    { new Guid("767b3607-9b58-4404-86cf-311d676e71b6"), "Havuzlu" },
                    { new Guid("a7f92a4d-8ec5-4619-b3fd-821228241ce4"), "Cam balkon" },
                    { new Guid("b1df6e21-5567-47a2-b1ea-01baf93891a4"), "Merkezi Isıtma" },
                    { new Guid("fd516f5b-7983-41df-9d54-6435f02402e6"), "Güvenlik" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Specifications",
                keyColumn: "Id",
                keyValue: new Guid("2bbb9c72-f34b-488b-99fb-eb84db730ca3"));

            migrationBuilder.DeleteData(
                table: "Specifications",
                keyColumn: "Id",
                keyValue: new Guid("30999148-ea38-4c31-b789-8ed39cfb5ec1"));

            migrationBuilder.DeleteData(
                table: "Specifications",
                keyColumn: "Id",
                keyValue: new Guid("3eca8670-2fb4-419d-b97e-8b6228ea553f"));

            migrationBuilder.DeleteData(
                table: "Specifications",
                keyColumn: "Id",
                keyValue: new Guid("46a1fc19-0732-4f76-b087-effeb11aaa62"));

            migrationBuilder.DeleteData(
                table: "Specifications",
                keyColumn: "Id",
                keyValue: new Guid("4dc44b8b-b92a-4f3a-99af-874352121b6e"));

            migrationBuilder.DeleteData(
                table: "Specifications",
                keyColumn: "Id",
                keyValue: new Guid("5a8ce8a7-d59a-428c-be14-a7cd74dcb97b"));

            migrationBuilder.DeleteData(
                table: "Specifications",
                keyColumn: "Id",
                keyValue: new Guid("6f5f1dcb-e5e0-45a3-9464-d15232e89fca"));

            migrationBuilder.DeleteData(
                table: "Specifications",
                keyColumn: "Id",
                keyValue: new Guid("767b3607-9b58-4404-86cf-311d676e71b6"));

            migrationBuilder.DeleteData(
                table: "Specifications",
                keyColumn: "Id",
                keyValue: new Guid("a7f92a4d-8ec5-4619-b3fd-821228241ce4"));

            migrationBuilder.DeleteData(
                table: "Specifications",
                keyColumn: "Id",
                keyValue: new Guid("b1df6e21-5567-47a2-b1ea-01baf93891a4"));

            migrationBuilder.DeleteData(
                table: "Specifications",
                keyColumn: "Id",
                keyValue: new Guid("fd516f5b-7983-41df-9d54-6435f02402e6"));
        }
    }
}

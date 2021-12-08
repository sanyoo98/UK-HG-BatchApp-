using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BatchApp.Migrations
{
    public partial class AddBatchToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Batches",
                columns: table => new
                {
                    BatchId = table.Column<Guid>(nullable: false),
                    BusinessUnit = table.Column<string>(nullable: false),
                    ExpiryDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Batches", x => x.BatchId);
                });

            migrationBuilder.CreateTable(
                name: "ACLs",
                columns: table => new
                {
                    ReadUser = table.Column<string>(nullable: false),
                    ReadGroup = table.Column<string>(nullable: false),
                    BatchModelBatchId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACLs", x => x.ReadUser);
                    table.ForeignKey(
                        name: "FK_ACLs_Batches_BatchModelBatchId",
                        column: x => x.BatchModelBatchId,
                        principalTable: "Batches",
                        principalColumn: "BatchId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Atributes",
                columns: table => new
                {
                    Key = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: false),
                    BatchModelBatchId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atributes", x => x.Key);
                    table.ForeignKey(
                        name: "FK_Atributes_Batches_BatchModelBatchId",
                        column: x => x.BatchModelBatchId,
                        principalTable: "Batches",
                        principalColumn: "BatchId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ACLs_BatchModelBatchId",
                table: "ACLs",
                column: "BatchModelBatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Atributes_BatchModelBatchId",
                table: "Atributes",
                column: "BatchModelBatchId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ACLs");

            migrationBuilder.DropTable(
                name: "Atributes");

            migrationBuilder.DropTable(
                name: "Batches");
        }
    }
}

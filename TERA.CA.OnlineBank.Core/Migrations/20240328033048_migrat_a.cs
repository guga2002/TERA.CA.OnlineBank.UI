using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TERA.CA.OnlineBank.Core.Migrations
{
    /// <inheritdoc />
    public partial class migrat_a : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TypeId",
                table: "Transactions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "TransactionTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Transaction_Type_Name = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_TypeId",
                table: "Transactions",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionTypes_Transaction_Type_Name",
                table: "TransactionTypes",
                column: "Transaction_Type_Name");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_TransactionTypes_TypeId",
                table: "Transactions",
                column: "TypeId",
                principalTable: "TransactionTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_TransactionTypes_TypeId",
                table: "Transactions");

            migrationBuilder.DropTable(
                name: "TransactionTypes");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_TypeId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Transactions");
        }
    }
}

﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TERA.CA.OnlineBank.Core.Migrations
{
    /// <inheritdoc />
    public partial class migrate_Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "Reciever_ID",
                table: "Transactions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_Reciever_ID",
                table: "Transactions",
                column: "Reciever_ID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Transactions_Reciever_ID",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Reciever_ID",
                table: "Transactions");
        }
    }
}

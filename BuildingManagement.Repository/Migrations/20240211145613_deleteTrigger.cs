﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuildingManagement.Repository.Migrations
{
    /// <inheritdoc />
    public partial class deleteTrigger : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP TRIGGER trg_InsertApartmentBill");
        }
    }
}

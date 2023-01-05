using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoList.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "List",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    DescriptionList = table.Column<string>(type: "TEXT", nullable: false),
                    DateCreate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateUpdate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_List", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    DateCreate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateUpdate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TasksList",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    IdList = table.Column<Guid>(type: "TEXT", nullable: false),
                    DescriptionTask = table.Column<string>(type: "TEXT", nullable: false),
                    Done = table.Column<bool>(type: "INTEGER", nullable: false),
                    DateCreate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateUpdate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ListId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TasksList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TasksList_List_ListId",
                        column: x => x.ListId,
                        principalTable: "List",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TasksList_ListId",
                table: "TasksList",
                column: "ListId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TasksList");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "List");
        }
    }
}

﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoList.Repositories.Migrations
{
    /// <inheritdoc />
<<<<<<<< HEAD:TodoList.Repositories/Migrations/20240403212630_InitialDataBase.cs
    public partial class InitialDataBase : Migration
========
    public partial class innitial : Migration
>>>>>>>> 471cca7dc9e75c3f6918bc4ef1c3db8eacbae92f:TodoList.Repositories/Migrations/20240404142014_innitial.cs
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
                    IdUser = table.Column<Guid>(type: "TEXT", nullable: false),
                    DateCreate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateUpdate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_List", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaskList",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    IdList = table.Column<Guid>(type: "TEXT", nullable: false),
                    IdUser = table.Column<Guid>(type: "TEXT", nullable: false),
                    DescriptionTask = table.Column<string>(type: "TEXT", nullable: false),
                    Done = table.Column<int>(type: "INTEGER", nullable: false),
                    DateCreate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateUpdate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Role = table.Column<string>(type: "TEXT", nullable: false),
                    UrlAvatar = table.Column<string>(type: "TEXT", nullable: false),
                    DateCreate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateUpdate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "List");

            migrationBuilder.DropTable(
                name: "TaskList");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}

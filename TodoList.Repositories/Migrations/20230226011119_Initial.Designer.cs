﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TodoList.Repositories.Contexts;

#nullable disable

namespace TodoList.Repositories.Migrations
{
    [DbContext(typeof(TodoListContext))]
    [Migration("20230226011119_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true);

            modelBuilder.Entity("TodoList.Domain.Entities.Lists.List", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("TEXT")
                        .HasColumnName("DateCreate");

                    b.Property<DateTime>("DateUpdate")
                        .HasColumnType("TEXT")
                        .HasColumnName("DateUpdate");

                    b.Property<string>("DescriptionList")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("DescriptionList");

                    b.Property<Guid>("IdUser")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("List", (string)null);
                });

            modelBuilder.Entity("TodoList.Domain.Entities.TasksList.TaskList", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("TEXT")
                        .HasColumnName("DateCreate");

                    b.Property<DateTime>("DateUpdate")
                        .HasColumnType("TEXT")
                        .HasColumnName("DateUpdate");

                    b.Property<string>("DescriptionTask")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("DescriptionTask");

                    b.Property<bool>("Done")
                        .HasColumnType("INTEGER")
                        .HasColumnName("Done");

                    b.Property<Guid>("IdList")
                        .HasColumnType("TEXT")
                        .HasColumnName("IdList");

                    b.Property<Guid>("IdUser")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("TaskList", (string)null);
                });

            modelBuilder.Entity("TodoList.Domain.Entities.Users.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("TEXT")
                        .HasColumnName("DateCreate");

                    b.Property<DateTime>("DateUpdate")
                        .HasColumnType("TEXT")
                        .HasColumnName("DateUpdate");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Password");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("User", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
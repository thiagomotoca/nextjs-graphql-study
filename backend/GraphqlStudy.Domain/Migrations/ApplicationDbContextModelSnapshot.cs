﻿// <auto-generated />
using System;
using GraphqlStudy.Domain.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GraphqlStudy.Domain.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("GraphqlStudy.Domain.Entities.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("employee", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("6a363a29-b588-44b4-bcff-67f5f73a87a3"),
                            Name = "Leila Ankunding"
                        },
                        new
                        {
                            Id = new Guid("5b29f85e-ae90-4397-92ae-0c96ae5d9c94"),
                            Name = "Kaci Jacobi"
                        });
                });

            modelBuilder.Entity("GraphqlStudy.Domain.Entities.Relative", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uuid")
                        .HasColumnName("employeeid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("relative", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("244d93ab-8dcf-400b-8dc2-22fa92d0b57e"),
                            EmployeeId = new Guid("6a363a29-b588-44b4-bcff-67f5f73a87a3"),
                            Name = "Hester Schuppe"
                        },
                        new
                        {
                            Id = new Guid("93ad2237-d809-4c57-ac8a-ce50a72f60c0"),
                            EmployeeId = new Guid("6a363a29-b588-44b4-bcff-67f5f73a87a3"),
                            Name = "Cleve Parisian"
                        },
                        new
                        {
                            Id = new Guid("7439b8e4-6577-46c8-b652-978b01866617"),
                            EmployeeId = new Guid("5b29f85e-ae90-4397-92ae-0c96ae5d9c94"),
                            Name = "Mia Little"
                        },
                        new
                        {
                            Id = new Guid("dd5c4a96-e315-4e61-8608-851751e60b8a"),
                            EmployeeId = new Guid("5b29f85e-ae90-4397-92ae-0c96ae5d9c94"),
                            Name = "Lawrence Simonis"
                        },
                        new
                        {
                            Id = new Guid("c7f8c808-aac1-4459-839f-086780162f90"),
                            EmployeeId = new Guid("5b29f85e-ae90-4397-92ae-0c96ae5d9c94"),
                            Name = "Mariam Gaylord"
                        });
                });

            modelBuilder.Entity("GraphqlStudy.Domain.Entities.Relative", b =>
                {
                    b.HasOne("GraphqlStudy.Domain.Entities.Employee", "Employee")
                        .WithMany("Relatives")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("GraphqlStudy.Domain.Entities.Employee", b =>
                {
                    b.Navigation("Relatives");
                });
#pragma warning restore 612, 618
        }
    }
}

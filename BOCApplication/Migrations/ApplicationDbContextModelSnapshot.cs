﻿// <auto-generated />
using System;
using BOCApplication.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BOCApplication.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BOCApplication.Model.Domain.CreateTable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PreferredFormId")
                        .HasColumnType("int");

                    b.Property<string>("TableName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PreferredFormId");

                    b.HasIndex("UserId");

                    b.ToTable("CreateTables");
                });

            modelBuilder.Entity("BOCApplication.Model.Domain.DataTab", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CreateTableId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrganisationImageBase64")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PreferredFormId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreateTableId");

                    b.HasIndex("PreferredFormId");

                    b.HasIndex("UserId");

                    b.ToTable("DataTabs");
                });

            modelBuilder.Entity("BOCApplication.Model.Domain.Fields", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Desscription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Max_length")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PreferredFormId")
                        .HasColumnType("int");

                    b.Property<string>("Preview")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Size")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PreferredFormId");

                    b.HasIndex("UserId");

                    b.ToTable("Fields");
                });

            modelBuilder.Entity("BOCApplication.Model.Domain.FormBuilder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Form")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MenuName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProcessId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProcessId");

                    b.ToTable("FormBuilders");
                });

            modelBuilder.Entity("BOCApplication.Model.Domain.PreferredForm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PreferredForms");
                });

            modelBuilder.Entity("BOCApplication.Model.Domain.Process", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Processes");
                });

            modelBuilder.Entity("BOCApplication.Model.Domain.Sections", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Desscription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PreferredFormId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PreferredFormId");

                    b.HasIndex("UserId");

                    b.ToTable("Sections");
                });

            modelBuilder.Entity("BOCApplication.Model.Domain.SubTabs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PreferredFormId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PreferredFormId");

                    b.HasIndex("UserId");

                    b.ToTable("SubTabs");
                });

            modelBuilder.Entity("BOCApplication.Model.Domain.Tabs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PreferredFormId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PreferredFormId");

                    b.HasIndex("UserId");

                    b.ToTable("Tabs");
                });

            modelBuilder.Entity("BOCApplication.Model.Domain.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("RefreshTokenExpiryTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BOCApplication.Model.Domain.CreateTable", b =>
                {
                    b.HasOne("BOCApplication.Model.Domain.PreferredForm", null)
                        .WithMany("CreateTables")
                        .HasForeignKey("PreferredFormId");

                    b.HasOne("BOCApplication.Model.Domain.User", "User")
                        .WithMany("CreateTables")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("BOCApplication.Model.Domain.DataTab", b =>
                {
                    b.HasOne("BOCApplication.Model.Domain.CreateTable", "CreateTable")
                        .WithMany()
                        .HasForeignKey("CreateTableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BOCApplication.Model.Domain.PreferredForm", null)
                        .WithMany("DataTabs")
                        .HasForeignKey("PreferredFormId");

                    b.HasOne("BOCApplication.Model.Domain.User", null)
                        .WithMany("DataTabs")
                        .HasForeignKey("UserId");

                    b.Navigation("CreateTable");
                });

            modelBuilder.Entity("BOCApplication.Model.Domain.Fields", b =>
                {
                    b.HasOne("BOCApplication.Model.Domain.PreferredForm", "PreferredForm")
                        .WithMany("Fields")
                        .HasForeignKey("PreferredFormId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BOCApplication.Model.Domain.User", "User")
                        .WithMany("Fields")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PreferredForm");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BOCApplication.Model.Domain.FormBuilder", b =>
                {
                    b.HasOne("BOCApplication.Model.Domain.Process", "Process")
                        .WithMany("FormBuilders")
                        .HasForeignKey("ProcessId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Process");
                });

            modelBuilder.Entity("BOCApplication.Model.Domain.Process", b =>
                {
                    b.HasOne("BOCApplication.Model.Domain.User", "User")
                        .WithMany("Process")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("BOCApplication.Model.Domain.Sections", b =>
                {
                    b.HasOne("BOCApplication.Model.Domain.PreferredForm", "PreferredForm")
                        .WithMany("Sections")
                        .HasForeignKey("PreferredFormId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BOCApplication.Model.Domain.User", "User")
                        .WithMany("Sections")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PreferredForm");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BOCApplication.Model.Domain.SubTabs", b =>
                {
                    b.HasOne("BOCApplication.Model.Domain.PreferredForm", "PreferredForm")
                        .WithMany("SubTabs")
                        .HasForeignKey("PreferredFormId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BOCApplication.Model.Domain.User", "User")
                        .WithMany("SubTabs")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PreferredForm");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BOCApplication.Model.Domain.Tabs", b =>
                {
                    b.HasOne("BOCApplication.Model.Domain.PreferredForm", "PreferredForm")
                        .WithMany("Tabs")
                        .HasForeignKey("PreferredFormId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BOCApplication.Model.Domain.User", "User")
                        .WithMany("Tabs")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PreferredForm");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BOCApplication.Model.Domain.PreferredForm", b =>
                {
                    b.Navigation("CreateTables");

                    b.Navigation("DataTabs");

                    b.Navigation("Fields");

                    b.Navigation("Sections");

                    b.Navigation("SubTabs");

                    b.Navigation("Tabs");
                });

            modelBuilder.Entity("BOCApplication.Model.Domain.Process", b =>
                {
                    b.Navigation("FormBuilders");
                });

            modelBuilder.Entity("BOCApplication.Model.Domain.User", b =>
                {
                    b.Navigation("CreateTables");

                    b.Navigation("DataTabs");

                    b.Navigation("Fields");

                    b.Navigation("Process");

                    b.Navigation("Sections");

                    b.Navigation("SubTabs");

                    b.Navigation("Tabs");
                });
#pragma warning restore 612, 618
        }
    }
}

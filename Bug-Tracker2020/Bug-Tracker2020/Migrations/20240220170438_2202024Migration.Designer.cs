﻿// <auto-generated />
using Bug_Tracker2020.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Bug_Tracker2020.Migrations
{
    [DbContext(typeof(BugDbContext))]
    [Migration("20240220170438_2202024Migration")]
    partial class _2202024Migration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-preview.1.24081.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Bug_Tracker2020.Models.Admin", b =>
                {
                    b.Property<int>("AdminID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AdminID"));

                    b.Property<bool>("AdminRole")
                        .HasColumnType("bit");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AdminID");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("Bug_Tracker2020.Models.Bug", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("AdminFirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AdminID")
                        .HasColumnType("int");

                    b.Property<string>("CreatedDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastModifiedDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subject")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserFirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("AdminID");

                    b.HasIndex("UserID");

                    b.ToTable("Bugs");
                });

            modelBuilder.Entity("Bug_Tracker2020.Models.Comment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("AdminFirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AdminID")
                        .HasColumnType("int");

                    b.Property<int>("BugID")
                        .HasColumnType("int");

                    b.Property<string>("CommentBody")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserFirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("BugID");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Bug_Tracker2020.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"));

                    b.Property<bool>("AdminRole")
                        .HasColumnType("bit");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Bug_Tracker2020.ViewModels.EditCommentViewModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("AdminFirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AdminID")
                        .HasColumnType("int");

                    b.Property<int>("BugID")
                        .HasColumnType("int");

                    b.Property<string>("CommentBody")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserFirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("EditCommentViewModel");
                });

            modelBuilder.Entity("Bug_Tracker2020.Models.Bug", b =>
                {
                    b.HasOne("Bug_Tracker2020.Models.Admin", null)
                        .WithMany("Bugs")
                        .HasForeignKey("AdminID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bug_Tracker2020.Models.User", null)
                        .WithMany("Bugs")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Bug_Tracker2020.Models.Comment", b =>
                {
                    b.HasOne("Bug_Tracker2020.Models.Bug", null)
                        .WithMany("Comments")
                        .HasForeignKey("BugID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Bug_Tracker2020.Models.Admin", b =>
                {
                    b.Navigation("Bugs");
                });

            modelBuilder.Entity("Bug_Tracker2020.Models.Bug", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("Bug_Tracker2020.Models.User", b =>
                {
                    b.Navigation("Bugs");
                });
#pragma warning restore 612, 618
        }
    }
}

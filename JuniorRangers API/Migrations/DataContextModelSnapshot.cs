﻿// <auto-generated />
using System;
using JuniorRangers_API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JuniorRangers_API.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AchievementMissionGroup", b =>
                {
                    b.Property<int>("AchievementsAchievementId")
                        .HasColumnType("int");

                    b.Property<int>("MissionGroupsMissionGroupId")
                        .HasColumnType("int");

                    b.HasKey("AchievementsAchievementId", "MissionGroupsMissionGroupId");

                    b.HasIndex("MissionGroupsMissionGroupId");

                    b.ToTable("AchievementMissionGroup");
                });

            modelBuilder.Entity("JuniorRangers_API.Models.Achievement", b =>
                {
                    b.Property<int>("AchievementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AchievementId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsCompletedClassMission")
                        .HasColumnType("bit");

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.HasKey("AchievementId");

                    b.ToTable("Achievements");
                });

            modelBuilder.Entity("JuniorRangers_API.Models.AchievementMissionGroup", b =>
                {
                    b.Property<int>("AchievementId")
                        .HasColumnType("int");

                    b.Property<int>("MissionGroupId")
                        .HasColumnType("int");

                    b.HasKey("AchievementId", "MissionGroupId");

                    b.HasIndex("MissionGroupId");

                    b.ToTable("AchievementMissionGroups");
                });

            modelBuilder.Entity("JuniorRangers_API.Models.Album", b =>
                {
                    b.Property<int>("AlbumId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AlbumId"));

                    b.Property<int>("ClassroomClassId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("AlbumId");

                    b.HasIndex("ClassroomClassId");

                    b.ToTable("Albums");
                });

            modelBuilder.Entity("JuniorRangers_API.Models.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookId"));

                    b.Property<int>("ClassroomClassId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("UploadDate")
                        .HasColumnType("datetime2");

                    b.HasKey("BookId");

                    b.HasIndex("ClassroomClassId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("JuniorRangers_API.Models.ClassMission", b =>
                {
                    b.Property<int>("ClassId")
                        .HasColumnType("int");

                    b.Property<int>("MissionGroupId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateAssigned")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateCompleted")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("bit");

                    b.HasKey("ClassId", "MissionGroupId");

                    b.HasIndex("MissionGroupId");

                    b.ToTable("ClassMissions");
                });

            modelBuilder.Entity("JuniorRangers_API.Models.Classroom", b =>
                {
                    b.Property<int>("ClassId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClassId"));

                    b.Property<string>("JoinCode")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClassId");

                    b.ToTable("Classrooms");
                });

            modelBuilder.Entity("JuniorRangers_API.Models.Message", b =>
                {
                    b.Property<int>("MessageID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MessageID"));

                    b.Property<int>("ClassroomClassId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("MessageText")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("MessageTitle")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("MessageType")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("SenderId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("MessageID");

                    b.HasIndex("ClassroomClassId");

                    b.HasIndex("SenderId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("JuniorRangers_API.Models.MissionGroup", b =>
                {
                    b.Property<int>("MissionGroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MissionGroupId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MissionGroupId");

                    b.ToTable("MissionGroups");
                });

            modelBuilder.Entity("JuniorRangers_API.Models.Picture", b =>
                {
                    b.Property<int>("PictureId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PictureId"));

                    b.Property<int?>("AlbumId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("PostId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UploadDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UploaderId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("PictureId");

                    b.HasIndex("AlbumId");

                    b.HasIndex("PostId");

                    b.HasIndex("UploaderId");

                    b.ToTable("Pictures");
                });

            modelBuilder.Entity("JuniorRangers_API.Models.Post", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PostId"));

                    b.Property<int>("ClassroomClassId")
                        .HasColumnType("int");

                    b.Property<int>("Likes")
                        .HasColumnType("int");

                    b.Property<DateTime>("PostDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PosterId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.HasKey("PostId");

                    b.HasIndex("ClassroomClassId");

                    b.HasIndex("PosterId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("JuniorRangers_API.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<int?>("ClassroomClassId")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<int>("UserNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserNumber"));

                    b.HasKey("Id");

                    b.HasIndex("ClassroomClassId");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("JuniorRangers_API.Models.UserAchievement", b =>
                {
                    b.Property<int>("UserNumber")
                        .HasColumnType("int");

                    b.Property<int>("AchievementId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateAwarded")
                        .HasColumnType("datetime2");

                    b.HasKey("UserNumber", "AchievementId");

                    b.HasIndex("AchievementId");

                    b.ToTable("UserAchievements");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "ec4678e0-af5b-4309-98ad-09b1f38c94e6",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "44b03480-cb6d-44a6-b7cb-a6bcc845005d",
                            Name = "Student",
                            NormalizedName = "STUDENT"
                        },
                        new
                        {
                            Id = "26dacc87-13ec-45a6-93ea-9a246a19ac59",
                            Name = "Ranger",
                            NormalizedName = "RANGER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("AchievementMissionGroup", b =>
                {
                    b.HasOne("JuniorRangers_API.Models.Achievement", null)
                        .WithMany()
                        .HasForeignKey("AchievementsAchievementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JuniorRangers_API.Models.MissionGroup", null)
                        .WithMany()
                        .HasForeignKey("MissionGroupsMissionGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("JuniorRangers_API.Models.AchievementMissionGroup", b =>
                {
                    b.HasOne("JuniorRangers_API.Models.Achievement", "Achievement")
                        .WithMany("AchievementMissionGroups")
                        .HasForeignKey("AchievementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JuniorRangers_API.Models.MissionGroup", "MissionGroup")
                        .WithMany("AchievementMissionGroups")
                        .HasForeignKey("MissionGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Achievement");

                    b.Navigation("MissionGroup");
                });

            modelBuilder.Entity("JuniorRangers_API.Models.Album", b =>
                {
                    b.HasOne("JuniorRangers_API.Models.Classroom", "Classroom")
                        .WithMany("Albums")
                        .HasForeignKey("ClassroomClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Classroom");
                });

            modelBuilder.Entity("JuniorRangers_API.Models.Book", b =>
                {
                    b.HasOne("JuniorRangers_API.Models.Classroom", "Classroom")
                        .WithMany("Books")
                        .HasForeignKey("ClassroomClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Classroom");
                });

            modelBuilder.Entity("JuniorRangers_API.Models.ClassMission", b =>
                {
                    b.HasOne("JuniorRangers_API.Models.Classroom", "Class")
                        .WithMany("ClassMissions")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JuniorRangers_API.Models.MissionGroup", "MissionGroup")
                        .WithMany("ClassMissions")
                        .HasForeignKey("MissionGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");

                    b.Navigation("MissionGroup");
                });

            modelBuilder.Entity("JuniorRangers_API.Models.Message", b =>
                {
                    b.HasOne("JuniorRangers_API.Models.Classroom", "Classroom")
                        .WithMany("Messages")
                        .HasForeignKey("ClassroomClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JuniorRangers_API.Models.User", "Sender")
                        .WithMany("Messages")
                        .HasForeignKey("SenderId");

                    b.Navigation("Classroom");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("JuniorRangers_API.Models.Picture", b =>
                {
                    b.HasOne("JuniorRangers_API.Models.Album", "Album")
                        .WithMany("Pictures")
                        .HasForeignKey("AlbumId");

                    b.HasOne("JuniorRangers_API.Models.Post", "Post")
                        .WithMany("Pictures")
                        .HasForeignKey("PostId");

                    b.HasOne("JuniorRangers_API.Models.User", "Uploader")
                        .WithMany("Picures")
                        .HasForeignKey("UploaderId");

                    b.Navigation("Album");

                    b.Navigation("Post");

                    b.Navigation("Uploader");
                });

            modelBuilder.Entity("JuniorRangers_API.Models.Post", b =>
                {
                    b.HasOne("JuniorRangers_API.Models.Classroom", "Classroom")
                        .WithMany("Posts")
                        .HasForeignKey("ClassroomClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JuniorRangers_API.Models.User", "Poster")
                        .WithMany("Posts")
                        .HasForeignKey("PosterId");

                    b.Navigation("Classroom");

                    b.Navigation("Poster");
                });

            modelBuilder.Entity("JuniorRangers_API.Models.User", b =>
                {
                    b.HasOne("JuniorRangers_API.Models.Classroom", "Classroom")
                        .WithMany("Users")
                        .HasForeignKey("ClassroomClassId");

                    b.Navigation("Classroom");
                });

            modelBuilder.Entity("JuniorRangers_API.Models.UserAchievement", b =>
                {
                    b.HasOne("JuniorRangers_API.Models.Achievement", "Achievement")
                        .WithMany("UserAchievement")
                        .HasForeignKey("AchievementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JuniorRangers_API.Models.User", "User")
                        .WithMany("UserAchievement")
                        .HasForeignKey("UserNumber")
                        .HasPrincipalKey("UserNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Achievement");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("JuniorRangers_API.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("JuniorRangers_API.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JuniorRangers_API.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("JuniorRangers_API.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("JuniorRangers_API.Models.Achievement", b =>
                {
                    b.Navigation("AchievementMissionGroups");

                    b.Navigation("UserAchievement");
                });

            modelBuilder.Entity("JuniorRangers_API.Models.Album", b =>
                {
                    b.Navigation("Pictures");
                });

            modelBuilder.Entity("JuniorRangers_API.Models.Classroom", b =>
                {
                    b.Navigation("Albums");

                    b.Navigation("Books");

                    b.Navigation("ClassMissions");

                    b.Navigation("Messages");

                    b.Navigation("Posts");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("JuniorRangers_API.Models.MissionGroup", b =>
                {
                    b.Navigation("AchievementMissionGroups");

                    b.Navigation("ClassMissions");
                });

            modelBuilder.Entity("JuniorRangers_API.Models.Post", b =>
                {
                    b.Navigation("Pictures");
                });

            modelBuilder.Entity("JuniorRangers_API.Models.User", b =>
                {
                    b.Navigation("Messages");

                    b.Navigation("Picures");

                    b.Navigation("Posts");

                    b.Navigation("UserAchievement");
                });
#pragma warning restore 612, 618
        }
    }
}

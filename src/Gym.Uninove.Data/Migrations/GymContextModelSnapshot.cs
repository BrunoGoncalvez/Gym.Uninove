﻿// <auto-generated />
using System;
using Gym.Uninove.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Gym.Uninove.Data.Migrations
{
    [DbContext(typeof(GymContext))]
    partial class GymContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.30")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Gym.Uninove.Core.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Complement")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("GymId")
                        .HasColumnType("int");

                    b.Property<string>("Neighborhood")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("GymId")
                        .IsUnique();

                    b.ToTable("Adresses");
                });

            modelBuilder.Entity("Gym.Uninove.Core.Entities.Equipment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DatePurchase")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("GymBranchId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<int>("StatusPurchase")
                        .HasColumnType("int");

                    b.Property<DateTime>("UsageTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("GymBranchId");

                    b.ToTable("Equipments");
                });

            modelBuilder.Entity("Gym.Uninove.Core.Entities.GroupClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("GymBranchId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GymBranchId");

                    b.HasIndex("TeacherId");

                    b.ToTable("GroupClasses");
                });

            modelBuilder.Entity("Gym.Uninove.Core.Entities.GymBranch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("UnitNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Gyms");
                });

            modelBuilder.Entity("Gym.Uninove.Core.Entities.ImageUrl", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Path")
                        .HasColumnType("longtext");

                    b.Property<int>("ProfileId")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("ProfileId")
                        .IsUnique();

                    b.ToTable("ImageUrl");
                });

            modelBuilder.Entity("Gym.Uninove.Core.Entities.Membership", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<float>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Memberships");
                });

            modelBuilder.Entity("Gym.Uninove.Core.Entities.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<int?>("GymBranchId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("GymBranchId");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("Gym.Uninove.Core.Entities.Users.Profile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("Occupation")
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("Gym.Uninove.Core.Entities.Users.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<int?>("GroupClassId")
                        .HasColumnType("int");

                    b.Property<int>("MembershipId")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .HasColumnType("longtext");

                    b.Property<string>("Role")
                        .HasColumnType("longtext");

                    b.Property<string>("UserName")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("GroupClassId");

                    b.HasIndex("MembershipId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Gym.Uninove.Core.Entities.Address", b =>
                {
                    b.HasOne("Gym.Uninove.Core.Entities.GymBranch", "Gym")
                        .WithOne("Address")
                        .HasForeignKey("Gym.Uninove.Core.Entities.Address", "GymId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gym");
                });

            modelBuilder.Entity("Gym.Uninove.Core.Entities.Equipment", b =>
                {
                    b.HasOne("Gym.Uninove.Core.Entities.GymBranch", null)
                        .WithMany("Equipments")
                        .HasForeignKey("GymBranchId");
                });

            modelBuilder.Entity("Gym.Uninove.Core.Entities.GroupClass", b =>
                {
                    b.HasOne("Gym.Uninove.Core.Entities.GymBranch", null)
                        .WithMany("GroupClasses")
                        .HasForeignKey("GymBranchId");

                    b.HasOne("Gym.Uninove.Core.Entities.Teacher", "Instructor")
                        .WithMany()
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Instructor");
                });

            modelBuilder.Entity("Gym.Uninove.Core.Entities.ImageUrl", b =>
                {
                    b.HasOne("Gym.Uninove.Core.Entities.Users.Profile", "Profile")
                        .WithOne("Photo")
                        .HasForeignKey("Gym.Uninove.Core.Entities.ImageUrl", "ProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("Gym.Uninove.Core.Entities.Teacher", b =>
                {
                    b.HasOne("Gym.Uninove.Core.Entities.GymBranch", null)
                        .WithMany("Instructors")
                        .HasForeignKey("GymBranchId");
                });

            modelBuilder.Entity("Gym.Uninove.Core.Entities.Users.Profile", b =>
                {
                    b.HasOne("Gym.Uninove.Core.Entities.Users.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Gym.Uninove.Core.Entities.Users.User", b =>
                {
                    b.HasOne("Gym.Uninove.Core.Entities.GroupClass", null)
                        .WithMany("Students")
                        .HasForeignKey("GroupClassId");

                    b.HasOne("Gym.Uninove.Core.Entities.Membership", "Membership")
                        .WithMany("Members")
                        .HasForeignKey("MembershipId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Membership");
                });

            modelBuilder.Entity("Gym.Uninove.Core.Entities.GroupClass", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("Gym.Uninove.Core.Entities.GymBranch", b =>
                {
                    b.Navigation("Address");

                    b.Navigation("Equipments");

                    b.Navigation("GroupClasses");

                    b.Navigation("Instructors");
                });

            modelBuilder.Entity("Gym.Uninove.Core.Entities.Membership", b =>
                {
                    b.Navigation("Members");
                });

            modelBuilder.Entity("Gym.Uninove.Core.Entities.Users.Profile", b =>
                {
                    b.Navigation("Photo");
                });
#pragma warning restore 612, 618
        }
    }
}
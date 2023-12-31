﻿// <auto-generated />
using System;
using KidsGaming.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace KidsGaming.Migrations
{
    [DbContext(typeof(KidsGamingContext))]
    partial class KidsGamingContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("KidsGaming.Models.BuyGame", b =>
                {
                    b.Property<int>("BuyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BuyId"), 1L, 1);

                    b.Property<int?>("GameId")
                        .HasColumnType("int");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("BuyId")
                        .HasName("PK__BuyGame__6DF70D4F242C675C");

                    b.HasIndex("GameId");

                    b.HasIndex("UserId");

                    b.ToTable("BuyGame", (string)null);
                });

            modelBuilder.Entity("KidsGaming.Models.BuyMembership", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int?>("TicketCount")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("UserId");

                    b.ToTable("BuyMemberships");
                });

            modelBuilder.Entity("KidsGaming.Models.Game", b =>
                {
                    b.Property<int>("GameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GameId"), 1L, 1);

                    b.Property<string>("GameName")
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.Property<int?>("GamePrice")
                        .HasColumnType("int");

                    b.HasKey("GameId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("KidsGaming.Models.MemberShip", b =>
                {
                    b.Property<int>("SubId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubId"), 1L, 1);

                    b.Property<int?>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("((2))");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("SubId")
                        .HasName("PK__MemberSh__4D9BB84A0A4893A2");

                    b.HasIndex("UserId");

                    b.ToTable("MemberShip", (string)null);
                });

            modelBuilder.Entity("KidsGaming.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"), 1L, 1);

                    b.Property<string>("RoleName")
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.HasKey("RoleId");

                    b.ToTable("Role", (string)null);
                });

            modelBuilder.Entity("KidsGaming.Models.UserInfo", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<string>("Email")
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("FullName")
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.Property<int?>("Membership")
                        .HasColumnType("int");

                    b.Property<string>("PasswordHash")
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("PasswordSalt")
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId")
                        .HasName("PK__UserInfo__1788CC4C7EC86069");

                    b.HasIndex("RoleId");

                    b.ToTable("UserInfo", (string)null);
                });

            modelBuilder.Entity("KidsGaming.Models.BuyGame", b =>
                {
                    b.HasOne("KidsGaming.Models.Game", "Game")
                        .WithMany("BuyGames")
                        .HasForeignKey("GameId")
                        .HasConstraintName("FK__BuyGame__GameId__440B1D61");

                    b.HasOne("KidsGaming.Models.UserInfo", "User")
                        .WithMany("BuyGames")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK__BuyGame__UserId__44FF419A");

                    b.Navigation("Game");

                    b.Navigation("User");
                });

            modelBuilder.Entity("KidsGaming.Models.BuyMembership", b =>
                {
                    b.HasOne("KidsGaming.Models.UserInfo", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("KidsGaming.Models.MemberShip", b =>
                {
                    b.HasOne("KidsGaming.Models.UserInfo", "User")
                        .WithMany("MemberShips")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK__MemberShi__UserI__403A8C7D");

                    b.Navigation("User");
                });

            modelBuilder.Entity("KidsGaming.Models.UserInfo", b =>
                {
                    b.HasOne("KidsGaming.Models.Role", "Role")
                        .WithMany("UserInfos")
                        .HasForeignKey("RoleId")
                        .HasConstraintName("FK__UserInfo__RoleId__3D5E1FD2");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("KidsGaming.Models.Game", b =>
                {
                    b.Navigation("BuyGames");
                });

            modelBuilder.Entity("KidsGaming.Models.Role", b =>
                {
                    b.Navigation("UserInfos");
                });

            modelBuilder.Entity("KidsGaming.Models.UserInfo", b =>
                {
                    b.Navigation("BuyGames");

                    b.Navigation("MemberShips");
                });
#pragma warning restore 612, 618
        }
    }
}

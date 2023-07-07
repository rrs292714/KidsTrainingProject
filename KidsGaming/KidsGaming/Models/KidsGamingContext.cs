using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace KidsGaming.Models
{
    public partial class KidsGamingContext : DbContext
    {
        public KidsGamingContext()
        {
        }

        public KidsGamingContext(DbContextOptions<KidsGamingContext> options)
            : base(options)
        {
        }
        public virtual DbSet<BuyMembership> BuyMemberships { get; set; } = null!;
        public virtual DbSet<BuyGame> BuyGames { get; set; } = null!;
        public virtual DbSet<Game> Games { get; set; } = null!;
        public virtual DbSet<MemberShip> MemberShips { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<UserInfo> UserInfos { get; set; } = null!;



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=PC0599\\MSSQL2019;Database=KidsGaming;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BuyGame>(entity =>
            {
                entity.HasKey(e => e.BuyId)
                    .HasName("PK__BuyGame__6DF70D4F242C675C");

                entity.ToTable("BuyGame");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.BuyGames)
                    .HasForeignKey(d => d.GameId)
                    .HasConstraintName("FK__BuyGame__GameId__440B1D61");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.BuyGames)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__BuyGame__UserId__44FF419A");
            });

            modelBuilder.Entity<Game>(entity =>
            {
                entity.Property(e => e.GameName)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MemberShip>(entity =>
            {
                entity.HasKey(e => e.SubId)
                    .HasName("PK__MemberSh__4D9BB84A0A4893A2");

                entity.ToTable("MemberShip");

                entity.Property(e => e.Status).HasDefaultValueSql("((2))");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.MemberShips)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__MemberShi__UserI__403A8C7D");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__UserInfo__1788CC4C7EC86069");

                entity.ToTable("UserInfo");

                entity.Property(e => e.Email)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.FullName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordHash)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordSalt)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserInfos)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__UserInfo__RoleId__3D5E1FD2");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

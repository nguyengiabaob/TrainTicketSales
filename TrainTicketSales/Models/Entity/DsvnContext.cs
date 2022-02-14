﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace TrainTicketSales.Models.Entity
{
    public partial class DsvnContext : DbContext
    {
        public DsvnContext()
        {
        }

        public DsvnContext(DbContextOptions<DsvnContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cabin> Cabin { get; set; }
        public virtual DbSet<CabinCategory> CabinCategory { get; set; }
        public virtual DbSet<Floor> Floor { get; set; }
        public virtual DbSet<SaleOrder> SaleOrder { get; set; }
        public virtual DbSet<SaleOrderDetail> SaleOrderDetail { get; set; }
        public virtual DbSet<Schedule> Schedule { get; set; }
        public virtual DbSet<Seat> Seat { get; set; }
        public virtual DbSet<SeatCategory> SeatCategory { get; set; }
        public virtual DbSet<SeatDetail> SeatDetail { get; set; }
        public virtual DbSet<Station> Station { get; set; }
        public virtual DbSet<Train> Train { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Cabin>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CabinCategoryCode).HasMaxLength(50);

                entity.Property(e => e.Index).HasMaxLength(250);

                entity.Property(e => e.TrainCode).HasMaxLength(50);

                entity.HasOne(d => d.CabinCategoryCodeNavigation)
                    .WithMany(p => p.Cabin)
                    .HasForeignKey(d => d.CabinCategoryCode)
                    .HasConstraintName("FK_Cabin_CabinCategory");

                entity.HasOne(d => d.TrainCodeNavigation)
                    .WithMany(p => p.Cabin)
                    .HasForeignKey(d => d.TrainCode)
                    .HasConstraintName("FK_Cabin_Train");
            });

            modelBuilder.Entity<CabinCategory>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("PK_Cabin");

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(250);
            });

            modelBuilder.Entity<Floor>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<SaleOrder>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.IdentityCard).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.Property(e => e.PhoneNumber).HasMaxLength(50);

                entity.Property(e => e.Status).HasComment("1: đặt mua; 2: chấp nhận bán; 3: trả tiền; 4: xác nhận nhận tiền, 5:  giao vé, 6: hoãn, 7: đổi chuyển");
            });

            modelBuilder.Entity<SaleOrderDetail>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IdentityCard).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.SeatDetailId).HasColumnName("SeatDetailID");

                entity.HasOne(d => d.SaleOrder)
                    .WithMany(p => p.SaleOrderDetail)
                    .HasForeignKey(d => d.SaleOrderId)
                    .HasConstraintName("FK_SaleOrderDetail_SaleOrder");

                entity.HasOne(d => d.SeatDetail)
                    .WithMany(p => p.SaleOrderDetail)
                    .HasForeignKey(d => d.SeatDetailId)
                    .HasConstraintName("FK_SaleOrderDetail_SeatDetail");
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BeginStationId).HasColumnName("BeginStationID");

                entity.Property(e => e.DateBegin).HasColumnType("datetime");

                entity.Property(e => e.DateEnd).HasColumnType("datetime");

                entity.Property(e => e.EndStationId).HasColumnName("EndStationID");

                entity.Property(e => e.TrainCode).HasMaxLength(50);

                entity.HasOne(d => d.BeginStation)
                    .WithMany(p => p.ScheduleBeginStation)
                    .HasForeignKey(d => d.BeginStationId)
                    .HasConstraintName("FK_Schedule_Station");

                entity.HasOne(d => d.EndStation)
                    .WithMany(p => p.ScheduleEndStation)
                    .HasForeignKey(d => d.EndStationId)
                    .HasConstraintName("FK_Schedule_Station1");

                entity.HasOne(d => d.TrainCodeNavigation)
                    .WithMany(p => p.Schedule)
                    .HasForeignKey(d => d.TrainCode)
                    .HasConstraintName("FK_Schedule_Train");
            });

            modelBuilder.Entity<Seat>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CabinId).HasColumnName("CabinID");

                entity.Property(e => e.FloorCode).HasMaxLength(50);

                entity.Property(e => e.SeatCategoryCode).HasMaxLength(50);

                entity.HasOne(d => d.Cabin)
                    .WithMany(p => p.Seat)
                    .HasForeignKey(d => d.CabinId)
                    .HasConstraintName("FK_Seat_Cabin");

                entity.HasOne(d => d.FloorCodeNavigation)
                    .WithMany(p => p.Seat)
                    .HasForeignKey(d => d.FloorCode)
                    .HasConstraintName("FK_Seat_Floor");

                entity.HasOne(d => d.SeatCategoryCodeNavigation)
                    .WithMany(p => p.Seat)
                    .HasForeignKey(d => d.SeatCategoryCode)
                    .HasConstraintName("FK_Seat_SeatCategory1");
            });

            modelBuilder.Entity<SeatCategory>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("PK_Seat");

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(250);
            });

            modelBuilder.Entity<SeatDetail>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ScheduleId).HasColumnName("ScheduleID");

                entity.Property(e => e.SeatId).HasColumnName("SeatID");

                entity.Property(e => e.Status).HasComment("0: trống, 1: đã thanh toán, 2: đang giữ chỗ");

                entity.HasOne(d => d.Schedule)
                    .WithMany(p => p.SeatDetail)
                    .HasForeignKey(d => d.ScheduleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SeatDetail_Schedule");

                entity.HasOne(d => d.Seat)
                    .WithMany(p => p.SeatDetail)
                    .HasForeignKey(d => d.SeatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SeatDetail_Seat");
            });

            modelBuilder.Entity<Station>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address).HasMaxLength(500);

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Km).HasMaxLength(250);

                entity.Property(e => e.Name).HasMaxLength(250);
            });

            modelBuilder.Entity<Train>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.Des).HasMaxLength(250);

                entity.Property(e => e.Name).HasMaxLength(250);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserName)
                    .HasName("PK_User");

                entity.Property(e => e.UserName).HasMaxLength(50);

                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FullName).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(500);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
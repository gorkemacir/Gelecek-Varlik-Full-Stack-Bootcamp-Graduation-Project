using System;
using BillingManagementSystem.Entity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BillingManagementSystem.Dal.Concrete.Context
{
    public partial class BillingManagementSystemContext : DbContext
    {
        public BillingManagementSystemContext()
        {
        }

        public BillingManagementSystemContext(DbContextOptions<BillingManagementSystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Apartment> Apartments { get; set; }
        public virtual DbSet<Debt> Debts { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-IFS9HER\\SQLEXPRESS01;Database=BillingManagementSystem;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Turkish_CI_AS");

            modelBuilder.Entity<Apartment>(entity =>
            {
                entity.ToTable("Apartment");

                entity.Property(e => e.ApartmentId).HasColumnName("apartment_id");

                entity.Property(e => e.ApartmentBlock)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("apartment_block");

                entity.Property(e => e.ApartmentCase)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("apartment_case");

                entity.Property(e => e.ApartmentFloor)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("apartment_floor");

                entity.Property(e => e.ApartmentNumber)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("apartment_number");

                entity.Property(e => e.ApartmentOwner)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("apartment_owner");

                entity.Property(e => e.ApartmentType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("apartment_type");
            });

            modelBuilder.Entity<Debt>(entity =>
            {
                entity.ToTable("Debt");

                entity.Property(e => e.DebtId).HasColumnName("debt_id");

                entity.Property(e => e.DebtAmount).HasColumnName("debt_amount");

                entity.Property(e => e.PaymentId).HasColumnName("payment_id");

                entity.HasOne(d => d.Payment)
                    .WithMany(p => p.Debts)
                    .HasForeignKey(d => d.PaymentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Debt_Payment");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.ToTable("Message");

                entity.Property(e => e.MessageId).HasColumnName("message_id");

                entity.Property(e => e.MessageText)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("message_text");

                entity.Property(e => e.MessageTime)
                    .HasColumnType("datetime")
                    .HasColumnName("message_time");

                entity.Property(e => e.MessageUser)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("message_user");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("Payment");

                entity.Property(e => e.PaymentId).HasColumnName("payment_id");

                entity.Property(e => e.PaymentAmount).HasColumnName("payment_amount");

                entity.Property(e => e.PaymentBalance).HasColumnName("payment_balance");

                entity.Property(e => e.PaymentCardnumber)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("payment_cardnumber");

                entity.Property(e => e.PaymentCvv)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("payment_cvv");

                entity.Property(e => e.PaymentDate)
                    .HasColumnType("date")
                    .HasColumnName("payment_date");

                entity.Property(e => e.PaymentFullname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("payment_fullname");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.ApartmentId).HasColumnName("apartment_id");

                entity.Property(e => e.BillElectric).HasColumnName("bill_electric");

                entity.Property(e => e.BillNaturalgas).HasColumnName("bill_naturalgas");

                entity.Property(e => e.BillWater).HasColumnName("bill_water");

                entity.Property(e => e.DebtId).HasColumnName("debt_id");

                entity.Property(e => e.PaymentId).HasColumnName("payment_id");

                entity.Property(e => e.SubscriptionAmount).HasColumnName("subscription_amount");

                entity.Property(e => e.UserCarinfo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("user_carinfo");

                entity.Property(e => e.UserFullname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("user_fullname");

                entity.Property(e => e.UserIdentity)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("user_identity");

                entity.Property(e => e.UserMail)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("user_mail");

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("user_password");

                entity.Property(e => e.UserTelephone)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("user_telephone");

                entity.HasOne(d => d.Apartment)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.ApartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Apartment");

                entity.HasOne(d => d.Debt)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.DebtId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Debt");

                entity.HasOne(d => d.Payment)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.PaymentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Payment");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

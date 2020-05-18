using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace clothing_store.DAL.Models
{
    public partial class OnlineStoreContext : DbContext
    {
        public OnlineStoreContext()
        {
        }

        public OnlineStoreContext(DbContextOptions<OnlineStoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Carts> Carts { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Contact> Contact { get; set; }
        public virtual DbSet<Images> Images { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Promotion> Promotion { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<RoleUser> RoleUser { get; set; }
        public virtual DbSet<Transactions> Transactions { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.//MNV;Initial Catalog=OnlineStore;Persist Security Info=True;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Carts>(entity =>
            {
                entity.HasKey(e => e.CartId)
                    .HasName("PK_Cart");

                entity.Property(e => e.CartId)
                    .HasColumnName("CartID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_Carts_Products1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Carts_Users1");
            });

            modelBuilder.Entity<Categories>(entity =>
            {
                entity.HasKey(e => e.CategoryId);

                entity.Property(e => e.CategoryId)
                    .HasColumnName("CategoryID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.SeoDescription)
                    .HasMaxLength(225)
                    .IsFixedLength();

                entity.Property(e => e.SeoTitle)
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.Property(e => e.Status)
                    .HasMaxLength(225)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.Property(e => e.ContactId)
                    .HasColumnName("ContactID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Message)
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.Property(e => e.Status)
                    .HasMaxLength(225)
                    .IsFixedLength();

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Contact)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Contact_Users");
            });

            modelBuilder.Entity<Images>(entity =>
            {
                entity.HasKey(e => e.ImageId)
                    .HasName("PK_Languages");

                entity.Property(e => e.ImageId)
                    .HasColumnName("ImageID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ImageSource)
                    .HasMaxLength(225)
                    .IsUnicode(false);

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Images)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Images_Products");
            });

            modelBuilder.Entity<OrderDetails>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.ProductId });

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderDetails_Orders");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderDetails_Products");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.OrderId);

                entity.Property(e => e.OrderId)
                    .HasColumnName("OrderID")
                    .ValueGeneratedNever();

                entity.Property(e => e.OrderDate).HasColumnType("date");

                entity.Property(e => e.ShipAddress)
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.Property(e => e.ShipEmail)
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.Property(e => e.ShipName)
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.Property(e => e.ShipPhoneNumber)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .IsFixedLength();

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Orders_Users1");
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasKey(e => e.ProductId);

                entity.Property(e => e.ProductId)
                    .HasColumnName("ProductID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.DateCreate).HasColumnType("date");

                entity.Property(e => e.Description)
                    .HasMaxLength(225)
                    .IsFixedLength();

                entity.Property(e => e.OriginalPrice).HasColumnType("money");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.SeoDescription)
                    .HasMaxLength(225)
                    .IsFixedLength();

                entity.Property(e => e.SeoTitle)
                    .HasMaxLength(225)
                    .IsFixedLength();

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Products_Categories");
            });

            modelBuilder.Entity<Promotion>(entity =>
            {
                entity.Property(e => e.PromotionId)
                    .HasColumnName("PromotionID")
                    .ValueGeneratedNever();

                entity.Property(e => e.FromDate).HasColumnType("date");

                entity.Property(e => e.ProductCategoryIds).HasColumnName("ProductCategoryIDs");

                entity.Property(e => e.ProductIds).HasColumnName("ProductIDs");

                entity.Property(e => e.PromotionName)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.Status)
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.Property(e => e.ToDate).HasColumnType("date");

                entity.HasOne(d => d.ProductIdsNavigation)
                    .WithMany(p => p.Promotion)
                    .HasForeignKey(d => d.ProductIds)
                    .HasConstraintName("FK_Promotion_Products1");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.Status)
                    .HasMaxLength(100)
                    .IsFixedLength();
            });

            modelBuilder.Entity<RoleUser>(entity =>
            {
                entity.HasKey(e => new { e.RoleId, e.UserId });

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Status).HasMaxLength(100);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.RoleUser)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoleUser_Role");

                entity.HasOne(d => d.UserNavigation)
                    .WithMany(p => p.RoleUser)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoleUser_Users");
            });

            modelBuilder.Entity<Transactions>(entity =>
            {
                entity.HasKey(e => e.TransactionId);

                entity.Property(e => e.TransactionId)
                    .HasColumnName("TransactionID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Amount).HasColumnType("money");

                entity.Property(e => e.ExternalTransactionId).HasColumnName("ExternalTransactionID");

                entity.Property(e => e.Fee).HasColumnType("money");

                entity.Property(e => e.Message)
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.Provider)
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.Property(e => e.Result)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.Status)
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.Property(e => e.TransactionDate).HasColumnType("date");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_Transactions_Orders");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Transactions_Users");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserId)
                    .HasColumnName("UserID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Dob)
                    .HasColumnName("DOB")
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.Email)
                    .HasMaxLength(25)
                    .IsFixedLength();

                entity.Property(e => e.FullName)
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(24)
                    .IsFixedLength();

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

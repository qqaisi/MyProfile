using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DataLibrary
{
    public partial class SHOPPING_DBContext : DbContext
    {
        public SHOPPING_DBContext()
        {
        }

        public SHOPPING_DBContext(DbContextOptions<SHOPPING_DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<Inventory1> Inventory1s { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<ItemsCat> ItemsCats { get; set; }
        public virtual DbSet<ItemsSubCat> ItemsSubCats { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderNumber> OrderNumbers { get; set; }
        public virtual DbSet<StoreBranch> StoreBranches { get; set; }
        public virtual DbSet<StoresName> StoresNames { get; set; }
        public virtual DbSet<Tcart> Tcarts { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=SHOPPING_DB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.HasKey(e => new { e.ItemId, e.StoreBranchId })
                    .HasName("Comp_PK");

                entity.ToTable("INVENTORY");

                entity.Property(e => e.ItemId).HasColumnName("ITEM_ID");

                entity.Property(e => e.StoreBranchId).HasColumnName("STORE_BRANCH_ID");

                entity.Property(e => e.ExpirationDate)
                    .HasColumnType("date")
                    .HasColumnName("EXPIRATION_DATE");

                entity.Property(e => e.MinQty).HasColumnName("MIN_QTY");

                entity.Property(e => e.Qty).HasColumnName("QTY");

                entity.Property(e => e.SubCatId).HasColumnName("Sub_Cat_Id");

                entity.Property(e => e.UnitCost).HasColumnName("UNIT_COST");

                entity.Property(e => e.UnitPrice).HasColumnName("UNIT_PRICE");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__INVENTORY__ITEM___3C34F16F");

                entity.HasOne(d => d.StoreBranch)
                    .WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.StoreBranchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__INVENTORY__STORE__3D2915A8");

                entity.HasOne(d => d.SubCat)
                    .WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.SubCatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__INVENTORY__Sub_C__3E1D39E1");
            });

            modelBuilder.Entity<Inventory1>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("INVENTORY1");

                entity.Property(e => e.ExpirationDate)
                    .HasColumnType("date")
                    .HasColumnName("EXPIRATION_DATE");

                entity.Property(e => e.ItemId).HasColumnName("ITEM_ID");

                entity.Property(e => e.MinQty).HasColumnName("MIN_QTY");

                entity.Property(e => e.Qty).HasColumnName("QTY");

                entity.Property(e => e.StoreBranchId).HasColumnName("STORE_BRANCH_ID");

                entity.Property(e => e.SubCatId).HasColumnName("Sub_Cat_Id");

                entity.Property(e => e.UnitCost).HasColumnName("UNIT_COST");

                entity.Property(e => e.UnitPrice).HasColumnName("UNIT_PRICE");

                entity.HasOne(d => d.Item)
                    .WithMany()
                    .HasForeignKey(d => d.ItemId)
                    .HasConstraintName("FK__INVENTORY__ITEM___4222D4EF");

                entity.HasOne(d => d.StoreBranch)
                    .WithMany()
                    .HasForeignKey(d => d.StoreBranchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__INVENTORY__STORE__4316F928");

                entity.HasOne(d => d.SubCat)
                    .WithMany()
                    .HasForeignKey(d => d.SubCatId)
                    .HasConstraintName("FK__INVENTORY__Sub_C__6E01572D");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.ToTable("ITEMS");

                entity.Property(e => e.ItemId).HasColumnName("ITEM_ID");

                entity.Property(e => e.ItemDesc)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("ITEM_DESC");

                entity.Property(e => e.ItemName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("ITEM_NAME");

                entity.Property(e => e.SubCatId).HasColumnName("SUB_CAT_ID");

                entity.HasOne(d => d.SubCat)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.SubCatId)
                    .HasConstraintName("FK__ITEMS__SUB_CAT_I__403A8C7D");
            });

            modelBuilder.Entity<ItemsCat>(entity =>
            {
                entity.HasKey(e => e.CatId)
                    .HasName("PK__ITEMS_CA__5F8323A87176A511");

                entity.ToTable("ITEMS_CAT");

                entity.Property(e => e.CatId).HasColumnName("CAT_ID");

                entity.Property(e => e.CatName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("CAT_NAME");
            });

            modelBuilder.Entity<ItemsSubCat>(entity =>
            {
                entity.HasKey(e => e.SubCatId)
                    .HasName("PK__ITEMS_SU__DCFEBEB5414D8973");

                entity.ToTable("ITEMS_SUB_CAT");

                entity.Property(e => e.SubCatId).HasColumnName("SUB_CAT_ID");

                entity.Property(e => e.CatId).HasColumnName("CAT_ID");

                entity.Property(e => e.SubCatName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("SUB_CAT_NAME");

                entity.HasOne(d => d.Cat)
                    .WithMany(p => p.ItemsSubCats)
                    .HasForeignKey(d => d.CatId)
                    .HasConstraintName("FK__ITEMS_SUB__CAT_I__3D5E1FD2");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => new { e.OrderNo, e.ItemId })
                    .HasName("PK_Name");

                entity.ToTable("ORDERS");

                entity.Property(e => e.OrderNo).HasColumnName("ORDER_NO");

                entity.Property(e => e.ItemId).HasColumnName("ITEM_ID");

                entity.Property(e => e.Qty).HasColumnName("QTY");

                entity.Property(e => e.UnitPrice).HasColumnName("UNIT_PRICE");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ORDERS__ITEM_ID__57DD0BE4");

                entity.HasOne(d => d.OrderNoNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.OrderNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ORDERS__ORDER_NO__56E8E7AB");
            });

            modelBuilder.Entity<OrderNumber>(entity =>
            {
                entity.HasKey(e => e.OrderNo)
                    .HasName("PK__ORDER_NU__460AEC57164294CA");

                entity.ToTable("ORDER_NUMBERS");

                entity.Property(e => e.OrderNo).HasColumnName("ORDER_NO");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("date")
                    .HasColumnName("ORDER_DATE");

                entity.Property(e => e.StoreBranchId).HasColumnName("STORE_BRANCH_ID");

                entity.Property(e => e.UserPk).HasColumnName("UserPK");

                entity.HasOne(d => d.StoreBranch)
                    .WithMany(p => p.OrderNumbers)
                    .HasForeignKey(d => d.StoreBranchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ORDER_NUM__STORE__540C7B00");

                entity.HasOne(d => d.UserPkNavigation)
                    .WithMany(p => p.OrderNumbers)
                    .HasForeignKey(d => d.UserPk)
                    .HasConstraintName("FK__ORDER_NUM__UserP__531856C7");
            });

            modelBuilder.Entity<StoreBranch>(entity =>
            {
                entity.ToTable("STORE_BRANCHES");

                entity.Property(e => e.StoreBranchId).HasColumnName("STORE_BRANCH_ID");

                entity.Property(e => e.StoreCity)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("STORE_CITY");

                entity.Property(e => e.StoreNameId).HasColumnName("STORE_NAME_ID");

                entity.Property(e => e.StorePhone)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("STORE_PHONE");

                entity.Property(e => e.StoreState)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("STORE_STATE");

                entity.Property(e => e.StoreStreet)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("STORE_STREET");

                entity.Property(e => e.StoreZipcode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("STORE_ZIPCODE");

                entity.HasOne(d => d.StoreName)
                    .WithMany(p => p.StoreBranches)
                    .HasForeignKey(d => d.StoreNameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__STORE_BRA__STORE__38996AB5");
            });

            modelBuilder.Entity<StoresName>(entity =>
            {
                entity.HasKey(e => e.StoreNameId)
                    .HasName("PK__STORES_N__A9D35357D894D822");

                entity.ToTable("STORES_NAMES");

                entity.Property(e => e.StoreNameId).HasColumnName("STORE_NAME_ID");

                entity.Property(e => e.StoreName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("STORE_NAME");
            });

            modelBuilder.Entity<Tcart>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TCart");

                entity.Property(e => e.Itemid).HasColumnName("itemid");

                entity.Property(e => e.Itemname)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("itemname");

                entity.Property(e => e.Minqty).HasColumnName("minqty");

                entity.Property(e => e.Qty).HasColumnName("qty");

                entity.Property(e => e.Unitprice).HasColumnName("unitprice");
                entity.Property(e => e.Userpk).HasColumnName("Userpk");
                entity.Property(e => e.Subtot).HasColumnName("Subtot");
                entity.Property(e => e.Total).HasColumnName("Total");


            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserPk)
                    .HasName("PK__USERS__1788857ECDEE3683");

                entity.ToTable("USERS");

                entity.HasIndex(e => e.Userid, "UQ__USERS__7B9E7F3436E2A161")
                    .IsUnique();

                entity.Property(e => e.UserPk).HasColumnName("UserPK");

                entity.Property(e => e.Email)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.StoreBranchId).HasColumnName("StoreBranchID");

                entity.Property(e => e.Ucity)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("UCity");

                entity.Property(e => e.User_Pwd)
                    .HasMaxLength(20)
                    .HasColumnName("USER_PWD");

                entity.Property(e => e.Userid)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("USERID");

                entity.Property(e => e.Ustate)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("UState");

                entity.Property(e => e.Ustreet)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("UStreet");

                entity.Property(e => e.Uzip)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("UZip");

                entity.HasOne(d => d.StoreBranch)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.StoreBranchId)
                    .HasConstraintName("FK__USERS__StoreBran__6442E2C9");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

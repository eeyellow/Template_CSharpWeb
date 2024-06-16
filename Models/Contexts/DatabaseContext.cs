using LC.Infrastructure.Database.Interface;
using LC.Infrastructure.Database.Extensions;
using LC.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace LC.Models.Contexts
{
    /// <summary> 主資料庫 </summary>
    public partial class DatabaseContext : IdentityDbContext<IdentityUser>
    {
        private static readonly bool[] MigratedRecord = { false };
        /// <summary> 使用者資料 </summary>
        public virtual DbSet<UserProfile> UserProfile { get; set; }
        /// <summary> 縣市 </summary>
        public virtual DbSet<County> County { get; set; }
        /// <summary> 鄉鎮市區 </summary>
        public virtual DbSet<Town> Town { get; set; }
        /// <summary> 村里 </summary>
        public virtual DbSet<Village> Village { get; set; }

        /// <summary> 建構式 </summary>
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            // 自動更新資料庫結構
            if (!MigratedRecord[0])
            {
                lock (MigratedRecord)
                {
                    if (!MigratedRecord[0])
                    {
                        this.Database.Migrate();
                        MigratedRecord[0] = true;
                    }
                }
            }
        }

        /// <summary> OnModelCreating </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            OnModelCreatingPartial(modelBuilder);

            // Infrastructure/Database/Extensions
            SoftDeleteQueryFilter.Apply(modelBuilder, typeof(IDelete));
            CustomDataTypeAttributeConvention.Apply(modelBuilder);
            DecimalPrecisionAttributeConvention.Apply(modelBuilder);
            SqlDefaultValueAttributeConvention.Apply(modelBuilder);

            // Infrastructure/Seeds
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

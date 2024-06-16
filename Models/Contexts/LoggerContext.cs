using Microsoft.EntityFrameworkCore;

namespace LC.Models.Contexts
{
    /// <summary> Log資料庫 </summary>
    public partial class LoggerContext : DbContext
    {
        /// <summary> 建構式 </summary>
        public LoggerContext(DbContextOptions<LoggerContext> options) : base(options)
        {

        }

        /// <summary> OnModelCreating </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

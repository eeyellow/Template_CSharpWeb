using Microsoft.EntityFrameworkCore;

namespace LC.Models.Contexts
{
    /// <summary> 排程資料庫 </summary>
    public partial class TaskContext : DbContext
    {
        /// <summary> 建構式 </summary>
        public TaskContext(DbContextOptions<TaskContext> options) : base(options)
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

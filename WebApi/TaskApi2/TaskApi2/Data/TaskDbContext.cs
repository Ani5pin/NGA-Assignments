using Microsoft.EntityFrameworkCore;
using TaskApi2.Models;

namespace TaskApi2.Data
{
    public class TaskDbContext : DbContext
    {
        public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options)
        {
        }

        public DbSet<Models.Task> Tasks { get; set; }
        public DbSet<SubTask> SubTasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Task>()
                .HasMany(t => t.SubTasks)
                .WithOne(st => st.Task)
                .HasForeignKey(st => st.TaskID);

            base.OnModelCreating(modelBuilder);
        }
    }
}

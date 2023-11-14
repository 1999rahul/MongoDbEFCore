using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;

namespace EfCoreMongoDB
{
    public class MongoDbContext: DbContext
    {
        public MongoDbContext(DbContextOptions<MongoDbContext> opts):base(opts) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Student>().ToCollection("Students");
        }

        public DbSet<Student> students { get; set; }
    }
}

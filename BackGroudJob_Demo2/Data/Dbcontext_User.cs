using BackGroudJob_Demo2.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BackGroudJob_Demo2.Data
{
    public class Dbcontext_User :DbContext
    {
        public Dbcontext_User(DbContextOptions<Dbcontext_User> options) :base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
    
    }

}

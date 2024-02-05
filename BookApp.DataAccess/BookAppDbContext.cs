using BookApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookApp.DataAccess
{
    public class BookAppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=SQL5080.site4now.net;Initial Catalog=db_a831d0_nbuy;User Id=db_a831d0_nbuy_admin;Password=Nbuy1234");
        }

        public DbSet<Book> Books { get; set; }
    }
}

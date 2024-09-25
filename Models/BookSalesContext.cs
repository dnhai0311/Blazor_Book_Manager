using Microsoft.EntityFrameworkCore;

namespace Blazor_BookSale_Manager.Models
{
    public class BookSalesContext : DbContext
    {
        public BookSalesContext(DbContextOptions<BookSalesContext> options)
           : base(options)
        {
        }
        public DbSet<BookSale> BookSales { get; set; }
    }
}

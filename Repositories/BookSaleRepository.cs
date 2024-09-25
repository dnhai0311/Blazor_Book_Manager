using Blazor_BookSale_Manager.Models;
using Microsoft.EntityFrameworkCore;

namespace Blazor_BookSale_Manager.Repositories
{
    public class BookSaleRepository : IBookSaleRepository
    {
        BookSalesContext bookSaleContext;
        public BookSaleRepository(BookSalesContext context)
        {
            this.bookSaleContext = context;
        }
        public async Task<List<BookSale>> GetAllBookSales()
        {
            return await this.bookSaleContext.BookSales.ToListAsync();
        }
        public async Task<BookSale> GetBookSaleById(int id)
        {
            var bookSale = await this.bookSaleContext.BookSales.FindAsync(id);

            if (bookSale == null)
            {
                throw new ($"BookSale với ID: {id} không thấy.");
            }

            return bookSale;
        }

        public async Task AddBookSale(BookSale bookSale)
        {
            this.bookSaleContext.Add(bookSale);
            await this.bookSaleContext.SaveChangesAsync();
        }
        public async Task UpdateBookSale(BookSale bookSale)
        {
            var existingBookSale = await bookSaleContext.BookSales.FindAsync(bookSale.Id);
            if (existingBookSale != null)
            {
                existingBookSale.Title = bookSale.Title;
                existingBookSale.Quantity = bookSale.Quantity;
                existingBookSale.Price = bookSale.Price;
                await bookSaleContext.SaveChangesAsync();
            }
        }
        public async Task DeleteBookSale(int id)
        {
            var bookSale = await bookSaleContext.BookSales.FindAsync(id);
            if (bookSale != null)
            {
                bookSaleContext.BookSales.Remove(bookSale);
                await bookSaleContext.SaveChangesAsync();
            }
        }

    }
}

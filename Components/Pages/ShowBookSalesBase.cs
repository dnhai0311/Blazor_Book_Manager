using Blazor_BookSale_Manager.Repositories;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Unidecode.NET;

namespace Blazor_BookSale_Manager.Components.Pages
{
    public class ShowBookSalesBase : ComponentBase
    {
        [Inject]
        public IBookSaleRepository bookSaleRepository { get; set; }

        [Inject]
        public NavigationManager navigationManager { get; set; }

        [Inject]
        public IJSRuntime JS { get; set; }

        public string SearchTerm = string.Empty;
        public string searchTerm
        {
            get => SearchTerm;
            set
            {
                SearchTerm = value;
                UpdatePagedBookSales();
            }
        }
        public int CurrentPage = 1;
        public int currentPage
        {
            get => CurrentPage;
            set
            {
                if (value > 0 && value <= (totalItems + PageSize - 1) / PageSize)
                {
                    CurrentPage = value;
                    UpdatePagedBookSales();
                }
            }
        }
        public int PageSize = 5;
        public int pageSize
        {
            get => PageSize;
            set
            {
                if (value != PageSize)
                {
                    PageSize = value;
                    CurrentPage = 1;
                    UpdatePagedBookSales();
                }
            }
        }
        public int totalItems;
        public List<BookSale> bookSales { get; set; } = new();

        public List<BookSale> filteredBookSales =>
            string.IsNullOrEmpty(searchTerm) ?
                bookSales :
                bookSales.Where(sale => sale.Title.Unidecode()
                .Contains(searchTerm.Unidecode(), StringComparison.OrdinalIgnoreCase))
                    .ToList();

        public List<BookSale> pagedBookSales =>
            filteredBookSales
                .Skip((CurrentPage - 1) * pageSize)
                .Take(PageSize)
                .ToList();
        protected override async Task OnInitializedAsync()
        {
            bookSales = await bookSaleRepository.GetAllBookSales();
            UpdatePagedBookSales();
        }

        public void UpdateBookSale(int id)
        {
            navigationManager.NavigateTo($"/edit/{id}");
        }

        public async Task DeleteBookSale(int id)
        {
            bool confirmed = await JS.InvokeAsync<bool>("confirm", $"Bạn muốn xóa Booksale với ID: {id}?");
            if (confirmed)
            {
                await bookSaleRepository.DeleteBookSale(id);
                bookSales = await bookSaleRepository.GetAllBookSales();
                UpdatePagedBookSales();
            }
        }

        public void UpdatePagedBookSales()
        {
            totalItems = filteredBookSales.Count();
        }

        public void PreviousPage()
        {
            if (CurrentPage > 1)
            {
                CurrentPage--;
                UpdatePagedBookSales();
            }
        }

        public void NextPage()
        {
            if (CurrentPage < (totalItems + PageSize - 1) / PageSize)
            {
                CurrentPage++;
                UpdatePagedBookSales();
            }
        }
    }
}

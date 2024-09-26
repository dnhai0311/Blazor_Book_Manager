using Blazor_BookSale_Manager.Models;
using Blazor_BookSale_Manager.Repositories;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Unidecode.NET;

namespace Blazor_BookSale_Manager.Components.Pages
{
    public class ShowListBase : ComponentBase
    {
        [Parameter]
        public string? Type { get; set; }
        [Parameter]
        public int? AuthorId { get; set; }
        [Inject]
        public required IBookSaleRepository bookSaleRepository { get; set; }

        [Inject]
        public required NavigationManager navigationManager { get; set; }

        [Inject]
        public required IJSRuntime JS { get; set; }

        public string SearchTerm = string.Empty;
        public string searchTerm
        {
            get => SearchTerm;
            set
            {
                SearchTerm = value;
                currentPage = 1;
                UpdatePaged();
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
                    UpdatePaged();
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
                    UpdatePaged();
                }
            }
        }
        public int totalItems;
        public List<object> items { get; set; } = new();

        private string GetItemTitle(object item)
        {
            return item switch
            {
                BookSale bookSale => bookSale.Title,
                Author author => author.AuthorName,
                _ => string.Empty
            };
        }

        public List<object> filteredItems =>
             string.IsNullOrEmpty(searchTerm) ?
                 items :
                 items.Where(item => GetItemTitle(item).Unidecode()
                 .Contains(searchTerm.Unidecode(), StringComparison.OrdinalIgnoreCase))
                     .ToList();
        public List<object> pagedItems =>
            filteredItems
                .Skip((CurrentPage - 1) * pageSize)
                .Take(PageSize)
                .ToList();
        protected override async Task OnInitializedAsync()
        {
            if (Type == "booksales")
            {
                var bookSales = await bookSaleRepository.GetAllBookSales();
                items.AddRange(bookSales);
            }
            else if (Type == "authors")
            {
                var authors = await bookSaleRepository.GetAllAuthors();
                items.AddRange(authors);
            } else if (AuthorId.HasValue)
            {
                Type = "booksales";
                var bookSales = await bookSaleRepository.GetAllBookSalesFromAuthor(AuthorId ?? 0);
                items.AddRange(bookSales);
            }
            UpdatePaged();
        }


        public void ShowAllBookSalesFromAuthor(int id)
        {
            navigationManager.NavigateTo($"/{Type}/{id}/booksales");
        }

        public void UpdateItem(int id)
        {
            navigationManager.NavigateTo($"/{Type}/{id}");
        }

        public async Task DeleteItem(int id)
        {
            if (Type == "booksales")
            {
                bool confirmed = await JS.InvokeAsync<bool>("confirm", $"Bạn muốn xóa Booksale với ID: {id}?");
                if (confirmed)
                {
                    await bookSaleRepository.DeleteBookSale(id);
                    items.RemoveAll(item => (item as BookSale)?.Id == id);
                    UpdatePaged();
                }
            }
        }


        public void UpdatePaged()
        {
            totalItems = filteredItems.Count();
        }

        public void PreviousPage()
        {
            if (CurrentPage > 1)
            {
                CurrentPage--;
                UpdatePaged();
            }
        }

        public void NextPage()
        {
            if (CurrentPage < (totalItems + PageSize - 1) / PageSize)
            {
                CurrentPage++;
                UpdatePaged();
            }
        }
    }
}

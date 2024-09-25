using Microsoft.AspNetCore.Components;
using Blazor_BookSale_Manager.Repositories;


namespace Blazor_BookSale_Manager.Components.Pages
{
    public class AddBookSaleBase : ComponentBase
    {
        [Inject]
        IBookSaleRepository bookSaleRepository { get; set; }
        [Inject]
        NavigationManager navigationManager { get; set; }
        [Parameter]
        public int? Id { get; set; }

        public BookSale bookSale { get; set; } = new BookSale();

        protected override async Task OnInitializedAsync()
        {
            if (Id.HasValue)
            {
                bookSale = await bookSaleRepository.GetBookSaleById(Id.Value);
            }
        }

        public async Task HandleValidSubmit()
        {
            if (bookSale.Id == 0)
            {
                await bookSaleRepository.AddBookSale(bookSale);
            }
            else
            {
                await bookSaleRepository.UpdateBookSale(bookSale);
            }
            navigationManager.NavigateTo("/list");
        }
    }
}

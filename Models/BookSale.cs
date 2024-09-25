using System.ComponentModel.DataAnnotations;

public class BookSale
{
    public int Id { get; set; } = 0;

    [Required]
    [StringLength(50, MinimumLength = 5, ErrorMessage = "Title có độ dài từ 5 -> 50 ký tự")]
    public string Title { get; set; } = String.Empty;

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Quantity phải lớn hơn 0")]
    public int Quantity { get; set; } = 0;

    [Required]
    [Range(1, double.MaxValue, ErrorMessage = "Price phải lớn hơn 0")]
    public double Price { get; set; } = 0;
}

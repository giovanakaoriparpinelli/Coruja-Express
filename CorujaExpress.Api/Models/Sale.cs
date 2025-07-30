using System.Text.Json.Serialization;

public class Sale
{
    public int Id { get; set; }
    public DateTime SaleDate { get; set; }
    public decimal TotalAmount { get; set; }
    public List<SaleItem> SaleItems { get; set; } = new List<SaleItem>();
}
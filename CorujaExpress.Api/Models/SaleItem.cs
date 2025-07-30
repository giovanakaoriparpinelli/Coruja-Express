using System.Text.Json.Serialization;

public class SaleItem
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public Product? Product { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public int SaleId { get; set; }
    
    [JsonIgnore]
    public Sale? Sale { get; set; }
}
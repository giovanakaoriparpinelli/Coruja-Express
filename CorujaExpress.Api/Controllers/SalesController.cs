using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// DTO (Data Transfer Object) para receber os dados do carrinho do frontend.
public class SaleDto
{
    // A lista agora é inicializada para evitar o aviso de nulidade.
    public List<CartItemDto> CartItems { get; set; } = new();
}

public class CartItemDto
{
    public int Id { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}


[ApiController]
[Route("api/[controller]")]
public class SalesController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public SalesController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Sale>>> GetSales()
    {
        var sales = await _context.Sales
                                  .Include(s => s.SaleItems)
                                  .ThenInclude(si => si.Product)
                                  .OrderByDescending(s => s.SaleDate)
                                  .ToListAsync();
        return Ok(sales);
    }

    [HttpPost]
    public async Task<ActionResult<Sale>> PostSale(SaleDto saleDto)
    {
        if (saleDto.CartItems == null || !saleDto.CartItems.Any())
        {
            return BadRequest("O carrinho não pode estar vazio.");
        }
        
        using var transaction = _context.Database.BeginTransaction();
        try
        {
            var newSale = new Sale
            {
                SaleDate = DateTime.UtcNow,
                TotalAmount = saleDto.CartItems.Sum(item => item.Quantity * item.Price)
            };

            foreach (var item in saleDto.CartItems)
            {
                var product = await _context.Products.FindAsync(item.Id);
                if (product == null || product.Stock < item.Quantity)
                {
                    transaction.Rollback();
                    return BadRequest($"Produto '{product?.Name ?? "ID "+item.Id}' fora de estoque ou insuficiente.");
                }

                product.Stock -= item.Quantity;

                newSale.SaleItems.Add(new SaleItem
                {
                    ProductId = item.Id,
                    Quantity = item.Quantity,
                    UnitPrice = item.Price
                });
            }

            _context.Sales.Add(newSale);
            await _context.SaveChangesAsync();
            transaction.Commit();

            return CreatedAtAction(nameof(GetSales), new { id = newSale.Id }, newSale);
        }
        catch (Exception)
        {
            transaction.Rollback();
            return StatusCode(500, "Ocorreu um erro interno ao processar a venda.");
        }
    }
}
using Microsoft.AspNetCore.Mvc;

namespace StockManagement.Api.Controllers;

[ApiController]
[Route("stocks")]
public class StockController : ControllerBase
{
    private static readonly List<Stock> stocks = new List<Stock>
    {
        new Stock("123", 45, "Adidas"),
        new Stock("239", 45, "Puma"),
        new Stock("874", 45, "Timberland")
    };

    private readonly ILogger<StockController> _logger;

    public StockController(ILogger<StockController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public ActionResult<List<Stock>> Get()
    {
        return Ok(stocks);
    }

    [HttpGet("{id}", Name = nameof(Get))]
    public ActionResult<Stock> Get(string id)
    {
        var stock = stocks.FirstOrDefault(x => x.Id == id);

        if (stock is null)
        {
            return NotFound();
        }

        return Ok(stock);
    }

    [HttpPost]
    public ActionResult Create([FromBody] Stock stock)
    {
        if (stocks.Any(x => x.Id == stock.Id))
        {
            return Conflict();
        }

        stocks.Add(stock);

        return CreatedAtRoute(nameof(Get), new { id = stock.Id }, stock);
    }

    [HttpDelete("{id}")]
    public ActionResult<List<Stock>> Delete(string id)
    {
        var stock = stocks.FirstOrDefault(x => x.Id == id);

        if (stock is null)
        {
            return NotFound();
        }

        stocks.Remove(stock);

        return Ok();
    }
}

public class Stock
{
    public string Id { get; set; }
    public int Quantity { get; set; }
    public string Brand { get; set; }

    public Stock()
    {

    }

    public Stock(string id, int quantity, string brand)
    {
        Id = id;
        Quantity = quantity;
        Brand = brand;
    }
}

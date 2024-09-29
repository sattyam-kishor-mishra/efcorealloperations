using efcorealloperations.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace efcorealloperations.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CurrencyController : ControllerBase
{
    private readonly ILogger<CurrencyController> _logger;
    private readonly AppDbContext _appDbContext;
    public CurrencyController(ILogger<CurrencyController> logger, AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var results = await _appDbContext.Currencies.ToListAsync();
            return Ok(results);
        }
        catch (System.Exception ex)
        {
            _logger.LogError(ex.ToString());
        }

        return NotFound();
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetAsync(int id)
    {
        try
        {
            var results = await _appDbContext.Currencies.FindAsync(id);
            
            return Ok(results);
        }
        catch (System.Exception ex)
        {
            _logger.LogError(ex.ToString());
        }

        return NotFound();
    }
}

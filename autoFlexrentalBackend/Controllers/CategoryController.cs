using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using autoFlexrentalBackend.Models;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly AutoFlexRentalContext _context;

    // Constructor
    public CategoryController(AutoFlexRentalContext context)
    {
        _context = context;
    }

    // Obtener todas las categor�as
    [HttpGet]
    public async Task<IActionResult> GetCategories()
    {
        var categories = await _context.Category.ToListAsync(); // Obtener las categor�as

        if (categories == null || !categories.Any())
        {
            return NotFound("No categories found.");
        }

        return Ok(categories);  // Devolver las categor�as encontradas
    }
}

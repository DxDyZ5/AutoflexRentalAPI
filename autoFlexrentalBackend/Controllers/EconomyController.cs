using System.Runtime.InteropServices;
using autoFlexrentalBackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


[ApiController]
[Route("api/economy")]
public class EconomyController : ControllerBase
{
    private readonly AutoFlexRentalContext _context;

    public EconomyController(AutoFlexRentalContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetEconomyData()
    {
        var economy = await _context.Economy.FirstOrDefaultAsync();
        return Ok(economy);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateEconomyData([FromBody] Economy updatedEconomy)
    {
        var economy = await _context.Economy.FirstOrDefaultAsync();
        if (economy == null)
        {
            _context.Economy.Add(updatedEconomy);
        }
        else
        {
            economy.TotalGains = updatedEconomy.TotalGains;
            economy.TotalInvestments = updatedEconomy.TotalInvestments;
        }

        await _context.SaveChangesAsync();
        return Ok(economy);
    }
}

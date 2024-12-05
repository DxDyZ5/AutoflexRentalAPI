using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Mvc;
[Route("api/test")]
[ApiController]
public class TestController : ControllerBase
{
    [HttpGet]
    public IActionResult GetTestMessage()
    {
        return Ok(new { message = "Conexi�n exitosa al backend" });
    }
}

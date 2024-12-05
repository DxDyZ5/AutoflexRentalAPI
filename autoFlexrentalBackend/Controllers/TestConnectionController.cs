using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;

namespace autoFlexrentalBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestConnectionController : ControllerBase
    {
        private readonly string _connectionString = "Server=DESKTOP-N0GJDDH;Database=AutoFlexRental;Integrated Security=True;TrustServerCertificate=True;";

        // GET: api/TestConnection
        [HttpGet]
        public IActionResult TestConnection()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    return Ok("Conexión exitosa a la base de datos.");
                }
                catch (Exception ex)
                {
                    return StatusCode(500, new { Message = "Error al conectar a la base de datos", Error = ex.Message });
                }
            }
        }
    }
}

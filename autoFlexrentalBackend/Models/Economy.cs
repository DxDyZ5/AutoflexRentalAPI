using System.Runtime.InteropServices;

public class Economy
{
    public int Id { get; set; }
    public decimal TotalGains { get; set; }
    public decimal TotalInvestments { get; set; }
    public decimal NetProfit => TotalGains - TotalInvestments; // Propiedad calculada
}

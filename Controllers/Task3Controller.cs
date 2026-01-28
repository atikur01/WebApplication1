using Microsoft.AspNetCore.Mvc;
using System.Numerics;

[ApiController]
[Route("atikvucse_protonmail_com")]
public class Task3Controller : ControllerBase
{
    [HttpGet]
    public IActionResult Get(string? x, string? y)
    {
        if (string.IsNullOrEmpty(x) || string.IsNullOrEmpty(y))
        {
            return Content("NaN", "text/plain");
        }

        x = x.Replace("{", "").Replace("}", "");
        y = y.Replace("{", "").Replace("}", "");

        if (!System.Text.RegularExpressions.Regex.IsMatch(x, "^[0-9]+$") || 
            !System.Text.RegularExpressions.Regex.IsMatch(y, "^[0-9]+$"))
        {
            return Content("NaN", "text/plain");
        }

        if (x == "0" || y == "0")
        {
            return Content("NaN", "text/plain");
        }

        var nx = BigInteger.Parse(x);
        var ny = BigInteger.Parse(y);

        var result = (nx / GCD(nx, ny)) * ny;

        return Content(result.ToString(), "text/plain");
    }

    private BigInteger GCD(BigInteger a, BigInteger b)
    {
        while (b != 0)
        {
            var t = b;
            b = a % b;
            a = t;
        }
        return a;
    }
}

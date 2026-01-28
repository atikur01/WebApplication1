using Microsoft.AspNetCore.Mvc;
using System.Numerics;

[ApiController]
[Route("atikvucse_protonmail_com")]
public class Task3Controller : ControllerBase
{
    [HttpGet]
    public IActionResult Get(string x, string y, string z = null)
    {
        if (!BigInteger.TryParse(x, out var a) ||
            !BigInteger.TryParse(y, out var b) ||
            a < 1 || b < 1)
        {
            return Content("NaN", "text/plain");
        }

        var lcm = BigInteger.Abs(a * b) / GCD(a, b);

        if (z != null)
        {
            if (!BigInteger.TryParse(z, out var c) || c < 1)
            {
                return Content("NaN", "text/plain");
            }
            lcm = BigInteger.Abs(lcm * c) / GCD(lcm, c);
        }

        return Content(lcm.ToString(), "text/plain");
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

using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace WebApplication1.Controllers
{
    [ApiController]
    public class Task3Controller : ControllerBase
    {
        [HttpGet]
        [Route("atikvucse_protonmail_com")]
        public IActionResult Get(string x, string y)
        {
            // Try parsing
            if (!long.TryParse(x, out long a) || !long.TryParse(y, out long b))
            {
                return Content("NaN", "text/plain");
            }

            // Natural numbers only (>=1)
            if (a < 1 || b < 1)
            {
                return Content("NaN", "text/plain");
            }

            long gcd = GCD(a, b);
            long lcm = (a / gcd) * b;

            return Content(lcm.ToString(), "text/plain");
        }

        private long GCD(long a, long b)
        {
            while (b != 0)
            {
                long temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
    }
}


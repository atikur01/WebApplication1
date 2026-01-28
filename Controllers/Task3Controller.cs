using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace WebApplication1.Controllers
{
    [ApiController]
    public class Task3Controller : ControllerBase
    {
        [HttpGet]
        [Route("atikvucse_protonmail_com")]
        public IActionResult Get(int x, int y, int z)
        {
            bool result = MysteryLogic(x, y,z);

            return Content(result.ToString().ToLower(), "text/plain");
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


        private bool MysteryLogic(int a, int b, int c)
        {
            // 🔒 HIDDEN LOGIC (example — replace with your own)
            // Example: checks if b is between a and c
            return (a < b && b < c) || (c < b && b < a);
        }

    }


    
}


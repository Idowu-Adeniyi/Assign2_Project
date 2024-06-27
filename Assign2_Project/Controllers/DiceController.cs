using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assign2_Project.Controllers
{
    public class DiceController : ApiController
    {
        [HttpGet]
        [Route("api/JS/DiceGame/{m}/{n}")]
        public String GetWaysToRollTen(int m, int n)
        {
            int ways = CalculateWaysToRollTen(m, n);
            string responseString = $"There {(ways == 1 ? "is" : "are")} {ways} way{(ways == 1 ? "" : "s")} to get the sum 10.";
            return responseString;
        }
        private int CalculateWaysToRollTen(int m, int n)
        {
            int count = 0;
            for (int i = 1; i <= m; i++)
            {
                for(int j = 1; j <= n; j++)
                {
                    if (i + j == 10)
                    {
                        count++;
                    }
                }
            }
            return count;
        }
    }
}

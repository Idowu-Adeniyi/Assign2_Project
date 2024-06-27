using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assign2_Project.Controllers
{
    public class MenuController : ApiController
    {
private readonly Dictionary<int, int> burgerCalories = new Dictionary<int, int>
        {
            {1, 461 },
            {2, 431 },
            {3, 420 },
            {4, 0 }

        };
private readonly Dictionary<int, int> drinkCalories = new Dictionary<int, int>
        {
            {1, 130 },
            {2, 160 },
            {3, 118 },
            {4, 0 }

        };
private readonly Dictionary<int, int> sideCalories = new Dictionary<int, int>
        {
            {1, 100 },
            {2, 57 },
            {3, 70 },
            {4, 0 }

        };
private readonly Dictionary<int, int> dessertCalories = new Dictionary<int, int>
        {
            {1, 167 },
            {2, 266 },
            {3, 75 },
            {4, 0 }

        };
        [HttpGet]
        [Route("api/J1/Menu/{burger}/{drink}/{side}/{dessert}")]
        public IHttpActionResult GetTotalCalories(int burger, int drink, int side, int dessert)
        {
            if (!burgerCalories.ContainsKey(burger) ||
                !drinkCalories.ContainsKey(drink) ||
                !sideCalories.ContainsKey(side) ||
                !dessertCalories.ContainsKey(dessert))
            {
                return BadRequest("Invalid input");
            }
            int totalCalories = burgerCalories[burger] + drinkCalories[drink] + sideCalories[side] + dessertCalories[dessert];
            return Ok($"Your total calories count is {totalCalories}");

        }
    }
}

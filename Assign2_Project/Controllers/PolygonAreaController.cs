using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assign2_Project.Controllers
{
    public class PolygonAreaController : ApiController
    {
        [HttpGet]
        [Route("PolygonArea/{vertices}")] // Ex.test input 0,0;4,0;4,3
        public String Get(string vertices)
        {
            var points = vertices.Split(';').Select(v => v.Split(',')).ToArray();
            if (points.Length < 3)
                return "A polygon must have at least 3 vertices.";
            double area = 0;
            for (int i = 0; i < points.Length; i++)
            {
                var (x1, y1) = (double.Parse(points[i][0]), double.Parse(points[i][1]));
                var (x2, y2) = (double.Parse(points[(i + 1) % points.Length][0]), double.Parse(points[(i + 1) % points.Length][1]));
                area += (x1 * y2) - (y1 * x2);
            }
            return $"The area of the polygon is {Math.Abs(area) / 2.0}";
        }
    }
}

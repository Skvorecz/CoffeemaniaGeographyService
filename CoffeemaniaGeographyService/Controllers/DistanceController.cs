using Microsoft.AspNetCore.Mvc;

namespace CoffeemaniaGeographyService.Controllers;

[Route("distance")]
public class DistanceController : Controller
{
    [HttpPost]
    public ActionResult<int> CalculateDistance()
    {
        return Ok(10);
    }
}
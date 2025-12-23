using CoffeemaniaGeographyService.Dtos;
using CoffeemaniaGeographyService.Services;
using Microsoft.AspNetCore.Mvc;

namespace CoffeemaniaGeographyService.Controllers;

[Route("distance")]
public class DistanceController(IDistanceService distanceService) : Controller
{
    [HttpPost]
    public ActionResult<CalculateDistanceResult> CalculateDistance(
        [FromBody]CalculateDistanceRequest request)
    {
        var result = distanceService.CalculateDistance(request.GeoPoint1, request.GeoPoint2);
        return Ok(result);
    }
}
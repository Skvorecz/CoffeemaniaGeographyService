using CoffeemaniaGeographyService.Dtos;
using CoffeemaniaGeographyService.Services;
using Microsoft.AspNetCore.Mvc;

namespace CoffeemaniaGeographyService.Controllers;

[Route("distance")]
public class DistanceController(IDistanceService distanceService) : Controller
{
    /// <summary>
    ///     Calculates the great-circle distance in kilometers between two geographic points
    ///     on the Earth's surface.
    /// </summary>
    /// <param name="request">
    ///     Request body containing two geographic points defined by latitude and longitude.
    /// </param>
    /// <returns>
    ///     Distance between the two points in kilometers.
    /// </returns>
    /// <response code="200">
    ///     Distance successfully calculated.
    /// </response>
    /// <response code="400">
    ///     One or both geographic points contain invalid coordinates.
    /// </response>
    [HttpPost]
    public ActionResult<CalculateDistanceResult> CalculateDistance(
        [FromBody]
        CalculateDistanceRequest request)
    {
        if (!IsValidGeoPoint(request.GeoPoint1, out var errorMessageGeoPoint1))
        {
            return BadRequest(new { error = errorMessageGeoPoint1 });
        }

        if (!IsValidGeoPoint(request.GeoPoint2, out var errorMessageGeoPoint2))
        {
            return BadRequest(new { error = errorMessageGeoPoint2 });
        }

        var distance = distanceService.CalculateDistanceInKilometers(request.GeoPoint1, request.GeoPoint2);
        return Ok(new CalculateDistanceResult(distance));
    }

    private bool IsValidGeoPoint(GeoPoint geoPoint, out string? errorMessage)
    {
        if (geoPoint.Latitude < -90 || geoPoint.Latitude > 90)
        {
            errorMessage = "Latitude must be between -90 and 90.";
            return false;
        }

        if (geoPoint.Longitude < -180 || geoPoint.Longitude > 180)
        {
            errorMessage = "Longitude must be between -180 and 180.";
            return false;
        }
        
        errorMessage = null;
        return true;
    }
}
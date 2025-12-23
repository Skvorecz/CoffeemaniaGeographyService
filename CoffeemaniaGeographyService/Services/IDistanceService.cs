using CoffeemaniaGeographyService.Dtos;

namespace CoffeemaniaGeographyService.Services;

public interface IDistanceService
{
    CalculateDistanceResult CalculateDistance(GeoPoint firstPoint, GeoPoint secondPoint);
}
using CoffeemaniaGeographyService.Dtos;

namespace CoffeemaniaGeographyService.Services;

public interface IDistanceService
{
    double CalculateDistanceInKilometers(GeoPoint firstPoint, GeoPoint secondPoint);
}
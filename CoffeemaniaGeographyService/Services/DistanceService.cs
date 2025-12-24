using CoffeemaniaGeographyService.Dtos;

namespace CoffeemaniaGeographyService.Services;

public class DistanceService : IDistanceService
{
    private const double EarthRadiusKilometers = 6371;

    public double CalculateDistanceInKilometers(GeoPoint firstPoint, GeoPoint secondPoint)
    {
        var latitudeDifferenceRadians =
            DegreesToRadians(secondPoint.Latitude - firstPoint.Latitude);

        var longitudeDifferenceRadians =
            DegreesToRadians(secondPoint.Longitude - firstPoint.Longitude);

        var firstLatitudeRadians =
            DegreesToRadians(firstPoint.Latitude);

        var secondLatitudeRadians =
            DegreesToRadians(secondPoint.Latitude);

        var a =
            Math.Sin(latitudeDifferenceRadians / 2) *
            Math.Sin(latitudeDifferenceRadians / 2) +
            Math.Cos(firstLatitudeRadians) *
            Math.Cos(secondLatitudeRadians) *
            Math.Sin(longitudeDifferenceRadians / 2) *
            Math.Sin(longitudeDifferenceRadians / 2);

        var angularDistance =
            2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

        var distance = EarthRadiusKilometers * angularDistance;
        return distance;
    }

    private double DegreesToRadians(double degrees)
    {
        return degrees * Math.PI / 180;
    }
}
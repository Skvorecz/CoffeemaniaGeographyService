namespace CoffeemaniaGeographyService.Dtos;

public class CalculateDistanceRequest
{
    public GeoPoint GeoPoint1 { get; init; }
    public GeoPoint GeoPoint2 { get; init; }
}
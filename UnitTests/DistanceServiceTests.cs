using CoffeemaniaGeographyService.Dtos;
using CoffeemaniaGeographyService.Services;
using FluentAssertions;

namespace UnitTests;

[TestFixture]
public class DistanceServiceTests
{
    private readonly DistanceService _distanceService = new();

    [Test]
    public void CalculateDistanceKmSamePointReturnsZero()
    {
        var point = new GeoPoint(55.7558, 37.6173); // Москва

        var result = _distanceService.CalculateDistanceInKilometers(point, point);

        result.Should().BeApproximately(0, 0.0001);
    }

    [Test]
    public void CalculateDistanceKmBetweenMoscowAndSaintPetersburgReturnsExpectedDistance()
    {
        var moscow = new GeoPoint(55.7558, 37.6173);
        var saintPetersburg = new GeoPoint(59.9311, 30.3609);

        var result = _distanceService.CalculateDistanceInKilometers(moscow, saintPetersburg);

        result.Should().BeApproximately(633, 2);
    }

    [Test]
    public void CalculateDistanceKmIsSymmetric()
    {
        var moscow = new GeoPoint(55.7558, 37.6173);
        var saintPetersburg = new GeoPoint(59.9311, 30.3609);

        var resultForward = _distanceService.CalculateDistanceInKilometers(moscow, saintPetersburg);
        var resultBackward = _distanceService.CalculateDistanceInKilometers(saintPetersburg, moscow);

        resultForward.Should().BeApproximately(resultBackward, 0.0001);
    }
}
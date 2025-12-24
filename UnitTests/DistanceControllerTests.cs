using CoffeemaniaGeographyService.Controllers;
using CoffeemaniaGeographyService.Dtos;
using CoffeemaniaGeographyService.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace UnitTests;

[TestFixture]
public class DistanceControllerTests
{
    [Test]
    public void PassingInvalidLatitudeThrownException()
    {
        var controller = new DistanceController(new Mock<IDistanceService>().Object);
        var validGeoPoint = new GeoPoint(55.7558, 37.6173);
        var invalidLatitudeGeoPoint = new GeoPoint(91, 37.6173);
        var request = new CalculateDistanceRequest { GeoPoint1 = validGeoPoint, GeoPoint2 = invalidLatitudeGeoPoint };

        var actionResult = controller.CalculateDistance(request);

        actionResult.Result.Should().BeOfType<BadRequestObjectResult>();
    }

    [Test]
    public void PassingInvalidLongitudeThrownException()
    {
        var controller = new DistanceController(new Mock<IDistanceService>().Object);
        var validGeoPoint = new GeoPoint(55.7558, 37.6173);
        var invalidLongitudeGeoPoint = new GeoPoint(55.7558, 181);
        var request = new CalculateDistanceRequest { GeoPoint1 = validGeoPoint, GeoPoint2 = invalidLongitudeGeoPoint };

        var actionResult = controller.CalculateDistance(request);

        actionResult.Result.Should().BeOfType<BadRequestObjectResult>();
    }

    [Test]
    public void ResultFromServiceReturned()
    {
        var moscow = new GeoPoint(55.7558, 37.6173);
        var saintPetersburg = new GeoPoint(59.9311, 30.3609);
        var serviceMock = new Mock<IDistanceService>();
        serviceMock.Setup(x => x.CalculateDistanceInKilometers(moscow, saintPetersburg))
            .Returns(633d);
        var controller = new DistanceController(serviceMock.Object);

        var actionResult = controller.CalculateDistance(new CalculateDistanceRequest
            { GeoPoint1 = moscow, GeoPoint2 = saintPetersburg });

        var okResult = actionResult.Result as OkObjectResult;
        okResult.Should().NotBeNull();
        var value = okResult.Value as CalculateDistanceResult;
        value.Should().NotBeNull();
        value.Distance.Should().Be(633d);
    }
}
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OSOS.Controllers;
using OSOS.Models;
using OSOS.Services.Interfaces;
using System;
using System.Collections.Generic;
using Xunit;

namespace OSOS.Test.Controllers
{
    public class TasksControllerTests
    {
        private readonly IPublicHolydayRepository _publicHolydayRepository;
        private readonly IWorkingDayStrategy _workingDayStrategy;
        public TasksControllerTests()
        {
            _publicHolydayRepository = A.Fake<IPublicHolydayRepository>();
            _workingDayStrategy = A.Fake<IWorkingDayStrategy>();
        }

        [Fact]
        public void TasksController_CalculateEndDate_ReturnOK()
        {
            // Arranges
            DateTime startDate = DateTime.Parse("2023/05/22");
            int estimateDate = 10;
            var publicHoliDays = A.Fake<List<PublicHoliday>>();
            var endDate = DateTime.Parse("2023/06/07");
            var controller = new TasksController(_publicHolydayRepository, _workingDayStrategy);

            A.CallTo(() => _publicHolydayRepository.AllPublicHolidays()).Returns(publicHoliDays);
            A.CallTo(() => _workingDayStrategy.CalculateEndDate(startDate, estimateDate, publicHoliDays)).Returns(endDate);

            // Act 
            var results = controller.CalculateEndDate(startDate, estimateDate);

            // Assert
            results.Should().NotBeNull();
            var okResults = results as OkObjectResult;
            okResults.StatusCode.Should().Be(StatusCodes.Status200OK);
            okResults.Value.Should().BeEquivalentTo(endDate);
        }
    }
}

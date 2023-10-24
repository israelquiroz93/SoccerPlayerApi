using Microsoft.AspNetCore.Mvc;
using Moq;
using SoccerPlayerApi.Controllers;
using SoccerPlayerApi.Data.Interfaces;
using SoccerPlayerApi.Models;
using FluentAssertions;
using System;

namespace SoccerPlayerAPITests
{
    [TestClass]
    public class SoccerPlayerTests
    {
        private readonly Mock<IPlayerRepository> _playerRepoMock = new Mock<IPlayerRepository>();
        Random random = new Random();

        [TestMethod]
        public async Task Get_WithExistingClients_ReturnsAllClients()
        {
            //Arrange
            var activelist = new List<Player>() { CreateRandomPlayer(), CreateRandomPlayer(), CreateRandomPlayer() };
            var faillist = new List<Player>() { CreateRandomPlayer()};
            _playerRepoMock.Setup(repo => repo.GetPlayers()).ReturnsAsync(activelist);

            var controller = new PlayersController(_playerRepoMock.Object);

            //Act

            var actualPlayers = await controller.GetPlayers();
            var players = actualPlayers as ObjectResult;


            //Assert
            players.Value.Should().BeEquivalentTo(
                activelist,
                options => options.ComparingByMembers<Player>()
            );
        }

        private Player CreateRandomPlayer()
        {
            return new Player()
            {
                PlayerId = random.Next(1000),
                Name = "Test",
                JerseyNumber = random.Next(1000),
                TeamId = random.Next(1000)
            };
        }
    }
}
using AplicationCore.Entities;
using AplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using TenisChallenge.WebApi.Controllers;
using TestPlayers.Repositories;

namespace TestPlayers
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            ITournamentService repositorioFalso = new RepoTest();
            var produController = new TennisCupController(repositorioFalso);

            // Act
            var respuesta = produController.GetPlayers().Result;

            // Assert
            Assert.AreEqual(4, ((respuesta as OkObjectResult).Value as List<Players>).Count());
        }
    }
}
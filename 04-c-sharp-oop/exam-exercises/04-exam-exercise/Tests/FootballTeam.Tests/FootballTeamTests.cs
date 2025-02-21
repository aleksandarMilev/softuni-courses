using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Xml.Serialization;

namespace FootballTeam.Tests
{
    public class FootballTeamTests
    {
        private FootballTeam team;

        [SetUp]
        public void Setup()
        {
            team = new FootballTeam("ManUtd", 15);
        }

        [Test]
        public void ConstructorShouldSetValuesProperly()
        {
            team = new FootballTeam("ManUtd", 20);

            Assert.IsNotNull(team);
            Assert.AreEqual("ManUtd", team.Name);
            Assert.AreEqual(20, team.Capacity);
            Assert.IsNotNull(team.Players);
        }

        [TestCase(null)]
        [TestCase("")]
        //[TestCase("    ")] WhiteSpace pass as valid input!!!
        public void NameSetterShouldThrowAnExceptionIfValueIsNullOrEmpty(string name)
        {
            Assert.Throws<ArgumentException>(()
                => team = new FootballTeam(name, 20));
        }

        [TestCase(null)]
        [TestCase("")]
        public void NameSetterExceptionShouldReturnTheCorrectMessage(string name)
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(()
                => team = new FootballTeam(name, 20));

            Assert.AreEqual("Name cannot be null or empty!", ex.Message);
        }

        [TestCase(14)]
        [TestCase(0)]
        [TestCase(-100_000)]
        public void CapacitySetterShouldThrowAnExceptionIfValueIsLessThan15(int capacity)
        {
            Assert.Throws<ArgumentException>(()
                => team = new FootballTeam("ManUtd", capacity));
        }

        [TestCase(14)]
        [TestCase(0)]
        [TestCase(-100_000)]
        public void CapacitySetterExceptionShouldReturnTheCorrectMessage(int capacity)
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(()
                => team = new FootballTeam("ManUnt", capacity));

            Assert.AreEqual("Capacity min value = 15", ex.Message);
        }

        [Test]
        public void AddNewPlayerShouldAddPlayerIfCapacityIsGreaterThanPlayersCount()
        {
            var player = new FootballPlayer("Berbatov", 9, "Forward");

            _ = team.AddNewPlayer(player);

            Assert.AreEqual(player, team.Players[0]);
        }

        [Test]
        public void AddNewPlayerShouldReturnTheCorrectMessageIfPlayerAddedSuccessfully()
        {
            var player = new FootballPlayer("Berbatov", 9, "Forward");

            Assert.AreEqual("Added player Berbatov in position Forward with number 9", team.AddNewPlayer(player));
        }

        [Test]
        public void AddNewPlayerShouldNotAddPlayerIfCapacityIsLessOrEqualToPlayersCount()
        {
            team.AddNewPlayer(new FootballPlayer("Berbatov", 9, "Forward"));
            team.AddNewPlayer(new FootballPlayer("player1", 9, "Forward"));
            team.AddNewPlayer(new FootballPlayer("player2", 9, "Forward"));
            team.AddNewPlayer(new FootballPlayer("player3", 9, "Forward"));
            team.AddNewPlayer(new FootballPlayer("player4", 9, "Forward"));
            team.AddNewPlayer(new FootballPlayer("player5", 9, "Forward"));
            team.AddNewPlayer(new FootballPlayer("player6", 9, "Forward"));
            team.AddNewPlayer(new FootballPlayer("player7", 9, "Forward"));
            team.AddNewPlayer(new FootballPlayer("player8", 9, "Forward"));
            team.AddNewPlayer(new FootballPlayer("player9", 9, "Forward"));
            team.AddNewPlayer(new FootballPlayer("player10", 9, "Forward"));
            team.AddNewPlayer(new FootballPlayer("player11", 9, "Forward"));
            team.AddNewPlayer(new FootballPlayer("player12", 9, "Forward"));
            team.AddNewPlayer(new FootballPlayer("player13", 9, "Forward"));
            team.AddNewPlayer(new FootballPlayer("player14", 9, "Forward"));
            team.AddNewPlayer(new FootballPlayer("player15", 9, "Forward"));

            var player16 = new FootballPlayer("player16", 9, "Forward");

            Assert.AreEqual("No more positions available!", team.AddNewPlayer(player16));
        }

        [Test]
        public void PickPlayerShouldReturnTheCorrectPlayer()
        {
            var berbatov = new FootballPlayer("Berbatov", 9, "Forward");

            team.AddNewPlayer(berbatov);
            team.AddNewPlayer(new FootballPlayer("player1", 9, "Forward"));
            team.AddNewPlayer(new FootballPlayer("player2", 9, "Forward"));

            Assert.AreEqual(berbatov, team.PickPlayer("Berbatov"));
        }

        [Test]
        public void PlayerScoreShouldReturnTheCorrectMessage()
        {
            var berbatov = new FootballPlayer("Berbatov", 9, "Forward");

            team.AddNewPlayer(berbatov);

            _ = team.PlayerScore(9);
            _ = team.PlayerScore(9);

            Assert.AreEqual($"Berbatov scored and now has 3 for this season!", team.PlayerScore(9));
        }
    }
}
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GamesCompLogic.Containers;
using GamesCompLogic.Classes;
using System.Linq;
using System;
using System.Collections.Generic;

namespace GamesCompTest
{
    [TestClass]
    public class TeamTest
    {
        [TestMethod]
        public void CreateTeam()
        {
            //arrange
            var Teamname = "Team1";
            List<Account> members = new List<Account>();
            //act
            var team = new Team(Teamname, members);
            //assert
            Assert.AreEqual(team.TeamName, Teamname, "Teamnames do not match");
            Assert.AreEqual(team._accounts, members, "Members do not match");
        }
    }
}

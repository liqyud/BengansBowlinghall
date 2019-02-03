using BengansBowlinghall.Builders;
using BengansBowlinghall.Directors;
using BengansBowlinghall.Factories;
using BengansBowlinghall.Managers;
using System;
using Xunit;

namespace BengansBowlinghallTest
{
    public class ResultManagerTests
    {
        // Singelton causes testing issues. Run every test individualy.
        [Fact]
        public void Year_Champion_Test()
        {
            var resultManager = ResultManager.Instance();
            var memberFactory = new MemberFactory(400);
            var member1 = memberFactory.CreateMember("Test", "Test street 1", true);
            var member2 = memberFactory.CreateMember("tester", "tester street 55", false);
            var matchDirector = new MatchDirector();
            var matchBuilder = new MatchBuilder(100);

            for (var i = 0; i < 10; i++)
            {
                matchDirector.Construct(matchBuilder, member1, member2);
                matchBuilder.GetResult().SetPlayerOneScore(50, 50, 50);
                matchBuilder.GetResult().SetPlayerTwoScore(100, 100, 100);
            }

            Assert.Equal(member2, resultManager.GetYearChampion(DateTime.Now));
        }

        [Fact]
        public void Year_Champion_Not_Enough_Matches_Test()
        {
            var resultManager = ResultManager.Instance();
            var memberFactory = new MemberFactory(400);
            var member1 = memberFactory.CreateMember("Test", "Test street 1", true);
            var member2 = memberFactory.CreateMember("tester", "tester street 55", true);
            var matchDirector = new MatchDirector();
            var matchBuilder = new MatchBuilder(100);

            for (var i = 0; i < 9; i++)
            {
                matchDirector.Construct(matchBuilder, member1, member2);
                matchBuilder.GetResult().SetPlayerOneScore(50, 50, 50);
                matchBuilder.GetResult().SetPlayerTwoScore(100, 100, 100);
            }

            Assert.Null(resultManager.GetYearChampion(DateTime.Now));
        }

        [Fact]
        public void Competition_Champion_Test()
        {
            var resultManager = ResultManager.Instance();
            var memberFactory = new MemberFactory(400);
            var member1 = memberFactory.CreateMember("Test", "Test street 1", true);
            var member2 = memberFactory.CreateMember("tester", "tester street 55", true);
            var competitionFactory = new CompetitionFactory();
            var testCompetition = competitionFactory.CreateCompetition("Test Cup", DateTime.Now, DateTime.Now.AddDays(7), 150);
            var matchDirector = new MatchDirector();
            var competitionMatchBuilder = new CompetitionMatchBuilder(testCompetition, 100);

            for (var i = 0; i < 10; i++)
            {
                matchDirector.Construct(competitionMatchBuilder, member1, member2);
                competitionMatchBuilder.GetResult().SetPlayerOneScore(50, 50, 50);
                competitionMatchBuilder.GetResult().SetPlayerTwoScore(100, 100, 100);
            }

            Assert.Equal(member2, resultManager.GetCompetitionResults(testCompetition));

        }

        [Fact]
        public void Competition_Champion_Not_Enough_Matches_Test()
        {
            var resultManager = ResultManager.Instance();
            var memberFactory = new MemberFactory(400);
            var member1 = memberFactory.CreateMember("Test", "Test street 1", true);
            var member2 = memberFactory.CreateMember("tester", "tester street 55", true);
            var competitionFactory = new CompetitionFactory();
            var testCompetition = competitionFactory.CreateCompetition("Test Cup", DateTime.Now, DateTime.Now.AddDays(7), 150);
            var matchDirector = new MatchDirector();
            var competitionMatchBuilder = new CompetitionMatchBuilder(testCompetition, 100);

            for (var i = 0; i < 9; i++)
            {
                matchDirector.Construct(competitionMatchBuilder, member1, member2);
                competitionMatchBuilder.GetResult().SetPlayerOneScore(50, 50, 50);
                competitionMatchBuilder.GetResult().SetPlayerTwoScore(100, 100, 100);
            }

            Assert.Null(resultManager.GetCompetitionResults(testCompetition));

        }
    }
}

using BengansBowlinghall.Builders;
using BengansBowlinghall.Directors;
using BengansBowlinghall.Factories;
using Xunit;

namespace BengansBowlinghallTest
{
    public class MatchTests
    {
        [Fact]
        public void Match_Test()
        {
            var memberFactory = new MemberFactory(400);
            var member1 = memberFactory.CreateMember("Test", "Test street 1", true);
            var member2 = memberFactory.CreateMember("tester", "tester street 55", true);
            var matchDirector = new MatchDirector();
            var matchBuilder = new MatchBuilder(100);
            matchDirector.Construct(matchBuilder, member1, member2);
            var testMatch = matchBuilder.GetResult();
            testMatch.SetPlayerOneScore(100, 100, 100);
            testMatch.SetPlayerTwoScore(0, 0, 0);

            Assert.Equal(member1, testMatch.GetWinner());
            Assert.Equal(member2, testMatch.GetLoser());
        }

        [Fact]
        public void  Match_Draw_Test()
        {
            var memberFactory = new MemberFactory(400);
            var member1 = memberFactory.CreateMember("Test", "Test street 1", true);
            var member2 = memberFactory.CreateMember("tester", "tester street 55", true);
            var matchDirector = new MatchDirector();
            var matchBuilder = new MatchBuilder(100);
            matchDirector.Construct(matchBuilder, member1, member2);
            var testMatch = matchBuilder.GetResult();
            testMatch.SetPlayerOneScore(100, 100, 100);
            testMatch.SetPlayerTwoScore(100, 100, 100);

            Assert.Null(testMatch.GetWinner());
            Assert.Null(testMatch.GetLoser());
        }
    }
}

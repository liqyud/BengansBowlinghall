using BengansBowlinghall.Factories;
using BengansBowlinghall.Managers;
using System.Linq;
using Xunit;

namespace BengansBowlinghallTest
{
    public class MemberTests
    {
        // Singelton causes testing issues. Run test individualy.
        [Fact]
        public void New_Member_Test()
        {
            var resultManager = ResultManager.Instance();
            resultManager.ResetForTesting();

            var memberFactory = new MemberFactory(400);
            var member = memberFactory.CreateMember("Test", "Test Street", true);

            Assert.Equal(member, resultManager.Members.SingleOrDefault());
        }
    }
}

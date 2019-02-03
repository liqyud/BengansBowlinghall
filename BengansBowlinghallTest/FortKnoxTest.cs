using BengansBowlinghall.Billing;
using BengansBowlinghall.Builders;
using BengansBowlinghall.Directors;
using BengansBowlinghall.Factories;
using BengansBowlinghall.Managers;
using System;
using System.Linq;
using Xunit;

namespace BengansBowlinghallTest
{
    // Singelton causes testing issues. Run test individualy.
    public class FortKnoxTest
    {
        [Fact]
        public void New_Member_Invoice_Test()
        {
            var fortKnox = FortKnox.Instance();
            var memberFactory = new MemberFactory(400);
            var member = memberFactory.CreateMember("Test1", "Test1", false);

            var invoices = fortKnox.ExportInvoices();
            var expectedInvoice = "Name: " + member.Name + " Address: " + member.Address + " Amount: " + 400;

            Assert.Single(invoices);
            Assert.Equal(expectedInvoice, invoices.Last());
        }

        [Fact]
        public void New_Member_No_Invoice_Test()
        {
            var resultManager = ResultManager.Instance();
            var fortKnox = FortKnox.Instance();
            const double membershipFee = 400;
            var memberFactory = new MemberFactory(membershipFee);
            var member = memberFactory.CreateMember("Test2", "Test2", true);

            Assert.Equal(member, resultManager.Members.Last());

            var invoices = fortKnox.ExportInvoices();

            Assert.Empty(invoices);
        }

        [Fact]
        public void Match_Invoice_Test()
        {
            var fortKnox = FortKnox.Instance();

            var invoices = fortKnox.ExportInvoices();
            Assert.Empty(invoices);

            var memberFactory = new MemberFactory(400);
            var member1 = memberFactory.CreateMember("Test1", "1", true);
            var member2 = memberFactory.CreateMember("Test2", "2", true);

            var matchDirector = new MatchDirector();
            var matchBuilder = new MatchBuilder(100);
            matchDirector.Construct(matchBuilder, member1, member2);

            var expectedInvoice1 = "Name: " + member1.Name + " Address: " + member1.Address + " Amount: " + 100;
            var expectedInvoice2 = "Name: " + member2.Name + " Address: " + member2.Address + " Amount: " + 100;

            invoices = fortKnox.ExportInvoices();

            Assert.Contains(expectedInvoice1, invoices);
            Assert.Contains(expectedInvoice2, invoices);


        }

        [Fact]
        public void Competition_Invoice_Test()
        {
            var fortKnox = FortKnox.Instance();

            var invoices = fortKnox.ExportInvoices();
            Assert.Empty(invoices);

            var memberFactory = new MemberFactory(400);
            var member1 = memberFactory.CreateMember("Test1", "1", true);
            var member2 = memberFactory.CreateMember("Test2", "2", true);

            var competitionFactory = new CompetitionFactory();
            var testCompetition = competitionFactory.CreateCompetition("Test Cup", DateTime.Now, DateTime.Now.AddDays(7), 150);

            var matchDirector = new MatchDirector();
            var competitionMatchBuilder = new CompetitionMatchBuilder(testCompetition, 100);
            matchDirector.Construct(competitionMatchBuilder, member1, member2);

            var expectedInvoice1 = "Name: " + member1.Name + " Address: " + member1.Address + " Amount: " + 100;
            var expectedInvoice2 = "Name: " + member2.Name + " Address: " + member2.Address + " Amount: " + 100;
            var expectedInvoice3 = "Name: " + member1.Name + " Address: " + member1.Address + " Amount: " + 150;
            var expectedInvoice4 = "Name: " + member2.Name + " Address: " + member2.Address + " Amount: " + 150;

            invoices = fortKnox.ExportInvoices();

            Assert.Contains(expectedInvoice1, invoices);
            Assert.Contains(expectedInvoice2, invoices);
            Assert.Contains(expectedInvoice1, invoices);
            Assert.Contains(expectedInvoice2, invoices);
        }
    }
}

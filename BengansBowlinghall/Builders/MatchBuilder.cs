using BengansBowlinghall.Billing;
using BengansBowlinghall.Interfaces;
using BengansBowlinghall.Managers;
using BengansBowlinghall.Models;

namespace BengansBowlinghall.Builders
{
    public class MatchBuilder : IBuilder
    {
        private Match _match;
        private readonly double _matchFee;

        public MatchBuilder(double matchFee)
        {
            _matchFee = matchFee;
        }

        public void CreateMatch(Member playerOne, Member playerTwo)
        {
            _match = new Match(playerOne, playerTwo);
            var resultManager = ResultManager.Instance();
            resultManager.Matches.Add(_match);
        }

        public void CreateInvoice(Member playerOne, Member playerTwo)
        {
            var fortKnox = FortKnox.Instance();
            fortKnox.NewInvoice(playerOne, _matchFee);
            fortKnox.NewInvoice(playerTwo, _matchFee);
        }

        public Match GetResult()
        {
            return _match;
        }
    }
}

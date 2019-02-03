using BengansBowlinghall.Billing;
using BengansBowlinghall.Interfaces;
using BengansBowlinghall.Managers;
using BengansBowlinghall.Models;

namespace BengansBowlinghall.Builders
{
    public class CompetitionMatchBuilder : IBuilder
    {
        private Match _match;
        private readonly Competition _competition;
        private readonly double _matchFee;

        public CompetitionMatchBuilder(Competition competition, double matchFee)
        {
            _competition = competition;
            _matchFee = matchFee;
        }


        public void CreateMatch(Member playerOne, Member playerTwo)
        {
            _match = new Match(playerOne, playerTwo);

            _competition.AddMatch(_match);

            var resultManager = ResultManager.Instance();
            resultManager.Matches.Add(_match);
        }

        public void CreateInvoice(Member playerOne, Member playerTwo)
        {
            var fortKnox = FortKnox.Instance();

            if (!_competition.IsParticipant(playerOne))
            {
                fortKnox.NewInvoice(playerOne, _competition.Fee);
                _competition.AddParticipant(playerOne);
            }
            if (!_competition.IsParticipant(playerTwo))
            {
                fortKnox.NewInvoice(playerTwo, _competition.Fee);
                _competition.AddParticipant(playerTwo);
            }

            fortKnox.NewInvoice(playerOne, _matchFee);
            fortKnox.NewInvoice(playerTwo, _matchFee);
        }

        public Match GetResult()
        {
            return _match;
        }
    }
}

using BengansBowlinghall.Models;
using System;
using BengansBowlinghall.Managers;

namespace BengansBowlinghall.Factories
{
    public class CompetitionFactory
    {
        private Competition _competition;

        public Competition CreateCompetition(string name, DateTime startDate, DateTime endDate, double competitionFee)
        {
            _competition = new Competition(name, startDate, endDate, competitionFee);

            var resultManager = ResultManager.Instance();
            resultManager.Competitions.Add(_competition);

            return _competition;
        }
    }
}

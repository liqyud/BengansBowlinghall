using System;
using System.Collections.Generic;
using System.Linq;
using BengansBowlinghall.Models;

namespace BengansBowlinghall.Managers
{
    public class ResultManager
    {
        private static ResultManager _instance;
        public List<Member> Members { get; set; }
        public List<Match> Matches { get; set; }
        public List<Competition> Competitions { get; set; }

        public ResultManager()
        {
            Members = new List<Member>();
            Matches = new List<Match>();
            Competitions = new List<Competition>();
        }

        public static ResultManager Instance()
        {
            return _instance ?? (_instance = new ResultManager());
        }

        public Member GetCompetitionResults(Competition competition)
        {
            Console.WriteLine("Competition results for: " + competition.Name);
            foreach (var match in competition.Matches)
            {
                var winner = competition.Participants.FirstOrDefault(p => p.Member == match.GetWinner());
                winner?.AddWin();
                var loser = competition.Participants.FirstOrDefault(p => p.Member == match.GetLoser());
                loser?.AddLoss();
            }

            var eligible = competition.Participants.Where(p => p.Qualifies()).ToList();
            if (!eligible.Any())
            {
                Console.WriteLine("No participants with 10 or more games.");
                return null;
            }

            var champion = eligible.FirstOrDefault();
            foreach (var participant in eligible)
            {
                if (participant.WinRate() > champion.WinRate())
                {
                    champion = participant;
                }
            }
            Console.WriteLine("Winner: " + champion.Member.Name);
            return champion.Member;
        }

        public Member GetYearChampion(DateTime date)
        {
            Console.WriteLine("Getting year champion for year: " + date.Year);
            var participants = new List<Participant>();
            foreach (var member in Members)
            {
                participants.Add(new Participant(member));
            }

            var relevantMatches = Matches.Where(g => g.Date.Year == date.Year).ToList();
            foreach (var match in relevantMatches)
            {
                var winner = participants.FirstOrDefault(p => p.Member == match.GetWinner());
                winner?.AddWin();
                var loser = participants.FirstOrDefault(p => p.Member == match.GetLoser());
                loser?.AddLoss();
            }

            var eligible = participants.Where(p => p.Qualifies()).ToList();
            if (!eligible.Any())
            {
                Console.WriteLine("No players eligible.");
                return null;

            }

            var champion = eligible.FirstOrDefault();
            foreach (var participant in eligible)
            {
                if (participant.WinRate() > champion.WinRate())
                {
                    champion = participant;
                }
            }
            Console.WriteLine("Champion: " + champion.Member.Name);
            return champion.Member;
        }

        public void ResetForTesting()
        {
            Members.Clear();
            Matches.Clear();
            Competitions.Clear();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace BengansBowlinghall.Models
{
    public class Competition
    {
        public string Name { get; set; }
        public double Fee { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public List<Match> Matches = new List<Match>();
        public List<Participant> Participants = new List<Participant>();

        public Competition(string name, DateTime startDate, DateTime endDate, double fee)
        {
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
            Fee = fee;
        }

        public void AddParticipant(Member member)
        {
            Participants.Add(new Participant(member));
        }

        public void AddMatch(Match match)
        {
            Matches.Add(match);
        }

        public bool IsParticipant(Member member)
        {
            return Participants.Any(p => p.Member == member);
        }
    }
}

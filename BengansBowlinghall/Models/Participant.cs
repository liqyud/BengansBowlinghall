namespace BengansBowlinghall.Models
{
    public class Participant
    {
        public Member Member { get; }
        private double _wins;
        private double _losses;

        public Participant(Member member)
        {
            Member = member;
            _wins = 0;
            _losses = 0;
        }

        public void AddWin()
        {
            _wins = _wins + 1;
        }
        public void AddLoss()
        {
            _losses = _losses + 1;
        }

        public bool Qualifies()
        {
            return _wins + _losses >= 10;
        }

        public double WinRate()
        {
            if (_wins + _losses >= 10)
                return _wins / (_wins + _losses);
            return 0;
        }
    }
}

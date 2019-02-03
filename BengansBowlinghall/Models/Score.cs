namespace BengansBowlinghall.Models
{
    public class Score
    {
        public double SetOne { get; set; }
        public double SetTwo { get; set; }
        public double SetThree { get; set; }

        public double GetTotalScore()
        {
            return SetOne + SetTwo + SetThree;
        }
    }
}

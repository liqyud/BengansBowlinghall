using System;

namespace BengansBowlinghall.Models
{
    public class Match
    {
        public Member PlayerOne { get; set; }
        public Member PlayerTwo { get; set; }
        public DateTime Date { get; set; }
        private Score PlayerOneScore { get; set; }
        private Score PlayerTwoScore { get; set; }

        public Match(Member playerOne, Member playerTwo)
        {
            Date = DateTime.Now;
            PlayerOne = playerOne;
            PlayerTwo = playerTwo;
            PlayerOneScore = new Score();
            PlayerTwoScore = new Score();
            Console.WriteLine("Created a new Match. Player One: " + PlayerOne.Name + " Player Two: " + PlayerTwo.Name);
        }

        public void SetPlayerOneScore(double setOne, double setTwo, double setThree)
        {
            PlayerOneScore.SetOne = setOne;
            PlayerOneScore.SetTwo = setTwo;
            PlayerOneScore.SetThree = setThree;
            Console.WriteLine("Player One's Score: " + setOne + ", " + setTwo + ", " + setThree + " Totals:" + PlayerOneScore.GetTotalScore());
        }

        public void SetPlayerTwoScore(double setOne, double setTwo, double setThree)
        {
            PlayerTwoScore.SetOne = setOne;
            PlayerTwoScore.SetTwo = setTwo;
            PlayerTwoScore.SetThree = setThree;
            Console.WriteLine("Player Two's Score: " + setOne + ", " + setTwo + ", " + setThree + " Totals:" + PlayerTwoScore.GetTotalScore());
        }

        public void GeneratePlayerScores()
        {
            var random = new Random();
            PlayerOneScore.SetOne = random.Next(0, 101);
            PlayerOneScore.SetTwo = random.Next(0, 101);
            PlayerOneScore.SetThree = random.Next(0, 101);
            PlayerTwoScore.SetOne = random.Next(0, 101);
            PlayerTwoScore.SetTwo = random.Next(0, 101);
            PlayerTwoScore.SetThree = random.Next(0, 101);
            Console.WriteLine("Player One Score Generated: " + PlayerOneScore.SetOne + ", " + PlayerOneScore.SetTwo + ", " + PlayerOneScore.SetThree + " Totals:" + PlayerOneScore.GetTotalScore());
            Console.WriteLine("Player Two Score Generated: " + PlayerTwoScore.SetOne + ", " + PlayerTwoScore.SetTwo + ", " + PlayerTwoScore.SetThree + " Totals:" + PlayerTwoScore.GetTotalScore());
            if (GetWinner() != null)
                Console.WriteLine("Winner: " + GetWinner().Name);
            else
                Console.WriteLine("Draw");
        }

        public Member GetWinner()
        {
            if (PlayerOneScore.GetTotalScore() > PlayerTwoScore.GetTotalScore())
                return PlayerOne;
            return PlayerOneScore.GetTotalScore() < PlayerTwoScore.GetTotalScore() ? PlayerTwo : null;
        }

        public Member GetLoser()
        {
            if (PlayerOneScore.GetTotalScore() < PlayerTwoScore.GetTotalScore())
                return PlayerOne;
            return PlayerOneScore.GetTotalScore() > PlayerTwoScore.GetTotalScore() ? PlayerTwo : null;
        }
    }
}
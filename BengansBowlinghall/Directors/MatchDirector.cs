using BengansBowlinghall.Interfaces;
using BengansBowlinghall.Models;

namespace BengansBowlinghall.Directors
{
    public class MatchDirector
    {
        public void Construct(IBuilder builder, Member playerOne, Member playerTwo)
        {
            builder.CreateMatch(playerOne, playerTwo);
            builder.CreateInvoice(playerOne, playerTwo);
        }
    }
}

using BengansBowlinghall.Models;

namespace BengansBowlinghall.Interfaces
{
    public interface IBuilder
    {
        void CreateMatch(Member playerOne, Member playerTwo);
        void CreateInvoice(Member playerOne, Member playerTwo);
        Match GetResult();
    }
}

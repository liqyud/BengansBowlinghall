using BengansBowlinghall.Models;

namespace BengansBowlinghall.Billing
{
    public class Invoice
    {
        private readonly Member _member;
        private readonly double _amount;

        public Invoice(Member member, double amount)
        {
            _member = member;
            _amount = amount;
        }

        public override string ToString()
        {
            return "Name: " + _member.Name + " Address: " + _member.Address + " Amount: " + _amount;
        }
    }
}

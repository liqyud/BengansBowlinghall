using BengansBowlinghall.Billing;

namespace BengansBowlinghall.Models
{
    public class Member
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public bool PaidMembership { get; set; }

        public Member(string name, string address, bool paidMembership)
        {
            Name = name;
            Address = address;
            PaidMembership = paidMembership;

            if (!paidMembership)
            {
                var fortKnox = FortKnox.Instance();
            }
        }
    }
}
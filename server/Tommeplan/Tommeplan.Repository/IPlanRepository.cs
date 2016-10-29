using System.Collections.Generic;
using System.Threading.Tasks;
using Tommeplan.Domene;

namespace Tommeplan.Repository
{
    public interface IPlanRepository
    {
        Plan GetPlan(Address address);
        Task<IEnumerable<Address>> GetAddresses(string text, string city);
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using Tommeplan.Domene;

namespace Tommeplan.Repository
{
    public interface IPlanRepository
    {
        Plan GetPlan(Address address);
        Task<IEnumerable<Address>> GetAddressesAsync(string text);
        IEnumerable<Address> GetAddresses(string text);
    }
}

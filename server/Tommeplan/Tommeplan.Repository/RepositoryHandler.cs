using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tommeplan.Domene;

namespace Tommeplan.Repository
{
    public class RepositoryHandler
    {
        private readonly Dictionary<string, IPlanRepository> _repositoryDictionary;
        
        public RepositoryHandler(Dictionary<string, IPlanRepository> repositoryDictionary)
        {
            if(repositoryDictionary == null || repositoryDictionary.Count == 0)
            {
                throw new Exception("At least one repository must exist.");
            }

            _repositoryDictionary = repositoryDictionary;
        }

        public IEnumerable<Address> GetAddresses(string text)
        {
            var addressTasks =
                _repositoryDictionary
                    .Select(x => x.Value.GetAddresses(text, x.Key))
                    .ToList();
            addressTasks.ForEach(x => x.Start());
            Task.WaitAll(addressTasks.ToArray());

            return addressTasks.SelectMany(x => x.Result);
        }

        public Plan GetPlan(Address address)
        {
            if(address == null)
            {
                throw new ArgumentException("Unable to find plan with no address");
            }
            return 
                _repositoryDictionary[address.City]
                    .GetPlan(address);
        }
    }
}

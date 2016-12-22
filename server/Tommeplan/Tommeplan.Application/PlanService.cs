using System;
using System.Collections.Generic;
using System.Linq;
using Tommeplan.Domene;
using Tommeplan.Repository;

namespace Tommeplan.Application
{
    public class PlanService
    {
        private readonly Dictionary<string, IPlanRepository> _repositoryDictionary;

        public PlanService(Dictionary<string, IPlanRepository> repositoryDictionary)
        {
            if (repositoryDictionary == null || repositoryDictionary.Count == 0)
            {
                throw new Exception("At least one repository must exist.");
            }

            _repositoryDictionary = repositoryDictionary;
        }

        public IEnumerable<Address> GetAddresses(string address)
        {
            var addressTasks =
                _repositoryDictionary
                    .Select(x =>
                    {
                        var task = x.Value.GetAddresses(address);
                        return task;
                    })
                    .ToArray();

            return addressTasks.SelectMany(x => x);
        }

        public Plan GetPlan(Address address)
        {
            if (address == null)
            {
                throw new ArgumentException("Unable to find plan with no address");
            }
            return
                _repositoryDictionary[address.City]
                    .GetPlan(address);
        }
    }
}

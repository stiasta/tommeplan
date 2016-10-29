using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tommeplan.Domene;
using Tommeplan.Repository;

namespace Tommeplan.Controllers
{
    public class AddressController : ApiController
    {
        private RepositoryHandler _repository;

        public AddressController(RepositoryHandler repository)
        {
            _repository = repository;
        }

        public IEnumerable<Address> Get(string searchstring)
        {
            return _repository.GetAddresses(searchstring);
        }
    }
}

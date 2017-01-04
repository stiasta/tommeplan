using System.Collections.Generic;
using System.Web.Http;
using Tommeplan.Application;
using Tommeplan.Domene;

namespace Tommeplan.Controllers
{
    public class AddressController : ApiController
    {
        private PlanService _service;

        public AddressController(PlanService service)
        {
            _service = service;
        }

        public IEnumerable<Address> Get(string searchstring)
        {
            return _service.GetAddresses(searchstring);
        }
    }
}

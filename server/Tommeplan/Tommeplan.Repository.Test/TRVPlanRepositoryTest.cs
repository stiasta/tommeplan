using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tommeplan.Repository;
using Tommeplan.Domene;
namespace Tommeplan.Repository.Test
{
    public class TRVPlanRepositoryTest
    {
        [TestFixture]
        public class GetAddresses
        {
            [Test]
            public void WithEmptyText_ShouldReturnEmptyCollection()
            {
                var repository = new TRVPlanRepository();

                Assert.AreEqual(
                    0, 
                    repository
                        .GetAddressesAsync(string.Empty)
                        .Result
                        .Count());
            }

            [Test, Explicit]
            public void WithBlåklokkev_ShouldReturnBlåklokkevegen()
            {
                var repository = new TRVPlanRepository();

                var result =
                    repository
                        .GetAddressesAsync("Blåklokkev")
                        .Result;
                
                Assert.True(result.Any(x => x.Road.Equals("Blåklokkevegen")));
            }
        }

        [TestFixture]
        public class GetPlan
        {
            [Test]
            public void WithoutAddress_ShouldThrowException()
            {
                var repository = new TRVPlanRepository();
                Assert.Throws<ArgumentNullException>(() => repository.GetPlan(null));
            }

            [Test]
            [Explicit]
            public void WithAddressForBlåklokkevegen_ShouldReturnForBlåklokkevegen()
            {
                var repository = new TRVPlanRepository();
                var plan = repository.GetPlan(new Address("Blåklokkevegen", "Trondheim", "108"));
                Assert.NotNull(plan);
            }
        }
    }
}

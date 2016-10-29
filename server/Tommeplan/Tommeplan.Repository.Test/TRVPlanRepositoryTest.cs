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
                        .GetAddresses(string.Empty, string.Empty)
                        .Result
                        .Count());
            }

            [Test, Explicit]
            public void WithBlåklokkev_ShouldReturnBlåklokkevegen()
            {
                var repository = new TRVPlanRepository();

                var result =
                    repository
                        .GetAddresses("Blåklokkev", "Trondheim")
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
        }
    }
}

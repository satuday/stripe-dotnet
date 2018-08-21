namespace StripeTests
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Stripe;
    using Stripe.Infrastructure;
    using Xunit;

    public class PlanCreateOptionsTest : BaseStripeTest
    {
        private PlanService service;

        public PlanCreateOptionsTest()
        {
            this.service = new PlanService();
        }

        [Fact]
        public void SerializeTiersProperly()
        {
            var options = new PlanCreateOptions
            {
                Tiers = new List<PlanTierOptions>
                {
                    new PlanTierOptions
                    {
                        Amount = 1000,
                        UpTo = new PlanTierOptions.UpToBound
                        {
                            Bound = 10
                        }
                    },
                    new PlanTierOptions
                    {
                        Amount = 2000,
                        UpTo = new PlanTierOptions.UpToInf()
                    }
                },
            };

            var url = this.service.ApplyAllParameters(options, string.Empty, false);
            Assert.Equal("?tiers[0][amount]=1000&tiers[0][up_to]=10&tiers[1][amount]=2000&tiers[1][up_to]=inf", url);
        }
    }
}

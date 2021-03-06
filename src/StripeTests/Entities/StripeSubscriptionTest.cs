namespace StripeTests
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Newtonsoft.Json;
    using Stripe;
    using Xunit;

    public class StripeSubscriptionTest : BaseStripeTest
    {
        [Fact]
        public void Deserialize()
        {
            string json = GetFixture("/v1/subscriptions/sub_123");
            var subscription = Mapper<StripeSubscription>.MapFromJson(json);
            Assert.NotNull(subscription);
            Assert.IsType<StripeSubscription>(subscription);
            Assert.NotNull(subscription.Id);
            Assert.Equal("subscription", subscription.Object);
        }

        [Fact]
        public void DeserializeWithExpansions()
        {
            string[] expansions =
            {
              "customer",
            };

            string json = GetFixture("/v1/subscriptions/sub_123", expansions);
            var subscription = Mapper<StripeSubscription>.MapFromJson(json);
            Assert.NotNull(subscription);
            Assert.IsType<StripeSubscription>(subscription);
            Assert.NotNull(subscription.Id);
            Assert.Equal("subscription", subscription.Object);

            Assert.NotNull(subscription.Customer);
            Assert.Equal("customer", subscription.Customer.Object);
        }
    }
}

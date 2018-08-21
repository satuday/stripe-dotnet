namespace StripeTests
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Stripe;
    using Xunit;

    public class SourceServiceTest : BaseStripeTest
    {
        private const string SourceId = "src_123";

        private SourceService service;
        private SourceCreateOptions createOptions;
        private SourceUpdateOptions updateOptions;
        private SourceListOptions listOptions;

        public SourceServiceTest()
        {
            this.service = new SourceService();

            this.createOptions = new SourceCreateOptions
            {
                Type = StripeSourceType.AchCreditTransfer,
                Currency = "usd"
            };

            this.updateOptions = new SourceUpdateOptions
            {
                Metadata = new Dictionary<string, string>()
                {
                    { "key", "value" },
                },
            };

            this.listOptions = new SourceListOptions()
            {
                Limit = 1,
            };
        }

        [Fact]
        public void Create()
        {
            var source = this.service.Create(this.createOptions);
            Assert.NotNull(source);
            Assert.Equal("source", source.Object);
        }
    }
}

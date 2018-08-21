namespace StripeTests
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Stripe;
    using Stripe.Infrastructure;
    using Xunit;

    public class AccountCreateOptionsTest : BaseStripeTest
    {
        private AccountService service;

        public AccountCreateOptionsTest()
        {
            this.service = new AccountService();
        }

        [Fact]
        public void SerializeAdditionalOwnersProperly()
        {
            var options = new AccountCreateOptions
            {
                LegalEntity = new AccountLegalEntityOptions
                {
                    AdditionalOwners = new List<AccountAdditionalOwner>()
                },
            };

            var url = this.service.ApplyAllParameters(options, string.Empty, false);
            Assert.Equal("?legal_entity[additional_owners]=", url);
        }
    }
}

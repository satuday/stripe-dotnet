using FluentAssertions;
using Xunit;

namespace Stripe.Tests.Xunit
{
    public class creating_and_updating_payment_intents : IClassFixture<payment_intents_fixture>
    {
        private readonly payment_intents_fixture fixture;

        public creating_and_updating_payment_intents(payment_intents_fixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public void created_has_the_right_information()
        {
            fixture.PaymentIntent.Should().NotBeNull();
            fixture.PaymentIntent.Amount.Should().Be(fixture.PaymentIntentCreateOptions.Amount);
            fixture.PaymentIntent.CaptureMethod.Should().Be(fixture.PaymentIntentCreateOptions.CaptureMethod);
            fixture.PaymentIntent.Currency.Should().Be(fixture.PaymentIntentCreateOptions.Currency);
            fixture.PaymentIntent.AllowedSourceTypes.Count.Should().Be(fixture.PaymentIntentCreateOptions.AllowedSourceTypes.Count);
        }

        [Fact]
        public void retrieved_has_the_right_information()
        {
            fixture.PaymentIntentRetrieved.Should().NotBeNull();
            fixture.PaymentIntentRetrieved.Amount.Should().Be(fixture.PaymentIntentUpdateOptions.Amount);
            fixture.PaymentIntentRetrieved.Currency.Should().Be(fixture.PaymentIntentUpdateOptions.Currency);
            fixture.PaymentIntentRetrieved.AllowedSourceTypes.Count.Should().Be(fixture.PaymentIntent.AllowedSourceTypes.Count);
        }

        [Fact]
        public void updated_has_the_right_information()
        {
            fixture.PaymentIntentUpdated.Should().NotBeNull();
            fixture.PaymentIntentUpdated.Amount.Should().Be(fixture.PaymentIntentUpdateOptions.Amount);
            fixture.PaymentIntentUpdated.Currency.Should().Be(fixture.PaymentIntentUpdateOptions.Currency);
            fixture.PaymentIntentUpdated.Metadata.Keys.Should().BeEquivalentTo(fixture.PaymentIntentUpdateOptions.Metadata.Keys);
        }

        [Fact]
        public void confirmed_has_the_right_information()
        {
            fixture.PaymentIntentConfirmed.Should().NotBeNull();
            fixture.PaymentIntentConfirmed.Charges.Data.Count.Should().Be(1);
            fixture.PaymentIntentConfirmed.AmountCapturable.Should().Be(fixture.PaymentIntentRetrieved.Amount);
            fixture.PaymentIntentConfirmed.AmountReceived.Should().Be(0);
            fixture.PaymentIntentConfirmed.Status.Should().Be("requires_capture");
        }

        [Fact]
        public void captured_has_the_right_information()
        {
            fixture.PaymentIntentCaptured.Should().NotBeNull();
            fixture.PaymentIntentCaptured.Charges.Data.Count.Should().Be(1);
            fixture.PaymentIntentCaptured.AmountReceived.Should().Be(fixture.PaymentIntentCaptureOptions.Amount);
            fixture.PaymentIntentCaptured.Status.Should().Be("succeeded");
        }

        [Fact]
        public void canceled_has_the_right_information()
        {
            fixture.PaymentIntentCanceled.Should().NotBeNull();
            fixture.PaymentIntentCanceled.Status.Should().Be("canceled");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace Stripe.Tests.Xunit
{
    public class payment_intents_fixture
    {
        public StripePaymentIntentCreateOptions PaymentIntentCreateOptions { get; }
        public StripePaymentIntentUpdateOptions PaymentIntentUpdateOptions { get; }
        public StripePaymentIntentCaptureOptions PaymentIntentCaptureOptions { get; }
        public StripePaymentIntentListOptions PaymentIntentListOptions { get; }

        public StripePaymentIntent PaymentIntent { get; }
        public StripePaymentIntent PaymentIntentUpdated { get; }
        public StripePaymentIntent PaymentIntentRetrieved { get; }
        public StripePaymentIntent PaymentIntentCanceled { get; }
        public StripePaymentIntent PaymentIntentCaptured { get; }
        public StripePaymentIntent PaymentIntentConfirmed { get; }
        public StripePaymentIntent PaymentIntentWithSourceAction { get; }
        public StripeList<StripePaymentIntent> PaymentIntentList { get; }

        public payment_intents_fixture()
        {
            PaymentIntentCreateOptions = new StripePaymentIntentCreateOptions
            {
                AllowedSourceTypes = new List<string>()
                {
                    "card",
                },
                Amount = 1000,
                CaptureMethod = "manual",
                Currency = "usd",
                Description = "Normal card, no source_next_action",
            };

            PaymentIntentUpdateOptions = new StripePaymentIntentUpdateOptions
            {
                Amount = 1234,
                Currency = "eur",
                Metadata = new Dictionary<string, string>()
                {
                    { "some-key", "some-value" }
                }
            };

            var service = new StripePaymentIntentService(Cache.ApiKey);
            PaymentIntent = service.Create(PaymentIntentCreateOptions);
            PaymentIntentUpdated = service.Update(PaymentIntent.Id, PaymentIntentUpdateOptions);
            PaymentIntentRetrieved = service.Get(PaymentIntent.Id);

            var sourceService = new StripeSourceService(Cache.ApiKey);
            var source = sourceService.Create(new StripeSourceCreateOptions
            {
                Type = StripeSourceType.Card,
                Usage = StripeSourceUsage.Reusable,
                Token = "tok_visa",
            });

            PaymentIntentConfirmed = service.Confirm(
                PaymentIntent.Id,
                new StripePaymentIntentConfirmOptions
                {
                    SourceId = source.Id,
                }
            );

            PaymentIntentCaptureOptions = new StripePaymentIntentCaptureOptions
            {
                Amount = 500,
            };
            PaymentIntentCaptured = service.Capture(PaymentIntent.Id, PaymentIntentCaptureOptions);


            var sourceRequires3DS = sourceService.Create(new StripeSourceCreateOptions
            {
                Type = StripeSourceType.Card,
                Amount = 1234,
                Currency = "eur",
                Card = new StripeCreditCardOptions
                {
                    // Using PAN as we don't have a 3DS test token yet
                    Number = "4000000000003063",
                    ExpirationMonth = 12,
                    ExpirationYear = 2020
                }
            });

            var intent = service.Create(PaymentIntentCreateOptions);
            PaymentIntentWithSourceAction = service.Confirm(
                intent.Id,
                new StripePaymentIntentConfirmOptions
                {
                    SourceId = sourceRequires3DS.Id,
                }
            );

            PaymentIntentCanceled = service.Cancel(PaymentIntentWithSourceAction.Id, new StripePaymentIntentCancelOptions());

            PaymentIntentListOptions = new StripePaymentIntentListOptions{};
            PaymentIntentList = service.List(PaymentIntentListOptions);
        }
    }
}

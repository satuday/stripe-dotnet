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

            var options = new StripeSourceCreateOptions
            {
                Type = StripeSourceType.Card,
                Usage = StripeSourceUsage.Reusable,
                Token = "tok_visa",
            };

            var source = new StripeSourceService(Cache.ApiKey).Create(options);

            var confirmOptions = new StripePaymentIntentConfirmOptions
            {
                SourceId = source.Id,
            };
            PaymentIntentConfirmed = service.Confirm(PaymentIntent.Id, confirmOptions);


            PaymentIntentCaptureOptions = new StripePaymentIntentCaptureOptions
            {
                Amount = 500,
            };
            PaymentIntentCaptured = service.Capture(PaymentIntent.Id, PaymentIntentCaptureOptions);


            var intentToCancel = service.Create(PaymentIntentCreateOptions);
            PaymentIntentCanceled = service.Cancel(intentToCancel.Id, new StripePaymentIntentCancelOptions());

            PaymentIntentListOptions = new StripePaymentIntentListOptions{};
            PaymentIntentList = service.List(PaymentIntentListOptions);
        }
    }
}

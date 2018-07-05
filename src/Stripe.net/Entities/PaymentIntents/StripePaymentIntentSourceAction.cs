using Newtonsoft.Json;
using Stripe.Infrastructure;

namespace Stripe
{
    public enum StripePaymentIntentSourceActionType
    {
        AuthorizeWithUrl,
        None,
        Unknown,
    }

    [JsonConverter(typeof(PaymentIntentSourceActionConverter))]
    public class StripePaymentIntentSourceAction : StripeEntity
    {
        public StripePaymentIntentSourceActionType Type { get; set; }

        public StripePaymentIntentSourceActionAuthorizeWithUrl AuthorizeWithUrl { get; set; }
    }
}

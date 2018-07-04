using System.Collections.Generic;
using Newtonsoft.Json;

namespace Stripe
{
    public class StripePaymentIntentCaptureOptions : StripeBaseOptions
    {
        [JsonProperty("amount")]
        public int? Amount { get; set; }
    }
}

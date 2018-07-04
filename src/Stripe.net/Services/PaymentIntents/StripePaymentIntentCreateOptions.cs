using System.Collections.Generic;
using Newtonsoft.Json;

namespace Stripe
{
    public class StripePaymentIntentCreateOptions : StripePaymentIntentSharedOptions
    {
        [JsonProperty("allowed_source_types_array")]
        public List<string> AllowedSourceTypes { get; set; }

        [JsonProperty("attempt_confirmation")]
        public bool? AttemptConfirmation { get; set; }

        [JsonProperty("capture_method")]
        public string CaptureMethod { get; set; }

        [JsonProperty("on_behalf_of")]
        public string OnBehalfOf { get; set; }

        [JsonProperty("return_url")]
        public string ReturnUrl { get; set; }

        [JsonProperty("shipping")]
        public StripeChargeShippingOptions Shipping { get; set; }

        [JsonProperty("statement_descriptor")]
        public string StatementDescriptor { get; set; }
    }
}

using System.Collections.Generic;
using Newtonsoft.Json;

namespace Stripe
{
    public class StripePaymentIntentSharedOptions : StripeBaseOptions, ISupportMetadata
    {
        [JsonProperty("amount")]
        public int? Amount { get; set; }

        [JsonProperty("application_fee")]
        public int? ApplicationFee { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("customer")]
        public string CustomerId { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("metadata")]
        public Dictionary<string, string> Metadata { get; set; }

        [JsonProperty("receipt_email")]
        public string ReceiptEmail { get; set; }

        [JsonProperty("save_source_to_customer")]
        public bool? SaveSourceToCustomer { get; set; }

        [JsonProperty("source")]
        public string SourceId { get; set; }

        [JsonProperty("transfer_data")]
        public StripePaymentIntentTransferDataOptions TransferData { get; set; }

        [JsonProperty("transfer_group")]
        public string TransferGroup { get; set; }
    }
}

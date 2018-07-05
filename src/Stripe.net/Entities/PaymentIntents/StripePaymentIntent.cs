using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Stripe.Infrastructure;

namespace Stripe
{
    public class StripePaymentIntent : StripeEntityWithId, ISupportMetadata
    {
        [JsonProperty("object")]
        public string Object { get; set; }

        [JsonProperty("allowed_source_types")]
        public List<string> AllowedSourceTypes { get; set; }

        [JsonProperty("amount")]
        public int? Amount { get; set; }

        [JsonProperty("amount_capturable")]
        public int? AmountCapturable { get; set; }

        [JsonProperty("amount_received")]
        public int? AmountReceived { get; set; }

        #region Expandable Application
        public string ApplicationId { get; set; }

        [JsonIgnore]
        public StripeApplication Application { get; set; }

        [JsonProperty("application")]
        internal object InternalApplication
        {
            set
            {
                StringOrObject<StripeApplication>.Map(value, s => ApplicationId = s, o => Application = o);
            }
        }
        #endregion

        [JsonProperty("application_fee")]
        public int? ApplicationFee { get; set; }

        [JsonProperty("canceled_at")]
        [JsonConverter(typeof(StripeDateTimeConverter))]
        public DateTime? CanceledAt { get; set; }

        [JsonProperty("capture_method")]
        public string CaptureMethod { get; set; }

        [JsonProperty("charges")]
        public StripeList<StripeCharge> Charges { get; set; }

        [JsonProperty("client_secret")]
        public string ClientSecret { get; set; }

        [JsonProperty("confirmation_method")]
        public string ConfirmationMethod { get; set; }

        [JsonProperty("created")]
        [JsonConverter(typeof(StripeDateTimeConverter))]
        public DateTime? Created { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        #region Expandable Customer
        public string CustomerId { get; set; }

        [JsonIgnore]
        public StripeCustomer Customer { get; set; }

        [JsonProperty("customer")]
        internal object InternalCustomer
        {
            set
            {
                StringOrObject<StripeCustomer>.Map(value, s => CustomerId = s, o => Customer = o);
            }
        }
        #endregion

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("livemode")]
        public bool LiveMode { get; set; }

        [JsonProperty("metadata")]
        public Dictionary<string, string> Metadata { get; set; }


        [JsonProperty("next_source_action")]
        public StripePaymentIntentSourceAction NextSourceAction { get; set; }

        #region Expandable OnBehalfOf (Account)
        public string OnBehalfOfId { get; set; }

        [JsonIgnore]
        public StripeAccount OnBehalfOf { get; set; }

        [JsonProperty("on_behalf_of")]
        internal object InternalOnBehalfOf
        {
            set
            {
                StringOrObject<StripeAccount>.Map(value, s => OnBehalfOfId = s, o => OnBehalfOf = o);
            }
        }
        #endregion

        [JsonProperty("receipt_email")]
        public string ReceiptEmail { get; set; }

        [JsonProperty("return_url")]
        public string ReturnUrl { get; set; }

        [JsonProperty("shipping")]
        public StripeShipping Shipping { get; set; }

        #region Expandable Source
        public string SourceId { get; set; }

        [JsonIgnore]
        public Source Source { get; set; }

        [JsonProperty("source")]
        internal object InternalSource
        {
            set
            {
                StringOrObject<Source>.Map(value, s => SourceId = s, o => Source = o);
            }
        }
        #endregion

        [JsonProperty("statement_descriptor")]
        public string StatementDescriptor { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("transfer_data")]
        StripePaymentIntentTransferData TransferData { get; set; }

        [JsonProperty("transfer_group")]
        public string TransferGroup { get; set; }
    }
}
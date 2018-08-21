namespace Stripe
{
    using Newtonsoft.Json;

    public class ChargeShippingOptions : ShippingOptions
    {
        [JsonProperty("shipping[carrier]")]
        public string Carrier { get; set; }

        [JsonProperty("shipping[tracking_number]")]
        public string TrackingNumber { get; set; }
    }
}

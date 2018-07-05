using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Stripe.Infrastructure
{
    internal class PaymentIntentSourceActionConverter : JsonConverter
    {
        public override bool CanWrite => false;

        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var incoming = JObject.FromObject(value);

            incoming.WriteTo(writer);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var sourceAction = new StripePaymentIntentSourceAction{};

            if (reader.TokenType == JsonToken.Null)
            {
                sourceAction.Type = StripePaymentIntentSourceActionType.None;
                return sourceAction;
            }

            var incoming = JObject.Load(reader);

            if (incoming.SelectToken("type")?.ToString() == "authorize_with_url")
            {
                sourceAction.Type = StripePaymentIntentSourceActionType.AuthorizeWithUrl;
                sourceAction.AuthorizeWithUrl = Mapper<StripePaymentIntentSourceActionAuthorizeWithUrl>.MapFromJson(incoming.SelectToken("value")?.ToString());
            }
            else
            {
                sourceAction.Type = StripePaymentIntentSourceActionType.Unknown;
            }

            return sourceAction;
        }
    }
}
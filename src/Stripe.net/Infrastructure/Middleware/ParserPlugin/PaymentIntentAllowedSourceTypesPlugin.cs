using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;

namespace Stripe.Infrastructure.Middleware
{
    internal class PaymentIntentAllowedSourceTypesPlugin : IParserPlugin
    {
        public bool Parse(ref string requestString, JsonPropertyAttribute attribute, PropertyInfo property, object propertyValue, object propertyParent)
        {
            if (attribute.PropertyName != "allowed_source_types_array") return false;

            var sourceTypes = ((List<string>) property.GetValue(propertyParent, null));

            var itemIndex = 0;
            foreach (var sourceType in sourceTypes)
            {
                RequestStringBuilder.ApplyParameterToRequestString(ref requestString,
                    $"allowed_source_types[{itemIndex}]", sourceType.ToString());

                itemIndex++;
            }

            return true;
        }
    }
}

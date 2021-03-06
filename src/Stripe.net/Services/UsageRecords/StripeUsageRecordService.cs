﻿namespace Stripe
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Stripe.Infrastructure;

    public class StripeUsageRecordService : StripeBasicService<StripeUsageRecord>
    {
        public StripeUsageRecordService()
            : base(null)
        {
        }

        public StripeUsageRecordService(string apiKey)
            : base(apiKey)
        {
        }

        public virtual StripeUsageRecord Create(StripeUsageRecordCreateOptions options, StripeRequestOptions requestOptions = null)
        {
            return this.Post($"{Urls.BaseUrl}/subscription_items/{options.SubscriptionItem}/usage_records", requestOptions, options);
        }

        public virtual Task<StripeUsageRecord> CreateAsync(StripeUsageRecordCreateOptions options, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.PostAsync($"{Urls.BaseUrl}/subscription_items/{options.SubscriptionItem}/usage_records", requestOptions, cancellationToken, options);
        }
    }
}

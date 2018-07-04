using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Stripe.Infrastructure;

namespace Stripe
{
    public class StripePaymentIntentService : StripeBasicService<StripePaymentIntent>
    {
        public StripePaymentIntentService() : base(null) { }
        public StripePaymentIntentService(string apiKey) : base(apiKey) { }

        public bool ExpandApplication { get; set; }
        public bool ExpandCustomer { get; set; }
        public bool ExpandOnBehalfOf { get; set; }
        public bool ExpandSource { get; set; }



        // Sync
        public virtual StripePaymentIntent Create(StripePaymentIntentCreateOptions options, StripeRequestOptions requestOptions = null)
        {
            return Post($"{Urls.BaseUrl}/payment_intents", requestOptions, options);
        }

        public virtual StripePaymentIntent Get(string paymentIntentId, StripeRequestOptions requestOptions = null)
        {
            return GetEntity($"{Urls.BaseUrl}/payment_intents/{paymentIntentId}", requestOptions);
        }

        public virtual StripePaymentIntent Update(string paymentIntentId, StripePaymentIntentUpdateOptions options, StripeRequestOptions requestOptions = null)
        {
            return Post($"{Urls.BaseUrl}/payment_intents/{paymentIntentId}", requestOptions, options);
        }

        public virtual StripeList<StripePaymentIntent> List(StripePaymentIntentListOptions listOptions = null, StripeRequestOptions requestOptions = null)
        {
            return GetEntityList($"{Urls.BaseUrl}/payment_intents", requestOptions, listOptions);
        }

        public virtual StripePaymentIntent Cancel(string paymentIntentId, StripePaymentIntentCancelOptions options, StripeRequestOptions requestOptions = null)
        {
            return Post($"{Urls.BaseUrl}/payment_intents/{paymentIntentId}/cancel", requestOptions, options);
        }

        public virtual StripePaymentIntent Capture(string paymentIntentId, StripePaymentIntentCaptureOptions options, StripeRequestOptions requestOptions = null)
        {
            return Post($"{Urls.BaseUrl}/payment_intents/{paymentIntentId}/capture", requestOptions, options);
        }

        public virtual StripePaymentIntent Confirm(string paymentIntentId, StripePaymentIntentConfirmOptions options, StripeRequestOptions requestOptions = null)
        {
            return Post($"{Urls.BaseUrl}/payment_intents/{paymentIntentId}/confirm", requestOptions, options);
        }



        // Async
        public virtual Task<StripePaymentIntent> CreateAsync(StripePaymentIntentCreateOptions options, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return PostAsync($"{Urls.BaseUrl}/payment_intents", requestOptions, cancellationToken, options);
        }

        public virtual Task<StripePaymentIntent> GetAsync(string paymentIntentId, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return GetEntityAsync($"{Urls.BaseUrl}/payment_intents/{paymentIntentId}", requestOptions, cancellationToken);
        }

        public virtual Task<StripePaymentIntent> UpdateAsync(string paymentIntentId, StripePaymentIntentUpdateOptions options, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return PostAsync($"{Urls.BaseUrl}/payment_intents/{paymentIntentId}", requestOptions, cancellationToken, options);
        }

        public virtual Task<StripeList<StripePaymentIntent>> ListAsync(StripePaymentIntentListOptions listOptions = null, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return GetEntityListAsync($"{Urls.BaseUrl}/payment_intents", requestOptions, cancellationToken, listOptions);
        }

        public virtual Task<StripePaymentIntent> CancelAsync(string paymentIntentId, StripePaymentIntentCancelOptions options, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return PostAsync($"{Urls.BaseUrl}/payment_intents/{paymentIntentId}/cancel", requestOptions, cancellationToken, options);
        }

        public virtual Task<StripePaymentIntent> CaptureAsync(string paymentIntentId, StripePaymentIntentCaptureOptions options, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return PostAsync($"{Urls.BaseUrl}/payment_intents/{paymentIntentId}/capture", requestOptions, cancellationToken, options);
        }

        public virtual Task<StripePaymentIntent> ConfirmAsync(string paymentIntentId, StripePaymentIntentConfirmOptions options, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return PostAsync($"{Urls.BaseUrl}/payment_intents/{paymentIntentId}/confirm", requestOptions, cancellationToken, options);
        }
    }
}

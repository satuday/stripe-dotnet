namespace Stripe
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Stripe.Infrastructure;

    public class ExternalAccountService : BasicService<StripeExternalAccount>
    {
        public ExternalAccountService()
            : base(null)
        {
        }

        public ExternalAccountService(string apiKey)
            : base(apiKey)
        {
        }

        public virtual StripeExternalAccount Create(string accountId, ExternalAccountCreateOptions options, RequestOptions requestOptions = null)
        {
            return this.Post($"{Urls.BaseUrl}/accounts/{accountId}/external_accounts", requestOptions, options);
        }

        public virtual StripeExternalAccount Get(string accountId, string externalAccountId, RequestOptions requestOptions = null)
        {
            return this.GetEntity($"{Urls.BaseUrl}/accounts/{accountId}/external_accounts/{externalAccountId}", requestOptions);
        }

        public virtual StripeExternalAccount Update(string accountId, string externalAccountId, ExternalAccountUpdateOptions options, RequestOptions requestOptions = null)
        {
            return this.Post($"{Urls.BaseUrl}/accounts/{accountId}/external_accounts/{externalAccountId}", requestOptions, options);
        }

        public virtual StripeList<StripeExternalAccount> List(string accountId, ExternalAccountListOptions listOptions = null, RequestOptions requestOptions = null)
        {
            return this.GetEntityList($"{Urls.BaseUrl}/accounts/{accountId}/external_accounts", requestOptions, listOptions);
        }

        public virtual StripeDeleted Delete(string accountId, string externalAccountId, RequestOptions requestOptions = null)
        {
            return this.DeleteEntity($"{Urls.BaseUrl}/accounts/{accountId}/external_accounts/{externalAccountId}", requestOptions);
        }

        public virtual Task<StripeExternalAccount> CreateAsync(string accountId, ExternalAccountCreateOptions options, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.PostAsync($"{Urls.BaseUrl}/accounts/{accountId}/external_accounts", requestOptions, cancellationToken, options);
        }

        public virtual Task<StripeExternalAccount> GetAsync(string accountId, string externalAccountId, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.GetEntityAsync($"{Urls.BaseUrl}/accounts/{accountId}/external_accounts/{externalAccountId}", requestOptions, cancellationToken);
        }

        public virtual Task<StripeExternalAccount> UpdateAsync(string accountId, string externalAccountId, ExternalAccountUpdateOptions options, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.PostAsync($"{Urls.BaseUrl}/accounts/{accountId}/external_accounts/{externalAccountId}", requestOptions, cancellationToken, options);
        }

        public virtual Task<StripeList<StripeExternalAccount>> ListAsync(string accountId, ExternalAccountListOptions listOptions = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.GetEntityListAsync($"{Urls.BaseUrl}/accounts/{accountId}/external_accounts", requestOptions, cancellationToken, listOptions);
        }

        public virtual Task<StripeDeleted> DeleteAsync(string accountId, string externalAccountId, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.DeleteEntityAsync($"{Urls.BaseUrl}/accounts/{accountId}/external_accounts/{externalAccountId}", requestOptions, cancellationToken);
        }
    }
}

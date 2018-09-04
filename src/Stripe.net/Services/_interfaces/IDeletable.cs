namespace Stripe
{
    using System.Threading;
    using System.Threading.Tasks;

    public interface IDeletable
    {
        StripeDeleted Delete(string id, StripeRequestOptions requestOptions = null);

        Task<StripeDeleted> DeleteAsync(string id, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}

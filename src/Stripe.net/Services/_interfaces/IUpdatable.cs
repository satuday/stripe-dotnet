namespace Stripe
{
    using System.Threading;
    using System.Threading.Tasks;

    public interface IUpdatable<T, O>
        where T : StripeEntity
        where O : StripeBaseOptions
    {
        T Update(string id, O updateOptions, StripeRequestOptions requestOptions = null);

        Task<T> UpdateAsync(string id, O updateOptions, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}

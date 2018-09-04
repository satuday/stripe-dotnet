namespace Stripe
{
    using System.Threading;
    using System.Threading.Tasks;

    public interface ICreatable<T, O>
        where T : StripeEntity
        where O : StripeBaseOptions
    {
        T Create(O createOptions, StripeRequestOptions requestOptions = null);

        Task<T> CreateAsync(O createOptions, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}

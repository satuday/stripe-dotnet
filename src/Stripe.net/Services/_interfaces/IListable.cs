namespace Stripe
{
    using System.Threading;
    using System.Threading.Tasks;

    public interface IListable<T, O>
        where T : StripeEntity
        where O : StripeBaseOptions
    {
        StripeList<T> List(O listOptions = null, StripeRequestOptions requestOptions = null);

        Task<StripeList<T>> ListAsync(O listOptions = null, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}

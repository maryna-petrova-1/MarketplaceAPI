using MarketplaceAPI.Infrastructure;

namespace MarketplaceAPI.Contracts.DataAccess.QueryProviders
{
	public interface IAuctionsQueryProvider
	{
		Task<List<Infrastructure.Models.Auction>> Get();

		Task<List<Infrastructure.Models.Auction>> Get(QueryObject queryObject);
	}
}


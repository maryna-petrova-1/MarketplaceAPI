using System;
using MarketplaceAPI.Data.Models;

namespace MarketplaceAPI.Contracts.DataAccess.QueryProviders
{
	public interface IAuctionsQueryProvider
	{
		IReadOnlyCollection<Auction> Get();
	}
}


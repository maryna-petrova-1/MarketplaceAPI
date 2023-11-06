using System;
using MarketplaceAPI.Data.Models;

namespace MarketplaceAPI.Contracts.DataAccess.QueryProviders
{
	public interface IAuctionsQueryProvider
	{
		Task<List<Infrastructure.Models.Auction>> Get();
	}
}


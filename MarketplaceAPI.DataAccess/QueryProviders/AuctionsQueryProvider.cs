using System;
using MarketplaceAPI.Contracts.DataAccess.QueryProviders;
using MarketplaceAPI.Data;
using MarketplaceAPI.Data.Models;

namespace MarketplaceAPI.DataAccess.QueryProviders
{
	public class AuctionsQueryProvider : IAuctionsQueryProvider
	{
		private readonly AuctionsContext _dbContext;

		public AuctionsQueryProvider(AuctionsContext dbContext)
		{
			_dbContext = dbContext;
		}

		public IReadOnlyCollection<Auction> Get()
		{
			return _dbContext.Auctions.ToList().AsReadOnly();
		}
	}
}


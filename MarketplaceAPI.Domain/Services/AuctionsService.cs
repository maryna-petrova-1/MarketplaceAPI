using System;
using MarketplaceAPI.Contracts.DataAccess.QueryProviders;
using MarketplaceAPI.Contracts.Domain.Services;
using MarketplaceAPI.Infrastructure.Models;
using MarketplaceAPI.Infrastructure;

namespace MarketplaceAPI.Domain.Services
{
	public class AuctionsService : IAuctionsService
	{
		private readonly IAuctionsQueryProvider _auctionsQueryProvider;

		public AuctionsService(IAuctionsQueryProvider auctionsQueryProvider)
		{
			_auctionsQueryProvider = auctionsQueryProvider;
		}

		public async Task<IEnumerable<Auction>> GetAuctions()
		{
			var auctions = await _auctionsQueryProvider.Get();

			return auctions;
		}

        public async Task<IEnumerable<Auction>> GetAuctions(QueryObject queryObject)
        {
            var auctions = await _auctionsQueryProvider.Get(queryObject);

            return auctions;
        }
    }
}


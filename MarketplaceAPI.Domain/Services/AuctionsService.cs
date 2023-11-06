using System;
using MarketplaceAPI.Contracts.DataAccess.QueryProviders;
using MarketplaceAPI.Contracts.Domain.Services;
using MarketplaceAPI.Infrastructure.Models;

namespace MarketplaceAPI.Domain.Services
{
	public class AuctionsService : IAuctionsService
	{
		private readonly IAuctionsQueryProvider _auctionsQueryProvider;

		public AuctionsService(IAuctionsQueryProvider auctionsQueryProvider)
		{
			_auctionsQueryProvider = auctionsQueryProvider;
		}

		public IEnumerable<Auction> GetAuctions()
		{
			var auctions = _auctionsQueryProvider.Get()
				.Select(x => new Auction
				{
					Id = x.Id,
					ItemId = x.ItemId,
					CreatedDt = x.CreatedDt,
					FinishedDt = x.FinishedDt,
					Price = x.Price,
					MarketStatus = (Status)x.MarketStatus,
					Seller = x.Seller,
					Buyer = x.Buyer,
					Item = new Item {
						Id = x.Item.Id,
						Name = x.Item.Name,
						Description = x.Item.Description,
						Metadata = x.Item.Metadata
					}
				});

			return auctions;
		}
	}
}


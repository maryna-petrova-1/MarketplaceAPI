using System;
using MarketplaceAPI.Contracts.DataAccess.QueryProviders;
using MarketplaceAPI.Data;
using MarketplaceAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace MarketplaceAPI.DataAccess.QueryProviders
{
	public class AuctionsQueryProvider : IAuctionsQueryProvider
	{
		private readonly AuctionsContext _dbContext;

		public AuctionsQueryProvider(AuctionsContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<List<Infrastructure.Models.Auction>> Get()
		{
			return await _dbContext.Auctions
                .Select(x => new Infrastructure.Models.Auction
                {
                    Id = x.Id,
                    ItemId = x.ItemId,
                    CreatedDt = x.CreatedDt,
                    FinishedDt = x.FinishedDt,
                    Price = x.Price,
                    MarketStatus = (Infrastructure.Models.Status)x.MarketStatus,
                    Seller = x.Seller,
                    Buyer = x.Buyer,
                    Item = new Infrastructure.Models.Item
                    {
                        Id = x.Item.Id,
                        Name = x.Item.Name,
                        Description = x.Item.Description,
                        Metadata = x.Item.Metadata
                    }
                })
				.ToListAsync();
		}
	}
}


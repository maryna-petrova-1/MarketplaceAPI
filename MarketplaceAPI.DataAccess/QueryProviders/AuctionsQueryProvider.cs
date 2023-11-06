using System;
using MarketplaceAPI.Contracts.DataAccess.QueryProviders;
using MarketplaceAPI.Data;
using MarketplaceAPI.Infrastructure;
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

        public async Task<List<Infrastructure.Models.Auction>> Get(QueryObject queryObject)
        {
            if (!string.IsNullOrEmpty(queryObject.Name))
            {
                _dbContext.Auctions.Where(x => x.Item.Name.Contains(queryObject.Name));
            }

            if (!string.IsNullOrEmpty(queryObject.Status))
            {
                _dbContext.Auctions.Where(x => x.MarketStatus.ToString() == queryObject.Status);
            }

            if (!string.IsNullOrEmpty(queryObject.Seller))
            {
                _dbContext.Auctions.Where(x => x.Seller.ToString() == queryObject.Seller);
            }

            return await _dbContext.Auctions
                .Skip((queryObject.Page - 1) * queryObject.PageSize)
                .Take(queryObject.PageSize)
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


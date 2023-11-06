using System;
using MarketplaceAPI.Infrastructure.Models;

namespace MarketplaceAPI.Contracts.Domain.Services
{
	public interface IAuctionsService
	{
        IEnumerable<Auction> GetAuctions();
    }
}


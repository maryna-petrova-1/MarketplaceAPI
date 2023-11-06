using System;
using MarketplaceAPI.Infrastructure.Models;

namespace MarketplaceAPI.Contracts.Domain.Services
{
	public interface IAuctionsService
	{
        Task<IEnumerable<Auction>> GetAuctions();
    }
}


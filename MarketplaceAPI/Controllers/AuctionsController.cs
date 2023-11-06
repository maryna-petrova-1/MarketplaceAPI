using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketplaceAPI.Contracts.Domain.Services;
using MarketplaceAPI.Infrastructure.Models;
using MarketplaceAPI.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace MarketplaceAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuctionsController : Controller
    {
        private readonly IAuctionsService _auctionsService;

        public AuctionsController(IAuctionsService auctionsService)
        {
            _auctionsService = auctionsService;
        }

        [HttpGet(Name = "GetAuctions")]
        public async Task<IEnumerable<Auction>> Get()
        {
            var auctions = await _auctionsService.GetAuctions();

            return auctions;
        }

        [HttpGet(Name = "GetAuctions")]
        public async Task<IEnumerable<Auction>> Get([FromQuery] QueryObject queryObject)
        {
            var auctions = await _auctionsService.GetAuctions(queryObject);

            return auctions;
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketplaceAPI.Contracts.Domain.Services;
using MarketplaceAPI.Infrastructure.Models;
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
        public IEnumerable<Auction> Get()
        {
            var auctions = _auctionsService.GetAuctions();

            return auctions;
        }
    }
}


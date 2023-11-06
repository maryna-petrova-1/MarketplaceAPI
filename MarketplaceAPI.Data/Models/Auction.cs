using System;
using System.Diagnostics;
using System.Net.NetworkInformation;

namespace MarketplaceAPI.Data.Models
{
    public enum Status
    {
        None, Canceled, Finished, Active
    }

    public class Auction
	{
        public int Id { get; set; }
        public DateTime CreatedDt { get; set; }
        public DateTime FinishedDt { get; set; }
        public decimal Price { get; set; }
        public Status MarketStatus { get; set; }
        public string Seller { get; set; }
        public string Buyer { get; set; }
        public int ItemId { get; set; }

        public Item Item { get; set; }
    }
}


using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using AcmeCorporation.API.Data.Models;
using AcmeCorporation.API.Shared.Enums;
using Microsoft.AspNetCore.Http;

namespace AcmeCorporation.API.Dto
{
    public class ProductDto
    {
        public ProductDto()
        {
            Photos = new List<IFormFile>();
            ImageUrls = new List<string>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public bool IsDeleted { get; set; }
        public IList<IFormFile> Photos { get; set; }
        public decimal InitialBid { get; set; }
        public decimal HighestBid { get; set; }
        public DateTime StartingTime { get; set; }
        public DateTime EndingTime { get; set; }
        public IList<string> ImageUrls { get; set; }
        public int TransactionCount { get; set; }
        public bool IsFileModified { get; set; }

    }
}
using Hotel.Models.Entity;
using System;
using System.Collections.Generic;

namespace Hotel.Services.Repository
{
    internal interface IOfferRepository : IRepository<Offer>
    {
        IEnumerable<Offer> GetAvailableOffers(DateTime start, DateTime end);
    }
}
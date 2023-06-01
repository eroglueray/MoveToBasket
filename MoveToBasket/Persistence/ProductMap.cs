using MongoDB.Bson.Serialization;
using MoveToBasket.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoveToBasket.API.Persistence
{
    public class ProductMap
    {
        public static void Configure()
        {
            BsonClassMap.RegisterClassMap<Product>(map =>
            {
                map.AutoMap();
                map.SetIgnoreExtraElements(true);
                map.MapIdMember(x => x.Id);
                map.MapMember(x => x.Brand).SetIsRequired(true);
                map.MapMember(x => x.Cost).SetIsRequired(true);
                map.MapMember(x => x.Model);
                map.MapMember(x => x.LastUpdated);
                map.MapMember(x => x.Amount).SetIsRequired(true);
            });
        }
    }
}

using MongoDB.Bson.Serialization;
using MoveToBasket.API.Models;

namespace MoveToBasket.API.Persistence
{
    public class BasketMap
    {
        public static void Configure()
        {
            BsonClassMap.RegisterClassMap<Basket>(map =>
            {
                map.AutoMap();
                map.SetIgnoreExtraElements(true);
                map.MapIdMember(x => x.Id);
                map.MapMember(x => x.Product).SetIsRequired(true);
                map.MapMember(x => x.Customer).SetIsRequired(true);
                map.MapMember(x => x.LastUpdated);
            });
        }
    }
}

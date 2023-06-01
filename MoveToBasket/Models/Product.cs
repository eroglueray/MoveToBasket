using System;
using MongoDB.Bson;

namespace MoveToBasket.API.Models
{

    public class Product
    {
        public Product()
        {
            Created = DateTime.Now;
            Id = new ObjectId();
        }


        public ObjectId Id { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public decimal Cost { get; set; }
        public int Amount { get; set; }

        public DateTime Created { get; set; }

        public DateTime? LastUpdated { get; set; }
    }
}

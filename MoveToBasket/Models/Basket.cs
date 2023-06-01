using MongoDB.Bson;
using System;


namespace MoveToBasket.API.Models
{
    public class Basket
    {
      
        public Basket()
        {
            Created = DateTime.Now;
            Id = new ObjectId();

        }

        public ObjectId Id { get; set; }
        public Product Product { get; set; }
        public Customer Customer { get; set; }
        public int Amount { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime Created { get; set; }
        public DateTime? LastUpdated { get; set; }

    }
}

//public string UserId { get; set; }
//public string UserName { get; set; }
//public string Content { get; set; }
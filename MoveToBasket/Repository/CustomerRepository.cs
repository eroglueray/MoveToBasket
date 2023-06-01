using MoveToBasket.API.Interfaces;
using MoveToBasket.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoveToBasket.API.Repository
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(IMongoContext context) : base(context)
        {
        }
    }
}

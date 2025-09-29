using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using delivery_order_services.Domain.Entities;
using delivery_order_services.Domain.Repository.Contracts;
using MongoDB.Driver;

namespace delivery_order_services.Domain.Repository
{
    public class OrderRepository(
           IMongoCollection<OrderEntity> _collection
        ) : IOrderRepository
    {

        public async Task<List<OrderEntity>> GetAllAsync()
            => await _collection.Find(_ => true).ToListAsync();

        public async Task<OrderEntity?> GetByIdAsync(string id)
             => await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(OrderEntity user)
             => await _collection.InsertOneAsync(user);
    }
}

using delivery_order_services.Domain.Entities;
using delivery_order_services.Domain.Repository.Contracts;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delivery_order_services.Domain.Repository
{
    public class UserRepository(
        IMongoCollection<UserEntity> _collection
        ) : IUserRepository
    {

        public async Task<List<UserEntity>> GetAllAsync()
            => await _collection.Find(_ => true).ToListAsync();

        public async Task<UserEntity?> GetByIdAsync(string id)
             => await _collection.Find(x => x.PkId == id).FirstOrDefaultAsync();

        public async Task CreateAsync(UserEntity user)
             => await _collection.InsertOneAsync(user);
    }
}

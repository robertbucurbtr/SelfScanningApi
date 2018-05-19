using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary.Database
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseClass
    {
        private readonly IGenericContext<T> _context;

        public GenericRepository(IGenericContext<T> context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context
                            .Entities
                            .Find(_ => true)
                            .ToListAsync();
        }

        public Task<T> GetById(string customerId)
        {
            FilterDefinition<T> filter = Builders<T>.Filter.Eq(m => m.EntityId, customerId);

            return _context
                    .Entities
                    .Find(filter)
                    .FirstOrDefaultAsync();
        }

        public async Task Create(T customer)
        {
            await _context.Entities.InsertOneAsync(customer);
        }

        public async Task<bool> Update(T customer)
        {
            ReplaceOneResult updateResult =
                await _context
                        .Entities
                        .ReplaceOneAsync(
                            filter: g => g.Id == customer.Id,
                            replacement: customer);

            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> Delete(string entityId)
        {
            FilterDefinition<T> filter = Builders<T>.Filter.Eq(m => m.EntityId, entityId);

            DeleteResult deleteResult = await _context
                                                .Entities
                                                .DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }
    }
}

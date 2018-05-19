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
        private string collection;

        public GenericRepository(IGenericContext<T> context)
        {
            _context = context;
            collection = string.Empty;
        }
        public void SetCollection(string collection)
        {
            this.collection = collection;
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            if(string.IsNullOrWhiteSpace(collection))
            {
                throw new NullReferenceException("Please set collection of the entities!");
            }
            return await _context[collection]
                            .Find(_ => true)
                            .ToListAsync();
        }

        public Task<T> GetById(string customerId)
        {
            if (string.IsNullOrWhiteSpace(collection))
            {
                throw new NullReferenceException("Please set collection of the entities!");
            }
            FilterDefinition<T> filter = Builders<T>.Filter.Eq(m => m.EntityId, customerId);

            return _context[collection]
                    .Find(filter)
                    .FirstOrDefaultAsync();
        }

        public async Task Create(T customer)
        {
            if (string.IsNullOrWhiteSpace(collection))
            {
                throw new NullReferenceException("Please set collection of the entities!");
            }
            await _context[collection].InsertOneAsync(customer);
        }

        public async Task<bool> Update(T customer)
        {
            if (string.IsNullOrWhiteSpace(collection))
            {
                throw new NullReferenceException("Please set collection of the entities!");
            }
            ReplaceOneResult updateResult =
                await _context[collection]
                        .ReplaceOneAsync(
                            filter: g => g.Id == customer.Id,
                            replacement: customer);

            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> Delete(string entityId)
        {
            if (string.IsNullOrWhiteSpace(collection))
            {
                throw new NullReferenceException("Please set collection of the entities!");
            }
            FilterDefinition<T> filter = Builders<T>.Filter.Eq(m => m.EntityId, entityId);

            DeleteResult deleteResult = await _context[collection]
                                                .DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }
    }
}

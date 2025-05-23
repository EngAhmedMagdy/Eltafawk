using BlazorApp1.Components.Pages.courses;
using BlazorApp1.Models;
using EltafawkPlatform.Models; // Adjust to your namespace
using MongoDB.Bson;
using MongoDB.Driver;
namespace EltafawkPlatform.Services
{
    public class SubscribePackageService
    {
        private readonly IMongoCollection<SubscribePackageModel> _collection;

        public SubscribePackageService(IMongoDatabase database)
        {
            _collection = database.GetCollection<SubscribePackageModel>("SubscribePackages");
        }

        public async Task<List<SubscribePackageModel>> GetAllAsync() =>
            await _collection.Find(_ => true).ToListAsync();

        public async Task<SubscribePackageModel?> GetByIdAsync(string id)
        {
            return await _collection.Find(c => c.Id == ObjectId.Parse(id)).FirstOrDefaultAsync();
        }

        public async Task CreateAsync(SubscribePackageModel model)
        {
            await _collection.InsertOneAsync(model);
        }

        public async Task UpdateAsync(string id , SubscribePackageModel model)
        {
            model.Id = ObjectId.Parse(id);
            await _collection.ReplaceOneAsync(c => c.Id == model.Id, model);
        }

        public async Task<bool> DeleteAsync(string id)
        {

            var result = await _collection.DeleteOneAsync(c => c.Id == ObjectId.Parse(id));
            return result.DeletedCount > 0;
        }
    }
}


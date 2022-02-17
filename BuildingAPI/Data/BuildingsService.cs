using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BuildingAPI.Data
{
    public class BuildingsService
    {
        private readonly IMongoCollection<Building> _buildings;

        public BuildingsService(IOptions<BuildingsDatabaseSettings> options)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);

            _buildings = mongoClient.GetDatabase(options.Value.DatabaseName)
                .GetCollection<Building>(options.Value.BuildingCollectionName);
        }

        public async Task<List<Building>> Get() =>
            await _buildings.Find(_ => true).ToListAsync();

        public async Task<Building> Get(string id) => 
            await _buildings.Find(m => m.Id == id).FirstOrDefaultAsync();

        public async Task Create(Building newBuilding) =>
            await _buildings.InsertOneAsync(newBuilding);

        public async Task Update(string id,Building updateBuilding) =>
            await _buildings.ReplaceOneAsync(m => m.Id == id, updateBuilding);

        public async Task Remove(string id) =>
            await _buildings.DeleteOneAsync(m =>m.Id == id);
    }
}

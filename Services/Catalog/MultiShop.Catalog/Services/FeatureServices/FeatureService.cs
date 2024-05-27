using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.FeatureDtos;
using MultiShop.Catalog.Dtos.FeatureSliderDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.FeatureServices
{
    public class FeatureService : IFeatureService
    {
        private readonly IMapper mapper;
        private readonly IMongoCollection<Feature> _featureCollection;

        public FeatureService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            this.mapper = mapper;
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _featureCollection = database.GetCollection<Feature>(databaseSettings.FeatureCollectionName);
        }
        public async Task CreateFeatureAsync(CreateFeatureDto createFeatureDto)
        {
            var value = mapper.Map<Feature>(createFeatureDto);
            await _featureCollection.InsertOneAsync(value);
        }

        public async Task DeleteFeatureAsync(string id)
        {
            await _featureCollection.DeleteOneAsync(x => x.FeatureId == id);
        }

        public async Task<List<ResultFeatureDto>> GetAllFeatureAsync()
        {
            var values = await _featureCollection.Find(x => true).ToListAsync();
            return mapper.Map<List<ResultFeatureDto>>(values);
        }

        public async Task<GetByIdFeatureDto> GetByIdFeatureAsync(string id)
        {
            var value = await _featureCollection.Find<Feature>(x => x.FeatureId == id).FirstOrDefaultAsync();
            return mapper.Map<GetByIdFeatureDto>(value);
        }

        public async Task UpdateFeatureAsync(UpdateFeatureDto updateFeatureDto)
        {
            var values = mapper.Map<Feature>(updateFeatureDto);
            await _featureCollection.FindOneAndReplaceAsync(x => x.FeatureId == updateFeatureDto.FeatureId, values);
        }
    }
}

using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Dtos.FeatureSliderDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.FeatureSliderServices
{
    public class FeatureSliderService : IFeatureSliderService
    {
        private readonly IMapper mapper;
        private readonly IMongoCollection<FeatureSlider> _featureSliderCollection;

        public FeatureSliderService(IMapper mapper,IDatabaseSettings databaseSettings)
        {
            this.mapper = mapper;
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _featureSliderCollection = database.GetCollection<FeatureSlider>(databaseSettings.FeatureSliderCollectionName);
        }

        public async Task CreateFeatureSliderAsync(CreateFeatureSliderDto createFeatureSliderDto)
        {
            var value = mapper.Map<FeatureSlider>(createFeatureSliderDto);
            await _featureSliderCollection.InsertOneAsync(value);
        }

        public async Task DeleteFeatureSliderAsync(string id)
        {
            await _featureSliderCollection.DeleteOneAsync(x => x.FeatureSliderId == id);
        }

        public async Task FeatureSliderChangeStatusToFalse(string id)
        {
            var value = await _featureSliderCollection.Find(x => x.FeatureSliderId == id).FirstAsync();
            value.Status = false;
            await _featureSliderCollection.FindOneAndReplaceAsync(x => x.FeatureSliderId == id,value);
        }

        public async Task FeatureSliderChangeStatusToTrue(string id)
        {
            var value = await _featureSliderCollection.Find(x => x.FeatureSliderId == id).FirstAsync();
            value.Status = true;
            await _featureSliderCollection.FindOneAndReplaceAsync(x => x.FeatureSliderId == id, value);
        }

        public async Task<List<ResultFeatureSliderDto>> GetAllFeatureSliderAsync()
        {
            var values = await _featureSliderCollection.Find(x => true).ToListAsync();
            return mapper.Map<List<ResultFeatureSliderDto>>(values);
        }

        public async Task<GetByIdFeatureSliderDto> GetByIdFeatureSliderAsync(string id)
        {
            var value = await _featureSliderCollection.Find<FeatureSlider>(x => x.FeatureSliderId == id).FirstOrDefaultAsync();
            return mapper.Map<GetByIdFeatureSliderDto>(value);
        }

        public async Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto updateCategoryDto)
        {
            var values = mapper.Map<FeatureSlider>(updateCategoryDto);
            await _featureSliderCollection.FindOneAndReplaceAsync(x => x.FeatureSliderId == updateCategoryDto.FeatureSliderId, values);
        }
    }
}



using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CRM.Domain.Model;
using CRM.Domain.Repositories;
using AutoMapper;
using CRM.Domain.Entities;

namespace CRM.Service.Services.RepresentativePlaces
{
    public class RepresentativePlaceService : IRepresentativePlaceService
    {

        IRepresentativePlaceRepository representativePlaceRepository;
        IMapper mapper;

        public RepresentativePlaceService(IMapper mapper, IRepresentativePlaceRepository representativePlaceRepository)
        {
            this.mapper = mapper;
            this.representativePlaceRepository = representativePlaceRepository;
        }

        public void DeleteRepresentativePlace(int id)
        {
            representativePlaceRepository.Delete(id);
        }

        public async Task<IEnumerable<RepresentativePlaceModel>> GetRepresentativePlaceAsync()
        {
            return mapper.Map<IEnumerable<RepresentativePlaceModel>>(await representativePlaceRepository.GetAllAsync());
        }

        public async Task<RepresentativePlaceModel> GetRepresentativePlaceAsync(int id)
        {
            return mapper.Map<RepresentativePlaceModel>(await representativePlaceRepository.GetAsync(id));
        }

        public async Task<RepresentativePlaceModel> InsertRepresentativePlaceAsync(RepresentativePlaceModel representativePlace)
        {
            representativePlace.AddedDate = DateTime.Now;
            var newRepresentativePlace = await representativePlaceRepository.InsertAsync(mapper.Map<RepresentativePlace>(representativePlace));
            await representativePlaceRepository.SaveChangesAsync();
            return mapper.Map<RepresentativePlaceModel>(newRepresentativePlace);
        }

        public async Task<RepresentativePlaceModel> UpdateRepresentativePlaceAsync(RepresentativePlaceModel representativePlace)
        {
            var representativePlaceForUpdate = await representativePlaceRepository.GetAsync(representativePlace.Id);
            representativePlaceForUpdate.ModifiedDate = DateTime.Now;
            representativePlaceForUpdate.PlaceId = representativePlace.PlaceId;
            representativePlaceForUpdate.UserId = representativePlace.UserId;
            await representativePlaceRepository.SaveChangesAsync();
            return mapper.Map<RepresentativePlaceModel>(representativePlaceForUpdate);
        }

    }


}



using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CRM.Domain.Model;
using CRM.Domain.Repositories;
using AutoMapper;
using CRM.Domain.Entities;
using CRM.Domain.RequestIdentity;

namespace CRM.Service.Services.RepresentativePlaces
{
    public class RepresentativePlaceService : IRepresentativePlaceService
    {

        IRepresentativePlaceRepository representativePlaceRepository;
        IMapper mapper;
        IUserRepository userRepository;
        IRequestIdentityProvider requestIdentityProvider;

        public RepresentativePlaceService(IMapper mapper, IRepresentativePlaceRepository representativePlaceRepository, IRequestIdentityProvider requestIdentityProvider, IUserRepository userRepository)
        {
            this.mapper = mapper;
            this.representativePlaceRepository = representativePlaceRepository;
            this.userRepository = userRepository;
            this.requestIdentityProvider = requestIdentityProvider;
        }

        public void DeleteRepresentativePlace(int id)
        {
            representativePlaceRepository.Delete(id);
        }

        public async Task<IEnumerable<RepresentativePlaceModel>> GetRepresentativePlaceAsync()
        {
            return mapper.Map<IEnumerable<RepresentativePlaceModel>>(await representativePlaceRepository.GetRepresentativePlaces());
        }

        public async Task<RepresentativePlaceModel> GetRepresentativePlaceAsync(int id)
        {
            return mapper.Map<RepresentativePlaceModel>(await representativePlaceRepository.GetAsync(id));
        }

        public async Task<RepresentativePlaceModel> InsertRepresentativePlaceAsync(RepresentativePlaceModel representativePlace)
        {
            var user = await userRepository.GetUser();

            representativePlace.AddedDate = DateTime.Now;
            representativePlace.CreatorUserId = requestIdentityProvider.UserId;
            representativePlace.LastModifierUserId = requestIdentityProvider.UserId;
            representativePlace.TenantId = user.TenantId;

            var newRepresentativePlace = await representativePlaceRepository.InsertAsync(mapper.Map<RepresentativePlace>(representativePlace));
            await representativePlaceRepository.SaveChangesAsync();
            return mapper.Map<RepresentativePlaceModel>(newRepresentativePlace);
        }

        public async Task<IEnumerable<RepresentativePlaceModel>> InsertRepresentativePlaceListAsync(IEnumerable<RepresentativePlaceModel> representativePlace)
        {
                var user = await userRepository.GetUser();

                List<RepresentativePlaceModel> repPlaceList = new List<RepresentativePlaceModel>();
            
                foreach (var repPlace in representativePlace)
                {
                    var repPlaceVar = new RepresentativePlaceModel
                    {
                        PlaceId = repPlace.PlaceId,
                        UserId = repPlace.UserId,
                        AddedDate = DateTime.Now,
                        TenantId = user.TenantId,
                        CreatorUserId = requestIdentityProvider.UserId,
                        LastModifierUserId = requestIdentityProvider.UserId
                };
                repPlaceList.Add(repPlaceVar);
            }

            representativePlaceRepository.InsertRepresentativePlaceList(mapper.Map<IEnumerable<RepresentativePlace>>(repPlaceList));
            await representativePlaceRepository.SaveChangesAsync();
            return repPlaceList;
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

        public async Task<IEnumerable<RepresentativePlaceModel>> GetRepresentativeByPlaceIdAsync(int placeId)
        {
            return mapper.Map<IEnumerable<RepresentativePlaceModel>>(await representativePlaceRepository.GetRepresentativeByPlaceId(placeId));
        }

       
    }


}

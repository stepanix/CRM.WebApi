using AutoMapper;
using CRM.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CRM.Domain.Model;
using CRM.Domain.Entities;
using CRM.Domain.RequestIdentity;

namespace CRM.Service.Services.Places
{
    public class PlaceService : IPlaceService
    {
        IPlaceRepository placeRepository;
        IMapper mapper;
        IUserRepository userRepository;
        IRequestIdentityProvider requestIdentityProvider;

        public PlaceService(IMapper mapper, IPlaceRepository placeRepository, IRequestIdentityProvider requestIdentityProvider, IUserRepository userRepository)
        {
            this.mapper = mapper;
            this.placeRepository = placeRepository;
            this.userRepository = userRepository;
            this.requestIdentityProvider = requestIdentityProvider;
        }

        public async Task<IEnumerable<PlaceModel>> GetPlacesAsync()
        {
            return mapper.Map<IEnumerable<PlaceModel>>(await placeRepository.GetPlaces());
        }

        public async Task<PlaceModel> GetPlaceAsync(int id)
        {
            return mapper.Map<PlaceModel>(await placeRepository.GetAsync(id));
        }

        public async Task<PlaceModel> InsertPlaceAsync(PlaceModel place)
        {
            var user = await userRepository.GetUser();

            place.AddedDate = DateTime.Now;
            place.TenantId = user.TenantId;
            place.CreatorUserId = requestIdentityProvider.UserId;
            place.LastModifierUserId = requestIdentityProvider.UserId;

            var newPlace = await placeRepository.InsertAsync(mapper.Map<Place>(place));
            await placeRepository.SaveChangesAsync();
            return mapper.Map<PlaceModel>(newPlace);
        }

        public async Task<PlaceModel> UpdatePlaceAsync(PlaceModel place)
        {
            var user = await userRepository.GetUser();
            var placeForUpdate = await placeRepository.GetAsync(place.Id);
            placeForUpdate.ModifiedDate = DateTime.Now;
            placeForUpdate.Name = place.Name;
            placeForUpdate.StatusId = place.StatusId;
            placeForUpdate.StreetAddress = place.StreetAddress;
            placeForUpdate.Latitude = place.Latitude;
            placeForUpdate.Longitude = place.Longitude;
            placeForUpdate.WebSite = place.WebSite;
            placeForUpdate.Phone = place.Phone;
            placeForUpdate.CellPhone = place.CellPhone;                     
            placeForUpdate.Comment = place.Comment;
            placeForUpdate.ContactName = place.ContactName;
            placeForUpdate.ContactTitle = place.ContactTitle;            
            placeForUpdate.Email = place.Email;
            placeForUpdate.TenantId = user.TenantId;
            placeForUpdate.LastModifierUserId = requestIdentityProvider.UserId;
            await placeRepository.SaveChangesAsync();
            return mapper.Map<PlaceModel>(placeForUpdate);
        }

        public void DeletePlace(int id)
        {
            placeRepository.Delete(id);
        }
    }
}

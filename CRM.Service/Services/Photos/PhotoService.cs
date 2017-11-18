using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CRM.Domain.Model;
using CRM.Domain.Repositories;
using AutoMapper;
using CRM.Domain.RequestIdentity;
using CRM.Domain.Entities;

namespace CRM.Service.Services.Photos
{
    public class PhotoService : IPhotoService
    {
        IPhotoRepository photoRepository;
        IMapper mapper;
        IUserRepository userRepository;
        IRequestIdentityProvider requestIdentityProvider;

        public PhotoService(IMapper mapper, IPhotoRepository photoRepository, IRequestIdentityProvider requestIdentityProvider, IUserRepository userRepository)
        {
            this.mapper = mapper;
            this.photoRepository = photoRepository;
            this.userRepository = userRepository;
            this.requestIdentityProvider = requestIdentityProvider;
        }


        public void DeletePhoto(int id)
        {
            photoRepository.Delete(id);
        }

        public async Task<PhotoModel> GetPhotoAsync(int id)
        {
            return mapper.Map<PhotoModel>(await photoRepository.GetAsync(id));
        }

        public async Task<IEnumerable<PhotoModel>> GetPhotosAsync()
        {
            return mapper.Map<IEnumerable<PhotoModel>>(await photoRepository.GetPhotos());
        }

        public async Task<IEnumerable<PhotoModel>> GetPhotosAsync(DateTime dateFrom, DateTime dateTo)
        {
            return mapper.Map<IEnumerable<PhotoModel>>(await photoRepository.GetPhotos(dateFrom, dateTo));
        }

        public async Task<PhotoModel> InsertPhotoAsync(PhotoModel photo)
        {
            var user = await userRepository.GetUser();

            photo.AddedDate = DateTime.Now;
            photo.TenantId = user.TenantId;
            photo.CreatorUserId = requestIdentityProvider.UserId;
            photo.LastModifierUserId = requestIdentityProvider.UserId;

            var newPhoto = await photoRepository.InsertAsync(mapper.Map<Photo>(photo));
            await photoRepository.SaveChangesAsync();
            return mapper.Map<PhotoModel>(newPhoto);
        }

        public async Task<PhotoModel> UpdatePhotoAsync(PhotoModel photo)
        {
            var user = await userRepository.GetUser();
            var photoForUpdate = await photoRepository.GetAsync(photo.Id);
            photoForUpdate.ModifiedDate = DateTime.Now;
            photoForUpdate.Note = photo.Note;
            photoForUpdate.ScheduleId = photo.ScheduleId;
            photoForUpdate.TenantId = user.TenantId;
            photoForUpdate.LastModifierUserId = requestIdentityProvider.UserId;
            await photoRepository.SaveChangesAsync();
            return mapper.Map<PhotoModel>(photoForUpdate);
        }

        public async Task<IEnumerable<PhotoModel>> GetPhotosAsync(DateTime dateFrom, DateTime dateTo, string rep)
        {
            return mapper.Map<IEnumerable<PhotoModel>>(await photoRepository.GetPhotos(dateFrom, dateTo,rep));
        }

        public async Task<IEnumerable<PhotoModel>> GetPhotosAsync(DateTime dateFrom, DateTime dateTo, int place)
        {
            return mapper.Map<IEnumerable<PhotoModel>>(await photoRepository.GetPhotos(dateFrom, dateTo,place));
        }

        public async Task<IEnumerable<PhotoModel>> GetPhotosAsync(DateTime dateFrom, DateTime dateTo, string rep, int place)
        {
            return mapper.Map<IEnumerable<PhotoModel>>(await photoRepository.GetPhotos(dateFrom, dateTo,rep,place));
        }

        public async Task<IEnumerable<PhotoModel>> InsertPhotoList(IEnumerable<PhotoModel> photos)
        {
            var user = await userRepository.GetUser();

            List<PhotoModel> photoList = new List<PhotoModel>();

            foreach (var photo in photos)
            {
                var photoVar = new PhotoModel
                {
                    RepoId = photo.RepoId,
                    SyncId = photo.SyncId,
                    PlaceId = photo.PlaceId,
                    ScheduleId = photo.ScheduleId,
                    Note = photo.Note,
                    PictureUrl = photo.PictureUrl,
                    AddedDate = DateTime.Now,
                    TenantId = user.TenantId,
                    CreatorUserId = requestIdentityProvider.UserId,
                    LastModifierUserId = requestIdentityProvider.UserId
                };
                photoList.Add(photoVar);
            }
            var newPhotoList = photoRepository.InsertPhotoList(mapper.Map<IEnumerable<Photo>>(photoList));
            await photoRepository.SaveChangesAsync();
            return photoList;
        }
    }
}


using CRM.Domain.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.Service.Services.Photos
{
    public interface IPhotoService
    {
        Task<IEnumerable<PhotoModel>> GetPhotosAsync();
        Task<IEnumerable<PhotoModel>> GetPhotosAsync(DateTime dateFrom, DateTime dateTo);
        Task<PhotoModel> GetPhotoAsync(int id);
        Task<PhotoModel> InsertPhotoAsync(PhotoModel photo);
        Task<PhotoModel> UpdatePhotoAsync(PhotoModel photo);
        void DeletePhoto(int id);
    }
}

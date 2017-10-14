

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
        Task<IEnumerable<PhotoModel>> GetPhotosAsync(DateTime dateFrom, DateTime dateTo, string rep);
        Task<IEnumerable<PhotoModel>> GetPhotosAsync(DateTime dateFrom, DateTime dateTo, int place);
        Task<IEnumerable<PhotoModel>> GetPhotosAsync(DateTime dateFrom, DateTime dateTo, string rep,int place);
        Task<PhotoModel> GetPhotoAsync(int id);
        Task<PhotoModel> InsertPhotoAsync(PhotoModel photo);
        Task<IEnumerable<PhotoModel>> InsertPhotoList(IEnumerable<PhotoModel> photos);
        Task<PhotoModel> UpdatePhotoAsync(PhotoModel photo);
        void DeletePhoto(int id);
    }
}

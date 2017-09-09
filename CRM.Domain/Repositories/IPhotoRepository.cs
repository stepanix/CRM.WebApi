

using CRM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.Domain.Repositories
{
    public interface IPhotoRepository : IBaseRepository<Photo>
    {
        Task<IEnumerable<Photo>> GetPhotos();
        Task<IEnumerable<Photo>> GetPhotos(DateTime dateFrom, DateTime dateTo);
        Task<Photo> GetPhoto(int id);
        Task<Photo> InsertPhoto(Photo place);
        Task<Photo> UpdatePhoto(Photo place);
        void DeletePhoto(int id);
    }
}

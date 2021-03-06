﻿

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
        Task<IEnumerable<Photo>> GetPhotos(DateTime dateFrom, DateTime dateTo, string rep, int place);
        Task<IEnumerable<Photo>> GetPhotos(DateTime dateFrom, DateTime dateTo, string rep);
        Task<IEnumerable<Photo>> GetPhotos(DateTime dateFrom, DateTime dateTo, int place);
        Task<Photo> GetPhoto(int id);
        Task<Photo> GetPhoto(string repoId);
        Task<Photo> InsertPhoto(Photo photo);
        IEnumerable<Photo> InsertPhotoList(IEnumerable<Photo> photos);
        Task<Photo> UpdatePhoto(Photo place);
        void DeletePhoto(int id);
    }
}

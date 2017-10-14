

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CRM.Domain.Entities;
using CRM.Domain.Repositories;
using CRM.Domain.RequestIdentity;
using CRM.EntityFramework.Repositories.Base;
using System.Linq;
using System.Data.Entity;

namespace CRM.EntityFramework.Repositories
{
    public class PhotoRepository : ORMBaseRepository<Photo, int>, IPhotoRepository
    {
        IRequestIdentityProvider requestIdentityProvider;

        public PhotoRepository(DataContext context, IRequestIdentityProvider requestIdentityProvider) : base(context)
        {
            this.requestIdentityProvider = requestIdentityProvider;
        }

        public void DeletePhoto(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Photo> GetPhoto(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Photo>> GetPhotos()
        {
            var user = await GetDataContext().Users.Where(u => u.Id == requestIdentityProvider.UserId).FirstOrDefaultAsync();
            return await GetDataContext()
               .Photos
               .Where(t => t.TenantId == user.TenantId && t.IsDeleted == false)
               .ToListAsync();
        }

        public async Task<IEnumerable<Photo>> GetPhotos(DateTime dateFrom, DateTime dateTo)
        {
            var user = await GetDataContext().Users.Where(u => u.Id == requestIdentityProvider.UserId).FirstOrDefaultAsync();
            return await GetDataContext()
               .Photos
               .Where(t => t.TenantId == user.TenantId && t.IsDeleted == false
               && (DbFunctions.TruncateTime(t.AddedDate) >= dateFrom && DbFunctions.TruncateTime(t.AddedDate) <= dateTo))
               .Include(u=> u.CreatorUser)
               .Include(p=> p.Place)
               .ToListAsync();
        }

        public async Task<IEnumerable<Photo>> GetPhotos(DateTime dateFrom, DateTime dateTo, int place)
        {
            var user = await GetDataContext().Users.Where(u => u.Id == requestIdentityProvider.UserId).FirstOrDefaultAsync();
            return await GetDataContext()
               .Photos
               .Where(t => t.TenantId == user.TenantId && t.IsDeleted == false
               && (DbFunctions.TruncateTime(t.AddedDate) >= dateFrom && DbFunctions.TruncateTime(t.AddedDate) <= dateTo)
               && t.PlaceId == place
               )
               .Include(u=>u.CreatorUser)
               .Include(p=>p.Place)
               .ToListAsync();
        }

        public async Task<IEnumerable<Photo>> GetPhotos(DateTime dateFrom, DateTime dateTo, string rep)
        {
            var user = await GetDataContext().Users.Where(u => u.Id == requestIdentityProvider.UserId).FirstOrDefaultAsync();
            return await GetDataContext()
               .Photos
               .Where(t => t.TenantId == user.TenantId && t.IsDeleted == false
               && (DbFunctions.TruncateTime(t.AddedDate) >= dateFrom && DbFunctions.TruncateTime(t.AddedDate) <= dateTo)
               && t.CreatorUserId == rep
               )
               .Include(u=>u.CreatorUser)
               .Include(p=>p.Place)
               .ToListAsync();
        }

        public async Task<IEnumerable<Photo>> GetPhotos(DateTime dateFrom, DateTime dateTo, string rep, int place)
        {
            var user = await GetDataContext().Users.Where(u => u.Id == requestIdentityProvider.UserId).FirstOrDefaultAsync();
            return await GetDataContext()
               .Photos
               .Where(t => t.TenantId == user.TenantId && t.IsDeleted == false
               && (DbFunctions.TruncateTime(t.AddedDate) >= dateFrom && DbFunctions.TruncateTime(t.AddedDate) <= dateTo)
               && t.CreatorUserId == rep && t.PlaceId == place)
               .Include(u=>u.CreatorUser)
               .Include(p=>p.Place)
               .ToListAsync();
        }

        public IEnumerable<Photo> InsertPhotoList(IEnumerable<Photo> photos)
        {
            GetDataContext().Photos.AddRange(photos);
            return photos;
        }

        public Task<Photo> InsertPhoto(Photo photo)
        {
            throw new NotImplementedException();
        }

        public Task<Photo> UpdatePhoto(Photo place)
        {
            throw new NotImplementedException();
        }
    }
}

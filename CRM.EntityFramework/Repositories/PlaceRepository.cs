﻿using CRM.Domain.Entities;
using CRM.Domain.Repositories;
using CRM.EntityFramework.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;
using CRM.Domain.RequestIdentity;

namespace CRM.EntityFramework.Repositories
{
    public class PlaceRepository : ORMBaseRepository<Place, int>, IPlaceRepository
    {
        IRequestIdentityProvider requestIdentityProvider;

        public PlaceRepository(DataContext context, IRequestIdentityProvider requestIdentityProvider) : base(context)
        {
            this.requestIdentityProvider = requestIdentityProvider;
        }

        public void DeletePlace(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Place> GetPlace(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Place>> GetPlaces()
        {
            var user = await GetDataContext().Users.Where(u => u.Id == requestIdentityProvider.UserId).FirstOrDefaultAsync();
            return await GetDataContext()
               .Places
               .Where(t => t.TenantId == user.TenantId && t.IsDeleted == false)
               .ToListAsync();
        }

        public async Task<IEnumerable<Place>> GetPlaces(DateTime dateFrom, DateTime dateTo)
        {
            var user = await GetDataContext().Users.Where(u => u.Id == requestIdentityProvider.UserId).FirstOrDefaultAsync();
            return await GetDataContext()
               .Places
               .Where(t => t.TenantId == user.TenantId && (DbFunctions.TruncateTime(t.AddedDate) >= dateFrom && DbFunctions.TruncateTime(t.AddedDate) <= dateTo)
               && !GetDataContext().Schedules.Any(p => p.PlaceId == t.Id && p.IsDeleted == false))
               .Include(u=>u.CreatorUser)
               .ToListAsync();
        }

        public async Task<IEnumerable<Place>> GetPlaces(DateTime dateFrom, DateTime dateTo, int place)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Place>> GetPlaces(DateTime dateFrom, DateTime dateTo, string rep)
        {
            var user = await GetDataContext().Users.Where(u => u.Id == requestIdentityProvider.UserId).FirstOrDefaultAsync();
            return await GetDataContext()
               .Places
               .Where(t => t.TenantId == user.TenantId && t.CreatorUserId==rep && (DbFunctions.TruncateTime(t.AddedDate) >= dateFrom && DbFunctions.TruncateTime(t.AddedDate) <= dateTo)
               && !GetDataContext().Schedules.Any(p => p.PlaceId == t.Id && p.IsDeleted == false))
               .Include(u=>u.CreatorUser)
               .ToListAsync();
        }

        public Task<IEnumerable<Place>> GetPlaces(DateTime dateFrom, DateTime dateTo, string rep, int place)
        {
            throw new NotImplementedException();
        }

        public Task<Place> InsertPlace(Place place)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Place> InsertPlaceList(IEnumerable<Place> places)
        {
            GetDataContext().Places.AddRange(places);
            return places;
        }

        public Task<Place> UpdatePlace(Place place)
        {
            throw new NotImplementedException();
        }
    }
}

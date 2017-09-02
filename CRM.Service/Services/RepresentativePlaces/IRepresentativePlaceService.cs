﻿using CRM.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.Service.Services.RepresentativePlaces
{
    public interface IRepresentativePlaceService
    {
        Task<IEnumerable<RepresentativePlaceModel>> GetRepresentativePlaceAsync();
        Task<RepresentativePlaceModel> GetRepresentativePlaceAsync(int id);
        Task<RepresentativePlaceModel> InsertRepresentativePlaceAsync(RepresentativePlaceModel representativePlace);
        Task<RepresentativePlaceModel> UpdateRepresentativePlaceAsync(RepresentativePlaceModel representativePlace);
        void DeleteRepresentativePlace(int id);
    }
}
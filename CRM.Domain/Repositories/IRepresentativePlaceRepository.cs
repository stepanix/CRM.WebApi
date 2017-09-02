﻿using CRM.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.Domain.Repositories
{
    public interface IRepresentativePlaceRepository : IBaseRepository<RepresentativePlace>
    {
        Task<IEnumerable<RepresentativePlace>> GetRepresentativePlaces();
        Task<RepresentativePlace> GetRepresentativePlace(int id);
        Task<RepresentativePlace> InsertRepresentativePlace(RepresentativePlace representativePlace);
        Task<RepresentativePlace> UpdateRepresentativePlace(RepresentativePlace representativePlace);
        void DeleteProductRetailAudit(int id);
    }
}

using CRM.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.Service.Services.RepresentativePlaces
{
    public interface IRepresentativePlaceService
    {
        Task<IEnumerable<RepresentativePlaceModel>> GetRepresentativePlaceAsync();
        Task<RepresentativePlaceModel> GetRepresentativePlaceAsync(int id);
        Task<IEnumerable<RepresentativePlaceModel>> GetRepresentativeByPlaceIdAsync(int placeId);
        Task<RepresentativePlaceModel> InsertRepresentativePlaceAsync(RepresentativePlaceModel representativePlace);
        Task<IEnumerable<RepresentativePlaceModel>> InsertRepresentativePlaceListAsync(IEnumerable<RepresentativePlaceModel> representativePlace);
        Task<RepresentativePlaceModel> UpdateRepresentativePlaceAsync(RepresentativePlaceModel representativePlace);
        void DeleteRepresentativePlace(int id);
    }
}

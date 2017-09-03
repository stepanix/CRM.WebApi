
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CRM.Domain.Model;
using CRM.Domain.Repositories;
using AutoMapper;
using CRM.Domain.Entities;

namespace CRM.Service.Services.Tenants
{
    public class TenantService : ITenantService
    {
        ITenantRepository tenantRepository;
        IMapper mapper;

        public TenantService(IMapper mapper, ITenantRepository tenantRepository)
        {
            this.mapper = mapper;
            this.tenantRepository = tenantRepository;
        }

        public void DeleteTenant(int id)
        {
            tenantRepository.Delete(id);
        }

        public async Task<TenantModel> GetTenantAsync(int id)
        {
            return mapper.Map<TenantModel>(await tenantRepository.GetAsync(id));
        }

        public async Task<IEnumerable<TenantModel>> GetTenantsAsync()
        {
            return mapper.Map<IEnumerable<TenantModel>>(await tenantRepository.GetAllAsync());
        }

        public async Task<TenantModel> InsertTenantAsync(TenantModel tenant)
        {
            tenant.AddedDate = DateTime.Now;
            var newTenant = await tenantRepository.InsertAsync(mapper.Map<Tenant>(tenant));
            await tenantRepository.SaveChangesAsync();
            return mapper.Map<TenantModel>(newTenant);
        }

        public async Task<TenantModel> UpdateTenantAsync(TenantModel tenant)
        {
            var tenantForUpdate = await tenantRepository.GetAsync(tenant.Id);
            tenantForUpdate.ModifiedDate = DateTime.Now;
            tenantForUpdate.Name = tenant.Name;
            await tenantRepository.SaveChangesAsync();
            return mapper.Map<TenantModel>(tenantForUpdate);
        }

    }
}

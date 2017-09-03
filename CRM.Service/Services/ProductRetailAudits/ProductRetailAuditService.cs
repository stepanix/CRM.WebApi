using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CRM.Domain.Model;
using CRM.Domain.Repositories;
using AutoMapper;
using CRM.Domain.Entities;
using CRM.Domain.RequestIdentity;

namespace CRM.Service.Services.ProductRetailAudits
{
    public class ProductRetailAuditService : IProductRetailAuditService
    {

        IProductRetailAuditRepository productRetailAuditRepository;
        IMapper mapper;
        IUserRepository userRepository;
        IRequestIdentityProvider requestIdentityProvider;

        public ProductRetailAuditService(IMapper mapper, IProductRetailAuditRepository productRetailAuditRepository, IUserRepository userRepository, IRequestIdentityProvider requestIdentityProvider)
        {
            this.mapper = mapper;
            this.productRetailAuditRepository = productRetailAuditRepository;
            this.userRepository = userRepository;
            this.requestIdentityProvider = requestIdentityProvider;
        }

        public void DeleteProductRetailAudit(int id)
        {
            productRetailAuditRepository.Delete(id);
        }

        public async Task<ProductRetailAuditModel> GetProductRetailAuditAsync(int id)
        {
            return mapper.Map<ProductRetailAuditModel>(await productRetailAuditRepository.GetAsync(id));
        }

        public async Task<IEnumerable<ProductRetailAuditModel>> GetProductRetailAuditsAsync()
        {
            return mapper.Map<IEnumerable<ProductRetailAuditModel>>(await productRetailAuditRepository.GetAllAsync());
        }

        public async Task<ProductRetailAuditModel> InsertProductRetailAuditAsync(ProductRetailAuditModel productRetailAudit)
        {
            var user = await userRepository.GetUser();
            productRetailAudit.AddedDate = DateTime.Now;
            productRetailAudit.TenantId = user.TenantId;
            productRetailAudit.CreatorUserId = requestIdentityProvider.UserId;
            productRetailAudit.LastModifierUserId = requestIdentityProvider.UserId;
            var newProductRetailAudit = await productRetailAuditRepository.InsertAsync(mapper.Map<ProductRetailAudit>(productRetailAudit));
            await productRetailAuditRepository.SaveChangesAsync();
            return mapper.Map<ProductRetailAuditModel>(newProductRetailAudit);
        }

        public async Task<ProductRetailAuditModel> UpdateProductRetailAuditAsync(ProductRetailAuditModel productRetailAudit)
        {
            var user = await userRepository.GetUser();

            var productRetailAuditForUpdate = await productRetailAuditRepository.GetAsync(productRetailAudit.Id);
            productRetailAuditForUpdate.ModifiedDate = DateTime.Now;
            productRetailAuditForUpdate.PlaceId = productRetailAudit.PlaceId;
            productRetailAuditForUpdate.RetailAuditFormId = productRetailAudit.RetailAuditFormId;
            productRetailAuditForUpdate.RetailAuditFormFieldValues = productRetailAudit.RetailAuditFormFieldValues;
            productRetailAuditForUpdate.TenantId = user.TenantId;
            productRetailAuditForUpdate.LastModifierUserId = requestIdentityProvider.UserId;
            await productRetailAuditRepository.SaveChangesAsync();
            return mapper.Map<ProductRetailAuditModel>(productRetailAuditForUpdate);
        }
    }
}

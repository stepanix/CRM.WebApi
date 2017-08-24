using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CRM.Domain.Model;
using CRM.Domain.Repositories;
using AutoMapper;
using CRM.Domain.Entities;

namespace CRM.Service.Services.ProductRetailAudits
{
    public class ProductRetailAuditService : IProductRetailAuditService
    {

        IProductRetailAuditRepository productRetailAuditRepository;
        IMapper mapper;

        public ProductRetailAuditService(IMapper mapper, IProductRetailAuditRepository productRetailAuditRepository)
        {
            this.mapper = mapper;
            this.productRetailAuditRepository = productRetailAuditRepository;
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
            productRetailAudit.AddedDate = DateTime.Now;
            var newProductRetailAudit = await productRetailAuditRepository.InsertAsync(mapper.Map<ProductRetailAudit>(productRetailAudit));
            await productRetailAuditRepository.SaveChangesAsync();
            return mapper.Map<ProductRetailAuditModel>(newProductRetailAudit);
        }

        public async Task<ProductRetailAuditModel> UpdateProductRetailAuditAsync(ProductRetailAuditModel productRetailAudit)
        {
            var productRetailAuditForUpdate = await productRetailAuditRepository.GetAsync(productRetailAudit.Id);
            productRetailAuditForUpdate.ModifiedDate = DateTime.Now;
            productRetailAuditForUpdate.PlaceId = productRetailAudit.PlaceId;
            productRetailAuditForUpdate.RetailAuditFormId = productRetailAudit.RetailAuditFormId;
            productRetailAuditForUpdate.RetailAuditFormFieldValues = productRetailAudit.RetailAuditFormFieldValues;

            await productRetailAuditRepository.SaveChangesAsync();
            return mapper.Map<ProductRetailAuditModel>(productRetailAuditForUpdate);
        }
    }
}

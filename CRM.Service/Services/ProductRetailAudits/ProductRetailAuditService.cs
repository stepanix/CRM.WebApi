﻿using System;
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
            return mapper.Map<IEnumerable<ProductRetailAuditModel>>(await productRetailAuditRepository.GetProductRetailAudits());
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
            productRetailAuditForUpdate.ScheduleId = productRetailAudit.ScheduleId;
            productRetailAuditForUpdate.LastModifierUserId = requestIdentityProvider.UserId;
            await productRetailAuditRepository.SaveChangesAsync();
            return mapper.Map<ProductRetailAuditModel>(productRetailAuditForUpdate);
        }

        public async Task<IEnumerable<ProductRetailAuditModel>> GetProductRetailAuditsAsync(DateTime dateFrom, DateTime dateTo)
        {
            return mapper.Map<IEnumerable<ProductRetailAuditModel>>(await productRetailAuditRepository.GetProductRetailAudits(dateFrom,dateTo));
        }

        public async Task<IEnumerable<ProductRetailAuditModel>> GetProductRetailAuditsAsync(DateTime dateFrom, DateTime dateTo, string rep)
        {
            return mapper.Map<IEnumerable<ProductRetailAuditModel>>(await productRetailAuditRepository.GetProductRetailAudits(dateFrom, dateTo, rep));
        }

        public async Task<IEnumerable<ProductRetailAuditModel>> GetProductRetailAuditsAsync(DateTime dateFrom, DateTime dateTo, int place)
        {
            return mapper.Map<IEnumerable<ProductRetailAuditModel>>(await productRetailAuditRepository.GetProductRetailAudits(dateFrom, dateTo, place));
        }

        public async Task<IEnumerable<ProductRetailAuditModel>> GetProductRetailAuditsAsync(DateTime dateFrom, DateTime dateTo, string rep, int place)
        {
            return mapper.Map<IEnumerable<ProductRetailAuditModel>>(await productRetailAuditRepository.GetProductRetailAudits(dateFrom, dateTo, rep, place));
        }

        public async Task<IEnumerable<ProductRetailAuditModel>> InsertProductRetailAuditListAsync(IEnumerable<ProductRetailAuditModel> productRetailAudits)
        {
            var user = await userRepository.GetUser();

            List<ProductRetailAuditModel> productRetailList = new List<ProductRetailAuditModel>();

            foreach (var productRetailAudit in productRetailAudits)
            {
                var productRetailVar = new ProductRetailAuditModel
                {
                    RepoId = productRetailAudit.RepoId,
                    Available = productRetailAudit.Available,
                    Promoted = productRetailAudit.Promoted,
                    Price = productRetailAudit.Price,
                    StockLevel = productRetailAudit.StockLevel,
                    Note = productRetailAudit.Note,
                    SyncId = productRetailAudit.SyncId,
                    PlaceId = productRetailAudit.PlaceId,
                    ScheduleId = productRetailAudit.ScheduleId,
                    RetailAuditFormId = productRetailAudit.RetailAuditFormId,
                    RetailAuditFormFieldValues = productRetailAudit.RetailAuditFormFieldValues,
                    AddedDate = DateTime.Now,
                    TenantId = user.TenantId,
                    CreatorUserId = requestIdentityProvider.UserId,
                    LastModifierUserId = requestIdentityProvider.UserId
                };
                productRetailList.Add(productRetailVar);
            }
            var newProductRetailAuditList = productRetailAuditRepository.InsertProductRetailAuditList(mapper.Map<IEnumerable<ProductRetailAudit>>(productRetailList));
            await productRetailAuditRepository.SaveChangesAsync();
            return productRetailList;
        }
    }
}

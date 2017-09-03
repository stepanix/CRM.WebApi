using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CRM.Domain.Model;
using CRM.Domain.Repositories;
using AutoMapper;
using CRM.Domain.Entities;
using CRM.Domain.RequestIdentity;

namespace CRM.Service.Services.RetailAuditForms
{
    public class RetailAuditFormService : IRetailAuditFormService
    {

        IRetailAuditFormRepository retailAuditFormRepository;
        IMapper mapper;
        IUserRepository userRepository;
        IRequestIdentityProvider requestIdentityProvider;

        public RetailAuditFormService(IMapper mapper, IRetailAuditFormRepository retailAuditFormRepository, IRequestIdentityProvider requestIdentityProvider, IUserRepository userRepository)
        {
            this.mapper = mapper;
            this.retailAuditFormRepository = retailAuditFormRepository;
            this.userRepository = userRepository;
            this.requestIdentityProvider = requestIdentityProvider;
        }

        public void DeleteRetailAuditForm(int id)
        {
            retailAuditFormRepository.Delete(id);
        }

        public async Task<RetailAuditFormModel> GetRetailAuditFormAsync(int id)
        {
            return mapper.Map<RetailAuditFormModel>(await retailAuditFormRepository.GetAsync(id));
        }

        public async Task<IEnumerable<RetailAuditFormModel>> GetRetailAuditFormsAsync()
        {
            return mapper.Map<IEnumerable<RetailAuditFormModel>>(await retailAuditFormRepository.GetAllAsync());
        }

        public async Task<RetailAuditFormModel> InsertRetailAuditFormAsync(RetailAuditFormModel retailAuditForm)
        {
            var user = await userRepository.GetUser();

            retailAuditForm.AddedDate = DateTime.Now;
            retailAuditForm.TenantId = user.TenantId;
            retailAuditForm.CreatorUserId = requestIdentityProvider.UserId;
            retailAuditForm.LastModifierUserId = requestIdentityProvider.UserId;
            var newRetailAudit = await retailAuditFormRepository.InsertAsync(mapper.Map<RetailAuditForm>(retailAuditForm));
            await retailAuditFormRepository.SaveChangesAsync();
            return mapper.Map<RetailAuditFormModel>(newRetailAudit);
        }

        public async  Task<RetailAuditFormModel> UpdateRetailAuditFormAsync(RetailAuditFormModel retailAuditForm)
        {
            var user = await userRepository.GetUser();
            var retailAuditFormForUpdate = await retailAuditFormRepository.GetAsync(retailAuditForm.Id);

            retailAuditFormForUpdate.ModifiedDate = DateTime.Now;
            retailAuditFormForUpdate.Available = retailAuditForm.Available;
            retailAuditFormForUpdate.Description = retailAuditForm.Description;
            retailAuditFormForUpdate.Name = retailAuditForm.Name;
            retailAuditFormForUpdate.Note = retailAuditForm.Note;
            retailAuditFormForUpdate.Price = retailAuditForm.Price;
            retailAuditFormForUpdate.Fields = retailAuditForm.Fields;
            retailAuditFormForUpdate.Promoted = retailAuditForm.Promoted;
            retailAuditFormForUpdate.StockLevel = retailAuditForm.StockLevel;

            retailAuditFormForUpdate.TenantId = user.TenantId;
            retailAuditFormForUpdate.LastModifierUserId = requestIdentityProvider.UserId;

            await retailAuditFormRepository.SaveChangesAsync();
            return mapper.Map<RetailAuditFormModel>(retailAuditFormForUpdate);
        }
    }
}

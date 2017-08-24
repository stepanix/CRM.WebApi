using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Domain.Model;
using CRM.Domain.Repositories;
using AutoMapper;
using CRM.Domain.Entities;

namespace CRM.Service.Services.RetailAuditForms
{
    public class RetailAuditFormService : IRetailAuditFormService
    {

        IRetailAuditFormRepository retailAuditFormRepository;
        IMapper mapper;

        public RetailAuditFormService(IMapper mapper, IRetailAuditFormRepository retailAuditFormRepository)
        {
            this.mapper = mapper;
            this.retailAuditFormRepository = retailAuditFormRepository;
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
            retailAuditForm.AddedDate = DateTime.Now;
            var newRetailAudit = await retailAuditFormRepository.InsertAsync(mapper.Map<RetailAuditForm>(retailAuditForm));
            await retailAuditFormRepository.SaveChangesAsync();
            return mapper.Map<RetailAuditFormModel>(newRetailAudit);
        }

        public async  Task<RetailAuditFormModel> UpdateRetailAuditFormAsync(RetailAuditFormModel retailAuditForm)
        {
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

            await retailAuditFormRepository.SaveChangesAsync();
            return mapper.Map<RetailAuditFormModel>(retailAuditFormForUpdate);
        }
    }
}

using CRM.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CRM.Domain.Model;
using AutoMapper;
using CRM.Domain.Entities;

namespace CRM.Service.Services.Forms
{
    public class FormService : IFormService
    {
        IFormRepository formRepository;
        IMapper mapper;

        public FormService(IMapper mapper, IFormRepository formRepository)
        {
            this.mapper = mapper;
            this.formRepository = formRepository;
        }

        public void DeleteForm(int id)
        {
            formRepository.Delete(id);
        }

        public async Task<FormModel> GetFormAsync(int id)
        {
            return mapper.Map<FormModel>(await formRepository.GetAsync(id));
        }

        public async Task<IEnumerable<FormModel>> GetFormsAsync()
        {
            return mapper.Map<IEnumerable<FormModel>>(await formRepository.GetAllAsync());
        }

        public async Task<FormModel> InsertFormAsync(FormModel form)
        {
            form.AddedDate = DateTime.Now;
            var newForm = await formRepository.InsertAsync(mapper.Map<Form>(form));
            await formRepository.SaveChangesAsync();
            return mapper.Map<FormModel>(newForm);
        }

        public async Task<FormModel> UpdateFormAsync(FormModel form)
        {
            var formForUpdate = await formRepository.GetAsync(form.Id);
            formForUpdate.ModifiedDate = DateTime.Now;
            formForUpdate.Description = form.Description;
            formForUpdate.Title = form.Title;
            formForUpdate.Fields = form.Fields;
            await formRepository.SaveChangesAsync();
            return mapper.Map<FormModel>(formForUpdate);
        }
    }
}

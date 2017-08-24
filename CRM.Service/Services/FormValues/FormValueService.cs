using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CRM.Domain.Model;
using CRM.Domain.Repositories;
using AutoMapper;
using CRM.Domain.Entities;

namespace CRM.Service.Services.FormValues
{
    public class FormValueService : IFormValueService
    {
        IFormValueRepository formValueRepository;
        IMapper mapper;

        public FormValueService(IMapper mapper, IFormValueRepository formValueRepository)
        {
            this.mapper = mapper;
            this.formValueRepository = formValueRepository;
        }

        public void DeleteFormValue(int id)
        {
            formValueRepository.Delete(id);
        }

        public async Task<FormValueModel> GetFormValueAsync(int id)
        {
            return mapper.Map<FormValueModel>(await formValueRepository.GetAsync(id));
        }

        public async Task<IEnumerable<FormValueModel>> GetFormValuesAsync()
        {
            return mapper.Map<IEnumerable<FormValueModel>>(await formValueRepository.GetAllAsync());
        }

        public async Task<FormValueModel> InsertFormValueAsync(FormValueModel formValue)
        {
            formValue.AddedDate = DateTime.Now;
            var newFormValue = await formValueRepository.InsertAsync(mapper.Map<FormValue>(formValue));
            await formValueRepository.SaveChangesAsync();
            return mapper.Map<FormValueModel>(newFormValue);
        }

        public async Task<FormValueModel> UpdateFormValueAsync(FormValueModel formValue)
        {
            var formValueForUpdate = await formValueRepository.GetAsync(formValue.Id);
            formValueForUpdate.ModifiedDate = DateTime.Now;
            formValueForUpdate.FormFieldValues = formValue.FormFieldValues;
            formValueForUpdate.FormId = formValue.FormId;
            formValueForUpdate.PlaceId = formValue.PlaceId;
            await formValueRepository.SaveChangesAsync();
            return mapper.Map<FormValueModel>(formValueForUpdate);
        }
    }
}

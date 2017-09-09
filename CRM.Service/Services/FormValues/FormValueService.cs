using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CRM.Domain.Model;
using CRM.Domain.Repositories;
using AutoMapper;
using CRM.Domain.Entities;
using CRM.Domain.RequestIdentity;

namespace CRM.Service.Services.FormValues
{
    public class FormValueService : IFormValueService
    {
        IFormValueRepository formValueRepository;
        IMapper mapper;
        IUserRepository userRepository;
        IRequestIdentityProvider requestIdentityProvider;

        public FormValueService(IMapper mapper, IFormValueRepository formValueRepository, IUserRepository userRepository, IRequestIdentityProvider requestIdentityProvider)
        {
            this.mapper = mapper;
            this.formValueRepository = formValueRepository;
            this.userRepository = userRepository;
            this.requestIdentityProvider = requestIdentityProvider;
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
            return mapper.Map<IEnumerable<FormValueModel>>(await formValueRepository.GetFormValues());
        }

        public async Task<FormValueModel> InsertFormValueAsync(FormValueModel formValue)
        {
            var user = await userRepository.GetUser();

            formValue.AddedDate = DateTime.Now;

            formValue.TenantId = user.TenantId;
            formValue.CreatorUserId = requestIdentityProvider.UserId;
            formValue.LastModifierUserId = requestIdentityProvider.UserId;

            var newFormValue = await formValueRepository.InsertAsync(mapper.Map<FormValue>(formValue));
            await formValueRepository.SaveChangesAsync();
            return mapper.Map<FormValueModel>(newFormValue);
        }

        public async Task<FormValueModel> UpdateFormValueAsync(FormValueModel formValue)
        {
            var formValueForUpdate = await formValueRepository.GetAsync(formValue.Id);
            var user = await userRepository.GetUser();

            formValueForUpdate.ModifiedDate = DateTime.Now;
            formValueForUpdate.FormFieldValues = formValue.FormFieldValues;
            formValueForUpdate.FormId = formValue.FormId;
            formValueForUpdate.PlaceId = formValue.PlaceId;
            formValueForUpdate.ScheduleId = formValue.ScheduleId;
            formValueForUpdate.TenantId = user.TenantId;
            formValueForUpdate.LastModifierUserId = requestIdentityProvider.UserId;
            await formValueRepository.SaveChangesAsync();
            return mapper.Map<FormValueModel>(formValueForUpdate);
        }

        public async Task<IEnumerable<FormValueModel>> GetFormValuesAsync(DateTime dateFrom, DateTime dateTo)
        {
            return mapper.Map<IEnumerable<FormValueModel>>(await formValueRepository.GetFormValues(dateFrom,dateTo));
        }

        public async Task<IEnumerable<FormValueModel>> GetFormValuesAsync(DateTime dateFrom, DateTime dateTo, string rep)
        {
            return mapper.Map<IEnumerable<FormValueModel>>(await formValueRepository.GetFormValues(dateFrom, dateTo,rep));
        }

        public async Task<IEnumerable<FormValueModel>> GetFormValuesAsync(DateTime dateFrom, DateTime dateTo, int place)
        {
            return mapper.Map<IEnumerable<FormValueModel>>(await formValueRepository.GetFormValues(dateFrom, dateTo, place));
        }

        public async Task<IEnumerable<FormValueModel>> GetFormValuesAsync(DateTime dateFrom, DateTime dateTo, string rep, int place)
        {
            return mapper.Map<IEnumerable<FormValueModel>>(await formValueRepository.GetFormValues(dateFrom, dateTo, rep,place));
        }
    }
}

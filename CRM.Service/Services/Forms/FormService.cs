using CRM.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CRM.Domain.Model;
using AutoMapper;
using CRM.Domain.Entities;
using CRM.Domain.RequestIdentity;

namespace CRM.Service.Services.Forms
{
    public class FormService : IFormService
    {
        IFormRepository formRepository;
        IMapper mapper;
        IUserRepository userRepository;
        IRequestIdentityProvider requestIdentityProvider;


        public FormService(IMapper mapper, IFormRepository formRepository, IUserRepository userRepository, IRequestIdentityProvider requestIdentityProvider)
        {
            this.mapper = mapper;
            this.formRepository = formRepository;
            this.userRepository = userRepository;
            this.requestIdentityProvider = requestIdentityProvider;
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
            return mapper.Map<IEnumerable<FormModel>>(await formRepository.GetForms());
        }

        public async Task<FormModel> InsertFormAsync(FormModel form)
        {
            form.AddedDate = DateTime.Now;
            var user = await userRepository.GetUser();

            form.TenantId = user.TenantId;
            form.CreatorUserId = requestIdentityProvider.UserId;
            form.LastModifierUserId = requestIdentityProvider.UserId;
            var newForm = await formRepository.InsertAsync(mapper.Map<Form>(form));
            await formRepository.SaveChangesAsync();
            return mapper.Map<FormModel>(newForm);
        }

        public async Task<FormModel> UpdateFormAsync(FormModel form)
        {
            var formForUpdate = await formRepository.GetAsync(form.Id);
            var user = await userRepository.GetUser();

            formForUpdate.ModifiedDate = DateTime.Now;
            formForUpdate.Description = form.Description;
            formForUpdate.Title = form.Title;
            formForUpdate.Fields = form.Fields;
            formForUpdate.TenantId = user.TenantId;
            formForUpdate.LastModifierUserId = requestIdentityProvider.UserId;
            await formRepository.SaveChangesAsync();
            return mapper.Map<FormModel>(formForUpdate);
        }
    }
}

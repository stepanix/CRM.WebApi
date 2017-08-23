using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CRM.Domain.Model;
using CRM.Domain.Repositories;
using AutoMapper;
using CRM.Domain.Entities;

namespace CRM.Service.Services.QuestionTypes
{
    public class QuestionTypeService : IQuestionTypeService
    {
        IQuestionTypeRepository questionTypeRepository;
        IMapper mapper;

        public QuestionTypeService(IMapper mapper, IQuestionTypeRepository questionTypeRepository)
        {
            this.mapper = mapper;
            this.questionTypeRepository = questionTypeRepository;
        }

        public void DeleteQuestionType(int id)
        {
            questionTypeRepository.Delete(id);
        }

        public async Task<QuestionTypeModel> GetQuestionTypeAsync(int id)
        {
            return mapper.Map<QuestionTypeModel>(await questionTypeRepository.GetAsync(id));
        }

        public async Task<IEnumerable<QuestionTypeModel>> GetQuestionTypesAsync()
        {
            return mapper.Map<IEnumerable<QuestionTypeModel>>(await questionTypeRepository.GetAllAsync());
        }

        public async Task<QuestionTypeModel> InsertQuestionTypeAsync(QuestionTypeModel questionType)
        {
            questionType.AddedDate = DateTime.Now;
            var newQuestionType = await questionTypeRepository.InsertAsync(mapper.Map<QuestionType>(questionType));
            await questionTypeRepository.SaveChangesAsync();
            return mapper.Map<QuestionTypeModel>(newQuestionType);
        }

        public async Task<QuestionTypeModel> UpdateQuestionTypeAsync(QuestionTypeModel questionType)
        {
            var questionTypeForUpdate = await questionTypeRepository.GetAsync(questionType.Id);
            questionTypeForUpdate.ModifiedDate = DateTime.Now;
            questionTypeForUpdate.Name = questionTypeForUpdate.Name;

            await questionTypeRepository.SaveChangesAsync();
            return mapper.Map<QuestionTypeModel>(questionTypeForUpdate);
        }
    }
}

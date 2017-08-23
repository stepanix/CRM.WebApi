using CRM.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Service.Services.QuestionTypes
{
    public interface IQuestionTypeService
    {
        Task<IEnumerable<QuestionTypeModel>> GetQuestionTypesAsync();
        Task<QuestionTypeModel> GetQuestionTypeAsync(int id);
        Task<QuestionTypeModel> InsertQuestionTypeAsync(QuestionTypeModel questionType);
        Task<QuestionTypeModel> UpdateQuestionTypeAsync(QuestionTypeModel questionType);
        void DeleteQuestionType(int id);
    }
}

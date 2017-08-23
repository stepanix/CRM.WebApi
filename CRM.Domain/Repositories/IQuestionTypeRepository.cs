using CRM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Repositories
{
    public interface IQuestionTypeRepository : IBaseRepository<QuestionType>
    {
        Task<IEnumerable<QuestionType>> GetQuestionTypes();
        Task<QuestionType> GetQuestionType(int id);
        Task<QuestionType> InsertQuestionType(QuestionType questiontype);
        Task<QuestionType> UpdateQuestionType(QuestionType questionType);
        void DeleteQuestionType(int id);
    }
}

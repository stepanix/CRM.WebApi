using CRM.Domain.Entities;
using CRM.Domain.Repositories;
using CRM.EntityFramework.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.EntityFramework.Repositories
{
    public class QuestionTypeRepository : ORMBaseRepository<QuestionType, int>, IQuestionTypeRepository
    {
        public QuestionTypeRepository(DataContext context) : base(context)
        {
        }

        public void DeleteQuestionType(int id)
        {
            throw new NotImplementedException();
        }

        public Task<QuestionType> GetQuestionType(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<QuestionType>> GetQuestionTypes()
        {
            throw new NotImplementedException();
        }

        public Task<QuestionType> InsertQuestionType(QuestionType questiontype)
        {
            throw new NotImplementedException();
        }

        public Task<QuestionType> UpdateQuestionType(QuestionType questionType)
        {
            throw new NotImplementedException();
        }
    }
}

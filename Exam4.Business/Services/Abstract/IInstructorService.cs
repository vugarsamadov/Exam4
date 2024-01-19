using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam4.Business.Models;
using Exam4.Business.Models.Pagination;

namespace Exam4.Business.Services.Abstract
{
    public interface IInstructorService
    {

        public Task CreateInstructorAsync(CreateInstructorVM model);

        public Task UpdateInstructorAsync(int id, UpdateInstructorVM model);

        public Task SoftDeleteInstructorAsync(int id);
        public Task RevokeDeleteInstructorAsync(int id);

        public Task<GenericPaginatedModel<InstructorVM>> GetInstructorsPaginated(int currentpage,int perPage);
        public Task<IEnumerable<InstructorVM>> GetSliderInstructors();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam4.Core.Entities;
using Exam4.Infrastructure.Repositories.Abstract;

namespace Exam4.Infrastructure.Repositories
{
    public class InstructorRepository : GenericRepository<Instructor>, IInstructorRepository
    {
        private ApplicationDbContext _dbContext { get; }
        public InstructorRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }




    }
}

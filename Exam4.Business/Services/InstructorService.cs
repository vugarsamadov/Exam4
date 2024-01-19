using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Exam4.Business.Models;
using Exam4.Business.Models.Pagination;
using Exam4.Business.Services.Abstract;
using Exam4.Core.Entities;
using Exam4.Infrastructure.Repositories.Abstract;

namespace Exam4.Business.Services
{
    public class InstructorService : IInstructorService
    {

        private IGenericRepository<Instructor> _instructorRepository { get; }
        private IMapper _mapper { get; }

        public InstructorService(IGenericRepository<Instructor> instructorRepository,IMapper mapper)
        {
            _instructorRepository = instructorRepository;
            _mapper = mapper;
        }


        public async Task CreateInstructorAsync(CreateInstructorVM model)
        {
            var entity = _mapper.Map<Instructor>(model);
            await _instructorRepository.CreateAsync(entity);
            await _instructorRepository.SaveChangesAsync();
        }

        public async Task<GenericPaginatedModel<InstructorVM>> GetInstructorsPaginated(int currentpage, int perPage)
        {
            var entities = await _instructorRepository.GetAllAsync(currentpage, perPage, true, "SpecializedArea");
            var models = _mapper.Map<IEnumerable<InstructorVM>>(entities);
            var count = await _instructorRepository.GetCountAsync();
            var pModel = new GenericPaginatedModel<InstructorVM>(perPage, currentpage, count, models);
            return pModel;
        }

        public async Task<IEnumerable<InstructorVM>> GetSliderInstructors()
        {
            var entities = await _instructorRepository.GetAllAsync(null, null, false, "SpecializedArea");
            var models = _mapper.Map<IEnumerable<InstructorVM>>(entities);
            return models;
        }

        public async Task RevokeDeleteInstructorAsync(int id)
        {
            var entity = await _instructorRepository.GetByIdAsync(id,true);
            if(entity != null) 
                entity.RevokeDelete();
            await _instructorRepository.SaveChangesAsync();
        }

        public async Task SoftDeleteInstructorAsync(int id)
        {
            var entity = await _instructorRepository.GetByIdAsync(id, true);
            if (entity != null)
                entity.Delete();
            await _instructorRepository.SaveChangesAsync();
        }

        public async Task UpdateInstructorAsync(int id, UpdateInstructorVM model)
        {
            var entity = await _instructorRepository.GetByIdAsync(id, true);
            if (entity != null)
                _mapper.Map(model,entity);
            await _instructorRepository.SaveChangesAsync();
        }
    }
}

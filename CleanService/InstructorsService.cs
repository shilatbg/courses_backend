using Clean.Core.Entities;
using Clean.Core.Repositories;
using Clean.Core.Services;

namespace Clean.Service
{
    public class InstructorsService : IInstructorsService
    {
        private readonly IInstructorsRepositories _instructorsRepositories;

        public InstructorsService(IInstructorsRepositories instructorsRepositories)
        {
            _instructorsRepositories = instructorsRepositories;
        }

        public List<Instructors> GetList()
        {
            return _instructorsRepositories.GetAll();
        }

        public Instructors GetById(int id)
        {
            return _instructorsRepositories.GetById(id);
        }

        public Instructors Add(Instructors instructors)
        {
            return _instructorsRepositories.Add(instructors);
        }

        public Instructors Update(int id, Instructors instructors)
        {
            return _instructorsRepositories.Update(id, instructors);
        }

        public bool Delete(int id)
        {
            return _instructorsRepositories.Delete(id);
        }
    }
}

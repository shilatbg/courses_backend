using Clean.Core.Entities;
using Clean.Core.Repositories;
using Clean.Core.Services;

namespace Clean.Service
{
    public class StudentsService : IStudentsService
    {
        private readonly IStudentsRepositories _studentsRepositories;

        public StudentsService(IStudentsRepositories studentsRepositories)
        {
            _studentsRepositories = studentsRepositories;
        }

        public List<Students> GetList()
        {
            return _studentsRepositories.GetAll();
        }

        public Students GetById(int id)
        {
            return _studentsRepositories.GetById(id);
        }

        public Students Add(Students students)
        {
            return _studentsRepositories.Add(students);
        }

        public Students Update(int id, Students students)
        {
            return _studentsRepositories.Update(id, students);
        }

        public bool Delete(int id)
        {
            return _studentsRepositories.Delete(id);
        }
    }
}

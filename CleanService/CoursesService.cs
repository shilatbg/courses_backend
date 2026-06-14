using Clean.Core.Entities;
using Clean.Core.Repositories;
using Clean.Core.Services;

namespace Clean.Service
{
    public class CoursesService : ICoursesService
    {
        private readonly ICoursesRepositories _coursesRepositories;

        public CoursesService(ICoursesRepositories coursesRepositories)
        {
            _coursesRepositories = coursesRepositories;
        }

        public List<Courses> GetList()
        {
            return _coursesRepositories.GetAll();
        }

        public Courses GetById(int id)
        {
            return _coursesRepositories.GetById(id);
        }

        public Courses Add(Courses courses)
        {
            return _coursesRepositories.Add(courses);
        }

        public Courses Update(int id, Courses courses)
        {
            return _coursesRepositories.Update(id, courses);
        }

        public bool Delete(int id)
        {
            return _coursesRepositories.Delete(id);
        }
    }
}

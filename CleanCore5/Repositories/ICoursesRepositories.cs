using Clean.Core.Entities;

namespace Clean.Core.Repositories
{
    public interface ICoursesRepositories
    {
        List<Courses> GetAll();
        Courses GetById(int id);
        Courses Add(Courses courses);
        Courses Update(int id, Courses courses);
        bool Delete(int id);
    }
}

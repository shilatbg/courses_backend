using Clean.Core.Entities;

namespace Clean.Core.Services
{
    public interface ICoursesService
    {
        List<Courses> GetList();
        Courses GetById(int id);
        Courses Add(Courses courses);
        Courses Update(int id, Courses courses);
        bool Delete(int id);
    }
}

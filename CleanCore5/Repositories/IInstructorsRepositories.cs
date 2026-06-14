using Clean.Core.Entities;

namespace Clean.Core.Repositories
{
    public interface IInstructorsRepositories
    {
        List<Instructors> GetAll();
        Instructors GetById(int id);
        Instructors Add(Instructors instructors);
        Instructors Update(int id, Instructors instructors);
        bool Delete(int id);
    }
}

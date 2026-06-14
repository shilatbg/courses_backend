using Clean.Core.Entities;

namespace Clean.Core.Services
{
    public interface IInstructorsService
    {
        List<Instructors> GetList();
        Instructors GetById(int id);
        Instructors Add(Instructors instructors);
        Instructors Update(int id, Instructors instructors);
        bool Delete(int id);
    }
}

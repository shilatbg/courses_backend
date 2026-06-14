using Clean.Core.Entities;

namespace Clean.Core.Services
{
    public interface IStudentsService
    {
        List<Students> GetList();
        Students GetById(int id);
        Students Add(Students students);
        Students Update(int id, Students students);
        bool Delete(int id);
    }
}

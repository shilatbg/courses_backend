using Clean.Core.Entities;

namespace Clean.Core.Repositories
{
    public interface IStudentsRepositories
    {
        List<Students> GetAll();
        Students GetById(int id);
        Students Add(Students students);
        Students Update(int id, Students students);
        bool Delete(int id);
    }
}

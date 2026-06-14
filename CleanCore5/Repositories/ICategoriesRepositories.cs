using Clean.Core.Entities;

namespace Clean.Core.Repositories
{
    public interface ICategoriesRepositories
    {
        List<Categories> GetAll();
        Categories GetById(int id);
        Categories Add(Categories categories);
        Categories Update(int id, Categories categories);
        bool Delete(int id);
    }
}

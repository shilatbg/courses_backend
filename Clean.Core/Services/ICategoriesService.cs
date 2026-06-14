using Clean.Core.Entities;

namespace Clean.Core.Services
{
    public interface ICategoriesService
    {
        List<Categories> GetList();
        Categories GetById(int id);
        Categories Add(Categories categories);
        Categories Update(int id, Categories categories);
        bool Delete(int id);
    }
}

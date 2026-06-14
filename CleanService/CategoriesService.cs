using Clean.Core.Entities;
using Clean.Core.Repositories;
using Clean.Core.Services;

namespace Clean.Service
{
    public class CategoriesService : ICategoriesService
    {
        private readonly ICategoriesRepositories _categoriesRepositories;

        public CategoriesService(ICategoriesRepositories categoriesRepositories)
        {
            _categoriesRepositories = categoriesRepositories;
        }

        public List<Categories> GetList()
        {
            return _categoriesRepositories.GetAll();
        }

        public Categories GetById(int id)
        {
            return _categoriesRepositories.GetById(id);
        }

        public Categories Add(Categories categories)
        {
            return _categoriesRepositories.Add(categories);
        }

        public Categories Update(int id, Categories categories)
        {
            return _categoriesRepositories.Update(id, categories);
        }

        public bool Delete(int id)
        {
            return _categoriesRepositories.Delete(id);
        }
    }
}

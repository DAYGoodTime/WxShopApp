using Core.Base.Implementation;
using Core.Base.Interface;
using Entity.Model;
using Entity.TestDbA;
using Service.IServices;

namespace Service.Services
{
    public class CategoryServices : BaseServices<Category>, ICategoryServices
    {
        private readonly IBaseRepository<Category> _baseRepository;

        public CategoryServices(IBaseRepository<Category> baseRepository) : base(baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public bool AddCategory(Category category)
        {
            return _baseRepository.Add(category);
        }

        public List<Category> GetAllCategories()
        {
            return _baseRepository.SelectAll();
        }

        public Category GetCategory(Guid categoryId)
        {
            return _baseRepository.Find(c => c.category_id == categoryId);
        }

        public bool RemoveCategory(Guid categoryId)
        {
            return _baseRepository.Delete(c => c.category_id == categoryId);
        }
    }
}

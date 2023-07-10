using Core.Base.Implementation;
using Core.Base.Interface;
using Entity.TestDbA;
using Service.IServices;
using WxsAppShop.Entity.Model;

namespace Service.Services
{
    public class NewsServices : BaseServices<News>, INewsServices
    {
        private readonly IBaseRepository<News> _baseRepository;

        public NewsServices(IBaseRepository<News> baseRepository) : base(baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public bool Add(News entity)
        {
            return _baseRepository.Add(entity);
        }

        public News Get(Guid entity_id)
        {
            return _baseRepository.Find(n => n.news_id == entity_id);
        }

        public List<News> GetAll()
        {
            return _baseRepository.SelectAll();
        }

        public List<News> GetAll(Guid forging_key)
        {
            return _baseRepository.Select(n => n.author_id == forging_key);
        }

        public bool Remove(Guid entity_id)
        {
            return _baseRepository.Delete(n => n.news_id == entity_id);
        }
    }
}

using Core.Base.Implementation;
using Core.Base.Interface;
using Entity.TestDbA;
using Service.IServices;
using WxsAppShop.Entity.Model;

namespace Service.Services
{
    public class TopicServices : BaseServices<Topic>, ITopicServices
    {
        private readonly IBaseRepository<Topic> _baseRepository;

        public TopicServices(IBaseRepository<Topic> baseRepository) : base(baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public bool Add(Topic entity)
        {
            return _baseRepository.Add(entity);
        }

        public Topic Get(Guid entity_id)
        {
            return _baseRepository.Find(t => t.topic_id == entity_id);
        }

        public List<Topic> GetAll()
        {
            return _baseRepository.SelectAll();
        }

        public List<Topic> GetAll(Guid forging_key)
        {
            return _baseRepository.Select(t => t.author_id == forging_key);
        }

        public bool Remove(Guid entity_id)
        {
            return _baseRepository.Delete(v => v.topic_id == entity_id);
        }
    }
}

using Core.Base.Implementation;
using Core.Base.Interface;
using Entity.TestDbA;
using Service.IServices;
using WxsAppShop.Entity.Model;

namespace Service.Services
{
    public class VoteServices : BaseServices<Vote>, IVoteServices
    {
        private readonly IBaseRepository<Vote> _baseRepository;

        public VoteServices(IBaseRepository<Vote> baseRepository) : base(baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public bool Add(Vote entity)
        {
            return _baseRepository.Add(entity);
        }

        public Vote Get(Guid entity_id)
        {
            return _baseRepository.Find(v => v.vote_id == entity_id);
        }

        public List<Vote> GetAll()
        {
            return _baseRepository.SelectAll();
        }

        public List<Vote> GetAll(Guid forging_key)
        {
            return _baseRepository.Select(v => v.author_id == forging_key);
        }

        public bool Remove(Guid entity_id)
        {
            return _baseRepository.Delete(v => v.vote_id == entity_id);
        }
    }
}

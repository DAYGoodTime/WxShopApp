using Core.Base.Implementation;
using Core.Base.Interface;
using Core.Base.Interface.Auto_registration;
using Entity.TestDbA;
using Service.IServices;
using System.Linq.Expressions;
using WxsAppShop.Entity.Model;

namespace Service.Services
{
    public class VoiceServices : BaseServices<Voice>, IVoiceServices
    {
        private readonly IBaseRepository<Voice> _baseRepository;

        public VoiceServices(IBaseRepository<Voice> baseRepository) : base(baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public bool Add(Voice entity)
        {
            return _baseRepository.Add(entity);
        }

        public Voice Get(Guid entity_id)
        {
            return _baseRepository.Find(v=>v.voice_id == entity_id);
        }

        public List<Voice> GetAll()
        {
           return _baseRepository.SelectAll();
        }

        public List<Voice> GetAll(Guid forging_key)
        {
           return _baseRepository.Select(v=>v.author_id == forging_key);
        }

        public bool Remove(Guid entity_id)
        {
            return _baseRepository.Delete(v=>v.voice_id == entity_id);
        }
    }
}

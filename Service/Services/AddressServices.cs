using Core.Base.Implementation;
using Core.Base.Interface;
using Entity.Model;
using Entity.TestDbA;
using Service.IServices;

namespace Service.Services
{
    public class AddressServices : BaseServices<Address>, IAddressService
    {
        private readonly IBaseRepository<Address> _baseRepository;

        public AddressServices(IBaseRepository<Address> baseRepository) : base(baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public bool AddAddress(Address address)
        {
            return _baseRepository.Add(address);
        }

        public bool RemoveAddress(Guid address_id)
        {
            return _baseRepository.Delete(a => a.address_id == address_id);
        }

        public Address SelectAddress(Guid address_id)
        {
            return _baseRepository.Find(a => a.address_id == address_id);
        }

        public List<Address> SelectAllAddress(Guid user_id)
        {
            return _baseRepository.SelectAll();
        }
    }
}

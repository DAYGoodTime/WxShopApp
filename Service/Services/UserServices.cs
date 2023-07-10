using Core.Base.Implementation;
using Core.Base.Interface;
using EBike.Utils;
using Entity.Base;
using Entity.Enum;
using Entity.Model;
using Entity.Schemas;
using Entity.Vo;
using Omu.ValueInjecter;
using Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WxsAppShop.Entity.Model;

namespace Service.Services
{
    public class UserServices : BaseServices<User>, IUserServices
    {
        private readonly IBaseRepository<User> _repository;
        private readonly IBaseRepository<ShoppingCar> _shoppingCarRepository;
        private readonly IBaseRepository<Item> _itemRepository;
        private readonly IBaseRepository<Order> _orderRepository;
        private readonly IBaseRepository<Collection> _collectionRepository;

        public UserServices(
            IBaseRepository<User> baseRepository,
            IBaseRepository<ShoppingCar> shoppingCarRepository,
            IBaseRepository<Item> itemRep,
            IBaseRepository<Order> orderRep,
            IBaseRepository<Collection> collRep
            ) : base(baseRepository)
        {
            _repository = baseRepository;
            _shoppingCarRepository = shoppingCarRepository;
            _itemRepository = itemRep;
            _orderRepository = orderRep;
            _collectionRepository = collRep;
        }

        public Collection? addCollection(Collection collection)
        {
            bool success = _collectionRepository.Add(collection);
            if (success)
            {
                return collection;
            }
            else
            {
                return null;
            }
        }

        public List<Collection> getUserCollections(Guid userId)
        {
            return _collectionRepository.Select(c => c.user_id == userId);
        }

        public UserOrderSates getUserOrderStateCount(Guid userId)
        {
            return new UserOrderSates()
            {
                Pending = _orderRepository.Select(o => o.user_id == userId && o.order_state == OrderState.Pending_Payment).Count,
                Already_Paid = _orderRepository.Select(o => o.user_id == userId && o.order_state == OrderState.Already_Paid).Count,
                Shipping = _orderRepository.Select(o => o.user_id == userId && o.order_state == OrderState.Shipping).Count,
                Finished = _orderRepository.Select(o => o.user_id == userId && o.order_state == OrderState.Finished).Count,
            };
        }

        public List<ShoppingCar> getUserShoppingCar(Guid userId)
        {
            List<ShoppingCar> carList = _shoppingCarRepository.Select(c => c.user_id == userId);
            foreach (ShoppingCar item in carList)
            {
                item.item = _itemRepository.Find(i => i.item_id == item.item_id);
            }
            return carList;
        }

        public bool removeCollection(Guid collection_id)
        {
            return _collectionRepository.Delete(c => c.collection_id == collection_id);
        }

        public UserVo? updateUser(User user)
        {
            bool success = _baseRepository.Update(user);
            if (success)
            {
                return new UserVo().InjectFrom(user) as UserVo;
            }
            else
            {
                return null;
            }
        }

        public UserVo UserLogin(User user)
        {
            if (user.user_name == null || user.user_password == null)
            {
                throw new ServiceException(ServiceErrorCode.ArgumentNull, "用户或密码为空");
            }
            List<User> users = _repository.Select(u => u.user_name == user.user_name);
            if (users.Count > 1)
            {
                throw new ServiceException(ServiceErrorCode.UnExpectedError, "存在多个用户!");
            }
            else if (users.Count == 0)
            {
                throw new ServiceException(ServiceErrorCode.ArgumentError, "用户或密码错误");
            }
            if (users[0].user_password != HashUtils.HashStr(user.user_password))
            {
                throw new ServiceException(ServiceErrorCode.NormalError, "用户或密码错误");
            }
            return users[0].toVo();
        }

        public async Task<UserVo> UserRegistry(User user)
        {
            if (user.user_name == null || user.user_password == null)
            {
                throw new ServiceException(ServiceErrorCode.ArgumentNull, "用户或密码为空");
            }
            List<User> users = await _repository.SelectAsync(u => u.user_name == user.user_name);
            if (users.Count > 1)
            {
                throw new ServiceException(ServiceErrorCode.UnExpectedError, "存在多个用户!");
            }
            user.create_time = DateTime.Now;
            user.user_password = HashUtils.HashStr(user.user_password);
            bool success = await _repository.AddAsync(user);
            if (success)
            {
                return user.toVo();
            }
            else
            {
                throw new ServiceException(ServiceErrorCode.DbContextError, "添加失败!");
            }
        }
    }
}

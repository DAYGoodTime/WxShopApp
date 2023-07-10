using Core.Base.Interface;
using Core.Base.Interface.Auto_registration;
using Entity.Model;
using Entity.Vo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WxsAppShop.Entity.Model;

namespace Service.IServices
{
    public interface IUserServices : IBaseServices<User>, IScopedInterface
    {
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="user">用户对象</param>
        /// <returns></returns>
        public UserVo UserLogin(User user);

        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="user">预用户对象</param>
        /// <returns></returns>
        public Task<UserVo> UserRegistry(User user);

        /// <summary>
        /// 获取用户购物车列表
        /// </summary>
        /// <param name="userId">用户id</param>
        /// <returns></returns>
        public List<ShoppingCar> getUserShoppingCar(Guid userId);
    }
}

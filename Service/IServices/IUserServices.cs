using Core.Base.Interface;
using Core.Base.Interface.Auto_registration;
using Entity.Model;
using Entity.Schemas;
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

        /// <summary>
        /// 更新用户属性
        /// </summary>
        /// <param name="user">用户对象</param>
        /// <returns>如果更新失败则null<see cref="UserVo"/></returns>
        public UserVo? updateUser(User user);

        /// <summary>
        /// 获得用户订单状况统计
        /// </summary>
        /// <param name="userId">用户id</param>
        /// <returns>承载四个统计的对象<see cref="UserOrderSates"/></returns>
        public UserOrderSates getUserOrderStateCount(Guid userId);

        /// <summary>
        /// 获取用户收藏列表
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<Collection> getUserCollections(Guid userId);
        /// <summary>
        /// 添加收藏
        /// </summary>
        /// <param name="collection">收藏实体类</param>
        /// <returns></returns>
        public Collection addCollection(Collection collection);

        /// <summary>
        /// 删除收藏
        /// </summary>
        /// <param name="collection_id">收藏id</param>
        /// <returns>是否删除成功</returns>
        public bool removeCollection(Guid collection_id);
    }
}

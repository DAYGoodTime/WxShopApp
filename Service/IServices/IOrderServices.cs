using Core.Base.Interface;
using Core.Base.Interface.Auto_registration;
using Entity.Base;
using Entity.Enum;
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
    public interface IOrderServices : IBaseServices<Order>, IScopedInterface
    {
        /// <summary>
        /// 判断是否能有足够的库存创建订单
        /// </summary>
        /// <param name="processOrder"></param>
        /// <returns></returns>
        public Task<Bool> canCreateAsync(List<ItemSubOptionVo> processOrder);

        /// <summary>
        /// 创建订单
        /// </summary>
        /// <param name="order">预提交的订单准备类</param>
        /// <returns></returns>
        public bool createOrder(CreateOrder order);

        /// <summary>
        /// 查询用户其下的所有订单
        /// </summary>
        /// <param name="userId">用户id</param>
        /// <returns></returns>
        public List<Order> selectUserOrders(Guid userId);

        /// <summary>
        /// 查询某个状态下的订单
        /// </summary>
        /// <param name="state">订单状态</param>
        /// <param name="userId">用户id</param>
        /// <returns></returns>
        public List<Order> selectOrdersByState(OrderState state, Guid userId);
    }
}

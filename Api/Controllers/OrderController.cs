using Entity.Base;
using Entity.Schemas;
using Entity.Vo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.IServices;
using WxsAppShop.Entity.Base;
using WxsAppShop.Entity.Model;

namespace Api.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IOrderServices _orderServices;

        public OrderController(IOrderServices orderServices)
        {
            _orderServices = orderServices;
        }
        /// <summary>
        /// 创建订单
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns>正常的返回对象<see cref="RespRsult"/></returns>
        [Route("create")]
        [HttpPost]
        //[ComplexArgumentProcess(typeof(CreateOrder))]
        public async Task<IActionResult> createOrder([FromBody] CreateOrder requestModel)
        {
            //TODO if user has discout
            Bool success = await _orderServices.canCreateAsync(requestModel.items);
            if (!success.isSuccess)
            {
                return Json(RespRsult.Error(success.reason));
            }
            bool isOK = _orderServices.createOrder(requestModel);
            if (!isOK)
            {
                return Json(RespRsult.Error("创建订单失败"));
            }
            return Json(RespRsult.OK());
        }
        /// <summary>
        /// 获取用户的订单
        /// </summary>
        /// <param name="userId">用户id</param>
        /// <returns>返回订单集合<see cref="List{Order}"/></returns>
        [HttpGet]
        [Route("getOrders/{userId:guid}")]
        public IActionResult getOrders(Guid userId)
        {
            return Json(RespRsult.OK(_orderServices.selectUserOrders(userId)));
        }

    }
}

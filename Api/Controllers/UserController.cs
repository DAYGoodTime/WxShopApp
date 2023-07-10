using Entity.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.IServices;
using WxsAppShop.Entity.Model;
using WxsAppShop.Entity.Base;
using Entity.Vo;
using Entity.Schemas;
using Entity.Model;

namespace Api.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserServices userServices;
        private readonly IAddressService addressService;

        public UserController(
            IUserServices _userService,
            IAddressService _addressService
            )
        {
            userServices = _userService;
            addressService = _addressService;
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="user">预对象，只需要用户名和密码</param>
        /// <returns></returns>
        [Route("login")]
        [HttpPost]
        public IActionResult userLogin([FromBody] User user)
        {
            try
            {
                UserVo res = userServices.UserLogin(user);
                return Json(RespRsult.OK(res));
            }
            catch (ServiceException e)
            {
                return Json(RespRsult.Error(e.Message));
            }
        }
        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="user">预对象，只需要用户名和密码</param>
        /// <returns></returns>
        [Route("registry")]
        [HttpPost]
        public async Task<IActionResult> userRegistry([FromBody] User user)
        {
            try
            {
                UserVo res = await userServices.UserRegistry(user);
                return Json(RespRsult.OK(res));
            }
            catch (ServiceException e)
            {
                return Json(RespRsult.Error(e.Message));
            }
        }
        /// <summary>
        /// 获取用户下的购物车列表
        /// </summary>
        /// <param name="userId">用户的id</param>
        /// <returns></returns>
        [Route("shoppingList/{userId:guid}")]
        [HttpGet]
        public IActionResult getUserShoppingList(Guid userId)
        {
            return Json(RespRsult.OK(userServices.getUserShoppingCar(userId)));
        }
        /// <summary>
        /// 更新用户数据
        /// </summary>
        /// <param name="user">需要更新的用户对象</param>
        /// <returns></returns>
        [Route("update")]
        [HttpPost]
        public IActionResult updateUser([FromBody] User user)
        {
            UserVo New = userServices.updateUser(user);
            if (New == null)
            {
                return Json(RespRsult.Error("更新用户失败"));
            }
            return Json(RespRsult.OK(New));
        }
        /// <summary>
        /// 获取用户订单状态统计
        /// </summary>
        /// <param name="userId">用户id</param>
        /// <returns>实体类，包含了各个状态的统计<see cref="UserOrderSates"/></returns>
        [Route("getOrderStateInfo/{userId:guid}")]
        [HttpGet]
        public IActionResult getUserOrderInfo(Guid userId)
        {
            return Json(RespRsult.OK(userServices.getUserOrderStateCount(userId)));
        }
        /// <summary>
        /// 查询用户所有地址
        /// </summary>
        /// <param name="userId">用户id</param>
        /// <returns>集合<see cref="List{Address}"/></returns>
        [Route("{userId:guid}/address")]
        [HttpGet]
        public IActionResult getUserAddress(Guid userId)
        {
            return Json(RespRsult.OK(addressService.SelectAllAddress(userId)));
        }
        /// <summary>
        /// 添加地址
        /// </summary>
        /// <param name="address">地址类</param>
        /// <returns></returns>
        [Route("addAddress")]
        [HttpPost]
        public IActionResult addAddress([FromBody] Address address)
        {
            bool success = addressService.AddAddress(address);
            if (success)
            {
                return Json(RespRsult.OK());
            }
            else
            {
                return Json(RespRsult.Error("添加失败"));
            }
        }

        /// <summary>
        /// 获取用户的收藏列表
        /// </summary>
        /// <param name="userId">用户id</param>
        /// <returns><see cref="List{Collection}"/></returns>
        [Route("{userId:guid}/collections")]
        [HttpGet]
        public IActionResult getUserCollection(Guid userId)
        {
            return Json(RespRsult.OK(userServices.getUserCollections(userId)));
        }
        /// <summary>
        /// 添加至收藏
        /// </summary>
        /// <param name="collection">收藏类</param>
        /// <returns>收藏类</returns>
        [Route("addCollection")]
        [HttpPost]
        public IActionResult addCollection([FromBody] Collection collection)
        {
            Collection? res = userServices.addCollection(collection);
            if (res == null)
            {
                return Json(RespRsult.Error("添加失败"));
            }
            else
            {
                return Json(RespRsult.OK(res));
            }
        }
        /// <summary>
        /// 删除收藏
        /// </summary>
        /// <param name="collectionId">收藏id</param>
        /// <returns></returns>
        [Route("delCollection/{collectionId:guid}")]
        [HttpDelete]
        public IActionResult removeCollection(Guid collectionId)
        {
            bool success = userServices.removeCollection(collectionId);
            if (success)
            {
                return Json(RespRsult.OK());
            }
            else
            {
                return Json(RespRsult.Error("删除失败"));
            }
        }
    }
}

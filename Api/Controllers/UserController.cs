using Entity.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.IServices;
using WxsAppShop.Entity.Model;
using WxsAppShop.Entity.Base;
using Entity.Vo;

namespace Api.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserServices userServices;

        public UserController(IUserServices _userService)
        {
            userServices = _userService;
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
    }
}
